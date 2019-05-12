using System;
using CommandLine;

namespace PipelineProject {
    class Program {
        static void Main(string[] args) {
            Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(o => {
                Pipeline p = new Pipeline(o.Input, o.Output, o.Root, o.Layer);
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
            [Option('r', "root", Required = true, HelpText = "Sets content output root.")]
            public string Root {
                get;
                set;
            }
            [Option('l', "layer", Required = true, HelpText = "Sets layer1 path.")]
            public string Layer {
                get;
                set;
            }
        }
    }
}