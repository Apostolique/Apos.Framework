using System;
using System.Collections.Generic;
using System.IO;
using Apos.Content.Compile;

namespace PipelineProject {
    public class Pipeline {
        public Pipeline(string inputPath, string outputPath) {
            _inputPath = inputPath;
            _outputPath = outputPath;

            List<string> result = new List<string>();
            searchDirectory(_inputPath, result);

            Target t = new Target(TargetPlatform.Windows, TargetGraphicsBackend.OpenGL);

            Dictionary<string, ICompilerPreset> compilerPreset = new Dictionary<string, ICompilerPreset>();
            compilerPreset.Add(".txt", new CompilerPreset<string, Settings<string>>(new CompileString(), new Settings<string>(t)));

            if (result.Count > 0) {
                Console.WriteLine("Found content:");
                foreach (string f in result) {
                    string trimFilePath = trimPathRoot(_inputPath, f);
                    string fileInputPath = createInputPath(_inputPath, trimFilePath);
                    string fileOutputPath = createOutputPath(_outputPath, trimFilePath);
                    try {
                        compilerPreset[Path.GetExtension(f)].Build(fileInputPath, fileOutputPath);
                        Console.WriteLine("\tCompiled: " + trimFilePath);
                    } catch (Exception e) {
                        Console.WriteLine("\tFailed:   " + trimFilePath);
                    }
                }
                Console.WriteLine("Done building content.");
            } else {
                Console.WriteLine("Didn't find any content.");
            }
        }

        private string _inputPath {
            get;
            set;
        }
        private string _outputPath {
            get;
            set;
        }
        private string createInputPath(string contentPath, string fileName) {
            return Path.Combine(contentPath, fileName);
        }
        private string createOutputPath(string buildPath, string fileName) {
            return Path.Combine(buildPath, Path.ChangeExtension(fileName, ".xnb"));
        }
        private void searchDirectory(string root, List<string> result) {
            try {
                foreach (string f in Directory.GetFiles(root)) {
                    result.Add(f);
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
                return fullPath2.Substring(fullPath1.Length).TrimStart(Path.DirectorySeparatorChar);
            }
            return path;
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