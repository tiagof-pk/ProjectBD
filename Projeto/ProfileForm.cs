using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Projeto
{

    public partial class ProfileForm : Form
    {
        private string ID; // User ID for the profile
        private string TutorID;


        public ProfileForm(string id)
        {
            ID = id; // Store the user ID
            InitializeComponent();

            if (!isTutor(ID))
            {
                
                using (SqlConnection connection = new SqlConnection(@"Data Source= mednat.ieeta.pt\\SQLSERVER,8101;Initial Catalog= p10g10;User ID=p10g10;Password= 4QU1.N40.3NTR45!1387"))
                using (SqlCommand cmd = new SqlCommand("SELECT TutorID from dbo.GetUserIds(@ID)", connection))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    connection.Open();
                    
                    TutorID = (String)cmd.ExecuteScalar();
                    lblTutorId.Text = TutorID;
                }

                lblCreatedObjectsHeader.Text = "Created Objects : ";


                dgvCreatedObjects.Rows.Add("Math101 - Algebra Basics", "OBJ001", "3");
                dgvCreatedObjects.Rows.Add("CS102 - Intro to Programming", "OBJ002", "9");

            }
            else
            {
                // Hide tutor-related UI
                lblTutorId.Visible = false;
                lblCreatedObjectsHeader.Visible = false;
                dgvCreatedObjects.Visible = false;
            }

            if (!isTutee(ID))
            {
                string TuteeId;
                using (SqlConnection connection = new SqlConnection(@"Data Source= mednat.ieeta.pt\\SQLSERVER,8101;Initial Catalog= p10g10;User ID=p10g10;Password= 4QU1.N40.3NTR45!1387"))
                using (SqlCommand cmd = new SqlCommand("SELECT TuteeID from dbo.GetUserids(@ID)", connection))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    connection.Open();

                    TuteeId = (String)cmd.ExecuteScalar();
                    lblTuteeId.Text = TuteeId;
                    cmd.ExecuteNonQuery();
                }

                using (SqlConnection connection = new SqlConnection(@"Data Source= mednat.ieeta.pt\\SQLSERVER,8101;Initial Catalog= p10g10;User ID=p10g10;Password= 4QU1.N40.3NTR45!1387"))
                using (SqlCommand cmd = new SqlCommand("SELECT [Number of Explored Objects] from dbo.GetTuteeByID(@TuteeID)", connection))
                {
                    cmd.Parameters.AddWithValue("@TuteeID", TuteeId);
                    connection.Open();

                    string str =  "Explored Object :  " + cmd.ExecuteScalar();

                    lblExploredCount.Text = str;
                    cmd.ExecuteNonQuery();
                }

            }
            else
            {
                // Hide Tutee-related UI
                lblTuteeId.Visible = false;
                lblExploredCount.Visible = false;
            }

            using (SqlConnection connection = new SqlConnection(@"Data Source= mednat.ieeta.pt\\SQLSERVER,8101;Initial Catalog= p10g10;User ID=p10g10;Password= 4QU1.N40.3NTR45!1387"))
            using (SqlCommand cmd = new SqlCommand("SELECT [Name] from dbo.GetUserNameAndEmail(@ID)", connection))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                connection.Open();

                txtName.Text = (String)cmd.ExecuteScalar();
                cmd.ExecuteNonQuery();
            }
            using (SqlConnection connection = new SqlConnection(@"Data Source= mednat.ieeta.pt\\SQLSERVER,8101;Initial Catalog= p10g10;User ID=p10g10;Password= 4QU1.N40.3NTR45!1387"))
            using (SqlCommand cmd = new SqlCommand("SELECT Email from dbo.GetUserNameAndEmail(@ID)", connection))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                connection.Open();

                txtEmail.Text = (String)cmd.ExecuteScalar();
                cmd.ExecuteNonQuery();
            }

            txtPassword.Text = ""; 
            lblUserId.Text = id;
        }

        public static string[] GetCreatedObjectsEntries(string TutorID)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source= mednat.ieeta.pt\\SQLSERVER,8101;Initial Catalog= p10g10;User ID=p10g10;Password= 4QU1.N40.3NTR45!1387"))
            using (SqlCommand cmd = new SqlCommand("SELECT * from dbo.GetObjectsByCreator(@CreatorID)", connection))
            {
                cmd.Parameters.AddWithValue("@CreatorID", TutorID);
                connection.Open(); 

               return (String[])cmd.ExecuteScalar();
                //cmd.ExecuteNonQuery();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            using (SqlConnection connection = new SqlConnection(@"Data Source= mednat.ieeta.pt\\SQLSERVER,8101;Initial Catalog= p10g10;User ID=p10g10;Password= 4QU1.N40.3NTR45!1387"))
            using (SqlCommand cmd = new SqlCommand("UpdateUserBasicInfo", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
            using (SqlConnection connection = new SqlConnection(@"Data Source= mednat.ieeta.pt\\SQLSERVER,8101;Initial Catalog= p10g10;User ID=p10g10;Password= 4QU1.N40.3NTR45!1387"))
            using (SqlCommand cmd = new SqlCommand("UpdateUserPasswordAndSalt", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                string salt = SecurityHelper.GenerateSalt();

                string hash = SecurityHelper.HashPassword(password, salt);

                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@password", hash);
                cmd.Parameters.AddWithValue("@salt", salt);



                connection.Open();
                cmd.ExecuteNonQuery();
            }



            MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static class SecurityHelper
        {
            public static string GenerateSalt(int length = 10)
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var random = new Random();
                var salt = new char[length];

                for (int i = 0; i < length; i++)
                    salt[i] = chars[random.Next(chars.Length)];

                return new string(salt);
            }

            public static string HashPassword(string password, string salt)
            {
                using (SHA256 sha = SHA256.Create())
                {
                    var combined = Encoding.UTF8.GetBytes(password + salt);
                    var hash = sha.ComputeHash(combined);
                    return Convert.ToBase64String(hash);
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Confirm logout
            var confirm = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                // Close this form and return to Login
                this.Hide();
                LogIn login = new LogIn();
                login.Show();
            }
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            // Open Main Menu and close Profile Form
            MainMenuForm menu = new MainMenuForm(ID);
            menu.Show();
            this.Close();
        }

        private bool isTutor(string id)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source= mednat.ieeta.pt\\SQLSERVER,8101;Initial Catalog= p10g10;User ID=p10g10;Password= 4QU1.N40.3NTR45!1387"))
            using (SqlCommand cmd = new SqlCommand("SELECT dbo.CanUserBeTutor(@ID)", connection))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                connection.Open();

                return (bool)cmd.ExecuteScalar();


                

            }
        }

        private bool isTutee(string id)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source= mednat.ieeta.pt\\SQLSERVER,8101;Initial Catalog= p10g10;User ID=p10g10;Password= 4QU1.N40.3NTR45!1387"))
            using (SqlCommand cmd = new SqlCommand("SELECT dbo.CanUserBeTutee(@ID)", connection))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                connection.Open();

                return (bool)cmd.ExecuteScalar();


            }

        }
    }
}
