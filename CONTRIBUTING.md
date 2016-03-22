# Somnium13
## Contribution Guidelines

### Project Structure
**IMPORTANT: Do not forget to initialize the "content" submodule.**

- Engine - Code and libraries that the game relies on.
  - Jake.cs - This contains the Main function. It's name is non-negotiable.
  - Config.cs - System wide configuration stuff. Should probably be parsed from a file.
  - ByImpl - Classes that emulate BYOND's functionality.
    - BaseClass - Abstract base classes that the Game extends.
    - StaticLib - All the global library functions. They have been sorted into different classes and follow the convention: Lang13, File13, Game13, etc.
  - NewLib - New libraries. Includes webserver, logger, and coroutine systems.
- Game - Transpiled code from /tg/station, based on the same commit as the "content" submodule.
  - Game13Ext.cs - Extends the Game13 library.
  - GlobalFuncs.cs - All global functions defined by the game end up in this static class.
  - GlobalVars.cs - All global variables defined by the game end up in this static class.
  - Zones - Contains Zone (Area) classes.
  - Tiles - Contains Tile (Turf) classes.
  - Objs - Contains Obj classes.
  - Mobs - Contains Mob classes.
  - Unsorted - Contains the rest of the classes.
- content - A submodule that links to /tg/station. This serves as the root directory for the File13 library, and certain subdirectories can be served to clients.
- www - Stuff that can be served to clients. Includes the webclient, JS libraries, and stuff to support developer services.

### Important Shit
1. Never try to fix anything you don't know how to -- If something throws an exception, it's because we need to know it fucked up.
2. Be careful when editing stuff in ByImpl. Lots of testing has gone into making it emulate BYOND's functionality.
3. Try to get rid of Lang13.Initial() -- It will only work for a small whitelist of fields.
4. If possible, try to get of ByTable usage and never use it in new code. It is a terrible data structure.
5. Try to get rid of use of the "dynamic" keyword.
6. Try to use Task13.Schedule() rather than Task13.Sleep()! Currently coroutines are implemented as threads, which is not a good thing.

### Transpiler Oddness
1. The class naming scheme is very odd. You can try to fix it, but please be consistent if you do.
2. The transpiler's type inference is bad. Often bool/int/double types will be incorrect. In particular, many bools should be ints. Be careful with the odd code that the transpiler inserts to switch between these types.
3. The transpiler had an odd way of dealing with default arguments: It always sets the default to null, and sets the actual default in the body of the function. This is to emulate BYOND's way of doing things, but it can and should probably be removed in most cases.
4. The __FieldInit() method is used to override values of fields of classes upon initialization. This is not ideal, but I can't think of a better way to do it for now.
5. The Txt class is used to emulate text macros. It is not done yet. Implementing proper() and improper() may pose a challenge.
6. Annotations are used for verb metadata. Verbs are not implemented yet. Some verbs (particularly in Admins.cs) should probably be static methods...
7. When in doubt, try to take a gander at the way the original DM works and try to emulate that. The DM reference may help you wrap your head around some of the oddness.

### Name Changes
```
world -> Game13 (See both Engine/ByImpl/StaticLib/Game13.cs and Game/Game13Ext.cs)
client -> Client / Base_Client
datum -> Game_Data / Base_Data
datum/* -> *
atom -> Ent_Static / Base_Static
atom/movable -> Ent_Dynamic / Base_Dynamic
atom/movable/* -> Dynamic_*
area -> Zone
turf -> Tile
obj -> Obj
mob -> Mob
```

### Code Style
I don't give much of a damn about style but here are some guidelines:

1. Please set your editor to use tabs rather than spaces. **VS defaults to using spaces, please change this**.
2. Try to follow the C# standard conventions. At least try to keep class names and public members upper camel cased.
