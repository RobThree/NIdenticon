using Microsoft.VisualStudio.TestTools.UnitTesting;
using NIdenticon;
using NIdenticon.BlockGenerators;
using NIdenticon.BrushGenerators;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;

namespace NIdenticonTests;

#if Windows
#pragma warning disable CA1416 // Validate platform compatibility
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

        using var doc = new StreamWriter(File.Create(Path.Combine("output", "doc.md")));
        doc.WriteLine("Result | Algorithm | Value | Blockgens | Background | Blocks | Brush");
        doc.WriteLine("--- | --- | --- | --- | --- | --- | ---");

        doc.WriteLine("![](examples/ex00.png) | `MD5` | `" + i + "` | Default | White | " + b.Width + "x" + b.Height + " | Static");
        CreateGenString("MD5", i, false, true)
            .Create(i, s, Color.White, b)
            .Save(Path.Combine(outputpath, "ex00.png"), ImageFormat.Png);

        doc.WriteLine("![](examples/ex01.png) | `MD5` | `" + i + "` | Extended | White | " + b.Width + "x" + b.Height + " | Static");
        CreateGenString("MD5", i, true, true)
            .Create(i, s, Color.White, b)
            .Save(Path.Combine(outputpath, "ex01.png"), ImageFormat.Png);

        doc.WriteLine("![](examples/ex02.png) | `SHA256` | `" + i + "` | Extended | White | " + b.Width + "x" + b.Height + " | Static");
        CreateGenString("SHA256", i, true, true)
            .Create(i, s, Color.White, b)
            .Save(Path.Combine(outputpath, "ex02.png"), ImageFormat.Png);

        doc.WriteLine("![](examples/ex03.png) | `SHA512` | `" + i + "` | Extended | White | " + b.Width + "x" + b.Height + " | Static");
        CreateGenString("SHA512", i, true, true)
            .Create(i, s, Color.White, b)
            .Save(Path.Combine(outputpath, "ex03.png"), ImageFormat.Png);

        doc.WriteLine("![](examples/ex04.png) | `MD5` | `" + n + "` | Extended | Transparent | " + b.Width + "x" + b.Height + " | Random");
        CreateGenString("MD5", n, true, false)
            .Create(n, s, Color.Transparent, b)
            .Save(Path.Combine(outputpath, "ex04.png"), ImageFormat.Png);

#if !NETCORE
        doc.WriteLine("![](examples/ex05.png) | `RipeMD160` | `" + n + "` | Extended | Transparent | " + b.Width + "x" + b.Height + " | Random");
        CreateGenString("RipeMD160", n, true, false)
            .Create(n, s, Color.Transparent, b)
            .Save(Path.Combine(outputpath, "ex05.png"), ImageFormat.Png);
