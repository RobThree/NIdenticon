using System.Drawing;

namespace NIdenticon.BrushGenerators;

public interface IBrushGenerator
{
    Brush GetBrush(uint seed);
}
