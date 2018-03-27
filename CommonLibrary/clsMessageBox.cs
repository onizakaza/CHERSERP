using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonLibrary
{
    public class clsMessageBox
    {
        private string messageBoxTitle = "";
        public void Error(string message)
        {
            MessageBox.Show(message, messageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public string MessageBoxTitle
        {
            get
            {
                return messageBoxTitle;
            }
            set
            {
                messageBoxTitle = value;
            }
        }
    }
}
