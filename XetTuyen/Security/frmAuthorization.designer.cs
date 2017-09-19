﻿namespace XetTuyen
{
    partial class frmAuthorization
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAuthorization));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.treGroup = new System.Windows.Forms.TreeView();
            this.imageListGroup = new System.Windows.Forms.ImageList(this.components);
            this.lblGroups = new System.Windows.Forms.Label();
            this.splitContainerMenu = new System.Windows.Forms.SplitContainer();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.treFunctionGroup = new System.Windows.Forms.TreeView();
            this.imageListFunction = new System.Windows.Forms.ImageList(this.components);
            this.btnGenerate = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.lstMethod = new System.Windows.Forms.ListView();
            this.clmItemDescription = new System.Windows.Forms.ColumnHeader();
            this.pnlAuthorization = new System.Windows.Forms.Panel();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblAuthorizationCount = new System.Windows.Forms.Label();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainerMenu.Panel1.SuspendLayout();
            this.splitContainerMenu.Panel2.SuspendLayout();
            this.splitContainerMenu.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.pnlAuthorization.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTitle.Size = new System.Drawing.Size(990, 32);
            this.lblTitle.Text = "Phân Quyền Cho Nhóm Người Dùng";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.splitContainer2);
            this.pnlMain.Size = new System.Drawing.Size(990, 490);
            // 
            // ucDataButton1
            // 
            this.ucDataButton1.AddNewVisible = false;
            this.ucDataButton1.DeleteVisible = false;
            this.ucDataButton1.ExcelVisible = false;
            this.ucDataButton1.LanguageVisible = false;
            this.ucDataButton1.Location = new System.Drawing.Point(0, 522);
            this.ucDataButton1.MultiLanguageVisible = false;
            this.ucDataButton1.PrintVisible = false;
            this.ucDataButton1.ReportVisible = false;
            this.ucDataButton1.Size = new System.Drawing.Size(990, 34);
            this.ucDataButton1.CancelHandler += new ucDataButton.DataHandler(this.ucDataButton1_CancelHandler);
            this.ucDataButton1.SaveHandler += new ucDataButton.DataHandler(this.ucDataButton1_SaveHandler);
            this.ucDataButton1.CloseHandler += new ucDataButton.DataHandler(this.ucDataButton1_CloseHandler);
            this.ucDataButton1.EditHandler += new ucDataButton.DataHandler(this.ucDataButton1_EditHandler);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treGroup);
            this.splitContainer2.Panel1.Controls.Add(this.lblGroups);
            this.splitContainer2.Panel1MinSize = 0;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainerMenu);
            this.splitContainer2.Size = new System.Drawing.Size(990, 490);
            this.splitContainer2.SplitterDistance = 256;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 2;
            // 
            // treGroup
            // 
            this.treGroup.BackColor = System.Drawing.SystemColors.Window;
            this.treGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treGroup.HideSelection = false;
            this.treGroup.ImageIndex = 0;
            this.treGroup.ImageList = this.imageListGroup;
            this.treGroup.Location = new System.Drawing.Point(0, 23);
            this.treGroup.Name = "treGroup";
            this.treGroup.SelectedImageIndex = 0;
            this.treGroup.ShowPlusMinus = false;
            this.treGroup.Size = new System.Drawing.Size(252, 463);
            this.treGroup.TabIndex = 4;
            this.treGroup.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treGroup_AfterSelect);
            // 
            // imageListGroup
            // 
            this.imageListGroup.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListGroup.ImageStream")));
            this.imageListGroup.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListGroup.Images.SetKeyName(0, "security.png");
            this.imageListGroup.Images.SetKeyName(1, "competences.gif");
            // 
            // lblGroups
            // 
            this.lblGroups.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroups.Location = new System.Drawing.Point(0, 0);
            this.lblGroups.Name = "lblGroups";
            this.lblGroups.Size = new System.Drawing.Size(252, 23);
            this.lblGroups.TabIndex = 3;
            this.lblGroups.Text = "Danh sách nhóm người dùng";
            this.lblGroups.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainerMenu
            // 
            this.splitContainerMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMenu.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMenu.Name = "splitContainerMenu";
            this.splitContainerMenu.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMenu.Panel1
            // 
            this.splitContainerMenu.Panel1.AutoScroll = true;
            this.splitContainerMenu.Panel1.Controls.Add(this.menuStrip2);
            // 
            // splitContainerMenu.Panel2
            // 
            this.splitContainerMenu.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainerMenu.Panel2.Controls.Add(this.pnlAuthorization);
            this.splitContainerMenu.Size = new System.Drawing.Size(729, 486);
            this.splitContainerMenu.SplitterDistance = 25;
            this.splitContainerMenu.TabIndex = 4;
            // 
            // menuStrip2
            // 
            this.menuStrip2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(729, 24);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip1";
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 57);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.AutoScroll = true;
            this.splitContainer3.Panel1.Controls.Add(this.treFunctionGroup);
            this.splitContainer3.Panel1.Controls.Add(this.btnGenerate);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.chkAll);
            this.splitContainer3.Panel2.Controls.Add(this.lstMethod);
            this.splitContainer3.Size = new System.Drawing.Size(729, 400);
            this.splitContainer3.SplitterDistance = 267;
            this.splitContainer3.SplitterWidth = 1;
            this.splitContainer3.TabIndex = 5;
            // 
            // treFunctionGroup
            // 
            this.treFunctionGroup.BackColor = System.Drawing.SystemColors.Window;
            this.treFunctionGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treFunctionGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treFunctionGroup.HideSelection = false;
            this.treFunctionGroup.ImageIndex = 0;
            this.treFunctionGroup.ImageList = this.imageListFunction;
            this.treFunctionGroup.Location = new System.Drawing.Point(0, 0);
            this.treFunctionGroup.Name = "treFunctionGroup";
            this.treFunctionGroup.SelectedImageIndex = 0;
            this.treFunctionGroup.Size = new System.Drawing.Size(263, 365);
            this.treFunctionGroup.TabIndex = 1;
            this.treFunctionGroup.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treFunctionGroup_NodeMouseDoubleClick);
            this.treFunctionGroup.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treFunctionGroup_AfterSelect);
            // 
            // imageListFunction
            // 
            this.imageListFunction.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListFunction.ImageStream")));
            this.imageListFunction.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListFunction.Images.SetKeyName(0, "");
            this.imageListFunction.Images.SetKeyName(1, "Module.gif");
            this.imageListFunction.Images.SetKeyName(2, "SelectedModule.gif");
            // 
            // btnGenerate
            // 
            this.btnGenerate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGenerate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(0, 365);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(263, 31);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Visible = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(5, 4);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(15, 14);
            this.chkAll.TabIndex = 4;
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // lstMethod
            // 
            this.lstMethod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstMethod.CheckBoxes = true;
            this.lstMethod.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmItemDescription});
            this.lstMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMethod.Enabled = false;
            this.lstMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMethod.FullRowSelect = true;
            this.lstMethod.GridLines = true;
            this.lstMethod.Location = new System.Drawing.Point(0, 0);
            this.lstMethod.MultiSelect = false;
            this.lstMethod.Name = "lstMethod";
            this.lstMethod.Size = new System.Drawing.Size(457, 396);
            this.lstMethod.TabIndex = 3;
            this.lstMethod.UseCompatibleStateImageBehavior = false;
            this.lstMethod.View = System.Windows.Forms.View.Details;
            this.lstMethod.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstMethod_ItemChecked);
            // 
            // clmItemDescription
            // 
            this.clmItemDescription.Name = "clmItemDescription";
            this.clmItemDescription.Text = "      Mô tả chức năng";
            this.clmItemDescription.Width = 400;
            // 
            // pnlAuthorization
            // 
            this.pnlAuthorization.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuthorization.Controls.Add(this.lblNumber);
            this.pnlAuthorization.Controls.Add(this.lblAuthorizationCount);
            this.pnlAuthorization.Controls.Add(this.lblGroupName);
            this.pnlAuthorization.Controls.Add(this.txtGroupName);
            this.pnlAuthorization.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAuthorization.Location = new System.Drawing.Point(0, 0);
            this.pnlAuthorization.Name = "pnlAuthorization";
            this.pnlAuthorization.Size = new System.Drawing.Size(729, 57);
            this.pnlAuthorization.TabIndex = 4;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumber.Location = new System.Drawing.Point(78, 32);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(71, 16);
            this.lblNumber.TabIndex = 4;
            this.lblNumber.Text = "Chức năng";
            // 
            // lblAuthorizationCount
            // 
            this.lblAuthorizationCount.AutoSize = true;
            this.lblAuthorizationCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthorizationCount.Location = new System.Drawing.Point(3, 32);
            this.lblAuthorizationCount.Name = "lblAuthorizationCount";
            this.lblAuthorizationCount.Size = new System.Drawing.Size(71, 16);
            this.lblAuthorizationCount.TabIndex = 3;
            this.lblAuthorizationCount.Text = "Chức năng";
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupName.Location = new System.Drawing.Point(3, 10);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(68, 16);
            this.lblGroupName.TabIndex = 2;
            this.lblGroupName.Text = "Tên nhóm";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGroupName.Location = new System.Drawing.Point(77, 5);
            this.txtGroupName.MaxLength = 50;
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.ReadOnly = true;
            this.txtGroupName.Size = new System.Drawing.Size(641, 22);
            this.txtGroupName.TabIndex = 1;
            // 
            // frmAuthorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(990, 556);
            this.Name = "frmAuthorization";
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.frmAuthorization_Shown);
            this.Load += new System.EventHandler(this.frmAuthorization_Load);
            this.pnlMain.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainerMenu.Panel1.ResumeLayout(false);
            this.splitContainerMenu.Panel1.PerformLayout();
            this.splitContainerMenu.Panel2.ResumeLayout(false);
            this.splitContainerMenu.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            this.splitContainer3.ResumeLayout(false);
            this.pnlAuthorization.ResumeLayout(false);
            this.pnlAuthorization.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView treGroup;
        private System.Windows.Forms.Label lblGroups;
        private System.Windows.Forms.SplitContainer splitContainerMenu;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TreeView treFunctionGroup;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.ListView lstMethod;
        private System.Windows.Forms.ColumnHeader clmItemDescription;
        private System.Windows.Forms.Panel pnlAuthorization;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblAuthorizationCount;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.ImageList imageListGroup;
        private System.Windows.Forms.ImageList imageListFunction;
    }
}
