using BouncyBall;

var grid = new Grid();
var iter = 0;

while (true)
{
    var buf = "";
    buf += $"Iteration: {iter}\n";
    buf += $"X: {grid.BallX}, Y: {grid.BallY}\n";
    grid.Update();
    foreach (var line in grid.Draw())
        buf += line;
    
    Console.WriteLine("\e[H\e[2J\e[3J");
    Console.WriteLine(buf);
    Thread.Sleep(10);
    iter++;
}
