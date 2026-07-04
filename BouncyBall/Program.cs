using BouncyBall;

var flags = new Flags(args);
var grid = new Grid(flags.Width, flags.Height);
var iter = 0;

while (true)
{
    var buf = "";
    buf += $"Iteration: {iter}\n";
    buf += $"X: {grid.BallX}, Y: {grid.BallY}\n";
    grid.Update();
    foreach (var line in grid.Draw())
    {
        buf += line;
    }

    Console.WriteLine("\e[H\e[2J\e[3J");
    Console.WriteLine(buf);
    Thread.Sleep(flags.UpdateRate);
    iter++;
}
