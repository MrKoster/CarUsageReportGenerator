using CarDistanceGenerator.Models;
using CarDistanceGenerator.Repositories;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;

namespace CarDistanceGenerator.Helpers
{
    public static class KilometrowkaTextHelper
    {
        public static Paragraph GetLeftHightConstText()
        {
            Paragraph p = new Paragraph
            {
                SpacingBefore = 1,
                SpacingAfter = 1,
                Alignment = Element.ALIGN_LEFT,
                Font = FontFactory.GetFont(BaseFont.HELVETICA, BaseFont.CP1257, 7f, Font.NORMAL),
                PaddingTop = 0
            };
            p.SetLeading(0, 1.5f);
            p.Add("Oznaczenie przedsiębiorcy (pieczęć firmowa)\n");
            p.Add("Nazwisko, imię i adres zamieszkania osoby\n");
            p.Add("używającej pojazd (pracownika / właściciela)*");
            return p;
        }

        public static Paragraph GetHeader()
        {
            Paragraph p = new Paragraph
            {
                SpacingBefore = 1,
                SpacingAfter = 1,
                Alignment = Element.ALIGN_CENTER,
                Font = FontFactory.GetFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1257, 12f, Font.BOLD),
                PaddingTop = 0
            };
            p.Add("EWIDENCJA PRZEBIEGU POJAZDU");
            return p;
        }

        public static Paragraph GetCarData(string month, string year)
        {
            Chunk glue = new Chunk(new VerticalPositionMark());

            Paragraph p = new Paragraph
            {
                SpacingBefore = 1,
                SpacingAfter = 1,
                Alignment = Element.ALIGN_LEFT,
                Font = FontFactory.GetFont(BaseFont.HELVETICA_OBLIQUE, BaseFont.CP1257, 10f, Font.NORMAL),
                PaddingTop = 0
            };
            p.SetLeading(0, 1.5f);

            p.Add(CarInfoRepository.GetDriverNameAndSurname());
            p.Add(new Chunk(glue));
            p.Add($"Miesiąc/rok: {month}/{year}\n");

            p.Add(CarInfoRepository.GetFullCompanyName());
            p.Add(new Chunk(glue));
            p.Add("Numer rejestracyjny pojazdu: " + CarInfoRepository.GetCarLicencePlate() + "\n");

            p.Add(CarInfoRepository.GetCompanyStreet_PartOne());
            p.Add(new Chunk(glue));
            p.Add("Marka pojazdu: " + CarInfoRepository.GetCarModelName() + "\n");

            p.Add(CarInfoRepository.GetCompanyStreet_PartTwo());
            p.Add(new Chunk(glue));
            p.Add("Pojemność silnika [cm3]: " + CarInfoRepository.GetCarEngineCapacity() + "\n");

            return p;
        }

        public static PdfPTable GetUsageTable(MonthlyCarUsage monthlyCarUsage)
        {
            // Init values
            string whiteSpace = " ";
            PdfPTable table = new PdfPTable(9);
            table.HeaderRows = 1;
            Font headersFont = FontFactory.GetFont(BaseFont.HELVETICA, BaseFont.CP1257, 9f, Font.NORMAL);
            Font cellsFont = FontFactory.GetFont(BaseFont.HELVETICA, BaseFont.CP1257, 7f, Font.NORMAL);

            // Header
            table.AddCell(new PdfPCell(new Phrase("Nr kolejny wpisu", headersFont)));
            table.AddCell(new PdfPCell(new Phrase("Data wyjazdu", headersFont)));
            table.AddCell(new PdfPCell(new Phrase("Opis trasy wyjadu (skąd - dokąd)", headersFont)));
            table.AddCell(new PdfPCell(new Phrase("Cel wyjazdu", headersFont)));
            table.AddCell(new PdfPCell(new Phrase("Liczba faktycznie przejechanych kilometrów", headersFont)));
            table.AddCell(new PdfPCell(new Phrase("Stawka za 1 kilometr przebiegu (zł, gr)", headersFont)));
            table.AddCell(new PdfPCell(new Phrase("Wartość (zł, gr)", headersFont)));
            table.AddCell(new PdfPCell(new Phrase("Podpis pracodawcy", headersFont)));
            table.AddCell(new PdfPCell(new Phrase("Uwagi", headersFont)));

            // Cells in rows
            foreach (var dailyUsage in monthlyCarUsage.CarUsages)
            {
                table.AddCell(new PdfPCell(new Phrase(dailyUsage.Number.ToString(), cellsFont)));
                table.AddCell(new PdfPCell(new Phrase(dailyUsage.Date, cellsFont)));
                table.AddCell(new PdfPCell(new Phrase(dailyUsage.RouteDescription, cellsFont)));
                table.AddCell(new PdfPCell(new Phrase(dailyUsage.TravelPurpose, cellsFont)));
                table.AddCell(new PdfPCell(new Phrase(dailyUsage.KilometersAmount.ToString(), cellsFont)));
                table.AddCell(new PdfPCell(new Phrase(dailyUsage.OneKilometerRateValue.ToString(), cellsFont)));
                table.AddCell(new PdfPCell(new Phrase(dailyUsage.SummedCostValue.ToString(), cellsFont)));
                table.AddCell(new PdfPCell(new Phrase(whiteSpace, cellsFont)));
                table.AddCell(new PdfPCell(new Phrase(whiteSpace, cellsFont)));
            }

            // Empty row
            table.AddCell(whiteSpace);
            table.AddCell(whiteSpace);
            table.AddCell(whiteSpace);
            table.AddCell(whiteSpace);
            table.AddCell(whiteSpace);
            table.AddCell(whiteSpace);
            table.AddCell(whiteSpace);
            table.AddCell(whiteSpace);
            table.AddCell(whiteSpace);

            // Summary
            table.AddCell(whiteSpace);
            table.AddCell(whiteSpace);
            table.AddCell(whiteSpace);
            table.AddCell(new PdfPCell(new Phrase("Razem", cellsFont)));
            table.AddCell(new PdfPCell(new Phrase(monthlyCarUsage.TotalKilometersAmount.ToString(), cellsFont)));
            table.AddCell(whiteSpace);
            table.AddCell(new PdfPCell(new Phrase(monthlyCarUsage.TotalCostValue.ToString(), cellsFont)));
            table.AddCell(whiteSpace);
            table.AddCell(whiteSpace);

            // Add spacings
            table.SpacingBefore = 25f;

            return table;
        }

    }
}
