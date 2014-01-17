using System.Drawing;

namespace Devcorner.NIdenticon.BrushGenerators
{
    public interface IBrushGenerator
    {
        Brush GetBrush(uint seed);
    }
}
