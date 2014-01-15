using System;
using System.Drawing;
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
        public string Algorithm { get; set; }
        public int DefaultWidth { get; set; }
        public int DefaultHeight { get; set; }
        public int DefaultBlocksHorizontal { get; set; }
        public int DefaultBlocksVertical { get; set; }
        public Encoding DefaultEncoding { get; set; }

        public Color DefaultBackgroundColor { get; set; }

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
        {
            this.Algorithm = algorithm;
            this.DefaultWidth = defaultWidth;
            this.DefaultHeight = defaultHeight;
            this.DefaultBackgroundColor = defaultBackgroundColor;
            this.DefaultBlocksHorizontal = defaultBlocksHorizontal;
            this.DefaultBlocksVertical = defaultBlocksVertical;
            this.DefaultEncoding = encoding;
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
            if (this.DefaultEncoding == null)
                throw new ArgumentNullException("encoding");

            return this.Create(encoding.GetBytes(value), width, height, backgroundcolor, blockshorizontal, blocksvertical);
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
            var ha = HashAlgorithm.Create(this.Algorithm);
            if (ha == null)
                throw new ArgumentOutOfRangeException(string.Format("Unknown algorithm '{0}'", this.Algorithm));

            if (blockshorizontal < 1)
                throw new ArgumentOutOfRangeException("blockshorizontal");
            if (blocksvertical < 1)
                throw new ArgumentOutOfRangeException("blocksvertical");

            if (width <= 0)
                throw new ArgumentOutOfRangeException("width");
            if (height <= 0)
                throw new ArgumentOutOfRangeException("height");

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

            var result = new Bitmap(width, height);
            using (var bgbrush = new SolidBrush(backgroundcolor))
            using (var fgbrush = new SolidBrush(Color.FromArgb(255, hash[0] & 255, hash[1] & 255, hash[2] & 255)))
            using (var gfx = Graphics.FromImage(result))
            {
                int i = 0;
                for (var x = 0; x <= blockshorizontal / 2; x++)
                {
                    for (var y = 0; y < blocksvertical; y++, i++)
                    {
                        var k = i % hash.Length;
                        var c = ((hash[k] >> (y % 8)) & 1) == 1 ? bgbrush : fgbrush;
                        gfx.FillRectangle(c, x * blockwidth, y * blockheight, blockwidth, blockheight);
                        gfx.FillRectangle(c, (width - blockwidth) - (x * blockwidth), y * blockheight, blockwidth, blockheight);
                    }
                }
            }
            return result;
        }
    }
}
