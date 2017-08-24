using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmnesiaDashboard
{
    public partial class MainWindow : Form
    {
        string[] _customPaths = { "", "" };
        string _gamePath = Properties.Settings.Default.GamePath;
        string _levelEditorPath = Properties.Settings.Default.LevelEditorPath;
        string _mapViewerPath = Properties.Settings.Default.MapViewerPath;
        string _particleEditorPath = Properties.Settings.Default.ParticleEditorPath;
        string _materialEditorPath = Properties.Settings.Default.MaterialEditorPath;
        string _modelEditorPath = Properties.Settings.Default.ModelEditorPath;
        string _modelViewerPath = Properties.Settings.Default.ModelViewerPath;
        string _gameExe = Properties.Settings.Default.GameExe;
        string _levelEditorExe = Properties.Settings.Default.LevelEditorExe;
        string _mapViewerExe = Properties.Settings.Default.MapViewerExe;
        string _particleEditorExe = Properties.Settings.Default.ParticleEditorExe;
        string _materialEditorExe = Properties.Settings.Default.MaterialEditorExe;
        string _modelEditorExe = Properties.Settings.Default.ModelEditorExe;
        string _modelViewerExe = Properties.Settings.Default.ModelViewerExe;
        string _redist = Properties.Settings.Default.RedistPath;
        string _appPath = Application.StartupPath;
                
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("[DEBUG] : Checking if FirstRun = true.");
            if (Properties.Settings.Default.FirstRun)
            {
                System.Diagnostics.Debug.WriteLine("[DEBUG] : FirstRun = true, running dialog.");
                MessageBox.Show("I see this is your first time running the Amnesia Dashboard. There will be a dialog box open up which you will need to use to locate your Amnesia's 'redist' folder.", "First Time Run");
                dlgFolderHandler();
            }
        }

        private void dlgFolderHandler()
        {
            System.Diagnostics.Debug.WriteLine("[DEBUG] : Opening dialog...");
            dlgFolder.ShowDialog();
            if (dlgFolder.SelectedPath != "")
            {
                System.Diagnostics.Debug.WriteLine("[DEBUG] : Dialog open. Checking if selected path is blank...");
                _redist = dlgFolder.SelectedPath;
                Environment.CurrentDirectory = _redist;
                if (File.Exists("Amnesia.exe"))
                {
                    System.Diagnostics.Debug.WriteLine("[DEBUG] : Checking if 'Amnesia.exe' exists...");
                    if (File.Exists("LevelEditor.Exe") && File.Exists("LevelEditor.Exe") && File.Exists("MapView.Exe") && File.Exists("MaterialEditor.Exe") && File.Exists("ModelEditor.Exe") && File.Exists("ModelView.Exe") && File.Exists("ParticleEditor.Exe"))
                    {
                        _levelEditorPath = Path.Combine(_redist, "LevelEditor.exe");
                        _mapViewerPath = Path.Combine(_redist, "MapView.exe");
                        _materialEditorPath = Path.Combine(_redist, "MaterialEditor.exe");
                        _modelEditorPath = Path.Combine(_redist, "ModelEditor.exe");
                        _modelViewerPath = Path.Combine(_redist, "ModelViewer.exe");
                        _particleEditorPath = Path.Combine(_redist, "ParticleEditor.exe");

                        _gameExe = "Amnesia.exe";
                        _levelEditorExe = "LevelEditor.exe";
                        _mapViewerExe = "MapView";
                        _materialEditorExe = "MaterialEditor";
                        _modelEditorExe = "ModelEditor";
                        _modelViewerExe = "ModelView";
                        _particleEditorExe = "ParticleEditor";

                        PathHandler pathHandler = new PathHandler();
                        pathHandler.UpdatePaths(_redist, _gamePath, _levelEditorPath, _mapViewerPath, _materialEditorPath, _modelEditorPath, _modelViewerPath, _particleEditorPath);
                        pathHandler.UpdateExe(_gameExe, _levelEditorExe, _mapViewerExe, _materialEditorExe, _modelEditorExe, _modelViewerExe, _particleEditorExe);
                    }
                }
                else
                {
                    MessageBox.Show("Unable to locate Amnesia executable in the folder selected." + Environment.NewLine + "Please make sure you are selecting the 'redist' folder.", "Error:", MessageBoxButtons.OK);
                    dlgFolder.Reset();
                    dlgFolderHandler();
                }
             }
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            dlgFolderHandler();
        }

        private void tmrButtons_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.GamePath != "")
            {
                btnGame.Enabled = true;
                GameToolStripMenuItem.Enabled = true;
            }

            if (Properties.Settings.Default.LevelEditorPath != "")
            {
                btnLevelEdit.Enabled = true;
                LevelEditorToolStripMenuItem.Enabled = true;
            }

            if (Properties.Settings.Default.MapViewerPath != "")
            {
                btnMapView.Enabled = true;
                MapViewerToolStripMenuItem.Enabled = true;
            }

            if (Properties.Settings.Default.MaterialEditorPath != "")
            {
                btnMaterialEdit.Enabled = true;
                MaterialEditorToolStripMenuItem.Enabled = true;
            }

            if (Properties.Settings.Default.ModelEditorPath != "")
            {
                btnModelEdit.Enabled = true;
                ModelEditorToolStripMenuItem.Enabled = true;
            }

            if (Properties.Settings.Default.ModelViewerPath != "")
            {
                btnModelView.Enabled = true;
                ModelViewerToolStripMenuItem.Enabled = true;
            }

            if (Properties.Settings.Default.ParticleEditorPath != "")
            {
                btnParticleEdit.Enabled = true;
                ParticleEditorToolStripMenuItem.Enabled = true;
            }


        }

        private void mainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control)
            {
                MessageBox.Show("Yay");
            }
        }

        private void AboutStripMenuItem7_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ResetAmnesiaToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are about to reset all of your Amnesia paths." + Environment.NewLine + Environment.NewLine + "Are you sure you want to do this?", "Are you sure?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Properties.Settings.Default.Reset();
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }
        }

        private void btnGame_Click(object sender, EventArgs e)
        {
            PathHandler pathHandler = new PathHandler();
            pathHandler.LaunchExe(_gameExe);
        }

        

        private void btnLevelEdit_Click(object sender, EventArgs e)
        {
            PathHandler pathHandler = new PathHandler();
            pathHandler.LaunchExe(_levelEditorExe);
        }

        private void btnMapView_Click(object sender, EventArgs e)
        {
            PathHandler pathHandler = new PathHandler();
            pathHandler.LaunchExe(_mapViewerExe);
        }

        private void btnParticleEdit_Click(object sender, EventArgs e)
        {
            PathHandler pathHandler = new PathHandler();
            pathHandler.LaunchExe(_particleEditorExe);
        }

        private void btnMaterialEdit_Click(object sender, EventArgs e)
        {
            PathHandler pathHandler = new PathHandler();
            pathHandler.LaunchExe(_materialEditorExe);
        }

        private void btnModelEdit_Click(object sender, EventArgs e)
        {
            PathHandler pathHandler = new PathHandler();
            pathHandler.LaunchExe(_modelEditorExe);
        }

        private void btnModelView_Click(object sender, EventArgs e)
        {
            PathHandler pathHandler = new PathHandler();
            pathHandler.LaunchExe(_modelViewerExe);
        }

        private void changeLevelEditorSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Opening level editor options.");
            LEditOptions settings = new LEditOptions();
            settings.ShowDialog();
        }

        private void tmrMapView_Tick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetProcessesByName("MapView.exe");
            //if ()
            //{

            //}
        }
    }
}
