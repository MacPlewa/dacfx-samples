// Copyright (c) Mac Plewa
// Licensed under the MIT License

using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Dac;
using System;
using System.IO;

namespace DacFxCommon
{
	public static class Operations
	{
		/// <summary>
		/// Exports a database to a bacpac file.
		/// </summary>
		/// <param name="opts">Configuration options.</param>
		public static void RunExport(ExportOptions opts)
		{
			SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder(opts.ConnectionString);

			DacServices ds = new DacServices(csb.ConnectionString);

			if (opts.Verbose)
			{
				Console.WriteLine($"Exporting {opts.DatabaseName} to {opts.TargetFile}");
			}

			ds.ExportBacpac(opts.TargetFile, opts.DatabaseName);

			if (opts.Verbose)
			{
				Console.WriteLine($"Successfully exported to {opts.DatabaseName}");
			}
		}

		/// <summary>
		/// Imports a database from a bacpac file.
		/// </summary>
		/// <param name="opts">Configuration options.</param>
		public static void RunImport(ImportOptions opts)
		{
			SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder(opts.ConnectionString);

			DacServices ds = new DacServices(csb.ConnectionString);

			if (opts.Verbose)
			{
				Console.WriteLine($"Importing {opts.SourceFile} to {opts.DatabaseName}");
			}

			ds.ImportBacpac(BacPackage.Load(opts.SourceFile), opts.DatabaseName);

			if (opts.Verbose)
			{
				Console.WriteLine($"Successfully imported to {opts.DatabaseName}");
			}
		}

		/// <summary>
		/// Extracts application to dacpac file.
		/// </summary>
		/// <param name="opts">Configuration options.</param>
		public static void RunExtract(ExtractOptions opts)
		{
			SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder(opts.ConnectionString);

			DacServices ds = new DacServices(csb.ConnectionString);

			Version version = new Version(opts.ApplicationVersion);

			if (opts.Verbose)
			{
				Console.WriteLine($"Extracting schema from {opts.DatabaseName} to {opts.TargetFile}");
			}
			
			ds.Extract(opts.TargetFile, opts.DatabaseName, opts.ApplicationName, version);

			if (opts.Verbose)
			{
				Console.WriteLine($"Schema successfully extracted to {opts.TargetFile}");
			}
		}

		/// <summary>
		/// Creates T-SQL script that can be used to deploy the schema of the supplied DacPackage to a database.
		/// </summary>
		/// <param name="opts">Configuration options.</param>
		public static void RunGenerateScript(GenerateScriptOptions opts)
		{
			SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder(opts.ConnectionString);

			DacServices ds = new DacServices(csb.ConnectionString);

			DacPackage.Load(opts.SourceFile);

			if (opts.Verbose)
			{
				Console.WriteLine($"Generating T-SQL script from {opts.SourceFile} to {opts.DatabaseName}");
			}

			var script = ds.GenerateDeployScript(DacPackage.Load(opts.SourceFile), opts.DatabaseName);

			File.WriteAllText(opts.ScriptFile, script);

			if (opts.Verbose)
			{
				Console.WriteLine($"T-SQL script successfuly generated to {opts.ScriptFile}");
			}
		}
	}
}
