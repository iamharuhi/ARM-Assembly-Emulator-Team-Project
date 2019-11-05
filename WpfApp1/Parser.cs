using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Parser
    {
        static Regex words = new Regex(@"(\;.+|[\[\]\,\!]|[\w\d\-\#\:]+|\S+)"); // Seperate out everything first
        static IDictionary<string, Regex> types = new Dictionary<string, Regex> {
            { "comment", new Regex(@"\;.*") }, // Comments discard everything after
            { "special", new Regex(@"[\[\]\,\!]") }, // Marks special characters for syntax checking
            { "register", new Regex(@"r(\d?\d)|q(\d?\d)|sp|lr|pc", RegexOptions.IgnoreCase) }, // Find registers r0-r99, q0-q99, sp, lr, pc
            { "hex", new Regex(@"^\#0x([\da-f]+)$", RegexOptions.IgnoreCase) }, // Find hexadecimal #0xABCDEF0123456789
            { "bin", new Regex(@"^\#0b([01]+)$", RegexOptions.IgnoreCase) }, // Find binary #0b10
            { "int", new Regex(@"^\#(\d*)$") }, // Find int #123456789
            { "NaN", new Regex(@"^\#.+") }, // Not a number
            { "bcond", new Regex(@"^(ldr|str)(b)?(v[sc]|l[toe]|g[te]|[mh]i|[chl]s|[pa]l|eq|ne|cc)?$", RegexOptions.IgnoreCase) },
            { "scond", new Regex(@"^(mov|mvn|ad[dcr]|sub|sbc|rs[bc]|and|[er]or|bic|orr|ls[lr]|asr|rrx)(s)?(v[sc]|l[toe]|g[te]|[mh]i|[chl]s|[pa]l|eq|ne|cc)?$", RegexOptions.IgnoreCase) }, // cmd{S}{cond}
            { "cond", new Regex(@"^(b[l]|cm[pn]|tst|teq|end)(v[sc]|l[toe]|g[te]|[mh]i|[chl]s|[pa]l|eq|ne|cc)?$", RegexOptions.IgnoreCase) },
            { "namecmd", new Regex(@"^(dcd|equ|fill)$", RegexOptions.IgnoreCase) },
            //{ "cond", new Regex(@"(v[sc]|l[toe]|g[te]|[mh]i|[chl]s|[pa]l|eq|ne|cc)") }, // conditions, NE, LT, GT
            { "label", new Regex(@"([a-z]\w+)", RegexOptions.IgnoreCase) } // label
        };
        static string[] cmds = { "mov", "mvn", "add", "adc", "adr", "sub", "sbc", "rsb", "rsc", "and",
                                "eor", "ror", "bic", "orr", "lsl", "lsr", "asr", "rrx", "ldr", "str",
                                "b", "bl", "cmp", "cmn", "tst", "teq", "end", "dcd", "equ", "fill"}; // Will I need this?
        
        public Parser() {

        }

        /*public static void Main(string[] args)
        {
            string testline = "strbne r0, [sp, #4]!\nldrne r1, [sp]";
            int i = 0;
            List<List<Tuple<string, string>>> test = parse(testline);
            foreach (List<Tuple<string, string>> line in test) {
                Console.Write("Line " + test.IndexOf(line) + " - ");
                foreach (Tuple<string, string> token in line) {
                    Console.Write("(T:" + token.Item1 + ", V:" + token.Item2 + "), ");
                }
                Console.Write("\n");
            }
            
        }*/

        public static List<List<Tuple<string, string>>> parse(string input) { // This is stupid
            List<List<Tuple<string, string>>> parsedLines = new List<List<Tuple<string, string>>>();
            List<string> lines = input.Split('\n').ToList();
            foreach (string line in lines) {
                parsedLines.Add(makeTokenFromLine(line));
            }

            return parsedLines;
        }

        public static bool checkSyntax(List<Tuple<string, string>> input)  { // return true for good, will throw an error if bad syntax
            // Syntax order list

            // Loop through list input
                // Check tuple type (if first and label, ignore label for now)
                    // Check order in syntax order list(s)
            return true;
        }

        public static List<Tuple<string, string>> makeTokenFromLine(string line) { // Returns a list of tokens as a tuple with the original value
            List<Tuple<string, string>> tokens = new List<Tuple<string, string>>();
            MatchCollection mc = words.Matches(line);
            bool match = false;

            foreach (Match m in mc)
            {
                foreach (KeyValuePair<string, Regex> type in types)
                {
                    if (type.Value.IsMatch(m.Value) && !match)
                    {
                        if (type.Key == "bcond" || type.Key == "scond" || type.Key == "cond")
                        {
                            GroupCollection cmdflags = type.Value.Match(m.Value).Groups;
                            tokens.Add(new Tuple<string, string>(type.Key, cmdflags[1].ToString()));
                            if (cmdflags.Count > 1 && (type.Key == "bcond" || type.Key == "scond"))
                            {
                                if (cmdflags[2].ToString() != "")
                                {
                                    tokens.Add(new Tuple<string, string>(type.Key.Substring(0, 1), cmdflags[2].ToString()));
                                }
                                if (cmdflags[3].ToString() != "")
                                {
                                    tokens.Add(new Tuple<string, string>("condition", cmdflags[3].ToString()));
                                }
                            }
                        } else if (type.Value.Match(m.Value).Groups.Count > 1) {
                            tokens.Add(new Tuple<string, string>(type.Key, type.Value.Match(m.Value).Groups[1].ToString()));
                        } else {
                            tokens.Add(new Tuple<string, string>(type.Key, type.Value.Match(m.Value).ToString()));
                        }
                        match = true;
                    }
                }
                match = false;
            }
            return tokens;
        }

        
    }
}
