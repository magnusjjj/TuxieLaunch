using Microsoft.Win32;
using Newtonsoft.Json;
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
        public string SteamName = "";
        public string ProperName = "";
        public bool Installed = false;
        public string Directory = "";
        public string ModDirectory = "";
        public bool IsTool = false;
        public bool IsMappableGame = false;
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

            string gamesjson = File.ReadAllText("games.json");
            listOfSourceGames = JsonConvert.DeserializeObject<List<SourceGame>>(gamesjson);
            return listOfSourceGames;
        }

        public static string grabSteamRegistry()
        {
            string name = "Software\\Valve\\Steam";
            
            return Registry.CurrentUser.OpenSubKey(name).GetValue("SteamPath").ToString().Replace("/", "\\");
        }

        public static void findSteamDirectories()
        {
            steamStores.Add(mainSteamDir);
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
