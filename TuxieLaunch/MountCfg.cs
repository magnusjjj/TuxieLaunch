using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuxieLaunch
{
    class MountCfg
    {
        // TODO: Add actual code for this
        public static void Write(string filename, string[] directories)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"
//
// Use this file to mount additional paths to the filesystem
// DO NOT add a slash to the end of the filename
//

""mountcfg""
{" + "\r\n" +"}");
            File.WriteAllText(filename, sb.ToString(), Encoding.ASCII);
            //sb.Append("\t\""++"\"");
        }
    }
}
