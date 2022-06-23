using NIdenticon.BlockGenerators;
using NIdenticon.BrushGenerators;
using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace NIdenticon;

//*
// Inspired by:
// * https://github.com/blog/1586-identicons
// * http://www.davidhampgonsalves.com/Identicons/
// * http://haacked.com/archive/2007/01/22/Identicons_as_Visual_Fingerprints.aspx/
// * http://www.codinghorror.com/blog/2007/01/identicons-for-net.html
// See also: http://en.wikipedia.org/wiki/Identicon
//*


/// <summary>
/// 
/// </summary>
public class IdenticonGenerator
{
    public static readonly IBlockGenerator[] DefaultBlockGeneratorsConfig = new IBlockGenerator[] {
        new RectangleGenerator(1)
    };

    public static readonly IBlockGenerator[] ExtendedBlockGeneratorsConfig = new IBlockGenerator[] {
        new RectangleGenerator(60),
        new TriangleGenerator(30),
        new RotatedRectangleGenerator(5),
        new PieGenerator(5),
    };

    public static readonly IBrushGenerator DefaultBrushGeneratorConfig = new RandomColorBrushGenerator();

    public string DefaultAlgorithm { get; set; }
    public Size DefaultSize { get; set; }
    public Size DefaultBlocks { get; set; }
    public Encoding DefaultEncoding { get; set; }
    public Color DefaultBackgroundColor { get; set; }
    public IBlockGenerator[] DefaultBlockGenerators { get; set; }
    public IBrushGenerator DefaultBrushGenerator { get; set; }

    public IdenticonGenerator()
        : this("SHA512") { }

    public IdenticonGenerator(string algorithm)
        : this(algorithm, new Size(400, 400)) { }

    public IdenticonGenerator(string algorithm, Size size)
        : this(algorithm, size, Color.Transparent) { }

    public IdenticonGenerator(string algorithm, Size size, Color defaultBackgroundColor)
        : this(algorithm, size, defaultBackgroundColor, new Size(6, 6)) { }

    public IdenticonGenerator(string algorithm, Size size, Color defaultBackgroundColor, Size defaultBlocks)
        : this(algorithm, size, defaultBackgroundColor, defaultBlocks, Encoding.UTF8) { }

    public IdenticonGenerator(string algorithm, Size size, Color defaultBackgroundColor, Size defaultBlocks, Encoding encoding)
        : this(algorithm, size, defaultBackgroundColor, defaultBlocks, encoding, DefaultBlockGeneratorsConfig) { }

    public IdenticonGenerator(string algorithm, Size size, Color defaultBackgroundColor, Size defaultBlocks, Encoding encoding, IBlockGenerator[] blockGenerators)
        : this(algorithm, size, defaultBackgroundColor, defaultBlocks, encoding, blockGenerators, DefaultBrushGeneratorConfig) { }

    public IdenticonGenerator(string algorithm, Size size, Color defaultBackgroundColor, Size defaultBlocks, Encoding encoding, IBlockGenerator[] blockGenerators, IBrushGenerator brushGenerator)
    {
        DefaultAlgorithm = algorithm;
        DefaultSize = size;
        DefaultBackgroundColor = defaultBackgroundColor;
        DefaultBlocks = defaultBlocks;
        DefaultEncoding = encoding;
        DefaultBlockGenerators = blockGenerators;
        DefaultBrushGenerator = brushGenerator;
    }

    public Bitmap Create(string value) => Create(value, DefaultSize);

    public Bitmap Create(string value, Size size) => Create(value, size, DefaultBackgroundColor);

    public Bitmap Create(string value, Size size, Color backgroundcolor) => Create(value, size, backgroundcolor, DefaultBlocks);

    public Bitmap Create(string value, Size size, Color backgroundcolor, Size blocks) => Create(value, size, backgroundcolor, blocks, DefaultEncoding);

    public Bitmap Create(string value, Size size, Color backgroundcolor, Size blocks, Encoding encoding) => Create(value, size, backgroundcolor, blocks, encoding, DefaultBlockGenerators);

    public Bitmap Create(string value, Size size, Color backgroundcolor, Size blocks, Encoding encoding, IBlockGenerator[] blockGenerators) => Create(value, size, backgroundcolor, blocks, encoding, blockGenerators, DefaultBrushGenerator);

