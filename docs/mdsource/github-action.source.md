# GitHub Actions

Markdown snippets can be run inside a [GitHub Action](https://help.github.com/en/actions) but installing and using [MarkdownSnippets.Tool](#installation).

Add the following to `.github\workflows\on-push-do-doco.yml` in the target repository.

snippet: on-push-do-doco.yml

This action performs the following tasks:

 * Use the [Checkout Action](https://github.com/marketplace/actions/checkout) to pull down the source
 * Install the MarkdownSnippets dotnet tool
 * Run MarkdownSnippets against the current directory
 * Push any changes back to GitHub


## More Info

 * [Software installed on GitHub-hosted runners](https://help.github.com/en/actions/automating-your-workflow-with-github-actions/software-installed-on-github-hosted-runners)