using System.Drawing;

namespace Devcorner.NIdenticon.BrushGenerators
{
    public class RandomColorBrushGenerator : IBrushGenerator
    {
        public Brush GetBrush(uint seed)
        {
            unchecked
            {
                return new SolidBrush(Color.FromArgb((int)seed));
            }
        }
    }
}
