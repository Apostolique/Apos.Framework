using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Apos.Content.Compile;

namespace PipelineProject {
    public class Pipeline {
        public Pipeline(string inputPath, string outputRoot, string outputFolder, string layer1) {
            _inputPath = fixPath(inputPath);
            _outputRoot = fixPath(outputRoot);
            _outputPath = fixPath(Path.Combine(outputRoot, outputFolder));
            _layer1 = fixPath(layer1);

            Console.WriteLine("Input path: " + _inputPath);
            Console.WriteLine("Output path: " + _outputPath);
            Console.WriteLine("Output root: " + _outputRoot);

            List<string> result = new List<string>();
            searchDirectory(_inputPath, result);

            Target target = new Target(TargetPlatform.Windows, TargetGraphicsBackend.OpenGL);

            Dictionary<string, ICompilerPreset> compilerPreset = new Dictionary<string, ICompilerPreset>();
            compilerPreset.Add(".txt", new CompilerPreset<string, Settings<string>>(new CompileString(), new Settings<string>(target)));

            if (result.Count > 0) {
                Console.WriteLine("Found content:");
                List<Tuple<string, string>> links = new List<Tuple<string, string>>();
                foreach (string f in result) {
                    string trimFilePath = trimPathRoot(_inputPath, f);
                    string fileInputPath = createInputPath(_inputPath, trimFilePath);
                    string fileOutputPath = createOutputPath(_outputPath, trimFilePath);
                    string trimOutputPath = trimPathRoot(_outputRoot, fileOutputPath);
                    try {
                        compilerPreset[Path.GetExtension(f)].Build(fileInputPath, fileOutputPath);
                        Console.WriteLine("\tCompiled: " + trimFilePath + " to " + fileOutputPath);
                        links.Add(new Tuple<string, string>(normalizePath(trimFilePath), trimOutputPath));
                    } catch (Exception e) {
                        Console.WriteLine("\tFailed:   " + trimFilePath);
                    }
                }
                generateClass(links, Path.Combine(_layer1, "Content.cs"));
                Console.WriteLine("Done building content.");
            } else {
                Console.WriteLine("Didn't find any content.");
            }
        }

        private string _inputPath {
            get;
            set;
        }
        private string _outputRoot {
            get;
            set;
        }
        private string _outputPath {
            get;
            set;
        }
        private string _layer1 {
            get;
            set;
        }

        private string createInputPath(string contentPath, string fileName) {
            return fixPath(Path.Combine(contentPath, fileName));
        }
        private string createOutputPath(string buildPath, string fileName) {
            return fixPath(Path.Combine(buildPath, Path.ChangeExtension(fileName, ".xnb")));
        }
        private void searchDirectory(string root, List<string> result) {
            try {
                foreach (string f in Directory.GetFiles(root)) {
                    result.Add(fixPath(f));
                }

                foreach (string d in Directory.GetDirectories(root)) {
                    searchDirectory(d, result);
                }
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
        private string trimPathRoot(string root, string path) {
            string fullPath1 = Path.GetFullPath(root);
            string fullPath2 = Path.GetFullPath(path);
            if (fullPath2.StartsWith(fullPath1, StringComparison.CurrentCultureIgnoreCase)) {
                return fixPath(fullPath2.Substring(fullPath1.Length)).TrimStart('/');
            }
            return path;
        }
        private string fixPath(string path) {
            return path.Replace('\\', '/');
        }
        private string normalizePath(string path) {
            return path.Replace('\\', '_').Replace('/', '_').Replace('.', '_');
        }
        private void generateClass(List<Tuple<string, string>> links, string outputFile) {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("namespace GameProject {");
            sb.AppendLine("    public static class Content {");
            foreach (Tuple<string, string> t in links) {
                sb.AppendLine("        public static string " + t.Item1 + " = \"" + t.Item2 + "\";");
            }
            sb.AppendLine("    }");
            sb.AppendLine("}");

            using (FileStream fs = new FileStream(outputFile, FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs)){
                sw.Write(sb.ToString());
            }
        }

        private interface ICompilerPreset {
            void Build(string inputPath, string outputPath);
        }
        private class CompilerPreset<T, K> : ICompilerPreset where K : Settings<T> {
            public CompilerPreset(Compiler<T, K> compiler, K settings) {
                Compiler = compiler;
                Settings = settings;
            }

            Compiler<T, K> Compiler {
                get;
                set;
            }
            K Settings {
                get;
                set;
            }

            public void Build(string inputPath, string outputPath) {
                Compiler.Build(inputPath, outputPath, Settings);
            }
        }
    }
}