# som--tg-station
WIP/Test output of the Somnium transdecompiler on tgstation.

## Hello, World!
As this project starts generating usable code, there are a few points I'd like to make:
- If you want to become part of my crack team of non-skids, hit me up at bigboysauceboss@aol.com
- Please do not jump the gun and start editing the code. It is autogenerated, and still has many issues.
- When the code does work, please THINK before editing. It will take quite a lot of planning to refactor the code into a more modular and coherant form.
- If you have an issue with the generated code, please submit an issue!
- I will not, under any circumstances, release the code for the transcompiler.
- I will transcompile other codebases on request.

## Progress
Project started early October (~8th?). It took about a month to start generating coherant code.

- Nov 1: 102 / 234 global functions decompiled.
- Nov 2: 242 / 366
- Nov 3: 301 / 373
- Nov 4: 374 / 402
- Nov 5: 412 / 412 **(100%)**
- Nov 6: No more gotos in global functions.
- Nov 7: Various Improvements
- Nov 8: Various Improvements
- Nov 9: Fixed oddball indexing.
- Nov 10: 8701 / 13382 total functions decompiled.
- Nov 11: 12892 / 13406
- Nov 12: 12953 / 13407
- Nov 13: 13148 / 13432
- Nov 14: 13223 / 13438
- Nov 15: 13443 / 13443 **(100% -- LTG1 complete!)**
- Hiatus
- Dec 5: Began conversion to C#... Global vars looking good, functions not so much!
- Dec 6: Started on Global func conversion. Type inference is hard.
- Dec 7: Refined type inference. Still working on globals. This javscript is getting super lit.
- Dec 8: Looking sexy AF.
- Dec 9: Work on member naming. Will re-add classes soon!
- Dec 10: Classes are back! Even more issues are cropping up, but teemo will guide us to victory.
- Dec 11: Back to quantitative measures of progress! 1305 compile errors!
- Dec 12: God damn it constructors are hard.
- Dec 13: 737 Errors (I do not trust this number, VS is dumb. On the bright side, most constructor insanity has been dealt with.)
- Dec 14: No longer using error count as things are too broken for it to be a good indicator.
- Dec 15: 746 Errors (VS now correctly parses the entire file. This should be accurate!)
- Dec 16: 731 Errors.
- Dec 17: I AM BUSY.
- Dec 18: I HAVE TO GET OUT OF THIS DAMN DORM.
- Dec 19: I AM OUT OF THE DAMN DORM.
- Dec 20: 674 Errors.
- Dec 21: 246 Errors.
- Dec 22: 233 Errors.
- Dec 23: 243 Errors. (We have resource names, though!)
- Dec 24: 150 Errors. (Other counts are somewhere in the neighborhood of 500. Regardless, things are coming together very quickly.)
- Dec 25: 131 Errors.

**Current:** Fixing issues with C# code generation. Going to try getting it compiling by the new year!

## License
[Licenses of tgstation.](https://github.com/somnium13/-tg-station#license) I'm not really sure how these apply to this project.
