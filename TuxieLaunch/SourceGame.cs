using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuxieLaunch
{
    public class SourceGame
    {
        public string SteamName { get; set; }
        public string ProperName { get; set; }
        public bool Installed { get; set; }
        public string Directory { get; set; }
    }

    public class SourceGames
    {
        public static string mainSteamDir;
        public static List<string>steamStores = new List<string>();
        public static List<SourceGame> games = new List<SourceGame>();



        public static void Init()
        {
            mainSteamDir = grabSteamRegistry();
            findSteamDirectories();
            games = getGamesList();
        }

        public static List<SourceGame> getGamesList()
        {
            List<SourceGame> listOfSourceGames = SourceGames.GetUnprocessedGamesList();
            listOfSourceGames = SourceGames.checkGamesInstalled(listOfSourceGames);
            return listOfSourceGames;
        }

        public static List<SourceGame> GetUnprocessedGamesList()
        {
            List<SourceGame> listOfSourceGames = new List<SourceGame>();

            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Contagion",
                ProperName = "Contagion",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Counter-Strike Global Offensive",
                ProperName = "Counter-Strike Global Offensive",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Counter-Strike Source",
                ProperName = "Counter-Strike Source",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Day of Defeat Source",
                ProperName = "Day of Defeat Source",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "dayofinfamy",
                ProperName = "Day of Infamy",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "GarrysMod",
                ProperName = "Garrys Mod",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Half-Life 2",
                ProperName = "Half-Life 2",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "insurgency2",
                ProperName = "Insurgency",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "insurgency2",
                ProperName = "Insurgency",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Left 4 Dead 2",
                ProperName = "Left 4 Dead 2",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "nmrih",
                ProperName = "No More Room In Hell",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Portal",
                ProperName = "Portal",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Portal 2",
                ProperName = "Portal 2",
                Installed = false,
                Directory = ""
            });
            listOfSourceGames.Add(new SourceGame
            {
                SteamName = "Team Fortress 2",
                ProperName = "Team Fortress 2",
                Installed = false,
                Directory = ""
            });

            return listOfSourceGames;
        }

        public static string grabSteamRegistry()
        {
            string name = "Software\\Valve\\Steam";
            return Registry.CurrentUser.OpenSubKey(name).GetValue("SteamPath").ToString().Replace("/", "\\");
        }

        public static void findSteamDirectories()
        {
            if (File.Exists(mainSteamDir + "/steamapps/libraryfolders.vdf"))
            {
                string[] lines = File.ReadAllLines(mainSteamDir + "/steamapps/libraryfolders.vdf");
                if (lines.Count() != 5)
                {
                    //This means we have multiple directories
                    steamStores.Clear();
                    steamStores.Add(mainSteamDir);
                    int numberOfDirectories = lines.Count() - 5;
                    for (int i = 4; i < lines.Count() - 1; i++)    //start at line 5 and go to closing bracket
                    {
                        string temp = lines[i];
                        int finalPosition = temp.LastIndexOf("\"");
                        int startPosition = temp.LastIndexOf("\"", finalPosition - 1) + 1;    //Dont grab the same position or starting quote
                        temp = temp.Substring(startPosition, (finalPosition - startPosition)).Replace("\\\\", "\\");
                        steamStores.Add(temp);
                    }
                    
                }
            }
            //checkGamesInstalled();
        }

        public static List<SourceGame> checkGamesInstalled(List<SourceGame> theinput)
        {
            // Cycle through all directories and store games we have and their locations
            foreach (string dir in steamStores)
            {
                foreach (SourceGame game in theinput)
                {
                    if (Directory.Exists(dir + "\\steamapps\\common\\" + game.SteamName))
                    {
                        game.Directory = dir + "\\steamapps\\common\\" + game.SteamName;
                        game.Installed = true;
                    }
                }
            }
            return theinput;
// updateDebugInfo();
        }

    }
}
