using System;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using IchigoJam;

public class Kawakudari
{
  static void Main()
  {
    new Kawakudari();
  }

  private Std15 std15;
  private Random rand;

  private uint frame;
  private int x;
  private bool running;

  public Kawakudari ()
  {
    std15 = new Std15(512, 384, 32, 24);
    rand = new Random();
    GameWindow win = new GameWindow (512, 384, GraphicsMode.Default, "kawakudari");
    win.Load += OnLoad;
    win.UpdateFrame+= OnUpdateFrame;
    win.KeyDown += OnKeyDown;
    win.RenderFrame+= OnRenderFrame;
    win.Resize += OnResize;
    win.Run(60.0);
  }

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

  private void OnRenderFrame (object sender, FrameEventArgs e)
  {
    std15.DrawScreen();
    ((GameWindow)sender).Context.SwapBuffers();
  }

  private void OnResize (object sender, EventArgs e)
  {
    GameWindow win = (GameWindow)sender;
    GL.Viewport(0,0,win.Width,win.Height);
  }

}

