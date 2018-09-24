using Microsoft.Win32;
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
using HammerHook;

// 1. Populate a 'found steam store locations' list
// 2. Populate a 'games found' list
// 3. Init the directory
// 4. 'Launch hammer'

namespace TuxieLaunch
{
    public partial class Form1 : Form
    {
        public string targetdirectory = "";

        public Form1()
        {
            InitializeComponent();
            SourceGames.Init();
            lblMainSteam.Text = "Main steam directory: " + SourceGames.mainSteamDir;
            richTextBoxAdditionalSteamDirectory.Lines = SourceGames.steamStores.ToArray();
            foreach(SourceGame g in SourceGames.games)
            {
                if (g.Installed) {
                    if(g.SteamName == "GarrysMod") {
                        targetdirectory = g.Directory + "/TuxieLauncher/";
                    }
                    contentMountListBox.Items.Add(g.ProperName + " -> " + g.Directory, CheckState.Checked);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            string warningmessage = "";
            if (!Directory.Exists(targetdirectory))
            {
                warningmessage = "Going to create the directory " + targetdirectory + ", that does not exist yet, and place the new gamemode in there. Are you sure?";
            } else
            {
                warningmessage = "Going to put the gamemode in the directory " + targetdirectory +", which already exists. This *should* mean that it's already a TuxieLauncher gamemode directory, and it will be overwritten. Are you sure?";
            }
            DialogResult dr = System.Windows.Forms.MessageBox.Show(warningmessage, "Yoloswag", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
                return;

            Directory.CreateDirectory(targetdirectory);
            ValveGameConfig.writeToGameinfo(targetdirectory, contentMountListBox.CheckedItems.Cast<string>());
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

 

        private void saveConfigBTN_Click(object sender, EventArgs e)
        {
            /*
            if (!Directory.Exists(this.grabSteamRegistry() + "/steamapps/common/Source SDK Base 2013 Multiplayer/customConfig"))
            {
                Directory.CreateDirectory(this.grabSteamRegistry() + "/steamapps/common/Source SDK Base 2013 Multiplayer/customConfig");
                Directory.CreateDirectory(this.grabSteamRegistry() + "/steamapps/common/Source SDK Base 2013 Multiplayer/customConfig/maps");
            }
            if (!Directory.Exists(this.grabSteamRegistry() + "/steamapps/common/Source SDK Base 2013 Multiplayer/customConfig/custom"))
            {
                Directory.CreateDirectory(this.grabSteamRegistry() + "/steamapps/common/Source SDK Base 2013 Multiplayer/customConfig/custom");
                File.CreateText(this.grabSteamRegistry() + "/steamapps/common/Source SDK Base 2013 Multiplayer/customConfig/custom/PUT_VPK_FILES_IN_HERE.txt");
            }
            if (!File.Exists(this.grabSteamRegistry() + "/steamapps/common/Source SDK Base 2013 Multiplayer/bin/GameConfig.txt"))
            {
                List<string> stringList = new List<string>();
                stringList.Add("\"Configs\"");
                stringList.Add("{");
                stringList.Add("\"Games\"");
                stringList.Add("{");
                stringList.Add(" ");
                stringList.Add(" ");
                stringList.Add(" ");
                stringList.Add(" ");
                stringList.Add(" ");
                stringList.Add(" ");
                stringList.Add("}");
                stringList.Add("\t\"SDKVersion\"\t\t\"5\"");
                stringList.Add("}");
                File.Create(this.grabSteamRegistry() + "/steamapps/common/Source SDK Base 2013 Multiplayer/bin/GameConfig.txt").Close();
                File.WriteAllLines(this.grabSteamRegistry() + "/steamapps/common/Source SDK Base 2013 Multiplayer/bin/GameConfig.txt", (IEnumerable<string>)stringList);
            }
            File.Create(this.grabSteamRegistry() + "/steamapps/common/Source SDK Base 2013 Multiplayer/customConfig/gameinfo.txt").Close();
            this.writeToGameinfo();
            this.writeToGameConfig();
            this.Close();*/
        }



   


        private void writeToGameConfig()
        {
            /*
            string[] strArray = File.ReadAllLines(this.grabSteamRegistry() + "/steamapps/common/Source SDK Base 2013 Multiplayer/bin/GameConfig.txt");
            int num1 = 0;
            int num2 = 0;
            bool flag = false;
            List<string> stringList = new List<string>();
            stringList.AddRange((IEnumerable<string>)strArray);
            string[] fgDfilePath = this.getFGDfilePath();
            this.getFGDfileNames();
            int count1 = this.fgdListBox.CheckedItems.Count;
            if (stringList.Contains("\t\t\"customConfig\""))
            {
                int num3 = stringList.IndexOf("\t\t\"customConfig\"");
                int num4 = num3 - 1;
                num1 = num3;
                num2 = stringList.IndexOf("\t\t}", num4 + 1);
                flag = true;
            }
            if (flag)
            {
                int num3 = 1;
                int count2 = num2 - num1 - 1;
                stringList.RemoveRange(num1 + 1, count2);
                stringList.Insert(num1 + num3, "\t \t {");
                int num4 = num3 + 1;
                stringList.Insert(num1 + num4, "\t\t\t\"GameDir\"\t\t\"" + this.grabSteamRegistry() + "\\steamapps\\common\\Source SDK Base 2013 Multiplayer\\customConfig\"");
                int num5 = num4 + 1;
                stringList.Insert(num1 + num5, "\t\t\t\"Hammer\"");
                int num6 = num5 + 1;
                stringList.Insert(num1 + num6, "\t\t\t{");
                int num7 = num6 + 1;
                int index1 = 0;
                for (int index2 = 0; index2 < count1; ++index2)
                {
                    for (int index3 = index1; !this.fgdListBox.GetItemChecked(index3) || index3 > this.fgdListBox.Items.Count + 1; ++index3)
                        ++index1;
                    stringList.Insert(num1 + num7, "\t\t\t\t \"GameData" + (object)index2 + "\" \t \"" + fgDfilePath[index1].ToString() + "\"");
                    ++index1;
                    ++num7;
                }
                stringList.Insert(num1 + num7, "\t\t\t\t \"TextureFormat\" \t \"5\"");
                int num8 = num7 + 1;
                stringList.Insert(num1 + num8, "\t\t\t\t \"MapFormat\" \t \"4\"");
                int num9 = num8 + 1;
                stringList.Insert(num1 + num9, "\t\t\t\t \"DefaultTextureScale\" \t \"0.250000\"");
                int num10 = num9 + 1;
                stringList.Insert(num1 + num10, "\t\t\t\t \"DefaultLightMapScale\" \t \"16\"");
                int num11 = num10 + 1;
                stringList.Insert(num1 + num11, "\t\t\t\t \"GameExe\" \t \" \"");
                int num12 = num11 + 1;
                stringList.Insert(num1 + num12, "\t\t\t\t \"DefaultSolidEntity\" \t \"func_detail\"");
                int num13 = num12 + 1;
                stringList.Insert(num1 + num13, "\t\t\t\t \"DefaultPointEntity\" \t \"info_player_start\"");
                int num14 = num13 + 1;
                stringList.Insert(num1 + num14, "\t\t\t\t\"BSP\" \t \"" + this.grabSteamRegistry() + "\\steamapps\\common\\Source SDK Base 2013 Multiplayer\\bin\\vbsp.exe\"");
                int num15 = num14 + 1;
                stringList.Insert(num1 + num15, "\t\t\t\t \"Vis\" \t \"" + this.grabSteamRegistry() + "\\steamapps\\common\\Source SDK Base 2013 Multiplayer\\bin\\vvis.exe\"");
                int num16 = num15 + 1;
                stringList.Insert(num1 + num16, "\t\t\t\t \"Light\" \t \"" + this.grabSteamRegistry() + "\\steamapps\\common\\Source SDK Base 2013 Multiplayer\\bin\\vrad.exe\"");
                int num17 = num16 + 1;
                stringList.Insert(num1 + num17, "\t\t\t\t \"GameExeDir\" \t \" \"");
                int num18 = num17 + 1;
                stringList.Insert(num1 + num18, "\t\t\t\t \"MapDir\" \t \"" + this.vmfLocation_TB.Text + "\"");
                int num19 = num18 + 1;
                stringList.Insert(num1 + num19, "\t\t\t\t \"BSPDir\" \t \"" + this.bspLocation_TB.Text + "\"");
                int num20 = num19 + 1;
                stringList.Insert(num1 + num20, "\t\t\t\t \"CordonTexture\" \t \"BLACK\"");
                int num21 = num20 + 1;
                stringList.Insert(num1 + num21, "\t\t\t\t \"MaterialExcludeCount\" \t \"0\"");
                int num22 = num21 + 1;
                stringList.Insert(num1 + num22, "\t\t\t}");
                int num23 = num22 + 1;
                File.WriteAllLines(this.grabSteamRegistry() + "/steamapps/common/Source SDK Base 2013 Multiplayer/bin/GameConfig.txt", (IEnumerable<string>)stringList);
            }
            else
            {
                int num3 = 1;
                int num4 = stringList.IndexOf("\t\"SDKVersion\"\t\t\"5\"") - 2;
                stringList.Insert(num4 + num3, "\t\t\"customConfig\"");
                int num5 = num3 + 1;
                stringList.Insert(num4 + num5, "\t\t{");
                int num6 = num5 + 1;
                stringList.Insert(num4 + num6, "\t\t\t\"GameDir\"\t\t\"" + this.grabSteamRegistry() + "\\steamapps\\common\\Source SDK Base 2013 Multiplayer\\customConfig\"");
                int num7 = num6 + 1;
                stringList.Insert(num4 + num7, "\t\t\t\"Hammer\"");
                int num8 = num7 + 1;
                stringList.Insert(num4 + num8, "\t\t\t{");
                int num9 = num8 + 1;
                int index1 = 0;
                for (int index2 = 0; index2 < count1; ++index2)
                {
                    for (int index3 = index1; !this.fgdListBox.GetItemChecked(index3) || index3 > this.fgdListBox.Items.Count + 1; ++index3)
                        ++index1;
                    stringList.Insert(num4 + num9, "\t\t\t\t \"GameData" + (object)index2 + "\" \t \"" + fgDfilePath[index1].ToString() + "\"");
                    ++index1;
                    ++num9;
                }
                stringList.Insert(num4 + num9, "\t\t\t\t \"TextureFormat\" \t \"5\"");
                int num10 = num9 + 1;
                stringList.Insert(num4 + num10, "\t\t\t\t \"MapFormat\" \t \"4\"");
                int num11 = num10 + 1;
                stringList.Insert(num4 + num11, "\t\t\t\t \"DefaultTextureScale\" \t \"0.250000\"");
                int num12 = num11 + 1;
                stringList.Insert(num4 + num12, "\t\t\t\t \"DefaultLightMapScale\" \t \"16\"");
                int num13 = num12 + 1;
                stringList.Insert(num4 + num13, "\t\t\t\t \"GameExe\" \t \" \"");
                int num14 = num13 + 1;
                stringList.Insert(num4 + num14, "\t\t\t\t \"DefaultSolidEntity\" \t \"func_detail\"");
                int num15 = num14 + 1;
                stringList.Insert(num4 + num15, "\t\t\t\t \"DefaultPointEntity\" \t \"info_player_start\"");
                int num16 = num15 + 1;
                stringList.Insert(num4 + num16, "\t\t\t\t\"BSP\" \t \"" + this.grabSteamRegistry() + "\\steamapps\\common\\Source SDK Base 2013 Multiplayer\\bin\\vbsp.exe\"");
                int num17 = num16 + 1;
                stringList.Insert(num4 + num17, "\t\t\t\t \"Vis\" \t \"" + this.grabSteamRegistry() + "\\steamapps\\common\\Source SDK Base 2013 Multiplayer\\bin\\vvis.exe\"");
                int num18 = num17 + 1;
                stringList.Insert(num4 + num18, "\t\t\t\t \"Light\" \t \"" + this.grabSteamRegistry() + "\\steamapps\\common\\Source SDK Base 2013 Multiplayer\\bin\\vrad.exe\"");
                int num19 = num18 + 1;
                stringList.Insert(num4 + num19, "\t\t\t\t \"GameExeDir\" \t \"  \"");
                int num20 = num19 + 1;
                stringList.Insert(num4 + num20, "\t\t\t\t \"MapDir\" \t \"" + this.vmfLocation_TB.Text + "\"");
                int num21 = num20 + 1;
                stringList.Insert(num4 + num21, "\t\t\t\t \"BSPDir\" \t \"" + this.bspLocation_TB.Text + "\"");
                int num22 = num21 + 1;
                stringList.Insert(num4 + num22, "\t\t\t\t \"CordonTexture\" \t \"BLACK\"");
                int num23 = num22 + 1;
                stringList.Insert(num4 + num23, "\t\t\t\t \"MaterialExcludeCount\" \t \"0\"");
                int num24 = num23 + 1;
                stringList.Insert(num4 + num24, "\t\t\t}");
                int num25 = num24 + 1;
                stringList.Insert(num4 + num25, "\t\t}");
                int num26 = num25 + 1;
                File.WriteAllLines(this.grabSteamRegistry() + "/steamapps/common/Source SDK Base 2013 Multiplayer/bin/GameConfig.txt", (IEnumerable<string>)stringList);
            }*/
        }

        private void btnStartHammer_Click(object sender, EventArgs e)
        {
            HammerHook.HammerHooker h = new HammerHooker();
            string[] args = new string[] {this.targetdirectory + "/../bin/hammer.exe"};
            h.Main(args);
            DialogResult dr = System.Windows.Forms.MessageBox.Show("ponies", "Yoloswag", MessageBoxButtons.OKCancel);
        }
    }
}
