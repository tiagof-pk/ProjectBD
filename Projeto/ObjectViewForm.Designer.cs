using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Projeto
{
    partial class ObjectViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblObjectId;
        private Label lblEndpoint;
        private Label lblCreator;
        private Label lblVisibility;
        private Label lblType;
        private Label lblDateCreated;
        private Label lblContributions;
        private Button btnBack;
        private Button btnFork;
        private Button btnMerge;
        private Label lblForkStatus;
        private List<string> userForks = new List<string>(); // Simulated forked object IDs
        private string originalObjectId = "OBJ-001"; // Simulated current object ID


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
            this.lblObjectId = new Label();
            this.lblEndpoint = new Label();
            this.lblCreator = new Label();
            this.lblVisibility = new Label();
            this.lblType = new Label();
            this.lblDateCreated = new Label();
            this.lblContributions = new Label();
            this.btnBack = new Button();
            this.btnFork = new Button();

            // Form settings
            this.Text = "Object View";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Title
            this.lblTitle.Text = "Object Details";
            this.lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.AutoSize = true;

            // Labels setup
            Label[] labels = { lblObjectId, lblEndpoint, lblCreator, lblVisibility, lblType, lblDateCreated, lblContributions };
            int y = 70;
            foreach (Label lbl in labels)
            {
                lbl.Location = new Point(20, y);
                lbl.AutoSize = true;
                this.Controls.Add(lbl);
                y += 30;
            }

            // Fork button
            this.btnFork = new System.Windows.Forms.Button();
            this.btnFork.Location = new System.Drawing.Point(30, 300);
            this.btnFork.Size = new System.Drawing.Size(120, 30);
            this.btnFork.Text = "Fork";
            this.btnFork.Click += new System.EventHandler(this.btnFork_Click);
            this.Controls.Add(this.btnFork);

            // Merge button
            this.btnMerge = new System.Windows.Forms.Button();
            this.btnMerge.Location = new System.Drawing.Point(160, 300);
            this.btnMerge.Size = new System.Drawing.Size(120, 30);
            this.btnMerge.Text = "Merge";
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            this.Controls.Add(this.btnMerge);

            // Fork info label
            this.lblForkStatus = new System.Windows.Forms.Label();
            this.lblForkStatus.Location = new System.Drawing.Point(30, 340);
            this.lblForkStatus.Size = new System.Drawing.Size(400, 30);
            this.Controls.Add(this.lblForkStatus);

            // Back Button
            this.btnBack.Text = "Back";
            this.btnBack.Location = new Point(460, 310);
            this.btnBack.Size = new Size(90, 30);
            this.btnBack.Click += new EventHandler(this.btnBack_Click);

            // Add controls
            this.Controls.Add(lblTitle);
            this.Controls.Add(btnBack);
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "ObjectViewForm";
        }

        #endregion
    }
}