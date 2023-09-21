using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GeneratePDFinMVC.Controllers
{
    public class PdfController : Controller
    {
        public IActionResult Index()
        {
            try
            {


                Document doc = new Document();
                if (System.IO.File.Exists("D:\\MvcDocument.pdf"))
                {
                    System.IO.File.Delete("D:\\MvcDocument.pdf");
                }

                FileStream fs = new FileStream("D:\\MvcDocument.pdf", FileMode.Create);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                doc.Add(new Paragraph("Hello,Weclome to MVC"));

                Paragraph para = new Paragraph("This is my Paragraph");
                doc.Add(para);

                Paragraph header = new Paragraph("Heder Text", new Font(Font.FontFamily.COURIER, 16, Font.BOLDITALIC));
                doc.Add(header);

                Anchor anchor = new Anchor("Visit Anaiyaan Technologies", new Font(Font.FontFamily.UNDEFINED, 12, Font.BOLD));
                anchor.Reference = "https://anaiyaantechnologies.com/";
                doc.Add(anchor);

                /*  Image image = Image.GetInstance(Server.MapPath("/Pictures/Anaiyaan Logo.png"));
                  image.ScaleToFit(200, 200);
                  doc.Add(image);*/

                List list = new List(List.UNORDERED);
                list.Add(new ListItem("Item 1"));
                list.Add(new ListItem("Item 1"));
                doc.Add(list);

                doc.Close();
                fs.Close();


                return View();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
