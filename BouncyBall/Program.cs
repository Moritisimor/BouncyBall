using BouncyBall;

Flags flags;
try
{
    flags = new Flags(args);
}
catch (FlagParseException e)
{
    Console.WriteLine(e.Message);
    Environment.Exit(1);
    return;
}

var grid = new Grid(flags.Width, flags.Height);
var iter = 0;

while (true)
{
    grid.Update();
    Console.WriteLine($"\e[H\e[2J\e[3J\nIteration: {iter}\nX: {grid.BallX}, Y: {grid.BallY}\n{grid.Draw()}");
    Thread.Sleep(flags.UpdateRate);
    iter++;
}
