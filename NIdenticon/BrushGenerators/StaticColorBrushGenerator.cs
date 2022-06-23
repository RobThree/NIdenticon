using System;
using System.Drawing;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace NIdenticon.BrushGenerators;

public class StaticColorBrushGenerator : IBrushGenerator
{
    private readonly Color _color;
    public StaticColorBrushGenerator(Color color)
        => _color = color;

    public static Color ColorFromIPAddress(IPAddress ipaddress)
        => Color.FromArgb(255, Color.FromArgb(BitConverter.ToInt32(ipaddress.GetAddressBytes(), 0)));

    public static Color ColorFromText(string value)
        => ColorFromText(value, Encoding.UTF8);

    public static Color ColorFromText(string value, Encoding encoding)
        => Color.FromArgb(255, Color.FromArgb(BitConverter.ToInt32(new MD5CryptoServiceProvider().ComputeHash(encoding.GetBytes(value)), 0)));

    public Brush GetBrush(uint seed)
        => new SolidBrush(_color);
}
