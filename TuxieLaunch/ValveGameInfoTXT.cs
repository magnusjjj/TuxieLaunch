using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuxieLaunch
{
    class ValveGameInfoTXT
    {
        public static void writeToGameinfo(string path, IEnumerable<string> contentMount)
        {
            List<string> stringList = new List<string>();
            stringList.Add("\"GameInfo\"");
            stringList.Add("{");
            stringList.Add("\t game \t \"customConfig\"");
            stringList.Add("\t title \t \"HAMMER4LIFE\"");
            stringList.Add("\t title2 \t \"HammerLegion\"");
            stringList.Add("\t type \t multiplayer_only");
            stringList.Add("\t nomodels \t 0");
            stringList.Add("\t nohimodel \t 1");
            stringList.Add("\t nocrosshair \t 1");
            stringList.Add("\t FileSystem");
            stringList.Add("{");
            stringList.Add("\t SteamAppId \t 4000");
            stringList.Add("\t ToolsAppId \t 211");
            stringList.Add("\t SearchPaths");
            stringList.Add("{");
            stringList.Add("\t game+mod \t customConfig/custom/*");
            stringList.Add("\t gamebin \t |gameinfo_path|bin");
            stringList.Add("\t game \t \"|all_source_engine_paths|hl2/hl2_english.vpk\"");
            stringList.Add("\t game \t \"|all_source_engine_paths|hl2/hl2_pak.vpk\"");
            stringList.Add("\t game \t \"|all_source_engine_paths|hl2/hl2_textures.vpk\"");
            stringList.Add("\t game \t \"|all_source_engine_paths|hl2/hl2_sound_vo_english.vpk\"");
            stringList.Add("\t game \t \"|all_source_engine_paths|hl2/hl2_sound_misc.vpk\"");
            stringList.Add("\t game \t \"|all_source_engine_paths|hl2/hl2_misc.vpk\"");
            if (contentMount.Contains((object)"Counter-Strike Source"))
                stringList.Add("\t game \t \"|all_source_engine_paths|../Counter-Strike Source/cstrike/cstrike_pak.vpk\"");
            if (contentMount.Contains((object)"Day of Defeat Source"))
                stringList.Add("\t game \t \"|all_source_engine_paths|../Day of Defeat Source/dod/dod_pak.vpk\"");
            if (contentMount.Contains((object)"GarrysMod"))
                stringList.Add("\t game \t \"|all_source_engine_paths|../GarrysMod/garrysmod/garrysmod.vpk\"");
            if (contentMount.Contains((object)"Half-Life 2 Deathmatch"))
                stringList.Add("\t game \t \"|all_source_engine_paths|../Half-Life 2 Deathmatch/hl2mp/hl2mp_pak.vpk\"");
            if (contentMount.Contains((object)"Half-Life 2 Episodic"))
            {
                stringList.Add("\t game \t \"|all_source_engine_paths|../Half-Life 2/episodic/ep1_pak.vpk\"");
                stringList.Add("\t game \t \"|all_source_engine_paths|episodic/ep1_english.vpk\"");
            }
            if (contentMount.Contains((object)"Half-Life 2 Episode 2"))
            {
                stringList.Add("\t game \t \"|all_source_engine_paths|../Half-Life 2/ep2/ep2_pak.vpk\"");
                stringList.Add("\t game \t \"|all_source_engine_paths|ep2/ep2_english.vpk\"");
            }
            if (contentMount.Contains((object)"Half-Life 2 Lost Coast"))
                stringList.Add("\t game \t \"|all_source_engine_paths|../Half-Life 2/lostcoast/lostcoast_pak.vpk\"");
            if (contentMount.Contains((object)"No More Room In Hell"))
                stringList.Add("\t game \t \"|all_source_engine_paths|../nmrih/nmrih\"");
            if (contentMount.Contains((object)"Portal"))
                stringList.Add("\t game \t \"|all_source_engine_paths|../Portal/portal/portal_pak.vpk\"");
            if (contentMount.Contains((object)"Source Mods"))
                stringList.Add("\t game \t \"|all_source_engine_paths|../../sourcemods/*\"");
            if (contentMount.Contains((object)"Team Fortress 2"))
            {
                stringList.Add("\t game \t \"|all_source_engine_paths|../Team Fortress 2/tf/tf2_misc.vpk\"");
                stringList.Add("\t game \t \"|all_source_engine_paths|../Team Fortress 2/tf/tf2_sound_misc.vpk\"");
                stringList.Add("\t game \t \"|all_source_engine_paths|../Team Fortress 2/tf/tf2_sound_vo_english.vpk\"");
                stringList.Add("\t game \t \"|all_source_engine_paths|../Team Fortress 2/tf/tf2_textures.vpk\"");
            }
            if (contentMount.Contains((object)"Zombie Panic Source"))
                stringList.Add("\t game \t \"|all_source_engine_paths|../Source SDK Base 2007/zps\"");
            if (contentMount.Contains((object)"EYE"))
                stringList.Add("\t game \t \"|all_source_engine_paths|../EYE/EYE\"");
            stringList.Add("\t platform \t |all_source_engine_paths|platform/platform_misc.vpk");
            stringList.Add("\t mod+mod_write+default_write_path \t \"|gameinfo_path|.\"");
            stringList.Add("\t game+game_write \t hl2mp");
            stringList.Add("\t platform \t |all_source_engine_paths|platform");
            stringList.Add("}");
            stringList.Add("}");
            stringList.Add("}");
            File.WriteAllLines(path + "/gameinfo.txt", (IEnumerable<string>)stringList);
        }
    }
}
