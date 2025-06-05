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

namespace Projeto
{
    public partial class LogIn : Form
    {
        // Temporary user store
        private Dictionary<string, string> users = new Dictionary<string, string>
        {
            { "admin", "admin" },
            { "admin@example.com", "admin" }
        };

        public LogIn()
        {
            InitializeComponent();
        }



        private void btnHint_Click(object sender, EventArgs e)
        {
            txtUsernameEmail.Text = "admin";
            txtPassword.Text = "admin";
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string input = txtUsernameEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username/email and password.");
                return;
            }

            if (LogInUser(input, password))
            {


                MessageBox.Show("Login successful!");
                MainMenuForm menu = new MainMenuForm(input);
                menu.Show();
                this.Hide(); // Close the login form

            }
            else
            {
                MessageBox.Show("Invalid credentials.");
            }
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            UserCreateForm form = new UserCreateForm();
            form.ShowDialog(); // or form.Show(); for non-blocking
        }

        public static bool LogInUser(string username, string password)
        {
            string hashCode = string.Empty;

            using (SqlConnection connection = new SqlConnection(@"Data Source= mednat.ieeta.pt\\SQLSERVER,8101;Initial Catalog= p10g10;User ID=p10g10;Password= 4QU1.N40.3NTR45!1387"))
            using (SqlCommand cmd = new SqlCommand("SELECT dbo.GetUserSalt(@ID)", connection))
            {
                cmd.Parameters.AddWithValue("@ID", username);
                connection.Open();

                string salt = (string)cmd.ExecuteScalar();

                if (salt == null)
                {
                    throw new Exception("User not found.");
                }

                hashCode = SecurityHelper.HashPassword(password, salt);

                cmd.ExecuteNonQuery();
            }

            using (SqlConnection connection = new SqlConnection(@"Data Source= mednat.ieeta.pt\\SQLSERVER,8101;Initial Catalog= p10g10;User ID=p10g10;Password= 4QU1.N40.3NTR45!1387"))
            using (SqlCommand cmd = new SqlCommand("SELECT dbo.CheckHash(@ID,@Hash)", connection))
            {
                
                cmd.Parameters.AddWithValue("@ID", username);
                cmd.Parameters.AddWithValue("@Hash", hashCode);
                connection.Open();
                bool result = (bool)cmd.ExecuteScalar();

                if (result == false)
                {
                    return false; // Login failed
                }
                else
                {
                    return true; // Login successful
                }

            }
        }
        public static class DatabaseManager
        {
            private static string connectionString = @"Data Source= mednat.ieeta.pt\\SQLSERVER,8101;Initial Catalog= p10g10;User ID=p10g10;Password= 4QU1.N40.3NTR45!1387";

            public static SqlConnection GetConnection()
            {
                return new SqlConnection(connectionString);
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

    }
}
