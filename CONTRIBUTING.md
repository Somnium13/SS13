# Somnium13
## Contribution Guidelines

### Project Structure
**IMPORTANT: Do not forget to initialize the "content" submodule.**

- Game - Transpiled code from /tg/station, based on the same commit as the "content" submodule.
- Engine - Code and libraries that the game relies on.
  - Jake.cs - This contains the Main function. It's name is non-negotiable.
  - Config.cs - System wide configuration stuff. Should probably be parsed from a file.
- content - A submodule that links to /tg/station. This serves as the root directory for the File13 library, and certain subdirectories can be served to clients.
- www - Stuff that can be served to clients. Includes the webclient, JS libraries, and stuff to support developer services.

### Code Style
I don't give much of a damn about style but here are some guidelines:

1. Please set your editor to use tabs rather than spaces. **VS defaults to using spaces, please change this**.
2. Try to follow the C# standard conventions, and at least keep class names and public members upper camel cased.



*this is incomplete!*
