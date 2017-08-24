using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmnesiaDashboard
{
    public partial class LEditOptions : Form
    {
        int height = Properties.Settings.Default.LEditH;
        int width = Properties.Settings.Default.LEditW;
        bool IsCustom = Properties.Settings.Default.LEditCustom;
        public LEditOptions()
        {
            System.Diagnostics.Debug.WriteLine("[DEBUG] : Local 'height' variable set to: " + height);
            System.Diagnostics.Debug.WriteLine("[DEBUG] : Local 'width' variable set to: " + width);
            InitializeComponent();

            if (!Properties.Settings.Default.LEditSettings)
            {
                System.Diagnostics.Debug.WriteLine("[DEBUG] : LEditSettigs = false.");
                grpSettings.Enabled = false;
                chkEnabled.Checked = false;
            }
            else 
            {
                System.Diagnostics.Debug.WriteLine("[DEBUG] : LEditSettings = true");
                grpSettings.Enabled = true;
                chkEnabled.Checked = true;
            }

            if (IsCustom)
            {
                ChangeCustom(true);
            }
            else
            {
                ChangeCustom(false);
            }

            System.Diagnostics.Debug.WriteLine("[DEBUG] : Setting custom textboxes to saved HxW parameters");
            txtWidth.Text = Convert.ToString(Properties.Settings.Default.LEditW);
            txtHeight.Text = Convert.ToString(Properties.Settings.Default.LEditH);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRes.SelectedIndex.Equals(0))
            {
                System.Diagnostics.Debug.WriteLine("[DEBUG] : 800x600 selected.");
                width = 800;
                height = 600;
            }
            else if(cmbRes.SelectedIndex.Equals(1))
            {
                System.Diagnostics.Debug.WriteLine("[DEBUG] : 1024x768 selected.");
                width = 1024;
                height = 768;
            }
            else if(cmbRes.SelectedIndex.Equals(2))
            {
                System.Diagnostics.Debug.WriteLine("[DEBUG] : 1280x1024 selected.");
                width = 1280;
                height = 1024;
            }
            else if(cmbRes.SelectedIndex.Equals(3))
            {
                System.Diagnostics.Debug.WriteLine("[DEBUG] : 1600x1200 selected.");
                width = 1600;
                height = 1200;
            }
            else if(cmbRes.SelectedIndex.Equals(4))
            {
                System.Diagnostics.Debug.WriteLine("[DEBUG] : 1920x1080 selected.");
                width = 1920;
                height = 1080;
            }
        }

        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnabled.Checked)
            {
                Properties.Settings.Default.LEditSettings = true;
                grpSettings.Enabled = true;
                System.Diagnostics.Debug.WriteLine("[DEBUG] : LEditSettings property: " + Properties.Settings.Default.LEditSettings);
            }
            else
            {
                Properties.Settings.Default.LEditSettings = false;
                grpSettings.Enabled = false;
                System.Diagnostics.Debug.WriteLine("[DEBUG] : LEditSettings property: " + Properties.Settings.Default.LEditSettings);
            }
           
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("[DEBUG] : APPLY clicked.");
            ApplySettings(false);
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("[DEBUG] : APPLY & LAUNCH clicked.");
            ApplySettings(true);
            System.Diagnostics.Debug.WriteLine("[DEBUG] : Launching 'LevelEdit.exe'...");
            PathHandler pathHandler = new PathHandler();
            pathHandler.LaunchExe(Properties.Settings.Default.LevelEditorExe);
        }

        private void ApplySettings(bool IsLaunch)
        {
            if (IsCustom)
            {
                width = Convert.ToInt32(txtWidth.Text);
                height = Convert.ToInt32(txtHeight);
            }

            //System.Diagnostics.Debug.WriteLine("[DEBUG] : width = " + width);
            //System.Diagnostics.Debug.WriteLine("[DEBUG] : height = " + height);
            //Properties.Settings.Default.LEditW = width;
            //Properties.Settings.Default.LEditH = height;
        }

        private void ChangeCustom(bool _IsCustom)
        {
            if (_IsCustom)
            {
                System.Diagnostics.Debug.WriteLine("[DEBUG] : Custom settings: ENABLED.");
                cmbRes.Enabled = false;
                lblW.Enabled = true;
                lblH.Enabled = true;
                txtHeight.Enabled = true;
                txtWidth.Enabled = true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("[DEBUG] : Custom settings: DISABLED.");
                cmbRes.Enabled = true;
                lblW.Enabled = false;
                lblH.Enabled = false;
                txtHeight.Enabled = false;
                txtWidth.Enabled = false;
            }
        }

        private void chkCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCustom.Checked)
            {
                ChangeCustom(true);
            }
            else
            {
                ChangeCustom(false);
            }
        }
    }
}
