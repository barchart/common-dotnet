# @barchart/common-dotnet

[![AWS CodeBuild](https://codebuild.us-east-1.amazonaws.com/badges?uuid=eyJlbmNyeXB0ZWREYXRhIjoiemRtQmdCR0VoRkJuQzVYTGwybDh6RVhuWGtrRWpVaUdDUS9XNjZtQTZrSUNRek1CTW0yOVZnQUdFWFB3K0NuOFk3R0lYUW85YlZwOWJmdG15TVpmUlZ3PSIsIml2UGFyYW1ldGVyU3BlYyI6InF6SEpMVGVnc3dkay84ZXAiLCJtYXRlcmlhbFNldFNlcmlhbCI6MX0%3D&branch=main)](https://github.com/barchart/common-dotnet)
[![NuGet](https://img.shields.io/nuget/v/Barchart.Common)](https://www.nuget.org/packages/Barchart.Common)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A _public_ library of .NET utilities.

## Features

- **AWS**: Utilities to support communication with the AWS services.
- **Collections**: Enhanced data structures for working with collections.
- **Core**: Core classes providing various functionalities.
- **Extensions**: Extensions used to extend the functionality of the data types.
- **Interfaces**: Common interfaces meant to be implemented by other classes to provide a common functionalities.
- **Utilities**: Helper classes used throughout the library.

## Installation

To install the package, use the following command:

```sh
dotnet add package Barchart.Common
```

## Release Process

To create a new release use the following steps:

* Ensure dependencies are up-to-date.
* Create a new file in the ```.releases``` folder and commit it.
* Bump the software version in the ```Barchart.Common.csproj``` file and tag the repository.
* Create a [GitHub Release](https://github.com/barchart/common-dotnet/releases) based on the tag and add the release notes.
* Finally, publish the packages to NuGet.

**Publishing to NuGet**

* To publish the package to NuGet you need to log in to the Barchart QA virtual machine.
* Open the powershell and navigate to the ```/desktop``` folder.
* Run the following command to publish the package:

```powershell

.\common-dotnet.ps1

```

## License

This software is available for use under the MIT license.
