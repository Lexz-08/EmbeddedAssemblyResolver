using ICSharpCode.TextEditor;
using System.Windows.Forms;

namespace AssemblyResolver_Demo
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			MessageBox.Show(typeof(TextEditorControl).ToString(), "TextEditorControl",
				MessageBoxButtons.OK, MessageBoxIcon.Information);
			MessageBox.Show(typeof(Bitmaps).ToString(), "Bitmaps",
				MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
