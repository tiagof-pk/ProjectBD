using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Projeto
{
    public partial class MainMenuForm : Form
    {
        private string ID;
        public MainMenuForm(string Id)
        {
            InitializeComponent();
            ID = Id;
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            // Open profile management form
            ProfileForm profileForm = new ProfileForm(ID);
            profileForm.ShowDialog();
            this.Hide();
        }

        private void btnCreateObject_Click(object sender, EventArgs e)
        {
            // Open object creation form
            CreateObjectForm objectForm = new CreateObjectForm(ID);
            objectForm.ShowDialog();
            this.Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Open search form
            SearchForm searchForm = new SearchForm(ID);
            searchForm.ShowDialog();
            this.Hide();
        }

        private void buttonBecomeTutor_Click(object sender, EventArgs e)
        {
            try
            {
                AssignRole(ID, "Tutor");
                MessageBox.Show("You are now a Tutor!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to assign Tutor role: " + ex.Message);
            }
        }

        private void buttonBecomeTutee_Click(object sender, EventArgs e)
        {
            try
            {
                AssignRole(ID, "Tutee");
                MessageBox.Show("You are now a Tutee!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to assign Tutee role: " + ex.Message);
            }
        }
        private void AssignRole(string userId, string role)
        {
            string roleID;
            if (role == "Tutor")
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source= mednat.ieeta.pt\\SQLSERVER,8101;Initial Catalog= p10g10;User ID=p10g10;Password= 4QU1.N40.3NTR45!1387"))
                using (SqlCommand cmd = new SqlCommand("UpdateUserTutorID", conn))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", userId);
                    roleID = role + userId;
                    cmd.Parameters.AddWithValue("@TutorID", roleID);
                    cmd.ExecuteNonQuery();
                }
            }
            else if (role == "Tutee")
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source= mednat.ieeta.pt\\SQLSERVER,8101;Initial Catalog= p10g10;User ID=p10g10;Password= 4QU1.N40.3NTR45!1387"))
                using (SqlCommand cmd = new SqlCommand("UpdateUserTuteeID", conn))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", userId);
                    roleID = role + userId;
                    cmd.Parameters.AddWithValue("@TuteeID", roleID);
                    cmd.ExecuteNonQuery();
                }
            }
            
        }

        private void buttonDeleteAccount_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to delete your account?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DeleteUser(ID);
                MessageBox.Show("Account deleted. The application will now close.");
                MainMenuForm menu = new MainMenuForm(ID);
                menu.Show();
                this.Close();

            }


        }

        public static void DeleteUser(string ID)
        {

            using (SqlConnection connection = new SqlConnection(@"Data Source= mednat.ieeta.pt\\SQLSERVER,8101;Initial Catalog= p10g10;User ID=p10g10;Password= 4QU1.N40.3NTR45!1387"))
            using (SqlCommand cmd = new SqlCommand("DeleteUser", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", ID);

                connection.Open();
                cmd.ExecuteNonQuery();
            }


        }
    }
}
