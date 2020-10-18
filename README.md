# kawakudari-opentk

This project implements part of the [std15.h](https://github.com/IchigoJam/c4ij/blob/master/src/std15.h) API (from [c4ij](https://github.com/IchigoJam/c4ij)) with [OpenTK](https://opentk.net), and [Kawakudari Game](https://ichigojam.github.io/print/en/KAWAKUDARI.html) on top of it.

It will allow programming for [IchigoJam](https://ichigojam.net/index-en.html)-like targets that display [IchigoJam FONT](https://mitsuji.github.io/ichigojam-font.json/) on screen using a C# programming language.
```
  private void OnLoad (object sender, EventArgs e)
  {
    frame = 0;
    x = 15;
    running = true;
  }

  private void OnUpdateFrame (object sender, FrameEventArgs e)
  {
    if (!running) return;
    if (frame % 5 == 0) {
      std15.Locate(x,5);
      std15.Putc('0');
      std15.Locate(rand.Next(0,32),23);
      std15.Putc('*');
      std15.Scroll(Std15.Direction.Up);
      if (std15.Scr(x,5) != '\0') {
        std15.Locate(0,23);
        std15.Putstr("Game Over..");
        std15.Putnum((int)frame);
        running = false;
      }
    }
    frame ++;
  }

  private void OnKeyDown (object sender, KeyboardKeyEventArgs e)
  {
    if(e.Key == Key.Left)  x--;
    if(e.Key == Key.Right) x++;
  }

```

## Prerequisite

### Windows

* [Download](https://dotnet.microsoft.com/download/dotnet-framework) and install .Net Framework.
(In most cases, it is pre-installed.)


### Linux, macOS

* [Download](https://www.mono-project.com/download/stable/) and install mono suitable for your environment.
* Download and install packages related OpenGL, OpenGL ES and OpenAL suitable for your environment.



## How to use

### Windows

To build it
```
> csc /r:OpenTK.dll Kawakudari.cs IchigoJam.cs
```
Or with full path to compiler,
```
> \Windows\Microsoft.NET\Framework64\v3.5\csc.exe /r:OpenTK.dll Kawakudari.cs IchigoJam.cs
```

To run it
```
> Kawakudari.exe
```


### Linux, macOS

To build it
```
$ mcs -r:OpenTK.dll Kawakudari.cs IchigoJam.cs
```

To run it
```
$ mono Kawakudari.exe
```



## License
[![Creative Commons License](https://i.creativecommons.org/l/by/4.0/88x31.png)](http://creativecommons.org/licenses/by/4.0/)
[CC BY](https://creativecommons.org/licenses/by/4.0/) [mitsuji.org](https://mitsuji.org)

This work is licensed under a [Creative Commons Attribution 4.0 International License](http://creativecommons.org/licenses/by/4.0/).
