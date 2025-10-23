using ExCSS;
using Helios.Cont.Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Helios.Cont.Business.Entity.rePrintResponse;

namespace DeskTest.Models.PrintModelsNew
{
    internal class documento_venta_detalle
    {
        public string nombre_Item { get; set; }
        public string unidad_medida { get; set; }
        public decimal cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal monto_igv { get; set; }
        public decimal monto_base { get; set; }
        public decimal descuento_item_percent { get; set; }
        public decimal descuento_item_monto { get; set; }
        public string codigo_BI { get; set; } //codigos de barra e interno
    }
}
