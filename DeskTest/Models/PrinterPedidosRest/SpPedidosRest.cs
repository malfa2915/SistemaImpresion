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

public class SpPedidosRest
{
    public string FechaPedido { get; set; }
    public string CargoPedido { get; set; }
    public string Usuario { get; set; }
    public string Moviliario { get; set; }
    public string TotalImporte { get; set; }
    public string Cliente { get; set; }
    public string DocCliente { get; set; }

    public List<SpPedidosRestDet> PedidosRestDet { get; set; }
    public List<DatosEmpresa> DatosEmpresa { get; set; }
}
