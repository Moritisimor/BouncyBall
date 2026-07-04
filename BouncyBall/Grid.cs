namespace BouncyBall;

public class Grid
{
    private readonly List<List<bool>> _internalGrid = [];
    private bool _movingUp;
    private bool _movingRight;
    
    public int BallX;
    public int BallY;
    
    private readonly int _width;
    private readonly int _height;

    public Grid(int width = 150, int height = 50)
    {
        BallY = 0;
        BallX = 0;
        _movingUp = false;
        _movingRight = true;

        _width = width;
        _height = height;

        foreach (var _ in Enumerable.Range(0, _height))
        {
            _internalGrid.Add(Enumerable.Repeat(false, _width).ToList());
        }
    }

    public List<string> Draw()
    {
        List<string> lines = [];
        foreach (var _ in Enumerable.Range(0, _width + 1))
        {
            lines.Add("-");
        }

        lines.Add("\n");
        foreach (var row in _internalGrid)
        {
            lines.Add("|");
            foreach (var cell in row)
            {
                lines.Add(cell ? "O" : " ");
            }

            lines.Add("|\n");
        }

        foreach (var _ in Enumerable.Range(0, _width + 1))
        {
            lines.Add("-");
        }

        return lines;
    }

    public void Update()
    {
        var oldY = BallY;
        var oldX = BallX;

        if (BallY == 0)
        {
            _movingUp = false;
        }

        if (BallX == 0)
        {
            _movingRight = true;
        }

        if (BallX == _width - 1)
        {
            _movingRight = false;
        }

        if (BallY == _height - 1)
        {
            _movingUp = true;
        }

        if (_movingUp)
        {
            BallY--;
        }
        else
        {
            BallY++;
        }

        if (_movingRight)
        {
            BallX++;
        }
        else
        {
            BallX--;
        }

        _internalGrid[oldY][oldX] = false;
        _internalGrid[BallY][BallX] = true;
    }
}
