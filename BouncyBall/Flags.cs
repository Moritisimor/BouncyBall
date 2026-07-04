namespace BouncyBall;

public class FlagParseException(string message) : Exception(message);

public class Flags
{
    public readonly int Height;
    public readonly int Width;
    public readonly int UpdateRate;

    public Flags(string[] args)
    {
        Height = 45;
        Width = 100;
        UpdateRate = 50;

        foreach (var arg in args)
        {
            if (arg.StartsWith("--height=") || arg.StartsWith("-h="))
            {
                var keyValue = arg.Split("=");
                if (keyValue.Length != 2)
                {
                    throw new FlagParseException("Malformed flag, expected '--height=<value>'");
                }

                try
                {
                    Height = int.Parse(keyValue[1]);
                }
                catch (Exception)
                {
                    throw new FlagParseException("Height value must be an integer");
                }

                if (Height < 1)
                {
                    throw new FlagParseException("Height must be greater than 0");
                }
            }

            if (arg.StartsWith("--width=") || arg.StartsWith("-w="))
            {
                var keyValue = arg.Split("=");
                if (keyValue.Length != 2)
                {
                    throw new FlagParseException("Malformed flag, expected '--width=<value>'");
                }
                
                try
                {
                    Width = int.Parse(keyValue[1]);
                }
                catch (Exception)
                {
                    throw new FlagParseException("Width value must be an integer");
                }
                
                if (Width < 1)
                {
                    throw new FlagParseException("Width must be greater than 0");
                }
            }

            if (arg.StartsWith("--update-rate=") || arg.StartsWith("-u="))
            {
                var keyValue = arg.Split("=");
                if (keyValue.Length != 2)
                {
                    throw new FlagParseException("Malformed flag, expected '--update-rate=<value>'");
                }

                try
                {
                    UpdateRate = int.Parse(keyValue[1]);
                }
                catch (Exception)
                {
                    throw new FlagParseException("Update rate value must be an integer");
                }
                
                if (UpdateRate < 1)
                {
                    throw new FlagParseException("Update rate must be greater than 0");
                }
            }
        }
    }
}