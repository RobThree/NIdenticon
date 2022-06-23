using System.Drawing;

namespace NIdenticon.BrushGenerators;

public class RandomColorBrushGenerator : IBrushGenerator
{
    public Brush GetBrush(uint seed)
    {
        unchecked
        {
            return new SolidBrush(Color.FromArgb(255, Color.FromArgb((int)seed)));
        }
    }
}