using Devcorner.NIdenticon.BlockGenerators;
using Devcorner.NIdenticon.BrushGenerators;
using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Devcorner.NIdenticon
{
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
        public static IBlockGenerator[] DefaultBlockGeneratorsConfig = new IBlockGenerator[] {
            new RectangleGenerator(1)
        };

        public static IBlockGenerator[] ExtendedBlockGeneratorsConfig = new IBlockGenerator[] {
            new RectangleGenerator(60),
            new TriangleGenerator(30),
            new RotatedRectangleGenerator(5),
            new PieGenerator(5),
        };

        public static IBrushGenerator DefaultBrushGeneratorConfig = new RandomColorBrushGenerator();

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
            : this(algorithm, size, defaultBackgroundColor, defaultBlocks, encoding, IdenticonGenerator.DefaultBlockGeneratorsConfig) { }

        public IdenticonGenerator(string algorithm, Size size, Color defaultBackgroundColor, Size defaultBlocks, Encoding encoding, IBlockGenerator[] blockGenerators)
            : this(algorithm, size, defaultBackgroundColor, defaultBlocks, encoding, blockGenerators, IdenticonGenerator.DefaultBrushGeneratorConfig) { }

        public IdenticonGenerator(string algorithm, Size size, Color defaultBackgroundColor, Size defaultBlocks, Encoding encoding, IBlockGenerator[] blockGenerators, IBrushGenerator brushGenerator)
        {
            this.DefaultAlgorithm = algorithm;
            this.DefaultSize = size;
            this.DefaultBackgroundColor = defaultBackgroundColor;
            this.DefaultBlocks = defaultBlocks;
            this.DefaultEncoding = encoding;
            this.DefaultBlockGenerators = blockGenerators;
            this.DefaultBrushGenerator = brushGenerator;
        }

        public Bitmap Create(string value)
        {
            return this.Create(value, this.DefaultSize);
        }

        public Bitmap Create(string value, Size size)
        {
            return this.Create(value, size, this.DefaultBackgroundColor);
        }

        public Bitmap Create(string value, Size size, Color backgroundcolor)
        {
            return this.Create(value, size, backgroundcolor, this.DefaultBlocks);
        }

        public Bitmap Create(string value, Size size, Color backgroundcolor, Size blocks)
        {
            return this.Create(value, size, backgroundcolor, blocks, this.DefaultEncoding);
        }

        public Bitmap Create(string value, Size size, Color backgroundcolor, Size blocks, Encoding encoding)
        {
            return this.Create(value, size, backgroundcolor, blocks, encoding, this.DefaultBlockGenerators);
        }

        public Bitmap Create(string value, Size size, Color backgroundcolor, Size blocks, Encoding encoding, IBlockGenerator[] blockGenerators)
        {
            return this.Create(value, size, backgroundcolor, blocks, encoding, blockGenerators, this.DefaultBrushGenerator);
        }

        public Bitmap Create(string value, Size size, Color backgroundcolor, Size blocks, Encoding encoding, IBlockGenerator[] blockGenerators, IBrushGenerator brushGenerator)
        {
            return this.Create(value, size, backgroundcolor, blocks, encoding, blockGenerators, brushGenerator, this.DefaultAlgorithm);
        }

        public Bitmap Create(string value, Size size, Color backgroundcolor, Size blocks, Encoding encoding, IBlockGenerator[] blockGenerators, IBrushGenerator brushGenerator, string algorithm)
        {
            if (this.DefaultEncoding == null)
                throw new ArgumentNullException("encoding");

            return this.Create(encoding.GetBytes(value ?? string.Empty), size, backgroundcolor, blocks, blockGenerators, brushGenerator);
        }

        public Bitmap Create(IPAddress ipaddress)
        {
            return this.Create(ipaddress, this.DefaultSize);
        }

        public Bitmap Create(IPAddress ipaddress, Size size)
        {
            return this.Create(ipaddress, size, this.DefaultBackgroundColor);
        }

        public Bitmap Create(IPAddress ipaddress, Size size, Color backgroundcolor)
        {
            return this.Create(ipaddress, size, backgroundcolor, this.DefaultBlocks);
        }

        public Bitmap Create(IPAddress ipaddress, Size size, Color backgroundcolor, Size blocks)
        {
            return this.Create(ipaddress, size, backgroundcolor, blocks, this.DefaultBlockGenerators);
        }

        public Bitmap Create(IPAddress ipaddress, Size size, Color backgroundcolor, Size blocks, IBlockGenerator[] blockGenerators)
        {
            return this.Create(ipaddress, size, backgroundcolor, blocks, blockGenerators, this.DefaultBrushGenerator);
        }

        public Bitmap Create(IPAddress ipaddress, Size size, Color backgroundcolor, Size blocks, IBlockGenerator[] blockGenerators, IBrushGenerator brushGenerator)
        {
            return this.Create(ipaddress, size, backgroundcolor, blocks, blockGenerators, brushGenerator, this.DefaultAlgorithm);
        }

        public Bitmap Create(IPAddress ipaddress, Size size, Color backgroundcolor, Size blocks, IBlockGenerator[] blockGenerators, IBrushGenerator brushGenerator, string algorithm)
        {
            if (ipaddress == null)
                throw new ArgumentNullException("ipaddress");

            return this.Create(ipaddress.GetAddressBytes(), size, backgroundcolor, blocks, blockGenerators, brushGenerator, algorithm);
        }

        public Bitmap Create(byte[] value)
        {
            return this.Create(value, this.DefaultSize);
        }

        public Bitmap Create(byte[] value, Size size)
        {
            return this.Create(value, size, this.DefaultBackgroundColor);
        }

        public Bitmap Create(byte[] value, Size size, Color backgroundcolor)
        {
            return this.Create(value, size, backgroundcolor, this.DefaultBlocks);
        }

        public Bitmap Create(byte[] value, Size size, Color backgroundcolor, Size blocks)
        {
            return this.Create(value, size, backgroundcolor, blocks, this.DefaultBlockGenerators);
        }

        public Bitmap Create(byte[] value, Size size, Color backgroundcolor, Size blocks, IBlockGenerator[] blockGenerators)
        {
            return this.Create(value, size, backgroundcolor, blocks, blockGenerators, this.DefaultBrushGenerator);
        }

        public Bitmap Create(byte[] value, Size size, Color backgroundcolor, Size blocks, IBlockGenerator[] blockGenerators, IBrushGenerator brushGenerator)
        {
            return this.Create(value, size, backgroundcolor, blocks, blockGenerators, brushGenerator, this.DefaultAlgorithm);
        }

        public Bitmap Create(byte[] value, Size size, Color backgroundcolor, Size blocks, IBlockGenerator[] blockGenerators, IBrushGenerator brushGenerator, string algorithm)
        {
            var ha = HashAlgorithm.Create(algorithm);
            if (ha == null)
                throw new ArgumentOutOfRangeException(string.Format("Unknown algorithm '{0}'", algorithm));

            if (blocks.Width < 1)
                throw new ArgumentOutOfRangeException("blockshorizontal");
            if (blocks.Height < 1)
                throw new ArgumentOutOfRangeException("blocksvertical");

            if (size.Width <= 0)
                throw new ArgumentOutOfRangeException("width");
            if (size.Height <= 0)
                throw new ArgumentOutOfRangeException("height");

            if (blockGenerators.Length == 0)
                throw new ArgumentException("blockgenerators");

            if (blockGenerators.Any(b => b == null))
                throw new ArgumentNullException("blockgenerators");

            size.Width -= size.Width % blocks.Width;
            size.Height -= size.Height % blocks.Height;

            if (size.Width <= 0)
                throw new ArgumentOutOfRangeException("width after rounding to nearest value");
            if (size.Height <= 0)
                throw new ArgumentOutOfRangeException("height after rounding to nearest value");

            bool hasunevencols = blocks.Width % 2 != 0;
            var allblockgens = blockGenerators.ToArray();
            var symblockgens = blockGenerators.Where(sbg => sbg.IsSymmetric).ToArray();

            if (hasunevencols && symblockgens.Length==0)
                throw new Exception("At least one symmetrical blockgenerator required for identicons with uneven number of horizontal blocks");

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
                int hashlen = hash.Length;
                int i = 0;
                int halfwidth = blocks.Width / 2;
                for (var x = 0; x < (hasunevencols ? halfwidth+1 : halfwidth); x++)
                {
                    for (var y = 0; y < blocks.Height; y++, i++)
                    {
                        var blockgen = GetBlockGenerator((x == halfwidth && hasunevencols) ? symblockgens : allblockgens, hash[i % hashlen]);
                        var seed = BitConverter.ToUInt32(dhash, i % hashlen);

                        using (var fgbrush = brushGenerator.GetBrush(seed))
                        {
                            Rectangle rl = new Rectangle(x * blockwidth, y * blockheight, blockwidth, blockheight);
                            blockgen.Draw(gfx, rl, bgbrush, fgbrush, seed, false);

                            if ((x != halfwidth) || ((x==halfwidth) && !hasunevencols))
                            {
                                Rectangle rr = new Rectangle((size.Width - blockwidth) - (x * blockwidth), y * blockheight, blockwidth, blockheight);
                                blockgen.Draw(gfx, rr, bgbrush, fgbrush, seed, true);
                            }
                        }
                    }
                }
            }
            return result;
        }

        private IBlockGenerator GetBlockGenerator(IBlockGenerator[] generators, byte seed)
        {
            var totalweight = generators.Sum(w => w.Weight);
            var f = ((double)totalweight / 256);
            //Determine which generator to use
            var r = seed * f;   //Determine "random" number from hash from 0 .. totalweight
            int g = -1;
            while (r >= 0)
                r -= generators[++g].Weight;
            return generators[g];
        }

        public IdenticonGenerator WithAlgorithm(string algorithm)
        {
            this.DefaultAlgorithm = algorithm;
            return this;
        }

        public IdenticonGenerator WithSize(int width, int height)
        {
            return this.WithSize(new Size(width, height));
        }

        public IdenticonGenerator WithSize(Size size)
        {
            this.DefaultSize = size;
            return this;
        }

        public IdenticonGenerator WithBlocks(int horizontal, int vertical)
        {
            return this.WithBlocks(new Size(horizontal, vertical));
        }

        public IdenticonGenerator WithBlocks(Size size)
        {
            this.DefaultBlocks = size;
            return this;
        }

        public IdenticonGenerator WithEncoding(Encoding encoding)
        {
            this.DefaultEncoding = encoding;
            return this;
        }

        public IdenticonGenerator WithBackgroundColor(Color color)
        {
            this.DefaultBackgroundColor = color;
            return this;
        }

        public IdenticonGenerator WithBlockGenerators(IBlockGenerator[] blockGenerators)
        {
            this.DefaultBlockGenerators = blockGenerators;
            return this;
        }

        public IdenticonGenerator WithBrushGenerator(IBrushGenerator brushGenerator)
        {
            this.DefaultBrushGenerator = brushGenerator;
            return this;
        }
    }
}
