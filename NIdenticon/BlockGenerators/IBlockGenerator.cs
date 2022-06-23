﻿using System.Drawing;

namespace NIdenticon.BlockGenerators;

public interface IBlockGenerator
{
    int Weight { get; }
    void Draw(Graphics g, Rectangle r, Brush bg, Brush fg, uint seed, bool fliphorizontal);
    bool IsSymmetric { get; }
}
