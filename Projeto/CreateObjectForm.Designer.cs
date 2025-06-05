using System;
using System.Windows.Forms;

namespace Projeto
{
    partial class CreateObjectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label lblTutorId;
        private System.Windows.Forms.Label lblTutteeId;
        private System.Windows.Forms.Label lblExploredObjects;
        private System.Windows.Forms.DataGridView dgvCreatedObjects;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblEndPoint;
        private System.Windows.Forms.TextBox txtEndPoint;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox comboType;
        private System.Windows.Forms.Label lblVisibility;
        private System.Windows.Forms.RadioButton radioPublic;
        private System.Windows.Forms.RadioButton radioPrivate;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnBack;

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

            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();

            this.lblEndPoint = new System.Windows.Forms.Label();
            this.txtEndPoint = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.comboType = new System.Windows.Forms.ComboBox();

            this.lblVisibility = new System.Windows.Forms.Label();
            this.radioPublic = new System.Windows.Forms.RadioButton();
            this.radioPrivate = new System.Windows.Forms.RadioButton();

            this.btnCreate = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();

            // Form properties
            this.Text = "Create New Object";
            this.Size = new System.Drawing.Size(500, 450);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // lblTitle
            this.lblTitle.Text = "Object Title:";
            this.lblTitle.Location = new System.Drawing.Point(30, 30);
            this.lblTitle.AutoSize = true;

            // txtTitle
            this.txtTitle.Location = new System.Drawing.Point(150, 30);
            this.txtTitle.Size = new System.Drawing.Size(250, 23);

            // lblEndPoint
            this.lblEndPoint.Text = "EndPoint:";
            this.lblEndPoint.Location = new System.Drawing.Point(30, 70);
            this.lblEndPoint.AutoSize = true;

            // txtEndPoint
            this.txtEndPoint.Location = new System.Drawing.Point(150, 70);
            this.txtEndPoint.Size = new System.Drawing.Size(250, 23);

            // lblType
            this.lblType.Text = "Type:";
            this.lblType.Location = new System.Drawing.Point(30, 110);
            this.lblType.AutoSize = true;

            // comboType
            this.comboType.Location = new System.Drawing.Point(150, 110);
            this.comboType.Size = new System.Drawing.Size(250, 23);
            this.comboType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboType.Items.AddRange(new object[] {
            "tree",
            "course",
            "evaluator",
            "topic-flow",           
            });

            // lblVisibility
            this.lblVisibility.Text = "Visibility:";
            this.lblVisibility.Location = new System.Drawing.Point(30, 150);
            this.lblVisibility.AutoSize = true;

            // radioPublic
            this.radioPublic.Text = "Public";
            this.radioPublic.Location = new System.Drawing.Point(150, 150);
            this.radioPublic.AutoSize = true;

            // radioPrivate
            this.radioPrivate.Text = "Private";
            this.radioPrivate.Location = new System.Drawing.Point(220, 150);
            this.radioPrivate.AutoSize = true;

            // btnCreate
            this.btnCreate.Text = "Create";
            this.btnCreate.Location = new System.Drawing.Point(150, 250);
            this.btnCreate.Size = new System.Drawing.Size(80, 30);
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);

            // btnBack
            this.btnBack.Text = "Main Menu";
            this.btnBack.Location = new System.Drawing.Point(240, 250);
            this.btnBack.Size = new System.Drawing.Size(100, 30);
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // Add controls to the form
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);

            this.Controls.Add(this.lblEndPoint);
            this.Controls.Add(this.txtEndPoint);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.comboType);

            this.Controls.Add(this.lblVisibility);
            this.Controls.Add(this.radioPublic);
            this.Controls.Add(this.radioPrivate);

            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnBack);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Text = "CreateObjectForm";
        }

        #endregion
    }
}