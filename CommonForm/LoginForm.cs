using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonLibrary;
using CommonVariable;



namespace CommonForm
{
    public partial class LoginForm : Form
    {
        clsDatabase db = new clsDatabase();

        public LoginForm()
        {
            InitializeComponent();
            
            comboBox1.SelectedIndex = 0;
            comboBox1.DrawItem += ComboBox1_DrawItem;  
            DataTable dt = new DataTable();
            dt = db.QueryDataTable("select top 1 loginname from sy_user");
            txtLoginName.Text = dt.Rows[0][0].ToString();
        }

        private void ComboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            var brush = Brushes.Black;
            e.DrawBackground();
            if(!(e.Index<0))
            e.Graphics.DrawString(((ComboBox)sender).Items[e.Index].ToString(), ((Control)sender).Font, brush, e.Bounds.X, e.Bounds.Y);
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(Login(txtLoginName.Text,txtPassword.Text))
            {
                DialogResult = DialogResult.Yes;
                this.Close();
            }
            else
            {

            }
        }

        private bool Login(string loginName,string password)
        {
            DataTable dt = db.QueryDataTable("SELECT * FROM SY_USER WHERE LoginName = '" + txtLoginName.Text.Trim() + "'");

            if(dt.Rows.Count == 0)
            {
                MessageBox.Show("Invalid Login Name");
                return false;
            }
            if(dt.Rows.Count > 0)
            {
                if(txtPassword.Text.Trim() == dt.Rows[0]["Password"].ToString().Trim())
                {
                    GlobalUser.FirstName = dt.Rows[0]["FirstName"].ToString().Trim();
                    GlobalUser.LastName = dt.Rows[0]["LastName"].ToString().Trim();
                    return true;
                }
                else
                {
                    MessageBox.Show("Invalid Password");
                    return false;
                }
            }

            return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }

    }
}
