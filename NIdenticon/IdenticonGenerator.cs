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
        public int DefaultWidth { get; set; }
        public int DefaultHeight { get; set; }
        public int DefaultBlocksHorizontal { get; set; }
        public int DefaultBlocksVertical { get; set; }
        public Encoding DefaultEncoding { get; set; }
        public Color DefaultBackgroundColor { get; set; }
        public IBlockGenerator[] DefaultBlockGenerators { get; set; }
        public IBrushGenerator DefaultBrushGenerator { get; set; }

        public IdenticonGenerator()
            : this("SHA512") { }

        public IdenticonGenerator(string algorithm)
            : this(algorithm, 400, 400) { }

        public IdenticonGenerator(string algorithm, int defaultWidth, int defaultHeight)
            : this(algorithm, defaultWidth, defaultHeight, Color.Transparent) { }

        public IdenticonGenerator(string algorithm, int defaultWidth, int defaultHeight, Color defaultBackgroundColor)
            : this(algorithm, defaultWidth, defaultHeight, defaultBackgroundColor, 5, 5) { }

        public IdenticonGenerator(string algorithm, int defaultWidth, int defaultHeight, Color defaultBackgroundColor, int defaultBlocksHorizontal, int defaultBlocksVertical)
            : this(algorithm, defaultWidth, defaultHeight, defaultBackgroundColor, defaultBlocksHorizontal, defaultBlocksVertical, Encoding.UTF8) { }

        public IdenticonGenerator(string algorithm, int defaultWidth, int defaultHeight, Color defaultBackgroundColor, int defaultBlocksHorizontal, int defaultBlocksVertical, Encoding encoding)
            : this(algorithm, defaultWidth, defaultHeight, defaultBackgroundColor, defaultBlocksHorizontal, defaultBlocksVertical, encoding, IdenticonGenerator.DefaultBlockGeneratorsConfig) { }

        public IdenticonGenerator(string algorithm, int defaultWidth, int defaultHeight, Color defaultBackgroundColor, int defaultBlocksHorizontal, int defaultBlocksVertical, Encoding encoding, IBlockGenerator[] blockgenerators)
            : this(algorithm, defaultWidth, defaultHeight, defaultBackgroundColor, defaultBlocksHorizontal, defaultBlocksVertical, encoding, blockgenerators, IdenticonGenerator.DefaultBrushGeneratorConfig) { }

        public IdenticonGenerator(string algorithm, int defaultWidth, int defaultHeight, Color defaultBackgroundColor, int defaultBlocksHorizontal, int defaultBlocksVertical, Encoding encoding, IBlockGenerator[] blockgenerators, IBrushGenerator brushgenerator)
        {
            this.DefaultAlgorithm = algorithm;
            this.DefaultWidth = defaultWidth;
            this.DefaultHeight = defaultHeight;
            this.DefaultBackgroundColor = defaultBackgroundColor;
            this.DefaultBlocksHorizontal = defaultBlocksHorizontal;
            this.DefaultBlocksVertical = defaultBlocksVertical;
            this.DefaultEncoding = encoding;
            this.DefaultBlockGenerators = blockgenerators;
            this.DefaultBrushGenerator = brushgenerator;
        }

        public Bitmap Create(string value)
        {
            return this.Create(value, this.DefaultWidth, this.DefaultHeight);
        }

        public Bitmap Create(string value, int width, int height)
        {
            return this.Create(value, width, height, this.DefaultBackgroundColor);
        }

        public Bitmap Create(string value, int width, int height, Color backgroundcolor)
        {
            return this.Create(value, width, height, backgroundcolor, this.DefaultBlocksHorizontal, this.DefaultBlocksVertical);
        }

        public Bitmap Create(string value, int width, int height, Color backgroundcolor, int blockshorizontal, int blocksvertical)
        {
            return this.Create(value, width, height, backgroundcolor, blockshorizontal, blocksvertical, this.DefaultEncoding);
        }

        public Bitmap Create(string value, int width, int height, Color backgroundcolor, int blockshorizontal, int blocksvertical, Encoding encoding)
        {
            return this.Create(value, width, height, backgroundcolor, blockshorizontal, blocksvertical, encoding, this.DefaultBlockGenerators);
        }

        public Bitmap Create(string value, int width, int height, Color backgroundcolor, int blockshorizontal, int blocksvertical, Encoding encoding, IBlockGenerator[] blockgenerators)
        {
            return this.Create(value, width, height, backgroundcolor, blockshorizontal, blocksvertical, encoding, blockgenerators, this.DefaultBrushGenerator);
        }

        public Bitmap Create(string value, int width, int height, Color backgroundcolor, int blockshorizontal, int blocksvertical, Encoding encoding, IBlockGenerator[] blockgenerators, IBrushGenerator brushgenerator)
        {
            if (this.DefaultEncoding == null)
                throw new ArgumentNullException("encoding");

            return this.Create(encoding.GetBytes(value), width, height, backgroundcolor, blockshorizontal, blocksvertical, blockgenerators, brushgenerator);
        }

        public Bitmap Create(IPAddress ipaddress)
        {
            return this.Create(ipaddress, this.DefaultWidth, this.DefaultHeight);
        }

        public Bitmap Create(IPAddress ipaddress, int width, int height)
        {
            return this.Create(ipaddress, width, height, this.DefaultBackgroundColor);
        }

        public Bitmap Create(IPAddress ipaddress, int width, int height, Color backgroundcolor)
        {
            return this.Create(ipaddress, width, height, backgroundcolor, this.DefaultBlocksHorizontal, this.DefaultBlocksVertical);
        }

        public Bitmap Create(IPAddress ipaddress, int width, int height, Color backgroundcolor, int blockshorizontal, int blocksvertical)
        {
            return this.Create(ipaddress, width, height, backgroundcolor, blockshorizontal, blocksvertical, this.DefaultBlockGenerators);
        }

        public Bitmap Create(IPAddress ipaddress, int width, int height, Color backgroundcolor, int blockshorizontal, int blocksvertical, IBlockGenerator[] blockgenerators)
        {
            return this.Create(ipaddress, width, height, backgroundcolor, blockshorizontal, blocksvertical, blockgenerators, this.DefaultBrushGenerator);
        }

        public Bitmap Create(IPAddress ipaddress, int width, int height, Color backgroundcolor, int blockshorizontal, int blocksvertical, IBlockGenerator[] blockgenerators, IBrushGenerator brushgenerator)
        {
            if (ipaddress == null)
                throw new ArgumentNullException("ipaddress");

            return this.Create(ipaddress.GetAddressBytes(), width, height, backgroundcolor, blockshorizontal, blocksvertical, blockgenerators, brushgenerator);
        }

        public Bitmap Create(byte[] value)
        {
            return this.Create(value, this.DefaultWidth, this.DefaultHeight);
        }

        public Bitmap Create(byte[] value, int width, int height)
        {
            return this.Create(value, width, height, this.DefaultBackgroundColor);
        }

        public Bitmap Create(byte[] value, int width, int height, Color backgroundcolor)
        {
            return this.Create(value, width, height, backgroundcolor, this.DefaultBlocksHorizontal, this.DefaultBlocksVertical);
        }

        public Bitmap Create(byte[] value, int width, int height, Color backgroundcolor, int blockshorizontal, int blocksvertical)
        {
            return this.Create(value, width, height, backgroundcolor, blockshorizontal, blocksvertical, this.DefaultBlockGenerators);
        }

        public Bitmap Create(byte[] value, int width, int height, Color backgroundcolor, int blockshorizontal, int blocksvertical, IBlockGenerator[] blockgenerators)
        {
            return this.Create(value, width, height, backgroundcolor, blockshorizontal, blocksvertical, blockgenerators, this.DefaultBrushGenerator);
        }

        public Bitmap Create(byte[] value, int width, int height, Color backgroundcolor, int blockshorizontal, int blocksvertical, IBlockGenerator[] blockgenerators, IBrushGenerator brushgenerator)
        {
            var ha = HashAlgorithm.Create(this.DefaultAlgorithm);
            if (ha == null)
                throw new ArgumentOutOfRangeException(string.Format("Unknown algorithm '{0}'", this.DefaultAlgorithm));

            if (blockshorizontal < 2)
                throw new ArgumentOutOfRangeException("blockshorizontal");
            if (blocksvertical < 1)
                throw new ArgumentOutOfRangeException("blocksvertical");

            if (width <= 0)
                throw new ArgumentOutOfRangeException("width");
            if (height <= 0)
                throw new ArgumentOutOfRangeException("height");

            if (blockgenerators.Length == 0)
                throw new ArgumentException("blockgenerators");

            if (blockgenerators.Any(b => b == null))
                throw new ArgumentNullException("blockgenerators");

            if (blockshorizontal % 2 > 0)
                throw new ArgumentOutOfRangeException("blockshorizontal must be even");

            width -= width % blockshorizontal;
            height -= height % blockshorizontal;

            if (width <= 0)
                throw new ArgumentOutOfRangeException("width after rounding to nearest value");
            if (height <= 0)
                throw new ArgumentOutOfRangeException("height after rounding to nearest value");

            ha.Initialize();
            var hash = ha.ComputeHash(value);
            var blockwidth = (int)Math.Ceiling((double)width / blockshorizontal);
            var blockheight = (int)Math.Ceiling((double)height / blocksvertical);

            var totalweight = blockgenerators.Sum(w => w.Weight);

            var result = new Bitmap(width, height);
            using (var bgbrush = new SolidBrush(backgroundcolor))
            using (var gfx = Graphics.FromImage(result))
            {
                gfx.FillRectangle(bgbrush, 0, 0, width, height);

                var dhash = hash.Concat(hash).ToArray();
                int hl = hash.Length;
                int i = 0;
                var f = ((double)totalweight / 256);
                for (var x = 0; x < blockshorizontal / 2; x++)
                {
                    for (var y = 0; y < blocksvertical; y++, i++)
                    {
                        var r = hash[i % hl] * f;   //Determine "random" number from hash from 0 .. totalweight
                        //Determine which generator to use
                        int g = -1;
                        while (r >= 0)
                            r -= blockgenerators[++g].Weight;

                        var seed = BitConverter.ToUInt32(dhash, i % hl);

                        using (var fgbrush = brushgenerator.GetBrush(seed))
                        {
                            Rectangle rl = new Rectangle(x * blockwidth, y * blockheight, blockwidth, blockheight);
                            blockgenerators[g].Draw(gfx, rl, bgbrush, fgbrush, seed, false);

                            Rectangle rr = new Rectangle((width - blockwidth) - (x * blockwidth), y * blockheight, blockwidth, blockheight);
                            blockgenerators[g].Draw(gfx, rr, bgbrush, fgbrush, seed, true);
                        }
                    }
                }
            }
            return result;
        }
    }
}
