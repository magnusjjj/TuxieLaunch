using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuxieLaunch
{
    public class Settings
    {
        public string gamedir = "";
        public string tooldir = "";
        public SourceGame origgame = new SourceGame();

        public static Settings Load(string filename)
        {
            try { 
                string jsoncontents = File.ReadAllText(filename, Encoding.UTF8);
                return JsonConvert.DeserializeObject<Settings>(jsoncontents);
            } catch(Exception e)
            {
                return new Settings();
            }
        }

        public void Save(string filename)
        {
            string jsoncontents = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(filename, jsoncontents, Encoding.UTF8);
        }
    }
}
