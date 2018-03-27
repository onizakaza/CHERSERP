namespace System
{
    partial class SY_RunningNo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SY_RunningNo));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelMainData = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMenu = new System.Windows.Forms.ComboBox();
            this.txtFormat = new System.Windows.Forms.TextBox();
            this.lblFormat = new System.Windows.Forms.Label();
            this.txtNextNo = new System.Windows.Forms.TextBox();
            this.lblNextNo = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.panelMainGrid = new System.Windows.Forms.Panel();
            this.mainGrid1 = new CommonForm.MainGrid();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.topMenu1 = new CommonForm.TopMenu();
            this.statusStrip1.SuspendLayout();
            this.panelMainData.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelMainGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 582);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(980, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // panelMainData
            // 
            this.panelMainData.Controls.Add(this.groupBox1);
            this.panelMainData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainData.Location = new System.Drawing.Point(0, 27);
            this.panelMainData.Name = "panelMainData";
            this.panelMainData.Size = new System.Drawing.Size(980, 555);
            this.panelMainData.TabIndex = 23;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbItem);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbMenu);
            this.groupBox1.Controls.Add(this.txtFormat);
            this.groupBox1.Controls.Add(this.lblFormat);
            this.groupBox1.Controls.Add(this.txtNextNo);
            this.groupBox1.Controls.Add(this.lblNextNo);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.lblDescription);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.lblCode);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(980, 555);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Running No";
            // 
            // cmbItem
            // 
            this.cmbItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.Location = new System.Drawing.Point(155, 166);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(201, 28);
            this.cmbItem.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Item";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Menu";
            // 
            // cmbMenu
            // 
            this.cmbMenu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMenu.FormattingEnabled = true;
            this.cmbMenu.Location = new System.Drawing.Point(155, 132);
            this.cmbMenu.Name = "cmbMenu";
            this.cmbMenu.Size = new System.Drawing.Size(201, 28);
            this.cmbMenu.TabIndex = 8;
            // 
            // txtFormat
            // 
            this.txtFormat.Location = new System.Drawing.Point(155, 232);
            this.txtFormat.Name = "txtFormat";
            this.txtFormat.Size = new System.Drawing.Size(201, 26);
            this.txtFormat.TabIndex = 7;
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Location = new System.Drawing.Point(89, 235);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(60, 20);
            this.lblFormat.TabIndex = 6;
            this.lblFormat.Text = "Format";
            // 
            // txtNextNo
            // 
            this.txtNextNo.Location = new System.Drawing.Point(155, 200);
            this.txtNextNo.Name = "txtNextNo";
            this.txtNextNo.Size = new System.Drawing.Size(201, 26);
            this.txtNextNo.TabIndex = 5;
            // 
            // lblNextNo
            // 
            this.lblNextNo.AutoSize = true;
            this.lblNextNo.Location = new System.Drawing.Point(84, 203);
            this.lblNextNo.Name = "lblNextNo";
            this.lblNextNo.Size = new System.Drawing.Size(65, 20);
            this.lblNextNo.TabIndex = 4;
            this.lblNextNo.Text = "Next No";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(155, 100);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(201, 26);
            this.txtDescription.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(60, 103);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(89, 20);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(155, 68);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(201, 26);
            this.txtCode.TabIndex = 1;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(102, 71);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(47, 20);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Code";
            // 
            // panelMainGrid
            // 
            this.panelMainGrid.Controls.Add(this.mainGrid1);
            this.panelMainGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainGrid.Location = new System.Drawing.Point(0, 27);
            this.panelMainGrid.Name = "panelMainGrid";
            this.panelMainGrid.Size = new System.Drawing.Size(980, 555);
            this.panelMainGrid.TabIndex = 23;
            // 
            // mainGrid1
            // 
            this.mainGrid1.AutoSize = true;
            this.mainGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainGrid1.Location = new System.Drawing.Point(0, 0);
            this.mainGrid1.Name = "mainGrid1";
            this.mainGrid1.OrderBy = "";
            this.mainGrid1.PageSize = 50;
            this.mainGrid1.PreCondition = "";
            this.mainGrid1.SelectedFields = "";
            this.mainGrid1.SelectedTable = "";
            this.mainGrid1.Size = new System.Drawing.Size(980, 555);
            this.mainGrid1.TabIndex = 0;
            this.mainGrid1.ViewName = "";
            this.mainGrid1.RowDoubleClicked += new System.EventHandler<CommonForm.RowDoubleClickedArg>(this.mainGrid1_RowDoubleClicked);
            // 
            // topMenu1
            // 
            this.topMenu1.AutoSize = true;
            this.topMenu1.BackColor = System.Drawing.SystemColors.Control;
            this.topMenu1.Dock = System.Windows.Forms.DockStyle.Top;
            this.topMenu1.Location = new System.Drawing.Point(0, 0);
            this.topMenu1.Name = "topMenu1";
            this.topMenu1.Size = new System.Drawing.Size(980, 27);
            this.topMenu1.TabIndex = 12;
            this.topMenu1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.topMenu1_ItemClicked);
            // 
            // SY_RunningNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::CHERSERP.Properties.Resources.BG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(980, 604);
            this.Controls.Add(this.panelMainData);
            this.Controls.Add(this.panelMainGrid);
            this.Controls.Add(this.topMenu1);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SY_RunningNo";
            this.Text = "Running Number";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelMainData.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelMainGrid.ResumeLayout(false);
            this.panelMainGrid.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private CommonForm.TopMenu topMenu1;
        private System.Windows.Forms.Panel panelMainData;
        private System.Windows.Forms.Panel panelMainGrid;
        private CommonForm.MainGrid mainGrid1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Windows.Forms.Label lblCode;
        private Windows.Forms.TextBox txtFormat;
        private Windows.Forms.Label lblFormat;
        private Windows.Forms.TextBox txtNextNo;
        private Windows.Forms.Label lblNextNo;
        private Windows.Forms.TextBox txtDescription;
        private Windows.Forms.Label lblDescription;
        private Windows.Forms.TextBox txtCode;
        private Windows.Forms.ComboBox cmbItem;
        private Windows.Forms.Label label2;
        private Windows.Forms.Label label1;
        private Windows.Forms.ComboBox cmbMenu;
    }
}