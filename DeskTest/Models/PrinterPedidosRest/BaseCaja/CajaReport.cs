using DeskTest.Models.PrinterPedidosRest.BaseCaja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helios.Web.Core.Models.Order.PrinterPedidosRest.BaseCaja
{
    public class CajaReport
    {
        public string FondoInicio { get; set; }
        public string OtrosIngresos { get; set; }
        public string OtrosEgresos { get; set; }
        public string Ventas { get; set; }
        public string CobranzasDeudas { get; set; }
        public string AnticipoRecibidos { get; set; }
        public string FechaCierre  { get; set; }
        public string Total { get; set; }
        public string Cargo { get; set; }
        public string NroDocumento { get; set; }
        public string Usuario { get; set; }
        public string FechaActualizacion { get; set; }
        public string FechaApertura { get; set; }
        public string VentaEfectivo { get; set; }
        public string FondInicialTotal { get; set; }
        public string OtrosEgresosTotal { get; set; }
        public string VentageneralTotal { get; set; }
        public List<DatosEmpresa> DatosEmpresa { get; set; }
        public List<CierreGeneralDetalleReport> CierreGeneralDetalle { get; set; }
        public List<CierreGeneralDetalleReportSalida> CierreGeneralDetalleSalida { get; set; }
        public List<CierreGeneralDetalleReportOtros> CierreGeneralDetalleOtros { get; set; }
    }
}
