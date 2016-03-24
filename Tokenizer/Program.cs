using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokenizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\n  Testing CToker - Tokenizer ");
            Console.Write("\n ============================\n");

            try
            {
                CToker toker = new CToker();
                //toker.returnComments = true;

                if (args.Length == 0)
                {
                    Console.Write("\n  Please enter name of file to tokenize\n\n");
                    return;
                }
                foreach (string file in args)
                {
                    string msg1;
                    if (!toker.openFile(file))
                    {
                        msg1 = "Can't open file " + file;
                        Console.Write("\n\n  {0}", msg1);
                        Console.Write("\n  {0}", new string('-', msg1.Length));
                    }
                    else
                    {
                        msg1 = "Processing file " + file;
                        Console.Write("\n\n  {0}", msg1);
                        Console.Write("\n  {0}", new string('-', msg1.Length));
                        string tok = "";
                        while ((tok = toker.getTok()) != "")
                            if (tok != "\n")
                                Console.Write("\n{0}", tok);
                        toker.close();
                    }
                }
                Console.Write("\n");
                //
                string[] msgs = new string[12];
                msgs[0] = "abc";
                msgs[11] = "-- \"abc def\" --";
                msgs[1] = "string with double quotes \"first quote\""
                          + " and \"second quote\" but no more";
                msgs[2] = "string with single quotes \'1\' and \'2\'";
                msgs[3] = "string with quotes \"first quote\" and \'2\'";
                msgs[4] = "string with C comments /* first */ and /*second*/ but no more";
                msgs[10] = @"string with @ \\stuff";
                msgs[5] = "/* single C comment */";
                msgs[6] = " -- /* another single comment */ --";
                msgs[7] = "// a C++ comment\n";
                msgs[8] = "// another C++ comment\n";
                msgs[9] = "/*\n *\n *\n */";

                foreach (string msg in msgs)
                {
                    if (!toker.openString(msg))
                    {
                        string msg2 = "Can't open string for reading";
                        Console.Write("\n\n  {0}", msg2);
                        Console.Write("\n  {0}", new string('-', msg2.Length));
                    }
                    else
                    {
                        string msg2 = "Processing \"" + msg + "\"";
                        Console.Write("\n\n  {0}", msg2);
                        Console.Write("\n  {0}", new string('-', msg2.Length));
                        string tok = "";
                        while ((tok = toker.getTok()) != "")
                        {
                            if (tok != "\n")
                                Console.Write("\n{0}", tok);
                            else
                                Console.Write("\nnewline");
                        }
                        toker.close();
                    }
                }
                Console.Write("\n\n");
            }
            catch (Exception ex)
            {
                Console.Write("\n\n  token \"{0}\" has embedded newline\n\n", ex.Message);
            }
        }
    }
}
