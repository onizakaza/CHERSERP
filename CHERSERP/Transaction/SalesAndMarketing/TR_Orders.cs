using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainPage.ProductionAndPlanning
{
    public partial class TR_Orders : Form
    {
        public TR_Orders()
        {
            InitializeComponent();
        }

        private void textboxLookup1_btnSearchClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Yesah");
        }

        private void topMenu1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            string itemName;
            if (item != null)
            {
                itemName = item.Text;
                switch (itemName)
                {
                    case "New":
                        MessageBox.Show("New");
                        break;
                    
                }
            }
        }
    }
}
