// Copyright (c) Mac Plewa
// Licensed under the MIT License

using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Dac;
using System;

namespace DacFxCommon
{
	public static class Operations
	{
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
	}
}
