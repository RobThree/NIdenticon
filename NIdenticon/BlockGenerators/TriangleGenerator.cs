using System.Drawing;

namespace NIdenticon.BlockGenerators;

public class TriangleGenerator : BlockGenerator
{
    public override bool IsSymmetric => false;

    public TriangleGenerator(int weight)
        : base(weight) { }

    public override void Draw(Graphics g, Rectangle r, Brush bg, Brush fg, uint seed, bool fliphorizontal)
    {
        var t = ((int)(seed & 0xEFFF) + (fliphorizontal ? 2 : 0)) % 4;
        g.FillPolygon(fg, GetTriangle(t, r));
    }

    private static Point[] GetTriangle(int type, Rectangle r)
        => type switch
        {
            //  ◢
            0 => new[] {
                    new Point(r.Left, r.Bottom),
                    new Point(r.Right, r.Top),
                    new Point(r.Right, r.Bottom)
                },
            //  ◤
            1 => new[] {
                    new Point(r.Left, r.Top),
                    new Point(r.Right, r.Top),
                    new Point(r.Left, r.Bottom)
                },
            //  ◣
            2 => new[] {
                    new Point(r.Left, r.Top),
                    new Point(r.Right, r.Bottom),
                    new Point(r.Left, r.Bottom)
                },
            //  ◥
            _ => new[] {
                    new Point(r.Left, r.Top),
                    new Point(r.Right, r.Top),
                    new Point(r.Right, r.Bottom)
                },
        };
}
