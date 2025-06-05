using System.Windows.Forms;
using System;
using System.Drawing;

namespace Projeto
{
    partial class UserProfileViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblName;
        private Label lblEmail;
        private Label lblUserId;
        private Label lblTutorId;
        private Label lblTutteeId;
        private Label lblExploredObjects;
        private DataGridView dgvCreatedObjects;
        private Button btnBack;


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        this.lblTitle = new Label();
        this.lblName = new Label();
        this.lblEmail = new Label();
        this.lblUserId = new Label();
        this.lblTutorId = new Label();
        this.lblTutteeId = new Label();
        this.lblExploredObjects = new Label();
        this.dgvCreatedObjects = new DataGridView();
        this.btnBack = new Button();

        // Form
        this.Text = "User Profile View";
        this.Size = new Size(800, 500);
        this.StartPosition = FormStartPosition.CenterScreen;

        // Title
        this.lblTitle.Text = "User Profile";
        this.lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
        this.lblTitle.Location = new Point(20, 20);
        this.lblTitle.AutoSize = true;

        // Labels
        this.lblName.Location = new Point(20, 60);
        this.lblEmail.Location = new Point(20, 85);
        this.lblUserId.Location = new Point(20, 110);
        this.lblTutorId.Location = new Point(20, 135);
        this.lblTutteeId.Location = new Point(20, 160);
        this.lblExploredObjects.Location = new Point(20, 185);

        this.lblName.AutoSize = true;
        this.lblEmail.AutoSize = true;
        this.lblUserId.AutoSize = true;
        this.lblTutorId.AutoSize = true;
        this.lblTutteeId.AutoSize = true;
        this.lblExploredObjects.AutoSize = true;

        // DataGridView for created objects
        this.dgvCreatedObjects.Location = new Point(20, 220);
        this.dgvCreatedObjects.Size = new Size(740, 180);
        this.dgvCreatedObjects.ReadOnly = true;
        this.dgvCreatedObjects.AllowUserToAddRows = false;
        this.dgvCreatedObjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        // Back Button
        this.btnBack.Text = "Back";
        this.btnBack.Location = new Point(670, 420);
        this.btnBack.Size = new Size(90, 30);
        this.btnBack.Click += new EventHandler(this.btnBack_Click);

        // Add to form
        this.Controls.Add(lblTitle);
        this.Controls.Add(lblName);
        this.Controls.Add(lblEmail);
        this.Controls.Add(lblUserId);
        this.Controls.Add(lblTutorId);
        this.Controls.Add(lblTutteeId);
        this.Controls.Add(lblExploredObjects);
        this.Controls.Add(dgvCreatedObjects);
        this.Controls.Add(btnBack);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "UserProfileViewForm";
        }

        #endregion
    }
}