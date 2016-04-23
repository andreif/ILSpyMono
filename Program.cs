using System;
using System.IO;
using System.Collections.Generic;
using ICSharpCode.Decompiler;
using ICSharpCode.ILSpy;


namespace ILSpyMono
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			AssemblyList assemblyList = new AssemblyList ("name");

			if (args.Length != 3) {
				Exit (0, "Usage: ILSpyMono.exe  list-of-dependencies.txt-or-dir  path/to/library.dll  path/to/output/dir");
			}
			string DepsFileOrDir = args [0], DllFile = args [1], OutPath = args [2];
			if (!File.Exists (DllFile)) {
				Error ("Assembly file not found: " + DllFile);
			}
			if (!Directory.Exists (OutPath)) {
				Console.Out.WriteLine ("WARNING: Output path already exists and will be overwritten: " + OutPath);
			} else {
				Directory.CreateDirectory (OutPath);
			}
			if (DepsFileOrDir != "-") {
				foreach (string path in LoadDeps(DepsFileOrDir)) {
					assemblyList.OpenAssembly (path, true);
				}
			}
			LoadedAssembly asm = assemblyList.OpenAssembly (DllFile, true);
			if (asm.HasLoadError) {
				Error ("Failed loading assembly");
			}

			using (var writer = new System.IO.StreamWriter(OutPath + "/" + asm.ShortName + ".csproj")) {
				try {
					new CSharpLanguage().DecompileAssembly(asm, 
						new PlainTextOutput(writer), 
						new DecompilationOptions { FullDecompilation = true, SaveAsProjectDirectory = OutPath });
				} catch (Exception ex) {
					Error ("Exception: " + ex.ToString());
				}
			}

			Console.Out.WriteLine ("Done.");
		}


		public static void Exit(int code, string message) {
			Console.Out.WriteLine (message);
			Environment.Exit (code);
		}


		public static void Error(string message) {
			Exit (1, "Error: " + message);
		}


		public static string[] LoadDeps(string path) {
			List<String> result = new List<String> ();

			if (Directory.Exists (path)) {
				return Directory.GetFiles (path, "*.dll", SearchOption.AllDirectories);

			} else if (!File.Exists (path)) {
				Error ("Dependencies list not found: " + path);
			}

			try
			{   // Open the text file using a stream reader.
				using (StreamReader sr = new StreamReader(path))
				{	// Read the stream to a string, and write the string to the console.
					String line = sr.ReadToEnd().Trim();
					if (line.Length > 0 && !line.StartsWith("#")) {
						if (!File.Exists(line)) {
							Error ("One of dependencies not found: " + line);
						}
						if (!line.EndsWith(".dll")) {
							Error ("List of dependencies should contain only dlls: " + line);
						}
						result.Add(line);
					}
				}
			} catch (Exception e) {
				Error ("The dependencies file could not be read: " + e.Message);
			}

			return result.ToArray ();
		}
	}
}
