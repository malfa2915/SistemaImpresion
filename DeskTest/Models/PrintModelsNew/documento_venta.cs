using ExCSS;
using JNetFx.Framework.Licensing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace DeskTest.Models.PrintModelsNew
{
    public class documento_venta
    {
        public string tipo_Documento { get; set; } // 01=Factura, 03=Boleta, 9907=NF, 07=NC, 08=ND
        public DateTime fecha_emision { get; set; }
        public string serie { get; set; }
        public int numero { get; set; }
        public decimal tasa_igv { get; set; } // % igv
        public decimal monto_exonerado { get; set; } //bi02
        public decimal monto_gravado { get; set; } //bi01
        public decimal monto_inafecto { get; set; }
        public decimal monto_igv { get; set; } //igv01
        public decimal monto_total_venta { get; set; } //monto dle comprobante
        public string monto_en_letras { get; set; }
        public string tipo_documento_receptor { get; set; } // 6=RUC, 1=DNI
        public string numero_documento_receptor { get; set; }
        public string razon_social_receptor { get; set; }
        public string cajero_nombre_venta { get; set; }  //nombre cajero operacion
        public string glosa { get; set; } //glosa - observaciones
        public string tipo_pago { get; set; } // CONTADO, CREDITO, CRONOGRAMA  terminos
        public decimal efectivo_recepcionado { get; set; } // Monto Pagado en efectivo
        public decimal descuento_global_percent { get; set; }
        public decimal descuento_global_monto { get; set; }
    }
}
