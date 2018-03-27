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
using System.Data.SqlClient;

namespace System
{
    public partial class SY_RunningNo : Form
    {
        private clsDatabase db = new clsDatabase();
        private clsMessageBox message = new clsMessageBox();
        private string saveFlag = "NEW";

        public SY_RunningNo()
        {
            #region FORM INITIAL
            InitializeComponent();
            message.MessageBoxTitle = this.Text;
            toolStripStatusLabel1.Text = "User : " + GlobalUser.FirstName + " " + GlobalUser.LastName;
            SelectDataIntoMainGrid();
            SetControlState("Search");
            #endregion

            LoadComboBox_Menu();
            cmbMenu.SelectedIndexChanged += CmbMenu_SelectedIndexChanged;
            cmbItem.Enabled = false;
        }

        private void CmbMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMenu.SelectedValue.ToString() != "")
            {
                LoadComboBox_Item();
                cmbItem.Enabled = true;
            }
            else
            {
                cmbItem.Enabled = false;
            }
        }

        private void LoadComboBox_Menu()
        {
            String strSQL;
            DataTable dt;
            Dictionary<string, string> DataToCombo = new Dictionary<string, string>();
            strSQL = "SELECT MenuName From VW_SY_MenuListItem ORDER BY MenuName";
            dt = db.QueryDataTable(strSQL);
            
            DataToCombo.Add("--Please Select--", "");
            
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    DataToCombo.Add(dt.Rows[i]["MenuName"].ToString(), dt.Rows[i]["MenuName"].ToString());
                }
            }
            cmbMenu.DataSource = new BindingSource(DataToCombo, null);
            cmbMenu.DisplayMember = "Key";
            cmbMenu.ValueMember = "Value";
            cmbMenu.SelectedIndex = 0;
        }

        private void LoadComboBox_Item()
        {
            String strSQL;
            DataTable dt;
            Dictionary<string, string> DataToCombo = new Dictionary<string, string>();
            strSQL = "SELECT ListItemName,EXEName From VW_SY_MenuListItem WHERE MenuName = "+db.SQLText(cmbMenu.SelectedValue.ToString())+" ORDER BY MenuName";
            dt = db.QueryDataTable(strSQL);

            DataToCombo.Add("--Please Select--", "");

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    DataToCombo.Add(dt.Rows[i]["ListItemName"].ToString(), dt.Rows[i]["EXEName"].ToString());
                }
            }
            cmbItem.DataSource = new BindingSource(DataToCombo, null);
            cmbItem.DisplayMember = "Key";
            cmbItem.ValueMember = "Value";
            cmbItem.SelectedIndex = 0;
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
                            ClearControls();
                        break;
                    case "Edit":
                        break;
                    case "Save":
                        if (!ValidateBeforeSave())
                            return;

                        if (SaveData())
                        {
                            MessageBox.Show("Save Completed.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearControls();
                            SetControlState("Search");
                            SelectDataIntoMainGrid();
                        }
                        break;
                    case "Delete":
                        break;
                    case "Search":
                        break;
                    case "Refresh":
                        SelectDataIntoMainGrid();
                        break;
                    case "Excel":
                        mainGrid1.Export(this.Text+DateTime.Now.ToString("yyyyMMdd"));
                        break;

                }
            }
        }
        private void SetControlState(string state)
            {
                switch (state.ToUpper())
                {
                    case "NEW":
                        topMenu1.MenuNew.Enabled = false;
                        topMenu1.MenuEdit.Enabled = false;
                        topMenu1.MenuSave.Enabled = true;
                        topMenu1.MenuDelete.Enabled = false;
                        topMenu1.MenuSearch.Enabled = true;
                        topMenu1.MenuRefresh.Enabled = false;
                        topMenu1.MenuExcel.Enabled = false;
                        panelMainData.Visible = true;
                        panelMainGrid.Visible = false;
                        saveFlag = "NEW";
                        break;
                    case "EDIT":
                        topMenu1.MenuNew.Enabled = false;
                        topMenu1.MenuEdit.Enabled = false;
                        topMenu1.MenuSave.Enabled = true;
                        topMenu1.MenuDelete.Enabled = false;
                        topMenu1.MenuSearch.Enabled = true;
                        topMenu1.MenuRefresh.Enabled = false;
                        topMenu1.MenuExcel.Enabled = false;
                        panelMainData.Visible = true;
                        panelMainGrid.Visible = false;
                        saveFlag = "EDIT";
                        break;
                    case "SEARCH":
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
        private void ClearControls()
        {
            txtCode.Text = "";
            txtDescription.Text = "";
            txtFormat.Text = "";
            txtNextNo.Text = "";
        }
        private void SelectDataIntoMainGrid()
        {
            try
            {
                mainGrid1.ViewName = "SY_RunningNo";
                mainGrid1.OrderBy = "Code";
                mainGrid1.PageSize = 1;
                mainGrid1.LoadGrid();
            }
            catch (SqlException ex)
            {
                message.Error(ex.Message);
            }
        }
        private void SelectData(string key)
        {
            DataTable dt = db.QueryDataTable("Select * from SY_RunningNo Where Code = "+db.SQLText(key));

            if(dt.Rows.Count > 0)
            {
                ClearControls();

                txtCode.Text = dt.Rows[0]["Code"].ToString().Trim();
                txtDescription.Text = dt.Rows[0]["Description"].ToString().Trim();
                txtFormat.Text = dt.Rows[0]["Format"].ToString().Trim();
                txtNextNo.Text = dt.Rows[0]["NextNo"].ToString().Trim();

                SetControlState("EDIT");
            }
        }
        private bool ValidateBeforeSave()
        {
            if(txtDescription.Text.Trim() == "")
            {
                message.Error("Please Insert Description.");
                return false;
            }
            return true;
        }
        private bool SaveData()
        {
            try
            {
                if (saveFlag == "NEW")
                {
                    //string strSQL = "INSERT INTO SY_RunningNo (Code,Description,NextNo,Format,CreatedBy,CreatedDate) " +
                    //                " VALUES(" + db.SQLText(txtCode.Text.Trim()) +
                    //                "," + db.SQLText(txtDescription.Text.Trim()) +
                    //                "," + db.SQLText(txtNextNo.Text.Trim()) +
                    //                "," + db.SQLText(txtFormat.Text.Trim()) +
                    //                "," + db.SQLText(GlobalUser.LoginName) +
                    //                ",GetDate())";

                    clsSave RunningNo = new clsSave("SY_RunningNo");
                    RunningNo.SetValue("Code", db.SQLText(txtCode.Text.Trim()));
                    RunningNo.SetValue("Description", db.SQLText(txtDescription.Text.Trim()));
                    RunningNo.SetValue("EXEName", db.SQLText(cmbItem.SelectedValue.ToString().Trim()));
                    RunningNo.SetValue("NextNo", db.SQLText(txtNextNo.Text.Trim()));
                    RunningNo.SetValue("Format", db.SQLText(txtFormat.Text.Trim()));
                    RunningNo.SetValue("CreatedBy", db.SQLText(GlobalUser.LoginName));
                    RunningNo.SetValue("CreatedDate", "GetDate()");

                    //message.Error(RunningNo.SQLInsert());
                    db.TransStart();
                    db.TransExecute(RunningNo.SQLInsert());
                    db.TransCommit();
                    return true;
                }
                else if(saveFlag == "EDIT")
                {
                    //string strSQL = " UPDATE SY_RunningNo SET " +
                    //                " Description = " + db.SQLText(txtDescription.Text.Trim()) +
                    //                " ,NextNo = " + db.SQLText(txtNextNo.Text.Trim()) +
                    //                " ,Format = " + db.SQLText(txtFormat.Text.Trim()) +
                    //                " ,ModifiedDate = GetDate()"+
                    //                " ,ModifiedBy = " + db.SQLText(GlobalUser.LoginName) +
                    //                " WHERE Code = " + db.SQLText(txtCode.Text.Trim());

                    clsSave RunningNo = new clsSave("SY_RunningNo");
                    RunningNo.SetKey("Code", db.SQLText(txtCode.Text.Trim()));

                    RunningNo.SetValue("Description", db.SQLText(txtDescription.Text.Trim()));
                    RunningNo.SetValue("EXEName", db.SQLText(cmbItem.SelectedValue.ToString().Trim()));
                    RunningNo.SetValue("NextNo", db.SQLText(txtNextNo.Text.Trim()));
                    RunningNo.SetValue("Format", db.SQLText(txtFormat.Text.Trim()));
                    RunningNo.SetValue("CreatedBy", db.SQLText(GlobalUser.LoginName));
                    RunningNo.SetValue("CreatedDate", "GetDate()");

                   

                    db.TransStart();
                    db.TransExecute(RunningNo.SQLUpdate());
                    db.TransCommit();
                    return true;


                }

                else
                {
                    return true;
                }
            }
            catch (SqlException ex)
            {
                db.TransRollBack();
                message.Error(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                message.Error(ex.Message);
                return false;
            }
        }

        // Event Handler Here !!!!
        #region EventHandler
        private void mainGrid1_RowDoubleClicked(object sender, RowDoubleClickedArg e)
        {
            string key = e.Row.Cells[0].Value.ToString();
            SelectData(key);
        }
        #endregion
    }
}
