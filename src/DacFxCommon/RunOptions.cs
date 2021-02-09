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
		public string SourceFile { get; set; }

		[Option(Required = true, HelpText = "Specifies the name of the target database.")]
		public string DatabaseName { get; set; }
	}

	public class ExtractOptions : RunOptions
	{
		[Option(Required = true, HelpText = "Specifies a valid SQL Server/Azure connection string to the source database.")]
		public string ConnectionString { get; set; }

		[Option(Required = true, HelpText = "Specifies a file (i.e. a .dacpac file) to be used as the target package.")]
		public string TargetFile { get; set; }

		[Option(Required = true, HelpText = "Specifies the name of the source database.")]
		public string DatabaseName { get; set; }

		[Option(Required = true, HelpText = "Specifies the identifier for the DAC application.")]
		public string ApplicationName { get; set; }

		[Option(Required = true, HelpText = "Specifies the version of the DAC application (major.minor.build.revision).")]
		public string ApplicationVersion { get; set; }
	}

	public class GenerateScriptOptions : RunOptions
	{
		[Option(Required = true, HelpText = "Specifies a valid SQL Server/Azure connection string to the target database.")]
		public string ConnectionString { get; set; }

		[Option(Required = true, HelpText = "Specifies a file (i.e. a .dacpac file) to be used as the source package.")]
		public string SourceFile { get; set; }

		[Option(Required = true, HelpText = "Specifies a file to write the SQL script to.")]
		public string ScriptFile { get; set; }

		[Option(Required = true, HelpText = "Specifies the name of the target database.")]
		public string DatabaseName { get; set; }
	}
}