    public Bitmap Create(string value, Size size, Color backgroundcolor, Size blocks, Encoding encoding, IBlockGenerator[] blockGenerators, IBrushGenerator brushGenerator) => Create(value, size, backgroundcolor, blocks, encoding, blockGenerators, brushGenerator, DefaultAlgorithm);

    public Bitmap Create(string value, Size size, Color backgroundcolor, Size blocks, Encoding encoding, IBlockGenerator[] blockGenerators, IBrushGenerator brushGenerator, string algorithm)
        => DefaultEncoding == null
        ? throw new ArgumentNullException(nameof(encoding))
        : IdenticonGenerator.Create(encoding.GetBytes(value ?? string.Empty), size, backgroundcolor, blocks, blockGenerators, brushGenerator, algorithm);

    public Bitmap Create(IPAddress ipaddress) => Create(ipaddress, DefaultSize);

    public Bitmap Create(IPAddress ipaddress, Size size) => Create(ipaddress, size, DefaultBackgroundColor);

    public Bitmap Create(IPAddress ipaddress, Size size, Color backgroundcolor) => Create(ipaddress, size, backgroundcolor, DefaultBlocks);

    public Bitmap Create(IPAddress ipaddress, Size size, Color backgroundcolor, Size blocks) => Create(ipaddress, size, backgroundcolor, blocks, DefaultBlockGenerators);

    public Bitmap Create(IPAddress ipaddress, Size size, Color backgroundcolor, Size blocks, IBlockGenerator[] blockGenerators) => Create(ipaddress, size, backgroundcolor, blocks, blockGenerators, DefaultBrushGenerator);

    public Bitmap Create(IPAddress ipaddress, Size size, Color backgroundcolor, Size blocks, IBlockGenerator[] blockGenerators, IBrushGenerator brushGenerator) => IdenticonGenerator.Create(ipaddress, size, backgroundcolor, blocks, blockGenerators, brushGenerator, DefaultAlgorithm);

    public static Bitmap Create(IPAddress ipaddress, Size size, Color backgroundcolor, Size blocks, IBlockGenerator[] blockGenerators, IBrushGenerator brushGenerator, string algorithm)
        => ipaddress == null
        ? throw new ArgumentNullException(nameof(ipaddress))
        : IdenticonGenerator.Create(ipaddress.GetAddressBytes(), size, backgroundcolor, blocks, blockGenerators, brushGenerator, algorithm);

    public Bitmap Create(byte[] value) => Create(value, DefaultSize);

    public Bitmap Create(byte[] value, Size size) => Create(value, size, DefaultBackgroundColor);

    public Bitmap Create(byte[] value, Size size, Color backgroundcolor) => Create(value, size, backgroundcolor, DefaultBlocks);

    public Bitmap Create(byte[] value, Size size, Color backgroundcolor, Size blocks) => Create(value, size, backgroundcolor, blocks, DefaultBlockGenerators);

    public Bitmap Create(byte[] value, Size size, Color backgroundcolor, Size blocks, IBlockGenerator[] blockGenerators) => Create(value, size, backgroundcolor, blocks, blockGenerators, DefaultBrushGenerator);

    public Bitmap Create(byte[] value, Size size, Color backgroundcolor, Size blocks, IBlockGenerator[] blockGenerators, IBrushGenerator brushGenerator) => IdenticonGenerator.Create(value, size, backgroundcolor, blocks, blockGenerators, brushGenerator, DefaultAlgorithm);

