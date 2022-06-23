using System.Drawing;

namespace NIdenticon.BlockGenerators;

public abstract class BlockGenerator : IBlockGenerator
{
    public int Weight { get; private set; }
    public abstract bool IsSymmetric { get; }

    public BlockGenerator(int weight) => Weight = weight;

    public abstract void Draw(Graphics g, Rectangle r, Brush bg, Brush fg, uint seed, bool fliphorizontal);
}
