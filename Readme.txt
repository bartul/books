# Books

## How to setup development environment

### Step 1 - Install MongoDB

To install MongoDB directly on your working machine, please follow instruction on links, depending on your OS.
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
