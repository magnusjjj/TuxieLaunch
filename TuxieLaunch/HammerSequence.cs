using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TuxieLaunch
{
    public class SequenceHeader
    {
        /*
        struct Header
        {
	        char signature[31];  // Worldcraft Command Sequences\r\n\x1a
	        float version;
	        unsigned int seq_count;
	        Sequence sequences[];
        }
        */
        byte[] _signature;

        byte[] signature
        {
            set
            {
                Array.Resize(ref value, 31);
                _signature = value;
            }
            get
            {
                return _signature;
            }
        }
        float version;
        public List<Sequence> sequences;

        public SequenceHeader() {
            signature = Encoding.ASCII.GetBytes("Worldcraft Command Sequences\r\n\x1a");
            version = 0.2F;
        }

        public void Write(BinaryWriter w)
        {
            w.Write(signature);
            w.Write(version);
            w.Write((UInt32)sequences.Count);
            foreach(Sequence sequence in sequences)
            {
                sequence.Write(w);
            }
        }
    }

    public class Sequence
    {
        /*
        struct Sequence
        {
	        char name[128];
	        unsigned int command_count; // Number of commands
	        Command commands[];
        }
         */
        byte[] _name;

       public string name
        {
            set
            {
                _name = HammerSequence.bytesstringhelper(value, 128);
            }
            get
            {
                return Encoding.ASCII.GetString(_name).TrimEnd((Char)0);
            }
        }

        public List<Command> commands = new List<Command>();
        public void Write(BinaryWriter w)
        {
            w.Write(_name);
            w.Write((UInt32)commands.Count);
            foreach (Command command in commands)
            {
                command.Write(w);
            }
        }
    }

    public class Command
    {
        [StructLayout(LayoutKind.Sequential,Pack=8,CharSet = CharSet.Ansi)]
        private struct commandy
        {
            public bool is_enabled;
            public Int32 special;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string executable;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string args;
            public bool is_long_filename;
            public bool ensurecheck;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string ensure_file;
            public bool useprocesswindow;
            public bool nowait;
        }
        /*
        struct Command
        {
	        char is_enabled; // 0/1, If command is enabled.
	        int special;
	        char executable[260]; // Name of EXE to run.
	        char args[260]; // Arguments for executable.
	        int is_long_filename; // Obsolete, but always set to true. Disables MS-DOS 8-char filenames.
	        int ensure_check; // Ensure file post-exists after compilation
	        char ensure_file[260]; // File to check exists.
	        int use_proc_win; // Use Process Window (ignored if exectuable = $game_exe).

	        // V 0.2+ only:
	        int no_wait;  // Wait for keypress when done compiling.
        }
         */
        public bool is_enabled;
        public CommandSpecial special;

        byte[] _executable;
        public string executable
        {
            set
            {
                _executable = HammerSequence.bytesstringhelper(value, 260);
            }
            get
            {
                return Encoding.ASCII.GetString(_executable).TrimEnd((Char)0);
            }
        }

        byte[] _args;
        public string args
        {
            set
            {
                _args = HammerSequence.bytesstringhelper(value, 260);
            }
            get
            {
                return Encoding.ASCII.GetString(_args).TrimEnd((Char)0);
            }
        }

        public bool is_long_filename;
        public bool ensure_check;

        byte[] _ensure_file;
        public string ensure_file
        {
            set
            {
                _ensure_file = HammerSequence.bytesstringhelper(value, 260);
            }
            get
            {
                return Encoding.ASCII.GetString(_ensure_file).TrimEnd((Char)0);
            }
        }

        public bool use_proc_win;
        public bool no_wait;

        public void Write(BinaryWriter w)
        {
            commandy y;
            y.is_enabled = is_enabled;
            y.special = (Int32)special;
            y.executable = executable;
            y.args = args;
            y.is_long_filename = is_long_filename;
            y.ensurecheck = ensure_check;
            y.ensure_file = ensure_file;
            y.useprocesswindow = use_proc_win;
            y.nowait = no_wait;
            int length = Marshal.SizeOf(y);
            IntPtr ptr = Marshal.AllocHGlobal(length);
            byte[] myBuffer = new byte[length];

            Marshal.StructureToPtr(y, ptr, true);
            Marshal.Copy(ptr, myBuffer, 0, length);
            Marshal.FreeHGlobal(ptr);

            w.Write(myBuffer);
            /*
            w.Write(is_enabled);
            w.Write(new byte[] { 0, 0, 0 });
            w.Write((Int32)special);
            w.Write(_executable);
            w.Write(_args);
            w.Write(is_long_filename);
            w.Write(ensure_check);
            w.Write(_ensure_file);
            w.Write(use_proc_win);
            w.Write(no_wait);*/
        }
    }

    public enum CommandSpecial
    {
        None=0,
        ChangeDirectory=256,
        CopyFile=257,
        DeleteFile=258,
        RenameFile=259
    }

    class HammerSequence
    {
        private MemoryStream stream = new MemoryStream();
        private BinaryWriter writer;

        public HammerSequence()
        {
            writer = new BinaryWriter(stream);
        }

        public void Write(string filename, List<Sequence> seq, Dictionary<string, string> hammersequencevariables)
        {
            SequenceHeader sh = new SequenceHeader();

            foreach(Sequence s in seq)
            {
                foreach(Command c in s.commands)
                { 
                    foreach (KeyValuePair<string, string> entry in hammersequencevariables)
                    {
                        c.args = c.args.Replace(entry.Key, entry.Value);
                        c.executable = c.executable.Replace(entry.Key, entry.Value);
                    }
                }
            }


            sh.sequences = seq;
            sh.Write(writer);
            FileStream f = File.Open(filename, FileMode.Create);
            writer.Flush();
            
            byte[] thebuffer = stream.ToArray();
            f.Write(thebuffer, 0, thebuffer.Length);
            f.Close();
        }

        public static byte[] bytesstringhelper(string thevalue, int thesize)
        {
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(thevalue);
            Array.Resize(ref bytes, thesize);
            return bytes;
        }
    }
}
