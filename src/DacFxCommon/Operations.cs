// Copyright (c) Mac Plewa
// Licensed under the MIT License

using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Dac;
using System;

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
				Console.WriteLine($"Importing {opts.TargetFile} to {opts.DatabaseName}");
			}

			ds.ImportBacpac(BacPackage.Load(opts.TargetFile), opts.DatabaseName);
		}
	}
}
