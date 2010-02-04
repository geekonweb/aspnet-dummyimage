using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using System.Drawing.Imaging;

namespace DummyImageSTD
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int width = 640;
            int height = 480;

            if (Request.Params["w"] != null)
            {
                int.TryParse(Request.Params["w"], out width);
            }
            if (Request.Params["h"] != null)
            {
                int.TryParse(Request.Params["h"], out height);
            }

            int top = 0;
            int left = 0;
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

            Response.ContentType = "image/jpg";
            image.Save(Response.OutputStream, ImageFormat.Jpeg);
            Response.End();
        }
    }
}
