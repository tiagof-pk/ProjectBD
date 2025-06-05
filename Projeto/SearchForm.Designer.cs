using System;
using System.Drawing;
using System.Windows.Forms;

namespace Projeto
{
    partial class SearchForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvResults;
        private CheckBox chkObjectType;
        private CheckBox chkObjectID;
        private CheckBox chkObjectEndpoint;
        private CheckBox chkObjectDate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtSearch = new TextBox();
            this.btnSearch = new Button();
            this.dgvResults = new DataGridView();
            this.chkObjectType = new CheckBox();
            this.chkObjectID = new CheckBox();
            this.chkObjectEndpoint = new CheckBox();
            this.chkObjectDate = new CheckBox();

            // Form Settings
            this.Text = "Search";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Search TextBox
            this.txtSearch.Location = new Point(20, 20);
            this.txtSearch.Size = new Size(500, 25);

            // Checkboxes
            int startX = 20;
            int startY = 60;

            this.chkObjectType.Text = "Type";
            this.chkObjectType.Location = new Point(startX, startY);
            this.chkObjectType.AutoSize = true;

            this.chkObjectID.Text = "Object ID";
            this.chkObjectID.Location = new Point(startX + 100, startY);
            this.chkObjectID.AutoSize = true;

            this.chkObjectEndpoint.Text = "Endpoint";
            this.chkObjectEndpoint.Location = new Point(startX + 220, startY);
            this.chkObjectEndpoint.AutoSize = true;

            this.chkObjectDate.Text = "Date";
            this.chkObjectDate.Location = new Point(startX + 340, startY);
            this.chkObjectDate.AutoSize = true;

            // Search Button
            this.btnSearch.Text = "Search";
            this.btnSearch.Location = new Point(540, 18);
            this.btnSearch.Size = new Size(100, 30);
            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);

            // DataGridView
            this.dgvResults.Location = new Point(20, 100);
            this.dgvResults.Size = new Size(740, 320);
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.ReadOnly = true;
            this.dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.CellClick += new DataGridViewCellEventHandler(this.dgvResults_CellClick);

            // Add controls
            this.Controls.Add(txtSearch);
            this.Controls.Add(btnSearch);
            this.Controls.Add(chkObjectType);
            this.Controls.Add(chkObjectID);
            this.Controls.Add(chkObjectEndpoint);
            this.Controls.Add(chkObjectDate);
            this.Controls.Add(dgvResults);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Text = "Search";
        }

        #endregion
    }
}
