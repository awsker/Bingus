# Bingus
This application makes running, administrating, spectating and streaming bingo matches easier. It's a stripped-down version of my [EldenBingo](https://github.com/awsker/EldenBingo) application, with all Elden Ring specific functionality removed. It's built on .NET 6.0, so requires that the [runtimes](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-6.0.19-windows-x64-installer) are installed.

![image](https://github.com/awsker/Bingus/assets/604653/fe736d5b-93ee-4629-b99a-5e0097d81f6e)

# Overview of Features
* Host a server capable of running multiple bingo races at once
* Create bingo lobbies with optional administrator password and upload your own bingo .json file
* Join lobbies as an individual player or part of a team, or even as spectator
* Chat in lobbies
* Configure your lobby with custom rules, like board size, extra points for bingo lines and more
* Matches can be started, paused and stopped by the referees
* Squares can be checked/unchecked by players or by referees on behalf of players
* Right click to mark squares with stars, visible only to the player marking the square
* Scroll Wheel up/down over a square allows players or referees to keep track of their progress of a square. This progress can only be seen by the owning player and spectators, but not by opposing players/teams
* Customize bingo board color/size/font

# Hosting your own server
Download the regular application and open Settings, and then enable "Host bingo server on launch".  
![host](https://user-images.githubusercontent.com/604653/235767838-ae5752a7-e9e7-4abb-a1d1-c8e6a59292aa.png)

Remember to set-up the appropriate port forwarding.

You can also host a dedicated lobby server. I don't release server binaries with the regular releases anymore but if you need them you can easily download the code and compile it yourself.

# Connecting to a server and joining a lobby
Connect to a server by pressing the 'Connect' button in the top left corner. You can choose to auto-connect to the same server every time you launch the application.

After you've successfully connected to the server, you can create your own lobby or join an existing one. A 'Lobby' in this application is a private room where you can run your bingo game. Any player that wishes to connect to a lobby needs that lobby's room name. There is no lobby browser.

## Joining a lobby
When joining (or creating) a lobby, you will be asked to input a nickname and select a team. In the 'Team' dropdown you can also select 'Spectator'.  
![join_spectator](https://user-images.githubusercontent.com/604653/235904929-2adf97ee-e6c4-4fc3-a8c7-586c383453d1.png)

## Creating a lobby
When creating a lobby you can enter any Room name you want, or use the one that was generated. If you enter an admin password, any player that connects to the lobby with that same admin password also becomes an administrator. If you leave it empty, only you will be able to administrate.

You can also configure the rules of the lobby:  
![Lobby settings](https://github.com/awsker/Bingus/assets/604653/e257606b-3db2-46b9-8b2e-211a2cedaecd)

* *Board size* specifies how large the bingo board will be. This takes effect the next time a board is generated.  
* *Random seed* will ensure that the same sequence of boards and random classes are generated/picked. This sequence will reset when a new json is uploaded. **0 means a random seed will be used**.  
* *Preparation Time* creates an extra preparation phase at the beginning of the match, after the initial countdown, in which players can see the board and the available classes and plan ahead before the match starts.  **0 means no preparation phase**
* *Bonus points for bingo* can be used if you want bingo lines to be worth a set number of points instead of immediately ending the match.  
* Setting *Max square in same category* will ensure that at most that many squares in the same category will be included in one board. **0 means this feature is disabled**. For more info on categories and the json format, see [Json Format](#json-format). 

# Administrating a lobby
You get no unfair gameplay advantage as an administrator, so you can join the game just fine. Only Admin-Spectators (ie. a player that is both administrator and spectator) have special privileges (see [AdminSpectators](#adminspectators)).

When you've joined a lobby as an administrator, the administrator tools will show under the bingo board. Use these tools to upload a Bingo .json file, following the same format as Bingo Brawlers and BingoSync but with some extensions. [Here is an example file](https://bingobrawlers.com/files/bingo-brawlers.json). For more info on the json format, see [Json Format](#json-format).

Once you've uploaded the file, a board is generated but will not be made visible to the players until the match is started. AdminSpectators can see the board and generate new boards if necessary.

Use the match control buttons at the bottom to start, pause or stop the match.  
![admin-controls](https://user-images.githubusercontent.com/604653/235774234-1d690243-9827-4510-9e51-a0befd3f0b78.png)  

# Bingo board controls
* Left click - Check or uncheck a square for you/your team. Visible for everyone.
* Right click - Mark a square with a star. The star can be used for anything, like a reminder for yourself or for coordinating a plan with your teammates. The star is only visible to your own team.
* Mouse wheel up/down - Increase/decrease the count of this square. The counter is useful for squares that have a set number of tasks that need to be completed, where it's easy to lose track of your progress. The counter is only visible to your own team and spectators.

# AdminSpectators
As an AdminSpectator, you are basically the referee of the match. You can view the generated bingo board before the game has started, and generate new boards. If you mark a player in the client list, you can perform board actions on behalf of that player, like checking/unchecking squares and incrementing/decrementing the count of a square.  
![counters](https://user-images.githubusercontent.com/604653/235781324-d6e7f488-9c25-4920-b6be-682e061e8987.png)  

# Settings
The settings are mostly for the convenience of a streamer, to set up the UI components to the right size and position to be easily captured in the streaming software. You can also enable server hosting from here.

# Json Format
The format is the same as is used by Bingo Brawlers and BingoSync but with extensions for tooltips, categories and counters.  
![json2](https://github.com/user-attachments/assets/847c42df-868c-4c3c-bc87-e73931643b82)

Use the **tooltip** key to define a tooltip when hovering that square:  
 ![image](https://github.com/awsker/EldenBingo/assets/604653/a5f97ed4-9454-462a-bd31-8b2de1e186f7)

Use the **category** key to define a single category, or the **categories** key to define an array of categories. These categories can be used in conjunction with the lobby setting *Max square in same category* to ensure that at most that number of categories will be present in one bingo board, in order to generate more balanced bingo boards.

If one or more squares have the tag **center** set to 1, one of them will be randomly selected to be the center square on board sizes where it's applicable.

Tokens can be used to create more dynamic squares. Create a token by surrounding a word with percentage signs (for example %x%) and declare a list of possible substitutions in an array with the same name as the token. One of those will be picked at random when the square is generated. You can even have multiple tokens in the same square. See example in the image above.
