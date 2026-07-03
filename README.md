This is my attempt on making a mod of amongus where u can see roles of other players on HUD.

What's IL2CPP:




How it started:
1) Used Il2cppdumper on global-metadata.dat and GameAssembly.dll
-> Got the DummyDll folder, dump.cs, il2cpp.h, and script.json files
2) Opened the DummyDll folder in DnSpy
-> Got a list of just names of the methods, classes,etc used in the Game.
3) In Ghidra, open GameAssembly.dll
-> Found the psuedocode/ Assembly code for the functions
4) Used BepInEx to add a plugin
-> Plugin contained the code for the mod where u can see roles of ppl on HUD
