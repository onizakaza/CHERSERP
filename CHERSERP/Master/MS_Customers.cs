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
        clsMessageBox message = new clsMessageBox();

        public MS_Customers()
        {
            InitializeComponent();
            InitialDetailGrid();
            toolStripStatusLabel1.Text = "User : " + GlobalUser.FirstName + " " + GlobalUser.LastName;
            SelectDataIntoMainGrid();
            SetControlState("Search");
        }
        private void SelectDataIntoMainGrid()
        {
            mainGrid1.ViewName = "MS_Customers";
            mainGrid1.OrderBy = "id";
            mainGrid1.LoadGrid();
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
                        break;
                    case "Excel":
                        mainGrid1.Export("1");
                        break;

                }
            }
        }
        private void ClearControls()
        {
            
        }
        private bool ValidateBeforeSave()
        {
            
            return true;
        }
        private bool SaveData()
        {
            try
            {
                clsRunningNo running = new clsRunningNo();


                #region SAVE TRANSACTION
                db.TransStart();

                //Get Running Number
                clsSave MS_Customer = new clsSave("MS_Customers");

                MS_Customer.SetValue("ID", db.SQLText(running.GetNextNumber(ref db, GetType().Namespace + "." + this.Name)));
                MS_Customer.SetValue("Name", db.SQLText(txtName.Text.Trim()));
                MS_Customer.SetValue("Branch", db.SQLText(txtBranch.Text.Trim()));
                MS_Customer.SetValue("TaxID", db.SQLText(txtTaxID.Text.Trim()));

                db.TransExecute(MS_Customer.SQLInsert());
                db.TransCommit();
                #endregion SAVE TRANSACTION

                return true;
            }
            catch (Exception ex)
            {
                db.TransRollBack();
                message.Error(ex.Message);
                return false;
            }
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

        private void InitialDetailGrid()
        {
            #region Initial grid1

            this.dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dataGridView1.AlternatingRowsDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dataGridView1.RowHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);

            //Adding Row
            DataGridViewTextBoxColumn ColumnRow = new DataGridViewTextBoxColumn();
            ColumnRow.HeaderText = "Row";
            ColumnRow.DataPropertyName = "Row";
            ColumnRow.Width = 50;
            ColumnRow.ReadOnly = true;
            dataGridView1.Columns.Add(ColumnRow);


            //Adding Details
            DataGridViewTextBoxColumn ColumnAddress = new DataGridViewTextBoxColumn();
            ColumnAddress.HeaderText = "Detail";
            ColumnAddress.DataPropertyName = "Detail";
            ColumnAddress.Width = 200;
            dataGridView1.Columns.Add(ColumnAddress);

            //Adding IsDefault
            DataGridViewCheckBoxColumn ColumnIsDefault = new DataGridViewCheckBoxColumn();
            ColumnIsDefault.HeaderText = "Default";
            ColumnIsDefault.DataPropertyName = "IsDefault";
            ColumnIsDefault.Width = 60;
            dataGridView1.Columns.Add(ColumnIsDefault);

            #endregion Initial grid1

            #region Initial grid2

            this.dataGridView2.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dataGridView2.AlternatingRowsDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dataGridView2.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dataGridView2.RowHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);

            //Adding Row
            DataGridViewTextBoxColumn ColumnRow2 = new DataGridViewTextBoxColumn();
            ColumnRow2.HeaderText = "Row";
            ColumnRow2.DataPropertyName = "Row";
            ColumnRow2.Width = 50;
            ColumnRow2.ReadOnly = true;
            dataGridView2.Columns.Add(ColumnRow2);

            //Adding Type
            DataGridViewComboBoxColumn columnType = new DataGridViewComboBoxColumn();
            columnType.DataPropertyName = "Type";
            columnType.HeaderText = "Type";
            columnType.Width = 80;
            columnType.Items.Add("E-mail");
            columnType.Items.Add("Phone");
            columnType.Items.Add("Others");
            dataGridView2.Columns.Add(columnType);

            //Adding Details
            DataGridViewTextBoxColumn ColumnDetail = new DataGridViewTextBoxColumn();
            ColumnDetail.HeaderText = "Detail";
            ColumnDetail.DataPropertyName = "Detail";
            ColumnDetail.Width = 200;
            dataGridView2.Columns.Add(ColumnDetail);

            //Adding Remark
            DataGridViewTextBoxColumn ColumnRemark = new DataGridViewTextBoxColumn();
            ColumnRemark.HeaderText = "Remark";
            ColumnRemark.DataPropertyName = "Remark";
            ColumnRemark.Width = 200;
            dataGridView2.Columns.Add(ColumnRemark);

            //Adding IsDefault
            DataGridViewCheckBoxColumn ColumnIsDefault2 = new DataGridViewCheckBoxColumn();
            ColumnIsDefault2.HeaderText = "Default";
            ColumnIsDefault2.DataPropertyName = "IsDefault";
            ColumnIsDefault2.Width = 60;
            dataGridView2.Columns.Add(ColumnIsDefault2);

            #endregion Initial grid2
        }

        private void setRowNumber(DataGridView dgv)
        {
            int rowNumber = 1;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                row.Cells[0].Value = rowNumber.ToString();
                rowNumber = rowNumber + 1;
            }
            dgv.AutoResizeRowHeadersWidth(
                DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            setRowNumber(dataGridView1);
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

            setRowNumber(dataGridView1);
        }

        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            setRowNumber(dataGridView2);
        }

        private void dataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            setRowNumber(dataGridView2);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
