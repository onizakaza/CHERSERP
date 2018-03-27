using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using CommonLibrary;

namespace CommonForm
{
    public partial class MainGrid : UserControl
    {
        clsDatabase DB = new clsDatabase();

        private string strSelectedFields = "";
        private string strSelectedTable = "";
        DataTable dtSource;
        string strViewName="";
        string strPreCondition="";
        string strOrderBy="";
        string strSearchCondition = "";
        int PageCount;
        int maxRec;
        int pageSize = 50;
        int currentPage = 1;
        int recNo;


        //public delegate void (object sender, RowDoubleClickedArg row);
        public event EventHandler<RowDoubleClickedArg> RowDoubleClicked;


        public MainGrid()
        {
            InitializeComponent();
        }

        public DataTable DataSource
        {
            set
            {
                dtSource = value;
            }
        }

        public string ViewName
        {
            get
            {
                return strViewName;
            }
            set
            {
                strViewName = value;
            }
        }
        public string PreCondition
        {
            get
            {
                return strPreCondition;
            }
            set
            {
                strPreCondition = value;
            }
        }
        public string OrderBy
        {
            get
            {
                return strOrderBy;
            }
            set
            {
                strOrderBy = value;
            }
        }

        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                if (value < 1)
                {
                    pageSize = 1;
                }
                else
                {
                    pageSize = value;
                }
            }
        }
        public int CurrentPage
        {
            get
            {
                return currentPage;
            }
        }

        public void LoadGrid()
        {

            //Count records
            string strSQL = "SELECT COUNT(*) FROM " + ViewName + " WHERE 1=1 ";
            if (PreCondition.Trim() != "")
                strSQL += " AND " + PreCondition;

            DataTable tmpDT = DB.QueryDataTable(strSQL);
            int.TryParse(tmpDT.Rows[0][0].ToString(), out maxRec);
            PageCount = maxRec / pageSize;

            //Adjust the page number if the last page contains a partial page.
            if ((maxRec % pageSize) > 0)
            {
                PageCount += 1;
            }

            // Initial seeings
            currentPage = 1;

            // Display the content of the current page.
            LoadPage();

        }

        public string SelectedFields
        {
            get
            {
                return strSelectedFields;
            }
            set
            {
                strSelectedFields = value;
            }
        }
        public string SelectedTable
        {
            get
            {
                return strSelectedTable;
            }
            set
            {
                strSelectedTable = value;
            }
        }
        private void DisplayPageInfo()
        {
            txtCurrentPage.Text = currentPage.ToString();
            lblPageCount.Text = PageCount.ToString();
        }
        private void LoadPage()
        {
            dtSource = DB.QueryDataTable(getSQLQuery());
            dataGridView1.DataSource = dtSource;
            DisplayPageInfo(); 
        }

        private string getSQLQuery()
        {
            string strSQL = "SELECT * INTO #TemporaryTable FROM ( " +
                         " SELECT * FROM ( " +
                             " SELECT ROW_NUMBER() OVER( ";
            if (strOrderBy.Trim() != "")
            {
                strSQL += " ORDER BY " + strOrderBy.Trim() + " ";
            }
            else
            {
                strSQL += " ORDER BY CreatedDate desc ";
            }

            strSQL += " ) AS NUMBER," +
                             " * FROM " + strViewName + " WHERE 1=1 ";

            if (strPreCondition.Trim() != "")
            {
                strSQL +=  " AND " + strPreCondition;
            }

            if(strSearchCondition.Trim() != "")
            {
                strSQL += " AND " + strSearchCondition;
            }

            strSQL += " ) AS TBL " +
                             " WHERE NUMBER BETWEEN ((" + currentPage.ToString() + " - 1) * " + pageSize.ToString() + " + 1) AND (" + currentPage.ToString() + " * " + pageSize.ToString() + ") " +
                         " ) AS TMP " +
                     " ALTER TABLE #TemporaryTable DROP COLUMN NUMBER " +
                     " SELECT * FROM #TemporaryTable ";
            if (strOrderBy.Trim() != "")
            {
                strSQL += " ORDER BY " + strOrderBy.Trim() + " ";
            }
            else
            {
                strSQL += " ORDER BY CreatedDate desc ";
            }

            strSQL += " DROP TABLE #TemporaryTable ";

            return strSQL;
        }
        
        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            //Check if you are already at the first page.
            if (currentPage == 1)
            {
                MessageBox.Show("You are at the First Page!");
                return;
            }

            currentPage = 1;
            LoadPage();
        }
        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            currentPage -= 1;
            //Check if you are already at the first page.
            if (currentPage < 1)
            {
                MessageBox.Show("You are at the First Page!");
                currentPage = 1;
                return;
            }

            LoadPage();
        }
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            //Check if the user clicks the "Fill Grid" button.
            if (pageSize == 0)
            {
                MessageBox.Show("Set the Page Size, and then click the Fill Grid button!");
                return;
            }

            currentPage += 1;
            if (currentPage > PageCount)
            {
                currentPage = PageCount;
                MessageBox.Show("You are at the Last Page!");
                return;
            }
            LoadPage();
        }
        private void btnLastPage_Click(object sender, EventArgs e)
        {
            //Check if you are already at the last page.
            if (currentPage == PageCount)
            {
                MessageBox.Show("You are at the Last Page!");
                return;
            }
            currentPage = PageCount;
            LoadPage();
        }
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowIndex >= 0)
            {
                if (this.RowDoubleClicked != null)
                {
                    RowDoubleClickedArg row = new RowDoubleClickedArg(dataGridView1.Rows[e.RowIndex]);
                    this.RowDoubleClicked(sender, row);
                }
                //dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ToString()
            }
        }
        public void Export(string FileName)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "CSV file (*.csv)|*.csv| All Files (*.*)|*.*";
            saveFileDialog1.Title = "Save";
            saveFileDialog1.FileName = FileName;
            

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ToCSV(dtSource, saveFileDialog1.FileName);

                if (File.Exists(saveFileDialog1.FileName))
                {
                    Process.Start(saveFileDialog1.FileName);
                }
            }


        }

        public void ToCSV(DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false,Encoding.UTF8);
            //headers  
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
                
            }
            sw.Close();
        }
    }
















    public class RowDoubleClickedArg : EventArgs
    {
        private DataGridViewRow row;
        public RowDoubleClickedArg(DataGridViewRow row)
        {
            this.row = row;
        }
        public DataGridViewRow Row
        {
            get { return row; }
        }

    }

    
}
