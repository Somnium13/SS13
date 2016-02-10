# somnium-engine
Somnium Engine and Server

All of the non-transcompiled, server-side components of Somnium.

Includes the game server, http server, libraries, etc...

This lives in the 'Engine' directory of a transcompiled SS13 codebase.

Due to the horrible way it is designed, it can't be an actual dependency.

## res gerendae
- Devclient NOW.
- Make naming consistent. Slowly changing everything to C# standard convention despite the fact that I like Java's better.
- Various functions in libraries. Most important listed below!
	- File library -- Make it actually do stuff, make it only able to access stuff within a single directory.
	- Better text macro replacement -- always explicitly yeild a string instead of an implicit cast, use invisible chars for some metadata.
	- Savefile -- This is not so important right now.
- Webserver -- For serving content!
- Many more things not worth getting worked up over right now.

## Layout
- ByImpl - Stuff from the old engine that transcompiled code uses.
	- StaticLib - Static libraries. The global functions from the old engine have been split into various categories.
	- BaseClass - Base classes that game classes inherit from.
- NewLib - Fancy new stuff that doesn't face transcompiled code.
- Jake.cs - Main function goes here. Engine scheduling also goes here. The awful structure that controls game scheduling and somewhat resembles a game loop is actually in Task13.
