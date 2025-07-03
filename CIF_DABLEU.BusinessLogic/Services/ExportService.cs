using CIF_DABLEU.BusinessLogic.Contracts;
using CIF_DABLEU.DataAccess.Contracts;
using ClosedXML.Excel; // Para Excel
using QuestPDF.Fluent; // Para PDF
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//QuestPDF.Settings.License = LicenseType.Community;

namespace CIF_DABLEU.BusinessLogic.Services
{
    public class ExportService : IExportService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ExportService(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }
        
        public async Task<byte[]> ExportProductsToExcelAsync()
        {
            var products = await _unitOfWork.Product.GetAllAsync();
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Productos");
                worksheet.Cell("A1").Value = "Nombre";
                worksheet.Cell("B1").Value = "Precio";
                worksheet.Cell("C1").Value = "Stock";
                worksheet.Row(1).Style.Font.Bold = true;

                int currentRow = 2;
                foreach (var product in products)
                {
                    worksheet.Cell(currentRow, 1).Value = product.Name;
                    worksheet.Cell(currentRow, 2).Value = product.Price;
                    worksheet.Cell(currentRow, 3).Value = product.Stock;
                    currentRow++;
                }

                worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }

        // La exportación de PDF es más compleja...
        public async Task<byte[]> ExportInvoiceToPdfAsync(int invoiceId)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            // Usamos el nuevo método para obtener todos los datos necesarios
            var invoice = await _unitOfWork.SaleInvoice.GetByIdWithDetailsAsync(invoiceId);

            if (invoice == null)
            {
                throw new Exception($"No se encontró la factura con ID {invoiceId}.");
            }

            // Usamos QuestPDF para generar el documento
            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(30);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    // Encabezado con el logo y datos de la factura
                    page.Header()
                        .Row(row =>
                        {
                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text("CIF_DABLEU SYSTEM")
                                    .SemiBold().FontSize(20).FontColor(Colors.Blue.Medium);
                                col.Item().Text("Tu Empresa S.A.");
                                col.Item().Text("Tu Dirección, 123");
                                col.Item().Text("tu.email@empresa.com");
                            });

                            row.ConstantItem(150).Column(col =>
                            {
                                col.Item().AlignCenter().Text($"Factura #{invoice.Id:D6}")
                                    .Bold().FontSize(14);
                                col.Item().AlignCenter().Text($"Fecha: {invoice.IssueDate:d}");
                            });
                        });

                    // Contenido principal de la página
                    page.Content()
                        .PaddingVertical(20)
                        .Column(column =>
                        {
                            // Datos del cliente
                            column.Item().Row(row =>
                            {
                                row.RelativeItem().Border(1).Padding(5).Column(col =>
                                {
                                    col.Item().Text("Facturar a:").SemiBold();
                                    col.Item().Text(invoice.Customer.Name);
                                    col.Item().Text(invoice.Customer.Address);
                                    col.Item().Text($"Tel: {invoice.Customer.Phone}");
                                });
                                row.ConstantItem(50); // Espacio
                                row.RelativeItem(); // Espacio vacío a la derecha
                            });

                            column.Spacing(20);

                            // Tabla con los detalles de la factura
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(3); // Descripción del producto
                                    columns.RelativeColumn();  // Cantidad
                                    columns.RelativeColumn();  // Precio Unit.
                                    columns.RelativeColumn();  // Subtotal
                                });

                                // Encabezado de la tabla
                                table.Header(header =>
                                {
                                    header.Cell().Background(Colors.Grey.Lighten1 - 3).Padding(5).Text("Descripción");
                                    header.Cell().Background(Colors.Grey.Lighten1 - 3).Padding(5).AlignCenter().Text("Cantidad");
                                    header.Cell().Background(Colors.Grey.Lighten1 - 3).Padding(5).AlignRight().Text("Precio Unit.");
                                    header.Cell().Background(Colors.Grey.Lighten1 - 3).Padding(5).AlignRight().Text("Subtotal");
                                });

                                // Filas de la tabla
                                foreach (var detail in invoice.Details)
                                {
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten1 - 2).Padding(5).Text(detail.Product.Name);
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten1 - 2).Padding(5).AlignCenter().Text(detail.Quantity);
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten1 - 2).Padding(5).AlignRight().Text($"{detail.UnitPrice:C2}");
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten1 - 2).Padding(5).AlignRight().Text($"{detail.SubTotal:C2}");
                                }
                            });

                            // Total
                            column.Item().AlignRight().PaddingTop(10).Row(row =>
                            {
                                row.ConstantItem(100).Text("TOTAL:").Bold().FontSize(14);
                                row.ConstantItem(100).AlignRight().Text($"{invoice.Total:C2}").Bold().FontSize(14);
                            });
                        });

                    // Pie de página
                    page.Footer()
                        .AlignCenter()
                        .Text("Gracias por su compra.")
                        .SemiBold();
                });
            }).GeneratePdf();
        }
    }
}
