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

namespace Projeto
{
    public partial class CreateObjectForm : Form
    {
        private string ID; // User ID for the creator, if needed in future operations
        public CreateObjectForm(string Id)
        {
            InitializeComponent();
            ID = Id;
            

           

        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            string objectTitle = txtTitle.Text.Trim();
            string endPoint = txtEndPoint.Text.Trim();
            string type = comboType.SelectedItem?.ToString() ?? "";
            bool isPublic = radioPublic.Checked;
            string TutorID;

            using (SqlConnection connection = new SqlConnection(@"Data Source= mednat.ieeta.pt\\SQLSERVER,8101;Initial Catalog= p10g10;User ID=p10g10;Password= 4QU1.N40.3NTR45!1387"))
            using (SqlCommand cmd = new SqlCommand("SELECT TutorID from dbo.GetUserIds(@ID)", connection))
            {
                cmd.Parameters.AddWithValue("@ID", ID);
                connection.Open();

                TutorID = (String)cmd.ExecuteScalar();

            }

            using (SqlConnection connection = new SqlConnection(@"Data Source= mednat.ieeta.pt\\SQLSERVER,8101;Initial Catalog= p10g10;User ID=p10g10;Password= 4QU1.N40.3NTR45!1387"))
            using (SqlCommand cmd = new SqlCommand("CreateEndpoint", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", ID);
                connection.Open();
                cmd.ExecuteNonQuery();
            }


            MessageBox.Show(objectTitle);
            using (SqlConnection connection = new SqlConnection(@"Data Source= mednat.ieeta.pt\\SQLSERVER,8101;Initial Catalog= p10g10;User ID=p10g10;Password= 4QU1.N40.3NTR45!1387"))
            using (SqlCommand cmd = new SqlCommand("CreateObject", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                string commit = SecurityHelper.HashPassword(objectTitle,TutorID);

                cmd.Parameters.AddWithValue("@ID", objectTitle);
                cmd.Parameters.AddWithValue("@Creator", TutorID);
                cmd.Parameters.AddWithValue("@Public", isPublic);
                cmd.Parameters.AddWithValue("@EndPoint_ID", "end");
                cmd.Parameters.AddWithValue("@Commit", commit);
                cmd.Parameters.AddWithValue("@Name", "");
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@ParentCommit", null);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenuForm menu = new MainMenuForm(ID);
            menu.Show();
            this.Close();
        }
    }
}

