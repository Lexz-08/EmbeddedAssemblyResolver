using EmbeddedAssemblyResolver;
using System;
using System.Windows.Forms;

namespace AssemblyResolver_Demo
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			AssemblyResolveManager.AddAssembly("ICSharpCode.TextEditor", "AssemblyResolver_Demo.Libraries.WinTitleBitmaps.dll");
			AssemblyResolveManager.AddAssembly("WinTitleBitmaps", "AssemblyResolver_Demo.Libraries.WinTitleBitmaps.dll");
			AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolveManager.AssemblyErrorResolver;

			Application.Run(new Form1());
		}
	}
}
