using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Threading;

namespace TuxieLaunch
{
    public partial class TuxieLauncher : Form
    {
        SynchronizationContext _syncContext;

        public string targetdirectory = "";
        public string bindir = "";
        public string configname = "settings.json";

        public Settings settings;

        public TuxieLauncher()
        {
            
            InitializeComponent();
            _syncContext = SynchronizationContext.Current;
            // Loads the settings. The config name = the path it will look for the config in.
            settings = Settings.Load(configname);
            updateorigdirectory();
            updatebindir();

            // Find a list of all the games and steam directories
            SourceGames.Init();

            // Put some debug info in some boxes
            lblMainSteam.Text = "Main steam directory: " + SourceGames.mainSteamDir;
            lblSteamDirs.Text = "Steam stores detected: \n"+string.Join("\n", SourceGames.steamStores);

            // It's time to look through the list of games, to:
            // - Add them to the list of games you can mount the content off
            // - Find the correct directory of the tools.
            // - Find all the possible entity definitions (.fgd's), and stuff them into a list.
            // TODO: Move the directory portion into a seperate function
            // TODO: Warn about using gmod tools, and kick up a link to install source sdk
            // TODO: Refactor away the code for selecting the target directory
            List<string> fgdlist = new List<string>();

            foreach(SourceGame g in SourceGames.games)
            {
                // We only want to add the games that are actually, you know, installed.
                if (g.Installed) {
                    // Add the games to the list of games you can mod for, and use tools from
                    // Here, we check if we have already saved what tools/games to use, and if so select them in the drop down boxes

                    if (g.IsMappableGame) { 
                        int tempgameid = ddGameToModFor.Items.Add(g.Directory);
                        if (g.Directory == settings.gamedir)
                        {
                            ddGameToModFor.SelectedIndex = tempgameid;
                            settings.origgame = g;
                        }
                    }

                    if (g.IsTool)
                    {
                        int temptoolid = ddTools.Items.Add(g.Directory);
                        if (g.Directory == settings.tooldir)
                        {
                            ddTools.SelectedIndex = temptoolid;
                        }
                    }


                    // Add the list of content we can mount..
                    contentMountListBox.Items.Add(g.ProperName + " -> " + g.Directory, CheckState.Checked);

                    // And finally, add all the FGD's (entity definitions) we can find :).
                    try {
                        fgdlist.AddRange(System.IO.Directory.GetFiles(g.Directory + "\\bin\\", "*.fgd"));
                        fgdlist.AddRange(System.IO.Directory.GetFiles(g.Directory + "\\garrysmod\\gamemodes\\", "*.fgd", SearchOption.AllDirectories));
                    } catch(Exception e)
                    {

                    }
                }
            }

            // Oh, and, this section here deals with checking off those fgd's that are already saved from the last time. Should probably move this.

            string gameconfigcontents = "";
            try { 
                 gameconfigcontents = File.ReadAllText(targetdirectory+"\\gameconfig.txt", Encoding.ASCII);
            } catch(Exception e)
            {

            }

            foreach (string filename in fgdlist)
            {
                chkLbFgd.Items.Add(filename, gameconfigcontents.Contains(filename));    
            }
        }

        private void updateorigdirectory()
        {
            foreach (SourceGame g in SourceGames.games)
            {
                // We only want to add the games that are actually, you know, installed.
                if (g.Installed)
                {
                    // Here, we check if we have already saved what tools/games to use, and if so select them in the drop down boxes
                    if (g.Directory == settings.gamedir)
                    {
                        settings.origgame = g;
                    }
                }
            }

            if (Directory.Exists(targetdirectory))
            {
                lblNotConfigured.Visible = false;
                btnStartHammer.Enabled = true;
                btnOpenFolder.Enabled = true;
            } else
            {
                lblNotConfigured.Visible = true;
                btnStartHammer.Enabled = false;
                btnOpenFolder.Enabled = false;
            }


            
        }

