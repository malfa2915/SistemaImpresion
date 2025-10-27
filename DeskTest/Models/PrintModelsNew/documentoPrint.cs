using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskTest.Models.PrintModelsNew
{
    public class documentoPrint
    {
        public string codigo_QR_base64 { get; set; }
        public string logo_base64 { get; set; }
        public string direccion_receptor { get; set; }
        public string moneda { get; set; }
        public string simbolo_moneda { get; set; } // S/. $
        public DatosEmpresa datos_Empresa { get; set; }
        public List<CuentaDolares> CuentaDolares { get; set; }
        public List<CuentaSoles> CuentaSoles { get; set; }
        public configuracion_inicio configuracion_Inicio { get; set; }
        public documento_venta documento_Venta { get; set; }
        public List<documento_venta_detalle> documento_Venta_Detalle { get; set; }
    }
}
