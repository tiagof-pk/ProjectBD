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
    
    public partial class ObjectViewForm : Form
    {   
        private string ID; // User ID
        private string objectId;
        private bool hasForked = false; // Replace with actual check in the future
        public ObjectViewForm(string id, string objectId)
        {
            InitializeComponent();
            ID = id; // Store the user ID
            this.objectId = objectId;
            LoadObjectData(objectId); // Load static/mock data

        }
        private void UpdateForkUI()
        {
            if (hasForked)
            {
                btnMerge.Text = "Merge";
                lblForkStatus.Text = "You have already forked this object.";
            }
            else
            {
                btnFork.Text = "Fork";
                lblForkStatus.Text = "You have not forked this object yet.";
            }
        }

        private void ObjectViewForm_Load(object sender, EventArgs e)
        {
            UpdateForkStatus();
        }

        private void btnFork_Click(object sender, EventArgs e)
        {
            string newForkId = $"{originalObjectId}-F{userForks.Count + 1}";
            userForks.Add(newForkId);
            MessageBox.Show($"Fork created: {newForkId}");
            UpdateForkStatus();
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            if (userForks.Count == 0)
            {
                MessageBox.Show("No forks available to merge.");
                return;
            }

            string lastFork = userForks.Last(); // Simulate merging the latest
            MessageBox.Show($"Fork {lastFork} merged into {originalObjectId}.");
            userForks.Remove(lastFork); // Optionally remove after merge
            UpdateForkStatus();
        }

        private void UpdateForkStatus()
        {
            lblForkStatus.Text = $"You have {userForks.Count} fork(s) for this object.";
            btnMerge.Enabled = userForks.Count > 0;
        }

        private void btnForkOrMerge_Click(object sender, EventArgs e)
        {
            if (!hasForked)
            {
                // Simulate Fork
                MessageBox.Show("Object forked successfully!");
                hasForked = true;
            }
            else
            {
                // Simulate Merge
                MessageBox.Show("Your forked version has been merged!");
                hasForked = false; // Optional: Reset state or keep forked
            }

            UpdateForkUI(); // Refresh UI
        }

        

        
        private void LoadObjectData(string objectId)
        {
            // Simulated object data
            lblObjectId.Text = "Object ID: " + objectId;
            lblEndpoint.Text = "Endpoint: Math101 - Algebra";
            lblCreator.Text = "Creator: John Doe";
            lblVisibility.Text = "Visibility: Public";
            lblType.Text = "Type: Educational";
            lblDateCreated.Text = "Created On: 2024-03-21";
            lblContributions.Text = "Contributions: 3";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Open Main Menu and close Object View Form
            MainMenuForm menu = new MainMenuForm(ID);
            menu.Show();
            this.Close();
        }
    }
}
