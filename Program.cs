using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace gtfto_parser
{
    class Program
    {
        static void Main(string[] args)
        {
            string tempstr;
            string mlstr = "temp";
            Int32 starti = -1;
            Int32 endi = 0;
            UInt32 multiline = 0;

            if (args.Length < 2)
            {
                Console.Write("GTFTO no args");
                Environment.Exit(2);
                return;
            }

            string filename = args[0];
            string startfrom = args[1].Trim('"');
            string endon = args[2].Trim('"');

            Encoding enc = new UTF8Encoding(true, true);
            StreamReader strtoproc = new StreamReader(filename, enc, false);

            //Console.Write("GTFTO rulez");

            while (!strtoproc.EndOfStream)
            {
                try
                {
                    tempstr = strtoproc.ReadLine();
                }
                catch (System.ObjectDisposedException)
                {
                    //MessageBox.Show("Ошибка чтения");
                    return;
                }
                catch (System.IO.IOException)
                {
                    //MessageBox.Show("Ошибка чтения");
                    return;
                }

                if (starti == -1 && tempstr.IndexOf(startfrom) != -1)
                {
                    starti = tempstr.IndexOf(startfrom);
                    mlstr = tempstr.Substring(starti);
                    //Console.Write(tempstr.Substring(tempstr.IndexOf(startfrom)));
                }

                if (starti != -1 && tempstr.IndexOf(endon) != -1)
                {
                    endi = tempstr.IndexOf(endon);

                    if (multiline == 0)
                    {
                        Console.Write(tempstr.Substring(starti, (endi - starti)));
                    }
                    else
                    {
                        mlstr += tempstr.Substring(0, endi);
                        Console.Write(mlstr);
                    }
                    Environment.Exit(0);
                    return;
                }

                if (starti != -1 && tempstr.IndexOf(endon) == -1)
                {
                    mlstr += tempstr;
                    multiline++;
                }
            }
            Environment.Exit(1);
            //Console.Write("GTFTO found noting");
        }
    }
}