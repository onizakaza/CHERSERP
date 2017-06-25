﻿using System;
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
            this.btnSearchClicked(sender, e);
        }
}
}
