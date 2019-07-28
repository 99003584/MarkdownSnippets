﻿using System;
using System.Collections.Generic;
using System.IO;
using MarkdownSnippets;

class Program
{
    static void Main(string[] args)
    {
        CommandRunner.RunCommand(Inner, args);
    }

    static void Inner(string targetDirectory, ConfigInput configInput)
    {
        Console.WriteLine($"TargetDirectory: {targetDirectory}");
        if (!Directory.Exists(targetDirectory))
        {
            Console.WriteLine($"Target directory does not exist: {targetDirectory}");
            Environment.Exit(1);
        }

        var (fileConfig, configFilePath) = ConfigReader.Read(targetDirectory);
        var configResult = ConfigDefaults.Convert(fileConfig, configInput);

        var message = LogBuilder.BuildConfigLogMessage(targetDirectory, configResult, configFilePath);
        Console.WriteLine(message);

        var processor = new DirectoryMarkdownProcessor(
            targetDirectory,
            log: Console.WriteLine,
            directoryFilter: ExcludeToFilterBuilder.ExcludesToFilter(configResult.Exclude),
            readOnly: configResult.ReadOnly,
            writeHeader: configResult.WriteHeader,
            linkFormat: configResult.LinkFormat,
            tocLevel: configResult.TocLevel);

        var snippets = new List<Snippet>();
        snippets.AppendUrlsAsSnippets(configResult.UrlsAsSnippets).GetAwaiter().GetResult();
        processor.IncludeSnippets(snippets);

        try
        {
            processor.Run();
        }
        catch (SnippetException exception)
        {
            Console.WriteLine($"Failed: {exception.Message}");
            Environment.Exit(1);
        }
    }
}