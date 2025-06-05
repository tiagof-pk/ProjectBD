using System.Windows.Forms;

namespace Projeto
{
    partial class ProfileForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label lblTutorId;
        private System.Windows.Forms.Label lblTuteeId;
        private System.Windows.Forms.Label lblCreatedObjectsHeader;
        private System.Windows.Forms.Label lblExploredCount;
        private System.Windows.Forms.DataGridView dgvCreatedObjects;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblProfileHeader;
        private System.Windows.Forms.Button btnBackToMenu;

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
            this.lblProfileHeader = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUserId = new System.Windows.Forms.Label();
            this.lblTutorId = new System.Windows.Forms.Label();
            this.lblTuteeId = new System.Windows.Forms.Label();
            this.lblCreatedObjectsHeader = new System.Windows.Forms.Label();
            this.lblExploredCount = new System.Windows.Forms.Label();
            this.dgvCreatedObjects = new System.Windows.Forms.DataGridView();
            this.btnBackToMenu = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCreatedObjects)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProfileHeader
            // 
            this.lblProfileHeader.AutoSize = true;
            this.lblProfileHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblProfileHeader.Location = new System.Drawing.Point(180, 15);
            this.lblProfileHeader.Name = "lblProfileHeader";
            this.lblProfileHeader.Size = new System.Drawing.Size(230, 51);
            this.lblProfileHeader.TabIndex = 0;
            this.lblProfileHeader.Text = "User Profile";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(50, 60);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(74, 25);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(50, 100);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(71, 25);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Email:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(50, 140);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(112, 25);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(150, 57);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(300, 31);
            this.txtName.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(150, 97);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(300, 31);
            this.txtEmail.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(150, 137);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(300, 31);
            this.txtPassword.TabIndex = 6;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(150, 180);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update Profile";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(300, 180);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 30);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(50, 230);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(219, 25);
            this.lblUserId.TabIndex = 9;
            this.lblUserId.Text = "User ID: [placeholder]";
            // 
            // lblTutorId
            // 
            this.lblTutorId.AutoSize = true;
            this.lblTutorId.Location = new System.Drawing.Point(50, 255);
            this.lblTutorId.Name = "lblTutorId";
            this.lblTutorId.Size = new System.Drawing.Size(224, 25);
            this.lblTutorId.TabIndex = 10;
            this.lblTutorId.Text = "Tutor ID: [placeholder]";
            // 
            // lblTuteeId
            // 
            this.lblTuteeId.AutoSize = true;
            this.lblTuteeId.Location = new System.Drawing.Point(50, 280);
            this.lblTuteeId.Name = "lblTuteeId";
            this.lblTuteeId.Size = new System.Drawing.Size(235, 25);
            this.lblTuteeId.TabIndex = 11;
            this.lblTuteeId.Text = "Tutee ID: [placeholder]";
            // 
            // lblCreatedObjectsHeader
            // 
            this.lblCreatedObjectsHeader.AutoSize = true;
            this.lblCreatedObjectsHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCreatedObjectsHeader.Location = new System.Drawing.Point(50, 325);
            this.lblCreatedObjectsHeader.Name = "lblCreatedObjectsHeader";
            this.lblCreatedObjectsHeader.Size = new System.Drawing.Size(228, 37);
            this.lblCreatedObjectsHeader.TabIndex = 13;
            this.lblCreatedObjectsHeader.Text = "Created Objects:";
            // 
            // lblExploredCount
            // 
            this.lblExploredCount.AutoSize = true;
            this.lblExploredCount.Location = new System.Drawing.Point(50, 305);
            this.lblExploredCount.Name = "lblExploredCount";
            this.lblExploredCount.Size = new System.Drawing.Size(312, 25);
            this.lblExploredCount.TabIndex = 12;
            this.lblExploredCount.Text = "Explored Objects: [placeholder]";
            // 
            // dgvCreatedObjects
            // 
            this.dgvCreatedObjects.AllowUserToAddRows = false;
            this.dgvCreatedObjects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCreatedObjects.ColumnHeadersHeight = 46;
            this.dgvCreatedObjects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgvCreatedObjects.Location = new System.Drawing.Point(50, 350);
            this.dgvCreatedObjects.MultiSelect = false;
            this.dgvCreatedObjects.Name = "dgvCreatedObjects";
            this.dgvCreatedObjects.ReadOnly = true;
            this.dgvCreatedObjects.RowHeadersWidth = 82;
            this.dgvCreatedObjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCreatedObjects.Size = new System.Drawing.Size(420, 160);
            this.dgvCreatedObjects.TabIndex = 15;
            // 
            // btnBackToMenu
            // 
            this.btnBackToMenu.Location = new System.Drawing.Point(370, 540);
            this.btnBackToMenu.Name = "btnBackToMenu";
            this.btnBackToMenu.Size = new System.Drawing.Size(100, 30);
            this.btnBackToMenu.TabIndex = 14;
            this.btnBackToMenu.Text = "Main Menu";
            this.btnBackToMenu.Click += new System.EventHandler(this.btnBackToMenu_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // ProfileForm
            // 
            this.ClientSize = new System.Drawing.Size(520, 600);
            this.Controls.Add(this.lblProfileHeader);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.lblTutorId);
            this.Controls.Add(this.lblTuteeId);
            this.Controls.Add(this.lblExploredCount);
            this.Controls.Add(this.lblCreatedObjectsHeader);
            this.Controls.Add(this.btnBackToMenu);
            this.Controls.Add(this.dgvCreatedObjects);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnLogout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profile";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCreatedObjects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}