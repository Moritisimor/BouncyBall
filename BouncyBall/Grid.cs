using System.Text;

namespace BouncyBall;

public class Grid
{
    private readonly List<List<bool>> _internalGrid = [];
    private bool _movingUp;
    private bool _movingRight;
    
    public int BallX { get; private set; }
    public int BallY { get; private set; }
    
    public int CornerHits { get; private set; }
    
    private readonly int _width;
    private readonly int _height;

    public Grid(int width = 150, int height = 50)
    {
        BallY = 0;
        BallX = 0;
        CornerHits = -1; // Starts at -1 because the first hit is the initial position of the ball.
        
        _movingUp = false;
        _movingRight = true;

        _width = width;
        _height = height;

        foreach (var _ in Enumerable.Range(0, _height))
        {
            _internalGrid.Add(Enumerable.Repeat(false, _width).ToList());
        }
    }

    public string Draw()
    {
        var builder = new StringBuilder();
        foreach (var _ in Enumerable.Range(0, _width + 2))
        {
            builder.Append('-');
        }

        builder.Append('\n');
        foreach (var row in _internalGrid)
        {
            builder.Append('|');
            foreach (var cell in row)
            {
                builder.Append(cell ? 'O' : ' ');
            }

            builder.Append('|');
            builder.Append('\n');
        }

        foreach (var _ in Enumerable.Range(0, _width + 2))
        {
            builder.Append('-');
        }

        return builder.ToString();
    }

    public void Update()
    {
        var oldY = BallY;
        var oldX = BallX;

        if (BallY == 0 && BallX == 0) // Top left corner
        {
            CornerHits++;
        }
        else if (BallY == _height - 1 && BallX == _width - 1) // Bottom right corner
        {
            CornerHits++;
        }
        else if (BallY == _height - 1 && BallX == 0) // Bottom left corner
        {
            CornerHits++;
        }
        else if (BallY == 0 && BallX == _width - 1) // Top right corner
        {
            CornerHits++;
        }
        
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
