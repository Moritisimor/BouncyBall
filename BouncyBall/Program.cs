using System.Text;
using BouncyBall;

Flags flags;
try
{
    flags = new Flags(args);
}
catch (FlagParseException e)
{
    Console.WriteLine($"Error while parsing flags: {e.Message}");
    Environment.Exit(1);
    return;
}

var grid = new Grid(flags.Width, flags.Height);
var iter = 0;

while (true)
{
    var builder = new StringBuilder();
    builder.Append($"X: {grid.BallX} Y: {grid.BallY} Corner hits: {grid.CornerHits}\n");
    builder.Append($"Iteration: {iter}\n");
    
    grid.Update();
    builder.Append(grid.Draw());
    
    Console.WriteLine("\e[H\e[2J\e[3J\n");
    Console.WriteLine(builder.ToString());
    Thread.Sleep(flags.UpdateRate);
    iter++;
}
