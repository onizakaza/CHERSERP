using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonForm
{
    public partial class TextboxLookup : UserControl
    {
        public event EventHandler btnSearchClicked;
        public TextboxLookup()
        {
            InitializeComponent();
            this.btnSearch.Click += BtnSearch_Click;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (this.btnSearchClicked != null)
            {
                this.btnSearchClicked(sender, e);
            }
        }

        public string lblText
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        public Color lblColor
        {
            get { return label1.ForeColor; }
            set { label1.ForeColor = value; }
        }
    }
}
