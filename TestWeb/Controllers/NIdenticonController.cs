using Devcorner.NIdenticon;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace TestWeb.Controllers
{
    public class NIdenticonController : Controller
    {
        [Route("nidenticon/{dimension:range(10,500)=50}/{text?}")]
        public ActionResult Index(int dimension, string text)
        {
            text = text ?? HttpContext.Request.UserHostAddress;
            var ic = new IdenticonGenerator();
            var bitmap = ic.Create(text, dimension, dimension);

            var ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Png);

            return File(ms.ToArray(), "image/png");
        }
    }
}
