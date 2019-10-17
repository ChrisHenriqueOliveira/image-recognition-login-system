﻿using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewButtonExample
{
    public partial class formEditRegister : MaterialSkin.Controls.MaterialForm
    {
        public formEditRegister()
        {
            InitializeComponent();

            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE
                );
        }

        public void editRegister(string user, string access)
        {
            lblUserCode.Text = user.Substring(0,user.Length-1);
            lblOldAccess.Text = access;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbNewAccess.Items.Contains(cbNewAccess.Text))
            {
                string OldName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\apsImage\\" + lblUserCode.Text + lblOldAccess.Text + ".png";
                string NewName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\apsImage\\" + lblUserCode.Text + cbNewAccess.SelectedItem + ".png";
                System.IO.File.Move(OldName, NewName);
                pnlEdited.Visible = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
