// Copyright (c) Mac Plewa
// Licensed under the MIT License

using CommandLine;

namespace DacFxCommon
{
	public class RunOptions
	{
		[Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
		public bool Verbose { get; set; }
	}

	public class ExportOptions : RunOptions
	{
		[Option(Required = true, HelpText = "Specifies a valid SQL Server/Azure connection string to the source database.")]
		public string ConnectionString { get; set; }

		[Option(Required = true, HelpText = "Specifies a target file (i.e., a .bacpac files) to be used as the target of action.")]
		public string TargetFile { get; set; }

		[Option(Required = true, HelpText = "Specifies the name of the source database.")]
		public string DatabaseName { get; set; }
	}
}
