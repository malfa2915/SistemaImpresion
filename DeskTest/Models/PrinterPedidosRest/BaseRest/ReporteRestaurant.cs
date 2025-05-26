using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using FastReport;
using FastReport.Barcode;
using Helios.Cont.Business.Entity;
using OpenInvoicePeru.Comun.Dto.Intercambio;
using OpenInvoicePeru.Comun.Dto.Modelos;

using System.Net;
using System.Xml;
using System.Drawing;
using System.Drawing.Printing;

public class ReporteRestaurant
{
    private List<SpPedidosRest> SpPedidosRest;
    private string ISprintir;

    private Report _report = new Report();
    public Report Report
    {
        get
        {
            return _report;
        }
        set
        {
            _report = value;
        }
    }

    public void ImprimirTicketPedido(List<datosGenerales> objDatosGenrales, documentoventaAbarrotes ListaProductos, string nombreCliente, string FormatImp, string ImporteTotal, int cantiPrint, string ImpreAlia, int formatPrin)
    {
        try
        {
            if (objDatosGenrales.Count > 0)
            {
                var datosG = objDatosGenrales.Where(x => x.NombreFormato == "TK").FirstOrDefault();
                if (datosG != null)
                {
                    string fileName = viewRepor(datosG, FormatImp, formatPrin);
                    if (fileName != "")
                    {
                        string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                        Report = new Report();
                        // If ListaProductos.Count > 0 Then
                        if (ListaProductos != null)
                        {
                            // reportPedidos(ListaProductos, nombreCliente, ImporteTotal)
                            reportPedidos(ListaProductos, nombreCliente, ImporteTotal, ImpreAlia);
                            Report.Load(path);
                            RegionReportParameters(FormatImp);
                            Report.RegisterData(SpPedidosRest, "RestPedidos");
                            Report.Prepare();
                            if (FormatImp == "Pedidos" | FormatImp == "Anulados")
                                ImprimeTicket(cantiPrint, ImpreAlia);
                            else
                            {
                                //Report.Report.PrintSettings.ShowDialog = false;
                                //Report.Print();
                            }
                        }
                    }
                }
            }
           // else
               // MessageBox.Show("No configuro una impresión", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
           // throw ex;
        }
    }


    // Private Sub reportPedidos(ListaProductos As List(Of documentoventaAbarrotesDet), nombreCliente As String, ImporteTotal As String)
    private void reportPedidos(documentoventaAbarrotes ListaProductos, string nombreCliente, string ImporteTotal, string ImpreAlia)
    {
        SpPedidosRest = new List<SpPedidosRest>();
        SpPedidosRest SpPedidosRestObj = new SpPedidosRest();
        SpPedidosRestDet SpPedidosDetRes = new SpPedidosRestDet();
        List<SpPedidosRestDet> SpPedidosDetResList = new List<SpPedidosRestDet>();
        List<documentoventaAbarrotesDet> docuImprin = new List<documentoventaAbarrotesDet>();
        SpPedidosRestObj = new SpPedidosRest();
        SpPedidosRestObj.Moviliario = nombreCliente;
        SpPedidosRestObj.FechaPedido = DateTime.Now.ToString();
        SpPedidosRestObj.TotalImporte = ImporteTotal;

        //var consultaNombre = (from b in UsuariosList
        //                      where b.IDUsuario == usuario.IDUsuario
        //                      select b).FirstOrDefault;
        //// If consultaNombre.Nombres <> "ADMIN" Then
        //SpPedidosRestObj.CargoPedido = consultaNombre.UsuarioRol.FirstOrDefault.nombrePerfil;
        //if (consultaNombre.ApellidoMaterno == "ADMIN" | consultaNombre.ApellidoMaterno == "-")
        //    SpPedidosRestObj.Usuario = $"{consultaNombre.Nombres}";
        //else
        //    SpPedidosRestObj.Usuario = $"{consultaNombre.Nombres} {consultaNombre.ApellidoPaterno} {consultaNombre.ApellidoMaterno}";
        //if (ListaProductos.CustomEntidad is not null)
        //    SpPedidosRestObj.Cliente = ListaProductos.CustomEntidad.GetNameEntidadCapitalize;
        //else
        //    SpPedidosRestObj.Cliente = ListaProductos.documentoventaAbarrotesDet.FirstOrDefault().NombreProveedor;

        //// End If
        //if (ImpreAlia == "")
        //    docuImprin = ListaProductos.documentoventaAbarrotesDet;
        //else
        //    docuImprin = ListaProductos.documentoventaAbarrotesDet.Where(o => o.isprinter == ImpreAlia).ToList();

        foreach (var I in docuImprin)
        {
            SpPedidosDetRes = new SpPedidosRestDet();

            if (I.DetalleItem != null)
                I.nombreItem = I.DetalleItem;

            if (I.delivery.GetValueOrDefault())
            {
                if (I.detalleAdicional != null)
                    SpPedidosDetRes.DescPediDet = $"{I.nombreItem } ({I.detalleAdicional}) - ({"PARA LLEVAR"})";
                else
                    SpPedidosDetRes.DescPediDet = $"{I.nombreItem } ({"PARA LLEVAR"})";
            }
            else if (I.detalleAdicional != null)
                SpPedidosDetRes.DescPediDet = $"{I.nombreItem } - ({I.detalleAdicional})";
            else
                SpPedidosDetRes.DescPediDet = I.nombreItem;

            if (I.monto1 != null)
                SpPedidosDetRes.CantidadDet = I.monto1.GetValueOrDefault().ToString();
            else
            {
                SpPedidosDetRes.CantidadDet = I.canDisponible.GetValueOrDefault().ToString();
                SpPedidosDetRes.Importe = I.importeMN.GetValueOrDefault().ToString();
            }
            SpPedidosDetRes.Precio = I.precioUnitario.GetValueOrDefault().ToString();

            SpPedidosDetResList.Add(SpPedidosDetRes);
        }
        SpPedidosRestObj.PedidosRestDet = SpPedidosDetResList;
        SpPedidosRest.Add(SpPedidosRestObj);
    }

