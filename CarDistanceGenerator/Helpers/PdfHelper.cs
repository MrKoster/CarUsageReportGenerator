using CarDistanceGenerator.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Reflection;

namespace CarDistanceGenerator.Helpers
{
    public static class PdfHelper
    {
        public static void GeneratePdfToFile(MonthlyCarUsage monthlyUsage)
        {
            GeneratePdfDocument(monthlyUsage);
        }

        private static void GeneratePdfDocument(MonthlyCarUsage monthlyUsage)
        {
            // Prepare paths
            string nowDateSalt = DateTime.Now.ToString("yyyyMMddHHmmss");
            string filePath = String.Format(@"{0}\kilometrowka_{1}.pdf",
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase),
                    nowDateSalt);
            string localPath = new Uri(filePath).LocalPath;

            // Generate pdf
            using (FileStream fileStream = new FileStream(localPath, FileMode.CreateNew))
            {
                Document document = new Document(PageSize.A4.Rotate(), 20, 20, 20, 20);
                PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
                document.Open(); //open the document in order to write inside.

                // Fill document content
                FillPdfDocumentContent(document, monthlyUsage);

                document.Close();
            };
        }

        private static void FillPdfDocumentContent(Document document, MonthlyCarUsage monthlyCarUsage)
        {
            document.Add(KilometrowkaTextHelper.GetLeftHightConstText());
            document.Add(KilometrowkaTextHelper.GetHeader());
            document.Add(KilometrowkaTextHelper.GetCarData(monthlyCarUsage.Month.ToString(), monthlyCarUsage.Year.ToString()));
            document.Add(KilometrowkaTextHelper.GetUsageTable(monthlyCarUsage));


        }
    }
}
