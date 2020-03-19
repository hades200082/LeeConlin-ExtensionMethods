# Extension Methods

**NuGet:** https://www.nuget.org/packages/LeeConlin.ExtensionMethods/

**Master branch:** [![Build status](https://ci.appveyor.com/api/projects/status/v6hm7m45f9nyl9ib/branch/master?svg=true)](https://ci.appveyor.com/project/hades200082/leeconlin-extensionmethods/branch/master)

## Summary

This is a collection of useful extension that I've built up over the years. I've kept it slim for now but happy to accept pull requests for additional ones if you have any you find useful - see the [Contribution Guide](https://github.com/hades200082/LeeConlin-ExtensionMethods/blob/master/CONTRIBUTING.md) for how to contribute. The package is released under the [BSD-3-Clause license](https://github.com/hades200082/LeeConlin-ExtensionMethods/blob/master/LICENSE.md) and any contributions must also fall under this license.

If you use it and find a bug, please report it on the github issue tracker or, better yet, write a test that highlights it, fix it and submit a PR.

I plan to keep adding to this package as I find/create more useful extension methods that I believe are generic enough to warrant being in the package.

## Supported .Net Versions

Written in **.Net Standard 2.0 this package should be compatible with:

- .Net Core 2.0+
- .Net Framework 4.6.1+<sup>1</sup>

<small><sup>1</sup> - While NuGet considers .NET Framework 4.6.1 as supporting .NET Standard 1.5 through 2.0, there are several issues with consuming .NET Standard libraries that were built for those versions from .NET Framework 4.6.1 projects. For .NET Framework projects that need to use such libraries, we recommend that you upgrade the project to target .NET Framework 4.7.2 or higher.</small>

## Installation with NuGet Package Manager

```bash
Install-Package LeeConlin.ExtensionMethods
```

## Documentation

I've taken pains to ensure that the extension methods are as self-documenting as possible, including as much information in the XML-Doc comments (for intellisense) as possible.

To see examples of usage, browse the source code in this repo, especially the `LeeConlin.ExtensionMethods.Tests` project. 

I'll be adding a project wiki here on github in due course.

## Reporting issues

Please report all issues on the [issue tracker](https://github.com/hades200082/LeeConlin-ExtensionMethods/issues).

If you can fix it, please see the [Contribution Guide](https://github.com/hades200082/LeeConlin-ExtensionMethods/blob/master/CONTRIBUTING.md) for how to submit a pull request.

## Contributing

Please see the [Contribution Guide](https://github.com/hades200082/LeeConlin-ExtensionMethods/blob/master/CONTRIBUTING.md).

### Current contributors

- Lee Conlin ([github profile](https://github.com/hades200082)) - Project owner