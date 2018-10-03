# HttpSender ![avatar](https://img.shields.io/badge/nuget-v0.0.0-yellowgreen.svg)
A simple C# library to send Http request

## Usage
NameSpace: HttpSender  
Class: Sender

### Send Get Request
static string Get(string url)

### Send Post Request
static string Post(string url,string content)  
static string Post(string url, Dictionary<string,string> content)

### Send Put Request
static string Put(string url)  
static string Put(string url, Dictionary<string,string> content)

### Send Delete Request
static string Delete(string url)

### Set OAuth Token in the Http header
static void OAuth(string token)
