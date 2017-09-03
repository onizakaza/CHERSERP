using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonVariable;
using CommonLibrary;
using CommonForm;

namespace Master
{
    public partial class MS_Customers : Form
    {
        clsDatabase db = new clsDatabase();
        public MS_Customers()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "User : " + GlobalUser.FirstName + " " + GlobalUser.LastName;
            SelectDataIntoMainGrid();
            SetControlState("Search");
        }
        private void SelectDataIntoMainGrid()
        {
            DataTable dt = db.QueryDataTable("Select * from MS_Customers");
            mainGrid1.SetDataSource(dt);
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
                SetControlState(itemName);
                switch (itemName)
                {
                    case "New":
                        break;
                    case "Edit":
                        break;
                    case "Save":
                        break;
                    case "Delete":
                        break;
                    case "Search":
                        break;
                    case "Refresh":
                        break;
                    case "Excel":
                        break;

                }
            }
        }
        private void SaveData()
        {
            
        } 
        private void SetControlState(string state)
        {
            switch (state)
            {
                case "New":
                    topMenu1.MenuNew.Enabled = false;
                    topMenu1.MenuEdit.Enabled = false;
                    topMenu1.MenuSave.Enabled = true;
                    topMenu1.MenuDelete.Enabled = false;
                    topMenu1.MenuSearch.Enabled = true;
                    topMenu1.MenuRefresh.Enabled = false;
                    topMenu1.MenuExcel.Enabled = false;
                    panelMainData.Visible = true;
                    panelMainGrid.Visible = false;
                    break;
                case "Edit":
                    topMenu1.MenuNew.Enabled = false;
                    topMenu1.MenuEdit.Enabled = false;
                    topMenu1.MenuSave.Enabled = true;
                    topMenu1.MenuDelete.Enabled = false;
                    topMenu1.MenuSearch.Enabled = true;
                    topMenu1.MenuRefresh.Enabled = false;
                    topMenu1.MenuExcel.Enabled = false;
                    panelMainData.Visible = true;
                    panelMainGrid.Visible = false;

                    break;
                case "Search":
                    topMenu1.MenuNew.Enabled = true;
                    topMenu1.MenuEdit.Enabled = true;
                    topMenu1.MenuSave.Enabled = false;
                    topMenu1.MenuDelete.Enabled = true;
                    topMenu1.MenuSearch.Enabled = true;
                    topMenu1.MenuRefresh.Enabled = true;
                    topMenu1.MenuExcel.Enabled = true;
                    panelMainData.Visible = false;
                    panelMainGrid.Visible = true;
                    break;

            }
        }
    }
}