        private void updatevalidation()
        {
            if (settings.gamedir.Length > 0)
            {
                ddGameToModFor.BackColor = Color.LightGreen;
            }
            else
            {
                ddGameToModFor.BackColor = Color.LightSalmon;
            }

            if (settings.gamedir.Length > 0)
            {
                ddTools.BackColor = Color.LightGreen;
            }
            else
            {
                ddTools.BackColor = Color.LightSalmon;
            }

            if(ddTools.BackColor == Color.LightGreen && ddGameToModFor.BackColor == Color.LightGreen)
            {
                btnGamemodeCreate.Enabled = true;
            } else
            {
                btnGamemodeCreate.Enabled = false;
            }
        }

        private void updatebindir()
        {
            bindir = settings.tooldir + "\\bin\\";
            targetdirectory = settings.tooldir + "\\TuxieLauncher\\";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string warningmessage = "";
            if (!Directory.Exists(targetdirectory))
            {
                warningmessage = "Going to create the directory " + targetdirectory + ", that does not exist yet, and place the new gamemode in there. Are you sure?";
            }
            else
            {
                warningmessage = "Going to put the gamemode in the directory " + targetdirectory + ", which already exists. This *should* mean that it's already a TuxieLauncher gamemode directory, and it will be overwritten. Are you sure?";
            }
            DialogResult dr = System.Windows.Forms.MessageBox.Show(warningmessage, "Yoloswag", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
                return;

            Directory.CreateDirectory(targetdirectory);
            Directory.CreateDirectory(targetdirectory+"\\materials\\");
            Directory.CreateDirectory(targetdirectory + "\\autosave\\");
            Directory.CreateDirectory(targetdirectory + "\\vmfdir\\");

            // Copied from https://stackoverflow.com/questions/58744/copy-the-entire-contents-of-a-directory-in-c-sharp . Shutup, tired, ok?

            string source_dir = Path.GetDirectoryName(Application.ExecutablePath)+"\\samplecontent\\";
            string destination_dir = targetdirectory;

            // substring is to remove destination_dir absolute path (E:\).

            // Create subdirectory structure in destination    
            foreach (string dir in System.IO.Directory.GetDirectories(source_dir, "*", System.IO.SearchOption.AllDirectories))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(destination_dir, dir));
                // Example:
                //     > C:\sources (and not C:\E:\sources)
            }

            foreach (string file_name in System.IO.Directory.GetFiles(source_dir, "*", System.IO.SearchOption.AllDirectories))
            {
                try
                {
                    System.IO.File.Copy(file_name, System.IO.Path.Combine(destination_dir, file_name.Substring(source_dir.Length)));
                } catch
                {

                }
                
            }


            ValveGameInfoTXT.writeToGameinfo(targetdirectory, contentMountListBox.CheckedItems.Cast<string>());
            HammerConfigTXT.Write(targetdirectory+ "\\GameConfig.txt", targetdirectory, settings, chkLbFgd.CheckedItems.Cast<string>());

            string hammersequencejson = File.ReadAllText("hammersequencetemplate.json");
            List<Sequence> hammersequencetemplate_deserialized = JsonConvert.DeserializeObject<List<Sequence>>(hammersequencejson);
            Dictionary<string, string> hammersequencevariables = new Dictionary<string, string>();
            hammersequencevariables["$tuxielauncher_origgamedir"] = "\""+settings.origgame.Directory + "\\" + settings.origgame.ModDirectory+"\"";
            hammersequencevariables["$tuxielauncher_dependency_resolver"] = Path.GetDirectoryName(Application.ExecutablePath) + "\\PythonResolver\\resolver.bat";
            HammerSequence hsq = new HammerSequence();


            hsq.Write(targetdirectory + "\\CmdSeq.wc", hammersequencetemplate_deserialized, hammersequencevariables);

