using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace EmbeddedAssemblyResolver
{
	/// <summary>
	/// Helps resolve dependency errors for embedded assemblies that do not exist as individual files on the device.
	/// </summary>
	public class AssemblyResolveManager
	{
		private static Dictionary<string, string> assemblies = new Dictionary<string, string>();

		/// <summary>
		/// Adds a new embedded assembly resource to a <see cref="Dictionary{TKey, TValue}"/> that stores the given name and resource path as strings.
		/// </summary>
		/// <param name="AssemblyResourceName">The name of the assembly to resolve on program launch.</param>
		/// <param name="AssemblyResourcePath">The resource path of the assembly used to resolve dependency errors.</param>
		public static void AddAssembly(string AssemblyResourceName, string AssemblyResourcePath) => assemblies.Add(AssemblyResourceName, AssemblyResourcePath);

		/// <summary>
		/// A <see cref="ResolveEventHandler"/> instance containing the event function that resolves the dependency errors of only the assemblies that are specified.
		/// </summary>
		/// <returns></returns>
		public static ResolveEventHandler AssemblyErrorResolver => (s, e) =>
		{
			if (assemblies.Count == 0)
				throw new InvalidOperationException("Cannot return assembly resolve handler because no assemblies to resolve were specified.");

			using (Stream asmStrm = Assembly.GetCallingAssembly().GetManifestResourceStream(assemblies[e.Name.Split(',')[0]]))
			{
				byte[] dllBuffer = new byte[asmStrm.Length];
				asmStrm.Read(dllBuffer, 0, dllBuffer.Length);

				return Assembly.Load(dllBuffer);
			}
		};
	}
}
