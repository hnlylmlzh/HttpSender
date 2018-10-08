# HttpSender [![avatar](https://img.shields.io/badge/nuget-v0.0.0-yellowgreen.svg)](https://www.nuget.org/packages/HttpSender/)
A simple C# library to send Http request

## Usage
NameSpace: HttpSender  
Class: Sender

### Send Get Request
1. static string Get(string url)  
```
string Response = Sender.Get("http://localhost:5000/home/info?username=jim");
```
### Send Post Request
2. static string Post(string url,string content)  
```
string Response = Sender.Post("http://localhost:5000/home/login", "username=jim&password=123456");
```
3. static string Post(string url, Dictionary<string,string> content)  
```
Dictionary<string, string> LoginInfo = new Dictionary<string, string> 
{ 
  { "username", "jim" },
  { "password", "123456" }
};
string Response = Sender.Post("http://localhost:5000/home/login", LoginInfo);
```
### Send Put Request
4. static string Put(string url)  
```
string Response = Sender.Put("http://localhost:5000/home/update?username=jim&age=15");
```
5. static string Put(string url, Dictionary<string,string> content)  
```
Dictionary<string, string> UpdateInfo = new Dictionary<string, string> 
{ 
  { "username", "jim" },
  { "age" , "15"}
};
string Response = Sender.Put("http://localhost:5000/home/update", UpdateInfo);
```
### Send Delete Request
6. static string Delete(string url)  
```
string Response = Sender.Delete("http://localhost:5000/home/delete?info=used");
```
### Set OAuth Token in the Http header
7. static void OAuth(string token)
```
//Providing that the oauth token is this string, "your_token"
Sender.OAuth("your_token");
string Result = Sender.Get("http://localhost:5000/home/secret");
```