            // TODO: Add actual code for this
            Directory.CreateDirectory(targetdirectory + "\\cfg\\");
            MountCfg.Write(targetdirectory + "\\cfg\\mount.cfg", new string[0]);

            updateorigdirectory();

            HammerRegistryConfig.Configurehammer(targetdirectory);

            System.Windows.Forms.MessageBox.Show("Success! :D");
        }

        private void btnStartHammer_Click(object snd, EventArgs e)
        {
            string exepath = Path.GetDirectoryName(Application.ExecutablePath);
            Process hammerprocess = new Process();
            hammerprocess.StartInfo.FileName = exepath + "\\withdll.exe";
            string overlaydir = Directory.GetCurrentDirectory() + "\\overlay\\";
            string filetest = "overlay/bin/hammer.exe";

            hammerprocess.StartInfo.Environment.Add("TUXIELAUNCHER_OVERLAY_DIRECTORY", overlaydir);
            hammerprocess.StartInfo.Environment.Add("TUXIELAUNCHER_SDK_DIRECTORY", settings.tooldir);
            hammerprocess.StartInfo.Environment["PATH"] += ";" + Directory.GetCurrentDirectory() + ";" + overlaydir + "\\bin\\";
            debugtext("Overlay directory is at: " + overlaydir);
            debugtext("SDK directory is at: " + settings.tooldir);

            if (File.Exists(filetest)){
                var enviromentPath = System.Environment.GetEnvironmentVariable("PATH");
                
                hammerprocess.StartInfo.Arguments = "--dll=\"liar.dll\" --exe=\"" + filetest + "\" --workdir=\"" + bindir.TrimEnd('\\') + "\"";
                debugtext("Found overlay hammer");
                debugtext("Current directory: " + Directory.GetCurrentDirectory());
                debugtext("Starting with path: " + hammerprocess.StartInfo.Environment["PATH"]);

            } else
            {
                hammerprocess.StartInfo.Arguments = "--dll=\"liar.dll\" --exe=\"" + bindir + "hammer.exe\" --workdir=\"" + bindir.TrimEnd('\\') + "\"";
            }
            hammerprocess.StartInfo.Environment.Add("VProject", targetdirectory.TrimEnd('\\'));
            hammerprocess.StartInfo.UseShellExecute = false;
            hammerprocess.StartInfo.RedirectStandardOutput = true;
            hammerprocess.StartInfo.RedirectStandardInput = true;
            hammerprocess.StartInfo.RedirectStandardError = true;
            hammerprocess.StartInfo.CreateNoWindow = true;
            hammerprocess.OutputDataReceived += (sender, args) => debugtext(args.Data);
            hammerprocess.ErrorDataReceived += (sender, args) => debugtext(args.Data);
            txtDebug.Text += hammerprocess.StartInfo.FileName + " " + hammerprocess.StartInfo.Arguments + "\r\n";
            hammerprocess.Start();
            hammerprocess.BeginOutputReadLine();
            hammerprocess.BeginErrorReadLine();
        }

        void debugtext(string data)
        {
            _syncContext.Post(_ => txtDebug.AppendText(data+"\r\n"), null);
        }

        private void richTextBoxAdditionalSteamDirectory_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            Process.Start(targetdirectory);
        }

        private void loadSettings()
        {
            string hammersequencejson = File.ReadAllText("hammersequencetemplate.json");
            List<Sequence> hammersequencetemplate_deserialized = JsonConvert.DeserializeObject<List<Sequence>>(hammersequencejson);
        }

        private void selectedgametomodforchanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            settings.gamedir = (string)comboBox.SelectedItem;
            settings.Save(configname);
            updateorigdirectory();
            updatevalidation();
        }

        private void selectedtoolstousechanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            settings.tooldir = (string)comboBox.SelectedItem;
            settings.Save(configname);
            updatebindir();
            updatevalidation();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutForm abouty = new AboutForm();
            abouty.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
