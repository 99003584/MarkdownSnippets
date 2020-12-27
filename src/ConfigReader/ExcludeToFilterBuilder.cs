﻿using System.Collections.Generic;
using System.Linq;
using MarkdownSnippets;

static class ExcludeToFilterBuilder
{
    public static DirectoryInclude ExcludesToFilter(List<string> excludes)
    {
        excludes = GetExcludesWithBothSlashes(excludes).ToList();
        return path => !excludes.Any(path.Contains);
    }

    static IEnumerable<string> GetExcludesWithBothSlashes(List<string> excludes)
    {
        foreach (var exclude in excludes)
        {
            yield return exclude.Replace('\\', '/');
            yield return exclude.Replace('/', '\\');
        }
    }
}