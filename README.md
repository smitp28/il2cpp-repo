This is my attempt on making a mod of amongus where u can see roles of other players on HUD.

What's IL2CPP:
Unity builds are of 2 types, Mono or IL2CPP(intermediate lang. to c++)
Unity has C# scripts, which compile to IL(intermediate lang) which cpu cant understand so Mono compiles,interprets and executes this IL, however this takes time and makes it slow, so IL2CPP convertes IL into CPP compiled code which machine can directly understand and hence make it faster. But due to this IL2CPP dont contain C# files which make them harder to mod and get the game data from. 
Hence we use the following tools: IL2CPPdumper it uses the global-metadata.dat which contains list of the methods and functions in compiled cpp code which machine can directly understand, il2cppdumper converts this into readable form for dnspy.
dnSpy can help in seeing this list created by il2cppdumper and with this list we can see the function names and maybe even guess their use, this information is enough sometimes to create some mods, however it things are complicated, we need ghidra.
Ghidra helps in showing us the whole game logic in assembly language, which can be tedious to understand but can be very helpful. With Ghidra we can understand how the whole game works.
BepInEx helps in adding mods to the game, we can create some code and add that to the game by using this software.


How it started:
1) Used Il2cppdumper on global-metadata.dat and GameAssembly.dll
-> Got the DummyDll folder, dump.cs, il2cpp.h, and script.json files
2) Opened the DummyDll folder in DnSpy
-> Got a list of just names of the methods, classes,etc used in the Game.
3) In Ghidra, open GameAssembly.dll
-> Found the psuedocode/ Assembly code for the functions
4) Used BepInEx to add a plugin
-> Plugin contained the code for the mod where u can see roles of ppl on HUD
-> modproject contains the files of plugin
