// Copyright (c) Mac Plewa
// Licensed under the MIT License

using CommandLine;
using DacFxCommon;

namespace ExtractDacpac
{
	public class Program
	{
		static void Main(string[] args)
		{
			Parser.Default.ParseArguments<ExtractOptions>(args).WithParsed(Operations.RunExtract);
		}
	}
}
