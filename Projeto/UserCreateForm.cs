using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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

    public partial class UserCreateForm : Form
    {

        public UserCreateForm()
        {
            InitializeComponent();
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string ID = txtID.Text.Trim();
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string salt = SecurityHelper.GenerateSalt();

            if (string.IsNullOrEmpty(ID) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(salt))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            MessageBox.Show(password);

            password = SecurityHelper.HashPassword(password, salt);


            RegisterUser(ID, name, email, password, salt);

            MessageBox.Show("User created successfully!");
            this.Close();
        }

        public static class DatabaseManager
        {
            private static string connectionString = @"Data Source= mednat.ieeta.pt\\SQLSERVER,8101;Initial Catalog= p10g10;User ID=p10g10;Password= 4QU1.N40.3NTR45!1387";

            public static SqlConnection GetConnection()
            {
                return new SqlConnection(connectionString);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void RegisterUser(string ID, string Name, string email, string password, string salt)
        {
     
            using (SqlConnection connection = new SqlConnection(@"Data Source= mednat.ieeta.pt\\SQLSERVER,8101;Initial Catalog= p10g10;User ID=p10g10;Password= 4QU1.N40.3NTR45!1387"))
            using (SqlCommand cmd = new SqlCommand("CreateUser", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID",ID);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@salt", salt);

                connection.Open();
                cmd.ExecuteNonQuery();
            }


        }
        

    }
}
