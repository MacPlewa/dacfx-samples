// Copyright (c) Mac Plewa
// Licensed under the MIT License

using CommandLine;
using DacFxCommon;

namespace ExportBacpac
{
	public class Program
	{
		static void Main(string[] args)
		{
			Parser.Default.ParseArguments<ExportOptions>(args).WithParsed(Operations.RunExport);
		}
	}
}
