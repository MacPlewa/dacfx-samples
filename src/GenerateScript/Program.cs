// Copyright (c) Mac Plewa
// Licensed under the MIT License

using CommandLine;
using DacFxCommon;

namespace GenerateScript
{
	public class Program
	{
		static void Main(string[] args)
		{
			Parser.Default.ParseArguments<GenerateScriptOptions>(args).WithParsed(Operations.RunGenerateScript);
		}
	}
}
