// Copyright (c) Mac Plewa
// Licensed under the MIT License

using CommandLine;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Dac;
using System;
using System.Collections.Generic;

namespace ExportBacpac
{
	public class Program
	{
		public class Options
		{
			[Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
			public bool Verbose { get; set; }

			[Option(Required = true, HelpText = "Specifies a valid SQL Server/Azure connection string to the source database.")]
			public string ConnectionString { get; set; }

			[Option(Required = true, HelpText = "Specifies a target file (i.e., a .bacpac files) to be used as the target of action.")]
			public string TargetFile { get; set; }

			[Option(Required = true, HelpText = "Specifies the name of the source database.")]
			public string DatabaseName { get; set; }
		}

		static void Main(string[] args)
		{
			Parser.Default.ParseArguments<Options>(args).WithParsed(RunExport).WithNotParsed(HandleOptionsParseError);
		}

		static void RunExport(Options opts)
		{
			SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder(opts.ConnectionString);

			DacServices ds = new DacServices(csb.ConnectionString);

			if (opts.Verbose)
			{
				Console.WriteLine($"Exporting {opts.DatabaseName} to {opts.TargetFile}");
			}

			ds.ExportBacpac(opts.TargetFile, opts.DatabaseName);
		}

		static void HandleOptionsParseError(IEnumerable<Error> errs)
		{
		}
	}
}