    private void RegionReportParameters(string FormatImp)
    {
        if (FormatImp == "Pedidos")
        {
            TextObject titulo = Report.FindObject("Text21") as TextObject;
            titulo.Text = "PEDIDOS";
        }
        else if (FormatImp == "PreCuenta")
        {
            TextObject titulo = Report.FindObject("Text21") as TextObject;
            titulo.Text = "PRE CUENTA";
        }
        else
        {
            TextObject titulo = Report.FindObject("Text21") as TextObject;
            titulo.Text = "ANULADOS";
        }
    }
    // Private Function viewRepor(TipoImpresion As String) As String
    private string viewRepor(datosGenerales TipoImpresion, string FormatImp, int formatPrin)
    {
        string fileName = string.Empty;
        switch (FormatImp)
        {
            case "Pedidos":
            case "Anulados":
                {
                    switch (TipoImpresion.formato)
                    {
                        case "80 MM":
                            {
                                switch (formatPrin)
                                {
                                    case 1:
                                        {
                                            fileName = @"Formularios\Comercial\OrdersManagement\Sale_Pos\Printer\infPedidosRest.frx";
                                            break;
                                        }

                                    default:
                                        {
                                            fileName = @"Formularios\Comercial\OrdersManagement\Sale_Pos\Printer\infPedidosRestTxtGran.frx";
                                            break;
                                        }
                                }

                                break;
                            }

                        case "55 MM":
                            {
                                fileName = @"Formularios\Comercial\OrdersManagement\Sale_Pos\Printer\infPedidosRest55mm.frx";
                                break;
                            }
                    }

                    break;
                }

            case "PreCuenta":
                {
                    switch (TipoImpresion.formato)
                    {
                        case "80 MM":
                            {
                                fileName = @"Formularios\Comercial\OrdersManagement\Sale_Pos\Printer\infPreVentaRest.frx";
                                break;
                            }

                        case "55 MM":
                            {
                                fileName = @"Formularios\Comercial\OrdersManagement\Sale_Pos\Printer\infPreVentaRest55m.frx";
                                break;
                            }
                    }

                    break;
                }
        }

        return fileName;
    }

    // Public Sub ImprimeTicket(ByVal impresora As datosGeneralesDet, ByVal conteoImpresion As Integer)
    public void ImprimeTicket(int CantPrint, string ImpreAlia)
    {

        // DocumentoAImprimir.PrinterSettings.PrinterName = impresora
        // Dim Canti = impresora.datosGeneralesDet.Where(Function(x) x.aliasImpresion = "")

        //for (int number = CantPrint; number >= 1; number += -1)
        //{
        //    Report.Report.PrintSettings.Printer = ImpreAlia;
        //    Report.Report.PrintSettings.ShowDialog = false;
        //    Report.Print();
        //}
    }
}
