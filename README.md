# Books

## How to setup development environment

### Step 1 - Install MongoDB

To install MongoDB directly on your working machine, please follow instruction depending on your OS.
* [Install MongoDB on Windows](http://docs.mongodb.org/getting-started/shell/tutorial/install-mongodb-on-windows/)
* [Install MongoDB on Linux](http://docs.mongodb.org/getting-started/shell/tutorial/install-on-linux/)
* [Install MongoDB on OSX](http://docs.mongodb.org/getting-started/shell/tutorial/install-mongodb-on-os-x/)

Or you can use install [vagrant](https://www.vagrantup.com/downloads.html) and start virtual machine via command prompt
```
cd dev
vagrant up
```
### Step 2 - Import data into MongoDB

To import test data into MongoDB installed in previous step, in project root use command prompt in following fashion:
```
cd dev
./import_data.bat
```

### Step 3 - Install ASP.NET 5


http://www.microsoft.com/en-us/download/details.aspx?id=49442


To install ASP.NET 5 on your machine, please follow instruction depending on your OS.
* [Install ASP.NET 5 on Windows](https://docs.asp.net/en/latest/getting-started/installing-on-windows.html)
* [Install ASP.NET 5 on Linux](https://docs.asp.net/en/latest/getting-started/installing-on-linux.html)
* [Install ASP.NET 5 on OSX](https://docs.asp.net/en/latest/getting-started/installing-on-mac.html)

### Step 4 - Running catalog API and web site  

Go project root and execute via command prompt
```
dnu restore
```
Then to start catalog API, use following commands:
```
cd Source\Catalog.Api
dnx web
```
Then to start web site, use following commands:
```
cd Source\Books.Web
dnx web
```

Install Visual Studio Community 2015 from [here](https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx), and ASP.NET 5 tools from [here](http://www.microsoft.com/en-us/download/details.aspx?id=49442).