#endif

        doc.WriteLine("![](examples/ex06.png) | `SHA1` | `" + n + "` | Extended | Transparent | " + b.Width + "x" + b.Height + " | Random");
        CreateGenString("SHA1", n, true, false)
            .Create(n, s, Color.Transparent, b)
            .Save(Path.Combine(outputpath, "ex06.png"), ImageFormat.Png);

        doc.WriteLine("![](examples/ex07.png) | `SHA256` | `" + n + "` | Extended | Transparent | " + b.Width + "x" + b.Height + " | Random");
        CreateGenString("SHA256", n, true, false)
            .Create(n, s, Color.Transparent, b)
            .Save(Path.Combine(outputpath, "ex07.png"), ImageFormat.Png);

        doc.WriteLine("![](examples/ex08.png) | `SHA384` | `" + n + "` | Extended | Transparent | " + b.Width + "x" + b.Height + " | Random");
        CreateGenString("SHA384", n, true, false)
            .Create(n, s, Color.Transparent, b)
            .Save(Path.Combine(outputpath, "ex08.png"), ImageFormat.Png);

        doc.WriteLine("![](examples/ex09.png) | `SHA512` | `" + n + "` | Extended | Transparent | " + b.Width + "x" + b.Height + " | Random");
        CreateGenString("SHA512", n, true, false)
            .Create(n, s, Color.Transparent, b)
            .Save(Path.Combine(outputpath, "ex09.png"), ImageFormat.Png);

        doc.WriteLine("![](examples/ex10.png) | `SHA256` | `" + ip1.ToString() + "` | Extended | Transparent | " + b.Width + "x" + b.Height + " | Static");
        CreateGenIp("SHA256", ip1, true, true)
            .Create(ip1, s, Color.Transparent, b)
            .Save(Path.Combine(outputpath, "ex10.png"), ImageFormat.Png);

        doc.WriteLine("![](examples/ex11.png) | `SHA256` | `" + ip2.ToString() + "` | Extended | Transparent | " + b.Width + "x" + b.Height + " | Static");
        CreateGenIp("SHA256", ip2, true, true)
            .Create(ip2, s, Color.Transparent, b)
            .Save(Path.Combine(outputpath, "ex11.png"), ImageFormat.Png);

        doc.WriteLine("![](examples/ex12.png) | `SHA256` | `" + ip1.ToString() + "` | Extended | Black | " + b.Width + "x" + b.Height + " | Static");
        CreateGenIp("SHA256", ip1, true, true)
            .Create(ip1, s, Color.Black, b)
            .Save(Path.Combine(outputpath, "ex12.png"), ImageFormat.Png);

        doc.WriteLine("![](examples/ex13.png) | `SHA256` | `" + ip2.ToString() + "` | Extended | Black | " + b.Width + "x" + b.Height + " | Static");
        CreateGenIp("SHA256", ip2, true, true)
            .Create(ip2, s, Color.Black, b)
            .Save(Path.Combine(outputpath, "ex13.png"), ImageFormat.Png);

        doc.WriteLine("![](examples/ex14.png) | `SHA1` | `Foobar` | Extended | Black | " + b.Width + "x" + b.Height + " | Static");
        CreateGenString("SHA1", "Foobar", true, true)
            .Create("Foobar", s, Color.Black, b)
            .Save(Path.Combine(outputpath, "ex14.png"), ImageFormat.Png);

        doc.WriteLine("![](examples/ex15.png) | `SHA1` | `FooBar` | Extended | Black | " + b.Width + "x" + b.Height + " | Static");
        CreateGenString("SHA1", "FooBar", true, true)
            .Create("FooBar", s, Color.Black, b)
            .Save(Path.Combine(outputpath, "ex15.png"), ImageFormat.Png);

        doc.WriteLine("![](examples/ex16.png) | `MD5` | `" + f + "` | Extended | Transparent | 4x4 | Static");
        CreateGenString("MD5", f, true, true)
            .Create(f, s, Color.Transparent, new Size(4, 4))
            .Save(Path.Combine(outputpath, "ex16.png"), ImageFormat.Png);

        doc.WriteLine("![](examples/ex17.png) | `MD5` | `" + f + "` | Extended | Transparent | 6x6 | Static");
        CreateGenString("MD5", f, true, true)
            .Create(f, s, Color.Transparent, new Size(6, 6))
            .Save(Path.Combine(outputpath, "ex17.png"), ImageFormat.Png);

        doc.WriteLine("![](examples/ex18.png) | `MD5` | `" + f + "` | Extended | Transparent | 12x12 | Static");
        CreateGenString("MD5", f, true, true)
            .Create(f, s, Color.Transparent, new Size(12, 12))
            .Save(Path.Combine(outputpath, "ex18.png"), ImageFormat.Png);

        doc.WriteLine("![](examples/ex19.png) | `MD5` | `" + f + "` | Default | Transparent | 4x6 | Static");
        CreateGenString("MD5", f, false, true)
            .Create(f, s, Color.Transparent, new Size(4, 6))
            .Save(Path.Combine(outputpath, "ex19.png"), ImageFormat.Png);

        doc.WriteLine("![](examples/ex20.png) | `MD5` | `" + f + "` | Default | Transparent | 6x4 | Static");
        CreateGenString("MD5", f, false, true)
            .Create(f, s, Color.Transparent, new Size(6, 4))
            .Save(Path.Combine(outputpath, "ex20.png"), ImageFormat.Png);

        doc.WriteLine("![](examples/ex21.png) | `SHA256` | `" + i + "` | Extended | Transparent | " + b.Width + "x" + b.Height + " | Random");
        CreateGenString("SHA256", i, true, false)
            .Create(f, new Size(90, 90), Color.Transparent, b)
            .Save(Path.Combine(outputpath, "ex21.png"), ImageFormat.Png);

        doc.WriteLine("![](examples/ex22.png) | `SHA256` | `" + i + "` | Extended | Transparent | " + b.Width + "x" + b.Height + " | Static");
        CreateGenString("SHA256", i, true, true)
            .Create(f, new Size(120, 120), Color.Transparent, b)
            .Save(Path.Combine(outputpath, "ex22.png"), ImageFormat.Png);

        doc.WriteLine("![](examples/ex23.png) | `SHA384` | `" + i + "` | Custom<br><sub>(Triangles only)</sub> | Transparent | " + b.Width + "x" + b.Height + " | Random");
        CreateGenString("SHA384", i, false, false)
            .Create(f, new Size(120, 120), Color.Transparent, b, Encoding.UTF8, new IBlockGenerator[] { new TriangleGenerator(1) })
            .Save(Path.Combine(outputpath, "ex23.png"), ImageFormat.Png);

        doc.WriteLine("![](examples/ex24.png) | `SHA384` | `" + i + "` | Custom<br><sub>(Pie-slices only)</sub> | Transparent | " + b.Width + "x" + b.Height + " | Random");
        CreateGenString("SHA384", i, false, false)
            .Create(f, new Size(120, 120), Color.Transparent, b, Encoding.UTF8, new IBlockGenerator[] { new PieGenerator(1) })
            .Save(Path.Combine(outputpath, "ex24.png"), ImageFormat.Png);

        doc.WriteLine("![](examples/ex25.png) | `SHA384` | `" + i + "` | Custom<br><sub>(Rectangle + Pie in 4:1)</sub> | Transparent | " + b.Width + "x" + b.Height + " | Static");
        CreateGenString("SHA384", i, false, true)
            .Create(f, new Size(120, 120), Color.Transparent, b, Encoding.UTF8, new IBlockGenerator[] { new RectangleGenerator(4), new PieGenerator(1) })
            .Save(Path.Combine(outputpath, "ex25.png"), ImageFormat.Png);
    }

    private static IdenticonGenerator CreateGenString(string alg, string s, bool useextended, bool usestatic)
    {
        var g = new IdenticonGenerator(alg);
        if (usestatic)
        {
            g.DefaultBrushGenerator = new StaticColorBrushGenerator(StaticColorBrushGenerator.ColorFromText(s));
        }

        if (useextended)
        {
            g.DefaultBlockGenerators = IdenticonGenerator.ExtendedBlockGeneratorsConfig;
        }

        return g;
    }

    private static IdenticonGenerator CreateGenIp(string alg, IPAddress ip, bool useextended, bool usestatic)
    {
        var g = new IdenticonGenerator(alg);
        if (usestatic)
        {
            g.DefaultBrushGenerator = new StaticColorBrushGenerator(StaticColorBrushGenerator.ColorFromIPAddress(ip));
        }

        if (useextended)
        {
            g.DefaultBlockGenerators = IdenticonGenerator.ExtendedBlockGeneratorsConfig;
        }

        return g;
    }
}
#pragma warning restore CA1416 // Validate platform compatibility
#endif