using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Devcorner.NIdenticon;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Net;
using Devcorner.NIdenticon.BrushGenerators;

namespace NIdenticonTests
{
    [TestClass]
    public class Documentation
    {
        [TestMethod]
        public void GenerateExamplesForDocumentation()
        {
            var outputpath = "output";
            Directory.CreateDirectory(outputpath);

            var i = "Identicon";
            var n = "RobIII";
            var f = "foo_bar";
            var ip1 = IPAddress.Parse("192.168.1.1");
            var ip2 = IPAddress.Parse("192.168.1.2");
            var s = new Size(60, 60);
            var b = new Size(6, 6);

            using (var doc = new StreamWriter(File.Create(Path.Combine("output", "doc.md"))))
            {
                doc.WriteLine("Result | Algorithm | Value | Blockgens | Background | Blocks");
                doc.WriteLine("--- | --- | --- | --- | --- | ---");

                doc.WriteLine("![](ex00.png) | `MD5` | `" + i + "` | Extended | White | " + b.Width + "x" + b.Height);
                CreateGenString("MD5", i, false)
                    .Create(i, s, Color.White, b)
                    .Save(Path.Combine(outputpath, "ex00.png"), ImageFormat.Png);

                doc.WriteLine("![](ex01.png) | `MD5` | `" + i + "` | Extended | White | " + b.Width + "x" + b.Height);
                CreateGenString("MD5", i, true)
                    .Create(i, s, Color.White, b)
                    .Save(Path.Combine(outputpath, "ex01.png"), ImageFormat.Png);

                doc.WriteLine("![](ex02.png) | `SHA256` | `" + i + "` | Extended | White | " + b.Width + "x" + b.Height);
                CreateGenString("SHA256", i, true)
                    .Create(i, s, Color.White, b)
                    .Save(Path.Combine(outputpath, "ex02.png"), ImageFormat.Png);

                doc.WriteLine("![](ex03.png) | `SHA512` | `" + i + "` | Extended | White | " + b.Width + "x" + b.Height);
                CreateGenString("SHA512", i, true)
                    .Create(i, s, Color.White, b)
                    .Save(Path.Combine(outputpath, "ex03.png"), ImageFormat.Png);

                doc.WriteLine("![](ex04.png) | `MD5` | `" + n + "` | Extended | Transparent | " + b.Width + "x" + b.Height);
                CreateGenString("MD5", n, true)
                    .Create(n, s, Color.Transparent, b)
                    .Save(Path.Combine(outputpath, "ex04.png"), ImageFormat.Png);

                doc.WriteLine("![](ex05.png) | `RipeMD160` | `" + n + "` | Extended | Transparent | " + b.Width + "x" + b.Height);
                CreateGenString("RipeMD160", n, true)
                    .Create(n, s, Color.Transparent, b)
                    .Save(Path.Combine(outputpath, "ex05.png"), ImageFormat.Png);

                doc.WriteLine("![](ex06.png) | `SHA1` | `" + n + "` | Extended | Transparent | " + b.Width + "x" + b.Height);
                CreateGenString("SHA1", n, true)
                    .Create(n, s, Color.Transparent, b)
                    .Save(Path.Combine(outputpath, "ex06.png"), ImageFormat.Png);

                doc.WriteLine("![](ex07.png) | `SHA256` | `" + n + "` | Extended | Transparent | " + b.Width + "x" + b.Height);
                CreateGenString("SHA256", n, true)
                    .Create(n, s, Color.Transparent, b)
                    .Save(Path.Combine(outputpath, "ex07.png"), ImageFormat.Png);

                doc.WriteLine("![](ex08.png) | `SHA384` | `" + n + "` | Extended | Transparent | " + b.Width + "x" + b.Height);
                CreateGenString("SHA384", n, true)
                    .Create(n, s, Color.Transparent, b)
                    .Save(Path.Combine(outputpath, "ex08.png"), ImageFormat.Png);

                doc.WriteLine("![](ex09.png) | `SHA512` | `" + n + "` | Extended | Transparent | " + b.Width + "x" + b.Height);
                CreateGenString("SHA512", n, true)
                    .Create(n, s, Color.Transparent, b)
                    .Save(Path.Combine(outputpath, "ex09.png"), ImageFormat.Png);

                doc.WriteLine("![](ex10.png) | `SHA256` | `" + ip1.ToString() + "` | Extended | Transparent | " + b.Width + "x" + b.Height);
                CreateGenIp("SHA256", ip1, true)
                    .Create(ip1, s, Color.Transparent, b)
                    .Save(Path.Combine(outputpath, "ex10.png"), ImageFormat.Png);

                doc.WriteLine("![](ex11.png) | `SHA256` | `" + ip2.ToString() + "` | Extended | Transparent | " + b.Width + "x" + b.Height);
                CreateGenIp("SHA256", ip2, true)
                    .Create(ip2, s, Color.Transparent, b)
                    .Save(Path.Combine(outputpath, "ex11.png"), ImageFormat.Png);

                doc.WriteLine("![](ex12.png) | `SHA256` | `" + ip1.ToString() + "` | Extended | Black | " + b.Width + "x" + b.Height);
                CreateGenIp("SHA256", ip1, true)
                    .Create(ip1, s, Color.Black, b)
                    .Save(Path.Combine(outputpath, "ex12.png"), ImageFormat.Png);

                doc.WriteLine("![](ex13.png) | `SHA256` | `" + ip2.ToString() + "` | Extended | Black | " + b.Width + "x" + b.Height);
                CreateGenIp("SHA256", ip2, true)
                    .Create(ip2, s, Color.Black, b)
                    .Save(Path.Combine(outputpath, "ex13.png"), ImageFormat.Png);

                doc.WriteLine("![](ex14.png) | `SHA1` | `Foobar` | Extended | Black | " + b.Width + "x" + b.Height);
                CreateGenString("SHA1", "Foobar", true)
                    .Create("Foobar", s, Color.Black, b)
                    .Save(Path.Combine(outputpath, "ex14.png"), ImageFormat.Png);

                doc.WriteLine("![](ex15.png) | `SHA1` | `FooBar` | Extended | Black | " + b.Width + "x" + b.Height);
                CreateGenString("SHA1", "FooBar", true)
                    .Create("FooBar", s, Color.Black, b)
                    .Save(Path.Combine(outputpath, "ex15.png"), ImageFormat.Png);

                doc.WriteLine("![](ex16.png) | `MD5` | `" + f + "` | Extended | Transparent | 4x4");
                CreateGenString("MD5", f, true)
                    .Create(f, s, Color.Transparent, new Size(4, 4))
                    .Save(Path.Combine(outputpath, "ex16.png"), ImageFormat.Png);

                doc.WriteLine("![](ex17.png) | `MD5` | `" + f + "` | Extended | Transparent | 6x6");
                CreateGenString("MD5", f, true)
                    .Create(f, s, Color.Transparent, new Size(6, 6))
                    .Save(Path.Combine(outputpath, "ex17.png"), ImageFormat.Png);

                doc.WriteLine("![](ex18.png) | `MD5` | `" + f + "` | Extended | Transparent | 12x12");
                CreateGenString("MD5", f, true)
                    .Create(f, s, Color.Transparent, new Size(12, 12))
                    .Save(Path.Combine(outputpath, "ex18.png"), ImageFormat.Png);

                doc.WriteLine("![](ex19.png) | `MD5` | `" + f + "` | Default | Transparent | 4x6");
                CreateGenString("MD5", f, false)
                    .Create(f, s, Color.Transparent, new Size(4, 6))
                    .Save(Path.Combine(outputpath, "ex19.png"), ImageFormat.Png);

                doc.WriteLine("![](ex20.png) | `MD5` | `" + f + "` | Default | Transparent | 6x4");
                CreateGenString("MD5", f, false)
                    .Create(f, s, Color.Transparent, new Size(6, 4))
                    .Save(Path.Combine(outputpath, "ex20.png"), ImageFormat.Png);

                doc.WriteLine("![](ex21.png) | `SHA256` | `" + i + "` | Extended | Transparent | " + b.Width + "x" + b.Height);
                CreateGenString("SHA256", i, true)
                    .Create(f, new Size(90, 90), Color.Transparent, b)
                    .Save(Path.Combine(outputpath, "ex21.png"), ImageFormat.Png);

                doc.WriteLine("![](ex22.png) | `SHA256` | `" + i + "` | Extended | Transparent | " + b.Width + "x" + b.Height);
                CreateGenString("SHA256", i, true)
                    .Create(f, new Size(120, 120), Color.Transparent, b)
                    .Save(Path.Combine(outputpath, "ex22.png"), ImageFormat.Png);
            }
        }

        private IdenticonGenerator CreateGenString(string alg, string s, bool useextended)
        {
            var g = new IdenticonGenerator(alg);
            g.DefaultBrushGenerator = new StaticColorBrushGenerator(StaticColorBrushGenerator.ColorFromText(s));
            if (useextended)
                g.DefaultBlockGenerators = IdenticonGenerator.ExtendedBlockGeneratorsConfig;
            return g;
        }

        private IdenticonGenerator CreateGenIp(string alg, IPAddress ip, bool useextended)
        {
            var g = new IdenticonGenerator(alg);
            g.DefaultBrushGenerator = new StaticColorBrushGenerator(StaticColorBrushGenerator.ColorFromIPAddress(ip));
            if (useextended)
                g.DefaultBlockGenerators = IdenticonGenerator.ExtendedBlockGeneratorsConfig;
            return g;
        }
    }
}
