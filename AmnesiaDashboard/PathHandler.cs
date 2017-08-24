using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmnesiaDashboard
{
    public class PathHandler
    {
        public void UpdatePaths(string redist, string GamePath, string LevelEditorPath, string MapViewPath, string MaterialEditorPath,string ModelEditorPath, string ModelViewerPath, string ParticleEditorPath)
        {
            Properties.Settings.Default.RedistPath = redist;
            Properties.Settings.Default.GamePath = GamePath;
            Properties.Settings.Default.LevelEditorPath = LevelEditorPath;
            Properties.Settings.Default.MapViewerPath = MapViewPath;
            Properties.Settings.Default.MaterialEditorPath = MaterialEditorPath;
            Properties.Settings.Default.ModelEditorPath = ModelEditorPath;
            Properties.Settings.Default.ModelViewerPath = ModelViewerPath;
            Properties.Settings.Default.ParticleEditorPath = ParticleEditorPath;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
        }

        public void UpdateExe(string GameExe, string LevelEditorExe, string MapViewExe, string MaterialEditorExe, string ModelEditorExe, string ModelViewerExe, string ParticleEditorExe)
        {
            Properties.Settings.Default.GamePath = GameExe;
            Properties.Settings.Default.LevelEditorPath = LevelEditorExe;
            Properties.Settings.Default.MapViewerPath = MapViewExe;
            Properties.Settings.Default.MaterialEditorPath = MaterialEditorExe;
            Properties.Settings.Default.ModelEditorPath = ModelEditorExe;
            Properties.Settings.Default.ModelViewerPath = ModelViewerExe;
            Properties.Settings.Default.ParticleEditorPath = ParticleEditorExe;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
        }

        public void LaunchExe(string exe)
        {
            Environment.CurrentDirectory = Properties.Settings.Default.RedistPath;
            System.Diagnostics.Process.Start(exe);
        }
    }
}
