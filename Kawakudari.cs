using System;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using IchigoJam;

public class Kawakudari : GameWindow
{
  static void Main()
  {
    new Kawakudari().Run(60.0);
  }

  private Random rand;
  private Std15 std15;
  private uint frame = 0;
  private int x = 15;
  private bool running = true;

  public Kawakudari()
          : base (512, 384, GraphicsMode.Default, "kawakudari")
  {
    this.KeyDown += window_KeyDown;
    rand = new Random();
    std15 = new Std15(512,384,32,24);
  }

  protected override void OnLoad(EventArgs e)
  {
    GL.ClearColor(0.0f,0.0f,0.0f,1.0f); // Black
    base.OnLoad(e);
  }

  protected override void OnResize(EventArgs e)
  {
    GL.Viewport(0,0,Width,Height);
    base.OnResize(e);
  }

  protected override void OnUpdateFrame(FrameEventArgs e)
  {
    if (!running) return;
    if(frame % 5 == 0)
    {
      std15.Locate(x,5);
      std15.Putc('0');
      std15.Locate(rand.Next(0,32),23);
      std15.Putc('*');

      std15.Scroll();
      if(std15.Scr(x,5) != '\0') running = false;
    }
    frame ++;
    base.OnUpdateFrame(e);
  }

  protected override void OnRenderFrame(FrameEventArgs e)
  {
    GL.Clear(ClearBufferMask.ColorBufferBit);
    std15.PAppletDraw();
    Context.SwapBuffers();       
    base.OnRenderFrame(e);
  }

  void window_KeyDown(object sender, KeyboardKeyEventArgs e)
  {
    if(e.Key == Key.Left)  x--;
    if(e.Key == Key.Right) x++;
  }

}

