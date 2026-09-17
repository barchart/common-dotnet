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
- **Schedulers**: Utilities to support scheduling tasks.

## Installation

To install the package, use the following command:

```sh
dotnet add package Barchart.Common
```

## Release Process

- Create and commit `.releases/<version>.md`.
- Run `./Tools/release.sh <version>` to update the project version and push the release commit and tag.
- Publish a [GitHub Release](https://github.com/barchart/common-dotnet/releases) from that tag. The release workflow tests, signs, and publishes the package to NuGet.

## License

This software is available for use under the MIT license.
