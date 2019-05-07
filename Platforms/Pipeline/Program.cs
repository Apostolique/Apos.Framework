using System;
using CommandLine;

namespace Pipeline {
    class Program {
        static void Main(string[] args) {
            Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(o => {
                Console.WriteLine("Input path: " + o.Input);
                Console.WriteLine("Output path: " + o.Output);

                Pipeline p = new Pipeline(o.Input, o.Output);
            });
        }

        private class Options {
            [Option('i', "input", Required = true, HelpText = "Sets content input path.")]
            public string Input {
                get;
                set;
            }
            [Option('o', "output", Required = true, HelpText = "Sets content output path.")]
            public string Output {
                get;
                set;
            }
        }
    }
}