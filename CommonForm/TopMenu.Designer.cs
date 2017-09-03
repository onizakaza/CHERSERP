namespace CommonForm
{
    partial class TopMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.menuNew = new System.Windows.Forms.ToolStripButton();
            this.menuEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSave = new System.Windows.Forms.ToolStripButton();
            this.menuDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSearch = new System.Windows.Forms.ToolStripButton();
            this.menuRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNew,
            this.menuEdit,
            this.toolStripSeparator1,
            this.menuSave,
            this.menuDelete,
            this.toolStripSeparator2,
            this.menuSearch,
            this.menuRefresh,
            this.toolStripSeparator3,
            this.menuExcel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(509, 40);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // menuNew
            // 
            this.menuNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuNew.Image = global::CommonForm.Properties.Resources.menuNew;
            this.menuNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuNew.Name = "menuNew";
            this.menuNew.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.menuNew.Size = new System.Drawing.Size(64, 37);
            this.menuNew.Text = "New";
            // 
            // menuEdit
            // 
            this.menuEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuEdit.Image = global::CommonForm.Properties.Resources.menuEdit;
            this.menuEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.menuEdit.Size = new System.Drawing.Size(64, 37);
            this.menuEdit.Text = "Edit";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // menuSave
            // 
            this.menuSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuSave.Image = global::CommonForm.Properties.Resources.menuSave;
            this.menuSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuSave.Name = "menuSave";
            this.menuSave.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.menuSave.Size = new System.Drawing.Size(64, 37);
            this.menuSave.Text = "Save";
            // 
            // menuDelete
            // 
            this.menuDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuDelete.Image = global::CommonForm.Properties.Resources.menuDelete;
            this.menuDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.menuDelete.Size = new System.Drawing.Size(64, 37);
            this.menuDelete.Text = "Delete";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // menuSearch
            // 
            this.menuSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuSearch.Image = global::CommonForm.Properties.Resources.menuSearch;
            this.menuSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuSearch.Name = "menuSearch";
            this.menuSearch.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.menuSearch.Size = new System.Drawing.Size(64, 37);
            this.menuSearch.Text = "Search";
            // 
            // menuRefresh
            // 
            this.menuRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuRefresh.Image = global::CommonForm.Properties.Resources.menuRefresh;
            this.menuRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuRefresh.Name = "menuRefresh";
            this.menuRefresh.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.menuRefresh.Size = new System.Drawing.Size(64, 37);
            this.menuRefresh.Text = "Refresh";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 40);
            // 
            // menuExcel
            // 
            this.menuExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuExcel.Image = global::CommonForm.Properties.Resources.menuExcel;
            this.menuExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuExcel.Name = "menuExcel";
            this.menuExcel.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.menuExcel.Size = new System.Drawing.Size(64, 37);
            this.menuExcel.Text = "Excel";
            // 
            // TopMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.toolStrip1);
            this.Name = "TopMenu";
            this.Size = new System.Drawing.Size(509, 40);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton menuNew;
        private System.Windows.Forms.ToolStripButton menuEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton menuSave;
        private System.Windows.Forms.ToolStripButton menuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton menuSearch;
        private System.Windows.Forms.ToolStripButton menuRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton menuExcel;
    }
}
