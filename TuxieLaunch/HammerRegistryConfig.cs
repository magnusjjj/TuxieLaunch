using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuxieLaunch
{
    class HammerRegistryConfig
    {
        public static void Configurehammer(string targetdirectory)
        {
            using (RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"Software\Valve\HammerTuxieLauncher\Splitter"))
            {
                rk.SetValue("DrawType0,0", 5);
            }

            using (RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"Software\Valve\HammerTuxieLauncher\Run Map"))
            {
                rk.SetValue("Mode", 1);
            }

            using (RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"Software\Valve\HammerTuxieLauncher\General"))
            {
                rk.SetValue("Autosave Dir", targetdirectory+"autosave\\");
            }
        }
    }
}
