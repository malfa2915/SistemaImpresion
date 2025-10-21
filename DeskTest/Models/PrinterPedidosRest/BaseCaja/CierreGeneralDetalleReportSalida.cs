using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskTest.Models.PrinterPedidosRest.BaseCaja
{
    public class CierreGeneralDetalleReportSalida
    {
        public string HeadTituloS { get; set; }
        public string DescripcionCajaS { get; set; }
        public string MontoSolesCajaS { get; set; }
        public string MontoDolaresCajaS { get; set; }

        public List<CierreGeneralDetalleReportSalidaDetalle> CierreGeneralDetalleSalida_SubDetalle { get; set; }
    }
}
