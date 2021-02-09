// Copyright (c) Mac Plewa
// Licensed under the MIT License

using CommandLine;
using DacFxCommon;

namespace ImportBacpac
{
	public class Program
	{
		static void Main(string[] args)
		{
			Parser.Default.ParseArguments<ImportOptions>(args).WithParsed(Operations.RunImport);
		}
	}
}
