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
    public partial class MainGrid : UserControl
    {
        private string strSelectedFields = "";
        private string strSelectedTable = "";


        public MainGrid()
        {
            InitializeComponent();
        }

        public void SetDataSource(DataTable dt)
        {
            dataGridView1.DataSource = dt;
        }

        public DataTable DataSource
        {
            set
            {
               dataGridView1.DataSource = value;
            }
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

        public void SelectData()
        {
            string strSQL = "SELECT";
        }
    }
}
