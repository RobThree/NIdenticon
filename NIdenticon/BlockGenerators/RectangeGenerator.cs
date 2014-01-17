using System.Drawing;

namespace Devcorner.NIdenticon.BlockGenerators
{
    public class RectangleGenerator : BlockGenerator
    {
        public RectangleGenerator(int weight)
            : base(weight) { }

        public override void Draw(Graphics g, Rectangle r, Brush bg, Brush fg, uint seed, bool fliphorizontal)
        {
            if (seed % 2 == 0)
                g.FillRectangle(fg, r);
        }
    }
}
