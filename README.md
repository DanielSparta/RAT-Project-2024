### Ultimate Sparta RAT C# Project

# Why my RAT is better than the others?
- Windows defender full bypass using Exclude list.
- Windows defender Exclude list bypass (app not showing at windows defender GUI whitelist while it is).
- Persistence (using task scheduler, every 5 minutes the program restarting if not opened).
- NET Framework, tested at the latest windows 11, 10, 8 versions.
- Open source & Easy to contact the developer

![image](https://github.com/DanielSparta/2024-RAT-projet/assets/111179755/21ed04f8-30e4-49c7-95a0-9231817bb765)

![image](https://github.com/DanielSparta/2024-RAT-projet/assets/111179755/d228432f-87b1-4a0e-8c2f-5643d0385c13)

# Info
This RAT project made for fun, I'm working on updates often.
I started with this project because i had so many ideas, with code i can be creative.

i made a previous RAT project at 2022(https://github.com/DanielSparta/RAT-Project-2022)
but its code is very bad.

# Client side
Program.cs 
- Main entry of the prgoram. This entry doing 2 important things:
1. If its first time program opened, ask for admin privleges, then create registry keys, and then open the Fake GUI app
2. Establishing socket connection to server

#### Folders at the client side
       
FakeProgram Folder (1 class inside): 
 - 1. GUI app that opens only once after program opens. At the second time opening it will not be shown.

Server Folder (1 class inside):
- 1. Server-Client communication. Receiving Socket data as AES, decrypting it, it goes into TLV protocol, then to Switch function that decide what is the reason that stands behind each socket data that has been received (Screen stream? Computer shutdown? Delete app?)

Setup Folder (6 classes inside):
- 1. OS folder: Getting windows OS type

2. Privilege folder:
- Getting admin priviliges if its the first time program opened

3. Registry folder:
-Getting registry data, Creating registry data, Checking if registry data exist

4. WinDefend folder:
- Adding app and host ipaddress to windows defender execlude list with AV Bypass technic (long sleeps) and with EXCLUDE bypass technic (this app will not shown at the execlude apps list, its hidden.)

5. Tools Folder (9 classes inside)
- The tools that this RAT is using. Some of them are using delegate to the Server class.

6. FileCopy class:
- This class copying self file to another location

7. schtask class:
- persistence. creating task that opens every this app every 5 minutes as admin.

8. Socket (1 class inside):
- Connecting to server. IpAddress value comes from web site, so i can change it to what i want at any time.
When connection establish, Server.cs class instance will created, and function inside it called Receive will
start, as a blocking function. not a thread, or async. because, when connection lost, then it will be returned
and then code will go to Reconnect() class.



# Server side
to do


## Authors

- [@DanielSparta](https://github.com/DanielSparta)
