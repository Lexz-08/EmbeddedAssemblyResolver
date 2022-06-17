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

			AssemblyResolutionManager.AddAssembly("ICSharpCode.TextEditor", "AssemblyResolver_Demo.Libraries.WinTitleBitmaps.dll");
			AssemblyResolutionManager.AddAssembly("WinTitleBitmaps", "AssemblyResolver_Demo.Libraries.WinTitleBitmaps.dll");
			AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolutionManager.AssemblyErrorResolver();

			Application.Run(new Form1());
		}
	}
}
