# Somnium13
## Licensing Information

I am not a lawyer or any kind of expert on software licensing, but even I can see that
there's a lot of grey area where SS13's licensing is concerned.
This is how the original code is licensed:

>All code after commit 333c566b88108de218d882840e61928a9b759d8f on 2014/31/12 at 4:38 PM PST (https://github.com/tgstation/-tg-station/commit/333c566b88108de218d882840e61928a9b759d8f) is licensed under GNU AGPL v3 (http://www.gnu.org/licenses/agpl-3.0.html).
>
>All code before commit 333c566b88108de218d882840e61928a9b759d8f on 2014/31/12 at 4:38 PM PST (https://github.com/tgstation/-tg-station/commit/333c566b88108de218d882840e61928a9b759d8f) is licensed under GNU GPL v3 (https://www.gnu.org/licenses/gpl-3.0.html). (Including tools unless their readme specifies otherwise.)
>
>See LICENSE-AGPLv3.txt and LICENSE-GPLv3.txt for more details.
>
>tgui clientside is licensed as a subproject under the MIT license. tgui assets are licensed under a Creative Commons Attribution-ShareAlike 4.0 International License (http://creativecommons.org/licenses/by-sa/4.0/).
>
>See tgui/LICENSE.md for more details.
>
>All assets including icons and sound are under a Creative Commons 3.0 BY-SA license (http://creativecommons.org/licenses/by-sa/3.0/) unless otherwise indicated.

I'm not really sure how this should be interpreted, since the entire codebase has been fed into a transpiler, and it's difficult
to tell which parts of the code are under which license.
You can probably just assume that GPL applies, and the extra stuff in AGPL **probably** applies.

All new code and in this repository uses the MIT license:

```
The MIT License (MIT)

Copyright (c) 2016 Somnium13

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```
