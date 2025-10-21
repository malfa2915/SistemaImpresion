using DeskTest.Models.PrinterPedidosRest.BaseCaja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helios.Web.Core.Models.Order.PrinterPedidosRest.BaseCaja
{
    public class CierreGeneralDetalleReport
    {
        public string DescripcionCaja { get; set; }
        public string MontoSolesCaja { get; set; }
        public string MontoDolaresCaja { get; set; }
        public string DescripcionCajaOtros { get; set; }
        public string MontoSolesCajaOtros { get; set; }
        public string MontoDolaresCajaOtros { get; set; }

        public List<CierreGeneralDetalleReportDetalle> CierreGeneralDetalle_Subdetalle { get; set; }
    }
}
