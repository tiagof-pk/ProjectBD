using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto
{
    public partial class UserProfileViewForm : Form
    {
        private string ID;
        

        public UserProfileViewForm(string id)
        {
            InitializeComponent();
            ID = id;

            LoadUserData(id); // Load static/mock data for now
        }

        private void LoadUserData(string userId)
        {


            // Simulated user data
            lblName.Text = "Name: John Doe";
            lblEmail.Text = "Email: john@example.com";
            lblUserId.Text = "User ID: " + userId;
            lblTutorId.Text = "Tutor ID: 1024";
            lblTutteeId.Text = "Tuttee ID: 3021";
            lblExploredObjects.Text = "Explored Objects: 5";

            // Simulated created object list
            DataTable table = new DataTable();
            table.Columns.Add("Object ID");
            table.Columns.Add("Object Name");
            table.Columns.Add("Contributions");

            table.Rows.Add("O1", "Math101 - Algebra", "3");
            table.Rows.Add("O2", "CS102 - Programming", "9");

            dgvCreatedObjects.DataSource = table;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenuForm menu = new MainMenuForm(ID);
            menu.Show();
            this.Close();
        }
    }
}
