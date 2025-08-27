using Microsoft.AspNetCore.Mvc;
using new_project_2.Data;
using new_project_2.Models;
using ClosedXML.Excel; 
using System.IO;       
using System.Linq;

namespace new_project_2.Controllers
{
    public class MusteriController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MusteriController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                _context.Musteriler.Add(musteri);
                _context.SaveChanges();
                ViewBag.Mesaj = "Müştəri uğurla əlavə olundu!";
                return View();
            }
            return View(musteri);
        }

        
        public IActionResult ExportToExcel()
        {
            var musteriler = _context.Musteriler.ToList();

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Musteriler");

           
            worksheet.Cell(1, 1).Value = "ID"; 
            worksheet.Cell(1, 2).Value = "Ad";
            worksheet.Cell(1, 3).Value = "Soyad";
            worksheet.Cell(1, 4).Value = "Ata adı";
            worksheet.Cell(1, 5).Value = "Email";
            

            int row = 2;
            foreach (var m in musteriler)
            {
                worksheet.Cell(row, 1).Value = m.idmusteriler;
                worksheet.Cell(row, 2).Value = m.musteriad;
                worksheet.Cell(row, 3).Value = m.musterisoyad;
                worksheet.Cell(row, 4).Value = m.musteriataadi;
                worksheet.Cell(row, 5).Value = m.Telefon;
                row++;
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();

            return File(
                content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Musteriler.xlsx");
        }
    }
}
