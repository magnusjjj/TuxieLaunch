﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuxieLaunch
{
    class HammerConfigTXT
    {
        public static void Write(string filename, string tuxielauncher_bin_dir, string tuxielauncher_game_dir, IEnumerable<string> fgdlocations)
        {
            FileStream filein = File.Open("HammerConfigTXTTemplate.txt", FileMode.Open);
            byte[] buffer = new byte[filein.Length];
            filein.Read(buffer, 0, (int)filein.Length);
            filein.Close();
            string template = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            template = template.Replace("TUXIELAUNCHER_BIN_DIR", tuxielauncher_bin_dir);
            template = template.Replace("TUXIELAUNCHER_GAME_DIR", tuxielauncher_game_dir.Substring(0,tuxielauncher_game_dir.Length-1));
            StringBuilder sb = new StringBuilder();
            int fgdnumber = 0;
            foreach (string item in fgdlocations)
            {
                // Possible todo, check for escaping.
                sb.Append("\t\t\t\t\"GameData"+fgdnumber+"\"\t\t\""+item+"\"\r\n");
                fgdnumber++;
            }
            template = template.Replace("TUXIELAUNCHER_GAMEDATA_LIST", sb.ToString());
            FileStream fileout = File.Open(filename, FileMode.Create);
            byte[] bufferout = Encoding.UTF8.GetBytes(template);
            fileout.Write(bufferout,0,bufferout.Length);
            fileout.Close();
        }
        
        /*
        public void write()
        {
            string template = @"
"Configs"
{
                "Games"

    {
                    "Garry's Mod"

        {
                        "GameDir"       "C:\Program Files (x86)\Steam\steamapps\common\GarrysMod\garrysmod"

            "Hammer"

            {
                            "GameData0"     "C:\Program Files (x86)\Steam\steamapps\common\GarrysMod\bin\garrysmod.fgd"

                "TextureFormat"     "5"

                "MapFormat"     "4"

                "DefaultTextureScale"       "0.250000"

                "DefaultLightmapScale"      "16"

                "GameExe"       "C:\Program Files (x86)\Steam\steamapps\common\GarrysMod\hl2.exe"

                "DefaultSolidEntity"        "func_detail"

                "DefaultPointEntity"        "info_player_start"

                "BSP"       "C:\Program Files (x86)\Steam\steamapps\common\GarrysMod\bin\vbsp.exe"

                "Vis"       "C:\Program Files (x86)\Steam\steamapps\common\GarrysMod\bin\vvis.exe"

                "Light"     "C:\Program Files (x86)\Steam\steamapps\common\GarrysMod\bin\vrad.exe"

                "GameExeDir"        "C:\Program Files (x86)\Steam\steamapps\common\GarrysMod"

                "MapDir"        "C:\Program Files (x86)\Steam\steamapps\common\GarrysMod\content\garrysmod\mapsrc"

                "BSPDir"        "C:\Program Files (x86)\Steam\steamapps\common\GarrysMod\garrysmod\maps"

                "CordonTexture"     "tools\toolsskybox"

                "MaterialExcludeCount"      "0"

            }
                    }
                }
                "SDKVersion"        "5"
}

            ";
        }*/
    }
}
