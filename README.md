# 2024 RAT projet
 Fully windows defender bypass + persistence

 Client side documentation:

Program.cs
        Main entry of the prgoram. This entry doing some important things:
        1. If its first time program opened, ask for admin privleges, then create registry keys, and then open the Fake GUI app
        2. Establishing socket connection to server

Folders
        FakeProgram (1 class inside): 
                GUI app that opens only once after program opens. At the second time opening it will not be shown.

        Server (1 class inside):
                Server-Client communication. Receiving Socket data as AES, decrypting it, it goes into TLV protocol, then to Switch function
                that decide what is the reason that stands behind each socket data that has been received (Screen stream? Computer shutdown? Delete app?)

        Setup (6 classes inside):
                OS folder:
                        Getting windows OS type

                Privilege folder:
                        Getting admin priviliges if its the first time program opened

                Registry folder:
                        Getting registry data, Creating registry data, Checking if registry data exist

                WinDefend folder:
                        Adding app and host ipaddress to windows defender execlude list with AV Bypass technic (long sleeps)
                        and with EXCLUDE bypass technic (this app will not shown at the execlude apps list, its hidden.)

                FileCopy class:
                        The program copying itself to another computer location with AV Bypass technic (long sleeps)

                schtask class:
                        persistence. creating task that opens every this app every 5 minutes as admin.

        Socket (1 class inside):
                Connecting to server. IpAddress value comes from web site, so i can change it to what i want at any time.
                When connection establish, Server.cs class instance will created, and function inside it called Receive will
                start, as a blocking function. not a thread, or async. because, when connection lost, then it will be returned
                and then code will go to Reconnect() class.

        Tools (9 classes inside)
                The tools that this RAT is using. Some of them are using delegate to the Server class.