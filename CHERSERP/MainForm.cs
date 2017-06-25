using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MainPage.ProductionAndPlanning;
using CommonForm;
using CommonLibrary;

namespace CHERSERP
{
    public partial class MainForm : Form
    {
        clsDatabase db = new clsDatabase();
        bool LoginFlag = false;

        public MainForm()
        {
            InitializeComponent();
            InitialTreeView();
            listView1.ItemActivate += ListView1_ItemActivate;
            treeView1.AfterSelect += TreeView1_AfterSelect;
            
        }

        private void InitialTreeView()
        {
            
            treeView1.BeginUpdate();
            treeView1.Nodes.Add("Home");
            treeView1.Nodes.Add("Production and Planing");
            treeView1.Nodes.Add("System and Configuration");
            

            treeView1.EndUpdate();
        }



        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Text = treeView1.SelectedNode.Text.Trim().ToUpper();
            switch (treeView1.SelectedNode.Text.Trim().ToUpper())
            {
                
                case "HOME":
                    tabControl1.Visible = false;
                    break;
                case "SYSTEM AND CONFIGURATION":
                    tabControl1.Visible = true;
                    break;
                default:
                    tabControl1.Visible = true;
                    OpenDashBoard();
                    GetListView();
                    break;
            }


        }

        private void OpenDashBoard()
        {
            
        }

        private void GetListView()
        {
            listView1.Items.Clear();
            ListViewItem listViewItem = new ListViewItem();
            listViewItem.Text = "Item Production";
            listViewItem.ImageIndex = 1;
            listView1.Items.Add(listViewItem);

            listViewItem = new ListViewItem();
            listViewItem.Text = "Exit";
            listViewItem.ImageIndex = 1;
            listView1.Items.Add(listViewItem);
        }

        private void ListView1_ItemActivate(object sender, EventArgs e)
        {

            switch(listView1.SelectedItems[0].Text.Trim().ToUpper())
            {
                case "EXIT":
                    if (MessageBox.Show("Do you want to Exit ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                    break;
                default:
                    SeedPlantation frm = new SeedPlantation();
                    frm.Show();
                    //MessageBox.Show(listView1.SelectedItems[0].Text);
                    break;
            }

            
        }


    }
}
