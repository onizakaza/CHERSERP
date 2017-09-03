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
    public partial class TopMenu : UserControl
    {

        public event ToolStripItemClickedEventHandler ItemClicked;


        public TopMenu()
        {
            InitializeComponent();
        }

        public ToolStripButton MenuNew
        { 
            get { return menuNew; }
        }
        public ToolStripButton MenuEdit
        {
            get { return menuEdit; }
        }
        public ToolStripButton MenuSave
        {
            get { return menuSave; }
        }
        public ToolStripButton MenuDelete
        {
            get { return menuDelete; }
        }
        public ToolStripButton MenuSearch
        {
            get { return menuSearch; }
        }
        public ToolStripButton MenuRefresh
        {
            get { return menuRefresh; }
        }
        public ToolStripButton MenuExcel
        {
            get { return menuExcel; }
        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (this.ItemClicked != null)
            {
                this.ItemClicked(sender, e);
            }
        }


    }
}
