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
using CommonVariable;

namespace CHERSERP
{
    public partial class MainForm : Form
    {
        clsDatabase db = new clsDatabase();
        clsPermission permission = new clsPermission();

        public MainForm()
        {
            InitializeComponent();
            InitialTreeView();
            listView1.ItemActivate += ListView1_ItemActivate;
            treeView1.AfterSelect += TreeView1_AfterSelect;

        }

        private void InitialTreeView()
        {
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add("Home");
            string[] menu = permission.GetMainMenu(GlobalUser.LoginName).Split('#');
            int i = 1;
            foreach (string a in menu)
            {
                if (a != "")
                {
                    treeView1.Nodes.Add(a);
                    string[] Submenu = permission.GetSubMenu(GlobalUser.LoginName, a).Split('#');
                    foreach (string b in Submenu)
                    {
                        if (b != "")
                        {
                            treeView1.Nodes[i].Nodes.Add(b);
                        }
                    }
                }
                i++;
            }
            treeView1.Nodes.Add("System and Configuration");
        }


        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Text = treeView1.SelectedNode.Text.Trim().ToUpper(); 
            GetListView(treeView1.SelectedNode.Text.Trim());
            OpenDashBoard();
        }

        private void OpenDashBoard()
        {

        }

        private void GetListView(string SelectedNode)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            listView3.Items.Clear();

            /* 
             ListViewItem listViewItem = new ListViewItem();
             listViewItem.Text = "Item Production";
             listViewItem.ImageIndex = 1;
             listView1.Items.Add(listViewItem);

             listViewItem = new ListViewItem();
             listViewItem.Text = "Exit";
             listViewItem.ImageIndex = 1;
             listView1.Items.Add(listViewItem);
             */

            switch (SelectedNode.ToUpper())
            {
                case "HOME":
                    tabControl1.Visible = false;
                    break;
                case "SYSTEM AND CONFIGURATION":
                    tabControl1.Visible = true;
                    break;
                default:
                    #region DEFAULT
                    tabControl1.Visible = true;
                    string[] ListItem = permission.GetListItem(SelectedNode).Split('#');
                    foreach (string a in ListItem)
                    {
                        if (a != "")
                        {
                            string[] itemInfo = a.Split(',');
                            ListViewItem listViewItem = new ListViewItem();
                            listViewItem.Text = itemInfo[0];
                            listViewItem.Tag = itemInfo[2];
                            listViewItem.ImageIndex = 1;
                            switch (itemInfo[1])
                            {
                                case "1":
                                    listView1.Items.Add(listViewItem);
                                    break;
                                case "2":
                                    listView2.Items.Add(listViewItem);
                                    break;
                                case "3":
                                    listView3.Items.Add(listViewItem);
                                    break;
                            }
                        }

                    }
                    #endregion
                    break;
            }
            


        }

        private void ListView1_ItemActivate(object sender, EventArgs e)
        {

            switch (listView1.SelectedItems[0].Text.Trim().ToUpper())
            {
                case "EXIT":
                    if (MessageBox.Show("Do you want to Exit ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                    break;
                default:
                    try
                    {
                        var form = (Form)Activator.CreateInstance(Type.GetType(listView1.SelectedItems[0].Tag.ToString().Trim()));
                        form.Show();
                        break;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error Loading Page "+ listView1.SelectedItems[0].Tag.ToString().Trim() +"\n" +ex.Message,this.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
                        break;
                    }
            }


        }


    }
}
