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

namespace TuxieLaunch
{
    public partial class Form1 : Form
    {
        public string targetdirectory = "";
        public string bindir = "";

        public Form1()
        {
            InitializeComponent();
            SourceGames.Init();
            lblMainSteam.Text = "Main steam directory: " + SourceGames.mainSteamDir;
            richTextBoxAdditionalSteamDirectory.Lines = SourceGames.steamStores.ToArray();
            List<string> fgdlist = new List<string>();
            foreach(SourceGame g in SourceGames.games)
            {
                if (g.Installed) {
                    if(g.SteamName == "GarrysMod") {
                        targetdirectory = g.Directory + "\\TuxieLauncher\\";
                        bindir = g.Directory+"\\bin\\";
                    }
                    contentMountListBox.Items.Add(g.ProperName + " -> " + g.Directory, CheckState.Checked);
                    fgdlist.AddRange(System.IO.Directory.GetFiles(g.Directory + "\\bin\\", "*.fgd"));
                    try { 
                        fgdlist.AddRange(System.IO.Directory.GetFiles(g.Directory + "\\garrysmod\\gamemodes\\", "*.fgd", SearchOption.AllDirectories));
                        fgdlist.AddRange(System.IO.Directory.GetFiles(g.Directory + "\\bin\\", "*.fgd"));
                    } catch(Exception e)
                    {

                    }
                }
            }

            foreach(string filename in fgdlist)
            {
                chkLbFgd.Items.Add(filename);    
            }
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
            ValveGameInfoTXT.writeToGameinfo(targetdirectory, contentMountListBox.CheckedItems.Cast<string>());
            HammerConfigTXT.Write(targetdirectory + "\\GameConfig.txt", targetdirectory + "..\\bin", targetdirectory, chkLbFgd.CheckedItems.Cast<string>());

            /*
            List<Sequence> seqlist = new List<Sequence>();

            for(int i = 0; i < 10; i++)
            { 
                Sequence hs = new Sequence();
                hs.name = "Sequence number " + i;
                for(int j = 0; j < 10; j++)
                {
                    Command c = new Command();
                    c.args = "Args";
                    c.ensure_check = true;
                    c.ensure_file = "Ensure file";
                    c.executable = "executable";
                    c.is_enabled = true;
                    c.is_long_filename = true;
                    c.no_wait = true;
                    c.special = CommandSpecial.None;
                    c.use_proc_win = false;
                    hs.commands.Add(c);
                }
                seqlist.Add(hs);
            }*/


            //JsonConvert.DefaultSettings.
            //File.WriteAllText("hammersequencetest.txt", JsonConvert.SerializeObject(seqlist, Formatting.Indented,), Encoding.UTF8);



            string hammersequencejson = File.ReadAllText("hammersequencetemplate.json");
            List<Sequence> hammersequencetemplate_deserialized = JsonConvert.DeserializeObject<List<Sequence>>(hammersequencejson);
            HammerSequence hsq = new HammerSequence();

            hsq.Write(targetdirectory + "\\CmdSeq.wc", hammersequencetemplate_deserialized);

            // TODO: Add actual code for this
            Directory.CreateDirectory(targetdirectory + "\\cfg\\");
            MountCfg.Write(targetdirectory + "\\cfg\\mount.cfg", new string[0]);

            /*using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    if (files.Length > 0) {
                        DialogResult dr = System.Windows.Forms.MessageBox.Show("Directory not empty! Are you sure?", "Yoloswag", MessageBoxButtons.OKCancel);
                        if(dr == DialogResult.Cancel)
                            return;
                        //"Files found: " + files.Length.ToString(), "Message");
                    }

                    ValveGameConfig.writeToGameinfo(fbd.SelectedPath, contentMountListBox.CheckedItems.Cast<string>());

                }
            }*/
        }

        private void btnStartHammer_Click(object sender, EventArgs e)
        {
            string exepath = Path.GetDirectoryName(Application.ExecutablePath);
            var startInfo = new ProcessStartInfo();
            startInfo.FileName = exepath + "/withdll.exe";
            startInfo.Arguments = "/d:\""+exepath+"/DetourDLL.dll\" " + targetdirectory + "../bin/hammer.exe";
            startInfo.WorkingDirectory = targetdirectory + "../bin/";
            string withdllpath = exepath + "/withdll.exe";
            string args = " /d:DetourDLL.dll /s:\"" + bindir + "\" " + bindir + "/hammer.exe";

            Process.Start(withdllpath, args);
            
        }

        private void richTextBoxAdditionalSteamDirectory_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
