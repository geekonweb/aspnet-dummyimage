using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace DummyImage.Controllers
{
    public class DummyController : Controller
    {
        //
        // GET: /Dummy/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get(int width, int height)
        {
            int top=0;
            int left=0;
            string imgText = string.Format("{0}x{1}", width, height);


            Font font = new Font("Courier", 12, FontStyle.Regular, GraphicsUnit.Point);

            top = (height / 2) - font.Height / 2;
            left = (width / 2) - (imgText.Length * 10 / 2);

            Bitmap image = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.Gainsboro);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.DrawString(imgText, font, new SolidBrush(Color.Black), left, top);
            g.Flush();

            MemoryStream stream = new MemoryStream();
            image.Save(stream, ImageFormat.Jpeg);
            stream.Seek(0, SeekOrigin.Begin);
            return new FileStreamResult(stream, "image/jpeg");
        }

    }
}
