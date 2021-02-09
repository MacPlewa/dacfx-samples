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

		[Option(Required = true, HelpText = "Specifies a target file (i.e. a .bacpac file) to be used as the target.")]
		public string TargetFile { get; set; }

		[Option(Required = true, HelpText = "Specifies the name of the source database.")]
		public string DatabaseName { get; set; }
	}

	public class ImportOptions : RunOptions
	{
		[Option(Required = true, HelpText = "Specifies a valid SQL Server/Azure connection string to the target database.")]
		public string ConnectionString { get; set; }

		[Option(Required = true, HelpText = "Specifies the source file (i.e. a .bacpac file) to be used as the source.")]
		public string TargetFile { get; set; }

		[Option(Required = true, HelpText = "Specifies the name of the target database.")]
		public string DatabaseName { get; set; }
	}
}
