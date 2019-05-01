using System;
using System.Collections.Generic;

namespace MarkdownSnippets
{
    /// <summary>
    /// Simple markdown handling to be passed to <see cref="MarkdownProcessor"/>.
    /// </summary>
    public static class SimpleSnippetMarkdownHandling
    {
        public static void AppendGroup(string key, IEnumerable<Snippet> snippets, Action<string> appendLine)
        {
            Guard.AgainstNull(snippets, nameof(snippets));
            Guard.AgainstNull(appendLine, nameof(appendLine));

            foreach (var snippet in snippets)
            {
                WriteSnippet(appendLine, snippet);
            }
        }

        static void WriteSnippet(Action<string> appendLine, Snippet snippet)
        {
            appendLine($@"```{snippet.Language}");
            appendLine(snippet.Value);
            appendLine(@"```");
        }
    }
}