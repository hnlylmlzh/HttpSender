# HttpSender [![avatar](https://img.shields.io/badge/nuget-v0.3.0-yellowgreen.svg)](https://www.nuget.org/packages/HttpSender/)
A simple library to send Http request

## Usage
**NameSpace**: HttpSender  
**Class**: Sender

### Send Get Request
#### static string Get(string url)
```
string Response = Sender.Get("http://localhost:5000/home/info?username=jim");
```
### Send Post Request
#### static string Post(string url,string content)
```
string Response = Sender.Post("http://localhost:5000/home/login", "username=jim&password=123456");
```
#### static string Post(string url, Dictionary<string,string> content)
```
Dictionary<string, string> LoginInfo = new Dictionary<string, string> 
{ 
  { "username", "jim" },
  { "password", "123456" }
};
string Response = Sender.Post("http://localhost:5000/home/login", LoginInfo);
```
### Send Put Request
#### static string Put(string url)
```
string Response = Sender.Put("http://localhost:5000/home/update?username=jim&age=15");
```
#### static string Put(string url, Dictionary<string,string> content)
```
Dictionary<string, string> UpdateInfo = new Dictionary<string, string> 
{ 
  { "username", "jim" },
  { "age" , "15"}
};
string Response = Sender.Put("http://localhost:5000/home/update", UpdateInfo);
```
### Send Delete Request
#### static string Delete(string url)
```
string Response = Sender.Delete("http://localhost:5000/home/delete?username=jim&year=2011");
```
### Set OAuth Token in the Http header
#### static void OAuth(string token)
```
//Providing that the oauth token is this string, "your_token"
Sender.OAuth("your_token");
string Result = Sender.Get("http://localhost:5000/home/secret");
```