    public static Bitmap Create(byte[] value, Size size, Color backgroundcolor, Size blocks, IBlockGenerator[] blockGenerators, IBrushGenerator brushGenerator, string algorithm)
    {
        var ha = (HashAlgorithm)CryptoConfig.CreateFromName(algorithm);
        if (ha == null)
        {
            throw new ArgumentOutOfRangeException(string.Format("Unknown algorithm '{0}'", algorithm));
        }

        if (blocks.Width < 1)
        {
            throw new ArgumentOutOfRangeException("blockshorizontal");
        }

        if (blocks.Height < 1)
        {
            throw new ArgumentOutOfRangeException("blocksvertical");
        }

        if (size.Width <= 0)
        {
            throw new ArgumentOutOfRangeException("width");
        }

        if (size.Height <= 0)
        {
            throw new ArgumentOutOfRangeException("height");
        }

        if (blockGenerators.Length == 0)
        {
            throw new ArgumentException("blockgenerators");
        }

        if (blockGenerators.Any(b => b == null))
        {
            throw new ArgumentNullException("blockgenerators");
        }

        size.Width -= size.Width % blocks.Width;
        size.Height -= size.Height % blocks.Height;

        if (size.Width <= 0)
        {
            throw new ArgumentOutOfRangeException("width after rounding to nearest value");
        }

        if (size.Height <= 0)
        {
            throw new ArgumentOutOfRangeException("height after rounding to nearest value");
        }

        var hasunevencols = blocks.Width % 2 != 0;
        var allblockgens = blockGenerators.ToArray();
        var symblockgens = blockGenerators.Where(sbg => sbg.IsSymmetric).ToArray();

        if (hasunevencols && symblockgens.Length == 0)
        {
            throw new Exception("At least one symmetrical blockgenerator required for identicons with uneven number of horizontal blocks");
        }

        ha.Initialize();
        var hash = ha.ComputeHash(value);
        var blockwidth = (int)Math.Ceiling((double)size.Width / blocks.Width);
        var blockheight = (int)Math.Ceiling((double)size.Height / blocks.Height);


        var result = new Bitmap(size.Width, size.Height);
        using (var bgbrush = new SolidBrush(backgroundcolor))
        using (var gfx = Graphics.FromImage(result))
        {
            gfx.FillRectangle(bgbrush, 0, 0, size.Width, size.Height);

            var dhash = hash.Concat(hash).ToArray();
            var hashlen = hash.Length;
            var i = 0;
            var halfwidth = blocks.Width / 2;
            for (var x = 0; x < (hasunevencols ? halfwidth + 1 : halfwidth); x++)
            {
                for (var y = 0; y < blocks.Height; y++, i++)
                {
                    var blockgen = IdenticonGenerator.GetBlockGenerator(x == halfwidth && hasunevencols ? symblockgens : allblockgens, hash[i % hashlen]);
                    var seed = BitConverter.ToUInt32(dhash, i % hashlen);

                    using var fgbrush = brushGenerator.GetBrush(seed);
                    var rl = new Rectangle(x * blockwidth, y * blockheight, blockwidth, blockheight);
                    blockgen.Draw(gfx, rl, bgbrush, fgbrush, seed, false);

                    if (x != halfwidth || (x == halfwidth && !hasunevencols))
                    {
                        var rr = new Rectangle(size.Width - blockwidth - (x * blockwidth), y * blockheight, blockwidth, blockheight);
                        blockgen.Draw(gfx, rr, bgbrush, fgbrush, seed, true);
                    }
                }
            }
        }
        return result;
    }

    private static IBlockGenerator GetBlockGenerator(IBlockGenerator[] generators, byte seed)
    {
        var totalweight = generators.Sum(w => w.Weight);
        var f = (double)totalweight / 256;
        //Determine which generator to use
        var r = seed * f;   //Determine "random" number from hash from 0 .. totalweight
        var g = -1;
        while (r >= 0)
        {
            r -= generators[++g].Weight;
        }

        return generators[g];
    }

    public IdenticonGenerator WithAlgorithm(string algorithm)
    {
        DefaultAlgorithm = algorithm;
        return this;
    }

    public IdenticonGenerator WithSize(int width, int height) => WithSize(new Size(width, height));

    public IdenticonGenerator WithSize(Size size)
    {
        DefaultSize = size;
        return this;
    }

    public IdenticonGenerator WithBlocks(int horizontal, int vertical) => WithBlocks(new Size(horizontal, vertical));

    public IdenticonGenerator WithBlocks(Size size)
    {
        DefaultBlocks = size;
        return this;
    }

    public IdenticonGenerator WithEncoding(Encoding encoding)
    {
        DefaultEncoding = encoding;
        return this;
    }

    public IdenticonGenerator WithBackgroundColor(Color color)
    {
        DefaultBackgroundColor = color;
        return this;
    }

    public IdenticonGenerator WithBlockGenerators(IBlockGenerator[] blockGenerators)
    {
        DefaultBlockGenerators = blockGenerators;
        return this;
    }

    public IdenticonGenerator WithBrushGenerator(IBrushGenerator brushGenerator)
    {
        DefaultBrushGenerator = brushGenerator;
        return this;
    }
}
