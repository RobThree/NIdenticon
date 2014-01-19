using Devcorner.NIdenticon;
using Devcorner.NIdenticon.BrushGenerators;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace TestWeb
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString GenerateIdenticon(this HtmlHelper html, string value, int dimension, bool useStaticBrush = false)
        {
            var i = new IdenticonGenerator();
            i.DefaultBlockGenerators = IdenticonGenerator.ExtendedBlockGeneratorsConfig;
            if (useStaticBrush)
                i.DefaultBrushGenerator = new StaticColorBrushGenerator(StaticColorBrushGenerator.ColorFromText(value));
            using (var bitmap = i.Create(value, new Size(dimension, dimension)))
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png);

                var img = new TagBuilder("img");
                img.Attributes.Add("width", bitmap.Width.ToString());
                img.Attributes.Add("height", bitmap.Height.ToString());
                img.Attributes.Add("src", String.Format("data:image/png;base64,{0}",
                    Convert.ToBase64String(stream.ToArray())));

                return MvcHtmlString.Create(img.ToString(TagRenderMode.SelfClosing));
            }
        }
    }
}