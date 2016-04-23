using System;
using System.IO;
using System.Windows.Threading;
using Mono.Cecil;
using ICSharpCode.Decompiler;


namespace System.Windows.Controls
{
	public class UserControl {
		public DecompilerSettings DataContext;
		public static void InitializeComponent() {}
	}
	public class TabItem {
		public object Header;
		public object Content;
	}
	public class Window {
		public object Owner;
		public static void InitializeComponent() {}
		public static void Close() {}
		public bool ShowDialog() { return true; }
		public class tabControl {
			public class Items {
				public static void Add(object obj) {}
			}
		}
		public bool DialogResult;
	}
	public abstract class SimpleCommand {
		public abstract void Execute (object parameter);
	}
	public class RefreshCommand: SimpleCommand {
		public override void Execute (object parameter) {}
	}
	public interface UIElement {}
	public interface RoutedEventArgs {}
	public class TextBlock {
		public string Text { get; set; }
	}
	[AttributeUsage(AttributeTargets.All)]
	public class ExportMainMenuCommand : Attribute  {
		public string Menu, Header, MenuCategory; 
		public int MenuOrder;
		public ExportMainMenuCommand() {}
	}
}

namespace System.Windows.Media {
	public class FontFamily {}
}

namespace TextView
{
	public class DecompilerTextViewState {}
	public class DecompilerTextView {
		internal static string CleanUpName(string text)
		{
			int pos = text.IndexOf(':');
			if (pos > 0)
				text = text.Substring(0, pos);
			pos = text.IndexOf('`');
			if (pos > 0)
				text = text.Substring(0, pos);
			text = text.Trim();
			foreach (char c in Path.GetInvalidFileNameChars())
				text = text.Replace(c, '-');
			return text;
		}
	}
}

namespace ICSharpCode.AvalonEdit.Highlighting
{
	public interface IHighlightingDefinition {}
	public class HighlightingDefinition: IHighlightingDefinition {}
	public class HighlightingManager {
		public class Instance {
			public static IHighlightingDefinition GetDefinitionByExtension(string ext) { return new HighlightingDefinition (); }
		}
	}
}

namespace ICSharpCode.ILSpy
{
	public sealed class MainWindow {
		public AssemblyList CurrentAssemblyList = new AssemblyList ("Main");
		public static MainWindow Instance { get { return instance; } }
		private static readonly MainWindow instance = new MainWindow();
	}
	internal static class RevisionClass
	{
		public const string Major = "0";
		public const string Minor = "0";
		public const string Build = "0";
		public const string Revision = "0";
		public const string VersionName = "0";
		public const string FullVersion = Major + "." + Minor + "." + Build + ".0";
	}
		
	public class App {
		public class Current {
			public class Dispatcher {
				public static void BeginInvoke (DispatcherPriority priority, Action action) {}
				public static void VerifyAccess() {}
				public static bool CheckAccess() { return true; }
				public static LoadedAssembly Invoke(DispatcherPriority priority, object func, string name) { 
					return new LoadedAssembly (null, null, null); 
				}
			}
		}
		internal static CommandLineArguments CommandLineArguments = new CommandLineArguments (new string[0]);
		public class CompositionContainer {
			public static void ComposeParts(object obj) {}
		}
	}

	public class AssemblyListManager {
		public static void SaveList(object list) {}
	}

	public class GacInterop {
		public static string FindAssemblyInNetGac(AssemblyNameReference name) { return null; }
	}

	public class TreeNodes {
		public class Analyzer {
			public class Helpers {
				public static MemberReference GetOriginalCodeLocation(MemberReference member) { return member; }
			}
		}
	}
	public class DisplaySettingsPanel {
		public class CurrentDisplaySettings {
			public static bool ShowMetadataTokens = false;
		}
	}
}