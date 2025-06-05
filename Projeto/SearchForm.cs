using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto
{
    public partial class SearchForm : Form
    {
        private string ID;
        public SearchForm(string iD)
        {
            InitializeComponent();
            LoadPublicObjectsFromUdf();
            ID = iD;
        }




        // Pseudocode plan:
        // 1. Add methods to fetch users and objects from the database.
        // 2. Use ADO.NET for database access (SqlConnection, SqlCommand, SqlDataAdapter).
        // 3. Replace static entries in LoadDefaultEntries with data from the database.
        // 4. Assume a connection string is available (add a private field).
        // 5. Fetch users and objects, fill DataTable, and bind to dgvResults.

        private string _connectionString = @"Data Source= mednat.ieeta.pt\\SQLSERVER,8101;Initial Catalog= p10g10;User ID=p10g10;Password= 4QU1.N40.3NTR45!1387"; // TODO: Set your actual connection string

        private DataTable GetUsersFromDatabase()
        {
            DataTable users = new DataTable();
            using (var conn = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                string query = "SELECT ID AS ID, Name AS [Name/Endpoint] FROM [User]";
                using (var cmd = new System.Data.SqlClient.SqlCommand(query, conn))
                using (var adapter = new System.Data.SqlClient.SqlDataAdapter(cmd))
                {
                    conn.Open();
                    users.Columns.Add("Type");
                    users.Columns.Add("ID");
                    users.Columns.Add("Name/Endpoint");
                    users.Columns.Add("Action");
                    DataTable temp = new DataTable();
                    adapter.Fill(temp);
                    foreach (DataRow row in temp.Rows)
                    {
                        users.Rows.Add("User", row["ID"], row["Name/Endpoint"]);
                    }
                }
            }
            return users;
        }




        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim().ToLower();
            DataTable filteredTable = new DataTable();
            filteredTable.Columns.Add("Type");
            filteredTable.Columns.Add("ID");
            filteredTable.Columns.Add("Name/Endpoint");

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.GetPublicObjects(@PageNumber, @PageSize)", connection))
            {
                cmd.Parameters.AddWithValue("@PageNumber", 1);
                cmd.Parameters.AddWithValue("@PageSize", 100);

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string id = reader["ID"].ToString();
                        string name = reader["Name"].ToString();
                        string type = reader["Type"].ToString();
                        DateTime date = reader.GetDateTime(reader.GetOrdinal("Date"));

                        bool matches = false;

                        if (string.IsNullOrEmpty(query))
                        {
                            matches = true; // show all if no query
                        }
                        else
                        {
                            if (chkObjectType.Checked && type.ToLower().Contains(query))
                                matches = true;

                            if (chkObjectID.Checked && id.ToLower().Contains(query))
                                matches = true;

                            if (chkObjectEndpoint.Checked && name.ToLower().Contains(query))
                                matches = true;

                            if (chkObjectDate.Checked && date.ToString("yyyy-MM-dd").Contains(query))
                                matches = true;
                        }

                        if (matches)
                        {
                            filteredTable.Rows.Add("Object", id, name);
                        }
                    }
                }
            }

            dgvResults.DataSource = filteredTable;

            // Add Action column if not already present
            if (!dgvResults.Columns.Contains("ActionButton"))
            {
                DataGridViewButtonColumn actionButton = new DataGridViewButtonColumn();
                actionButton.Name = "ActionButton";
                actionButton.HeaderText = "Action";
                actionButton.Text = "View";
                actionButton.UseColumnTextForButtonValue = true;
                dgvResults.Columns.Add(actionButton);
            }
        }


        private void dgvResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvResults.Columns["ActionButton"].Index && e.RowIndex >= 0)
            {
                string type = dgvResults.Rows[e.RowIndex].Cells["Type"].Value.ToString();
                string id = dgvResults.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                if (type == "User")
                {
                    UserProfileViewForm viewForm = new UserProfileViewForm(id);
                    viewForm.ShowDialog();
                }
                else if (type == "Object")
                {
                    ObjectViewForm objectForm = new ObjectViewForm(ID,id);
                    objectForm.ShowDialog();
                }
                
            }
        }
        private void LoadPublicObjectsFromUdf()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Type");
            table.Columns.Add("ID");
            table.Columns.Add("Name/Endpoint");

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.GetPublicObjects(@PageNumber, @PageSize)", connection))
            {
                cmd.Parameters.AddWithValue("@PageNumber", 1);
                cmd.Parameters.AddWithValue("@PageSize", 20);

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string id = reader["ID"].ToString();
                        string endpoint = reader["Name"].ToString();  // Assuming "Name" is the endpoint field
                        table.Rows.Add("Object", id, endpoint);
                    }
                }
            }

            dgvResults.DataSource = table;

            // Optional: Add Action button manually if not set in Designer
            if (!dgvResults.Columns.Contains("ActionButton"))
            {
                DataGridViewButtonColumn actionButton = new DataGridViewButtonColumn();
                actionButton.Name = "ActionButton";
                actionButton.HeaderText = "Action";
                actionButton.Text = "View";
                actionButton.UseColumnTextForButtonValue = true;
                dgvResults.Columns.Add(actionButton);
            }
        }
    }
}
