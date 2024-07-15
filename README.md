# OLDumpHelper

A simple console application to help with parsing dump files from OpenLibrary.
It removes all the colums before the JSON content and parses the data to a readable format.

For example, in the original file you can have the same property with 2 different formats:

```sh
"authors": [{"type": "/type/author_role", "author": {"key": "/authors/OL3965142A"}}]
```
and
```sh
"authors": [{"type": {"key": "/type/author_role"}, "author": {"key": "/authors/OL3965325A"}}]
```
Here the 'type' property can be a string but also an object. The goal is to have all the data with the same format.

## Requirements
- .NET 8
- Dump file from OpenLibrary. You can download dumps here: https://openlibrary.org/developers/dumps


## Running

<!-- Dillinger requires [Node.js](https://nodejs.org/) v10+ to run. -->

Start the application. It will prompt a terminal with multiple choices:

```sh
1) Authors
2) Works
```
Then you need to specify the path to the file (it needs to be extracted first).
By default temporary files are created in **%USERPROFILE%\AppData\Local\Temp**

## What works


| Dump | Working? |
| ------ | ------ |
| Authors | Yes |
| Works | Yes |
| Editions | No |
| Ratings | No |
