using System.Drawing;

namespace NIdenticon.BlockGenerators;

public class RectangleGenerator : BlockGenerator
{
    public override bool IsSymmetric => true;

    public RectangleGenerator(int weight)
        : base(weight) { }

    public override void Draw(Graphics g, Rectangle r, Brush bg, Brush fg, uint seed, bool fliphorizontal)
    {
        if (seed % 2 == 0)
        {
            g.FillRectangle(fg, r);
        }
    }
}
