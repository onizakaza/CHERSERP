using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonForm;
using CommonVariable;

namespace CHERSERP
{
    public partial class MDIForm : Form
    {
        public MDIForm()
        {
            this.Shown += ParrentForm_Shown;
            InitializeComponent();
          
        }

        private void ParrentForm_Shown(object sender, EventArgs e)
        {
            try
            {
                LoginForm frmlogin = new LoginForm();
                frmlogin.ShowDialog();

                if (frmlogin.DialogResult == DialogResult.Yes)
                {
                    MainForm mainForm = new MainForm();
                    mainForm.MdiParent = this;
                    mainForm.ShowIcon = false;
                    mainForm.FormBorderStyle = FormBorderStyle.None;
                    mainForm.Dock = DockStyle.Fill;
                    toolStripStatusLabelUser.Text = "User : "+ GlobalUser.FirstName+ " " + GlobalUser.LastName;
                    mainForm.Show();
                }
                else if (frmlogin.DialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CHERSERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.No;
                this.Close();
            }
        }

    }
}
