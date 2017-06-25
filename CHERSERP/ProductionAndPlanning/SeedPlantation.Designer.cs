namespace MainPage.ProductionAndPlanning
{
    partial class SeedPlantation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeedPlantation));
            this.textboxLookup1 = new CommonForm.TextboxLookup();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textboxLookup1
            // 
            this.textboxLookup1.Location = new System.Drawing.Point(117, 76);
            this.textboxLookup1.Name = "textboxLookup1";
            this.textboxLookup1.Size = new System.Drawing.Size(419, 26);
            this.textboxLookup1.TabIndex = 0;
            this.textboxLookup1.btnSearchClicked += new System.EventHandler(this.textboxLookup1_btnSearchClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seed Plantation";
            // 
            // SeedPlantation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::CHERSERP.Properties.Resources.BG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(980, 604);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textboxLookup1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SeedPlantation";
            this.Text = "SeedPlantation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CommonForm.TextboxLookup textboxLookup1;
        private System.Windows.Forms.Label label1;
    }
}