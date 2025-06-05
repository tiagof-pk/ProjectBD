namespace Projeto
{
    partial class MainMenuForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnCreateObject;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button buttonBecomeTutor;
        private System.Windows.Forms.Button buttonBecomeTutee;
        private System.Windows.Forms.Button buttonDeleteAccount;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnCreateObject = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.buttonBecomeTutor = new System.Windows.Forms.Button();
            this.buttonBecomeTutee = new System.Windows.Forms.Button();
            this.buttonDeleteAccount = new System.Windows.Forms.Button();

            // MainMenuForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 520);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            // lblWelcome
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.lblWelcome.Location = new System.Drawing.Point(20, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(440, 40);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome!";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Shared button style
            System.Drawing.Size buttonSize = new System.Drawing.Size(300, 40);
            System.Drawing.Point centerPos = new System.Drawing.Point((this.ClientSize.Width - buttonSize.Width) / 2, 0);
            int verticalSpacing = 20;
            int startY = 80;

            // btnProfile
            this.btnProfile.Location = new System.Drawing.Point(centerPos.X, startY);
            this.btnProfile.Size = buttonSize;
            this.btnProfile.Text = "Check / Update Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);

            // btnCreateObject
            this.btnCreateObject.Location = new System.Drawing.Point(centerPos.X, startY + (buttonSize.Height + verticalSpacing) * 1);
            this.btnCreateObject.Size = buttonSize;
            this.btnCreateObject.Text = "Create New Object";
            this.btnCreateObject.UseVisualStyleBackColor = true;
            this.btnCreateObject.Click += new System.EventHandler(this.btnCreateObject_Click);

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(centerPos.X, startY + (buttonSize.Height + verticalSpacing) * 2);
            this.btnSearch.Size = buttonSize;
            this.btnSearch.Text = "Search Users / Objects";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // buttonBecomeTutor
            this.buttonBecomeTutor.Location = new System.Drawing.Point(centerPos.X, startY + (buttonSize.Height + verticalSpacing) * 3);
            this.buttonBecomeTutor.Size = buttonSize;
            this.buttonBecomeTutor.Text = "Become Tutor";
            this.buttonBecomeTutor.UseVisualStyleBackColor = true;
            this.buttonBecomeTutor.Click += new System.EventHandler(this.buttonBecomeTutor_Click);

            // buttonBecomeTutee
            this.buttonBecomeTutee.Location = new System.Drawing.Point(centerPos.X, startY + (buttonSize.Height + verticalSpacing) * 4);
            this.buttonBecomeTutee.Size = buttonSize;
            this.buttonBecomeTutee.Text = "Become Tutee";
            this.buttonBecomeTutee.UseVisualStyleBackColor = true;
            this.buttonBecomeTutee.Click += new System.EventHandler(this.buttonBecomeTutee_Click);

            // buttonDeleteAccount
            this.buttonDeleteAccount.Location = new System.Drawing.Point(centerPos.X, startY + (buttonSize.Height + verticalSpacing) * 5);
            this.buttonDeleteAccount.Size = buttonSize;
            this.buttonDeleteAccount.Text = "Delete My Account";
            this.buttonDeleteAccount.UseVisualStyleBackColor = true;
            this.buttonDeleteAccount.Click += new System.EventHandler(this.buttonDeleteAccount_Click);

            // Add Controls
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.btnCreateObject);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.buttonBecomeTutor);
            this.Controls.Add(this.buttonBecomeTutee);
            this.Controls.Add(this.buttonDeleteAccount);

            this.ResumeLayout(false);
        }

        #endregion
    }
}
