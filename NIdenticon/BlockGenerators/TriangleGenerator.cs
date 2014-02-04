using System.Drawing;

namespace Devcorner.NIdenticon.BlockGenerators
{
    public class TriangleGenerator : BlockGenerator
    {
        public override bool IsSymmetric
        {
            get { return false; }
        }

        public TriangleGenerator(int weight)
            : base(weight) { }

        public override void Draw(Graphics g, Rectangle r, Brush bg, Brush fg, uint seed, bool fliphorizontal)
        {
            var t = ((int)(seed & 0xEFFF) + (fliphorizontal ? 2 : 0)) % 4;
            g.FillPolygon(fg, GetTriangle(t, r));
        }

        private Point[] GetTriangle(int type, Rectangle r)
        {
            switch (type)
            {
                case 0: //  ◢
                    return new[] {
                        new Point(r.Left, r.Bottom),
                        new Point(r.Right, r.Top),
                        new Point(r.Right, r.Bottom)
                    };
                case 1: //  ◤
                    return new[] {
                        new Point(r.Left, r.Top),
                        new Point(r.Right, r.Top),
                        new Point(r.Left, r.Bottom)
                    };
                case 2: //  ◣
                    return new[] {
                        new Point(r.Left, r.Top),
                        new Point(r.Right, r.Bottom),
                        new Point(r.Left, r.Bottom)
                    };
                case 3: //  ◥
                default:
                    return new[] {
                        new Point(r.Left, r.Top),
                        new Point(r.Right, r.Top),
                        new Point(r.Right, r.Bottom)
                    };
            }
        }
    }
}
