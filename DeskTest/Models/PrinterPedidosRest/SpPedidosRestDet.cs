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
public class SpPedidosRestDet
{
    public string DescPediDet { get; set; }
    public string CantidadDet { get; set; }
    public string Importe { get; set; }
    public string Precio { get; set; }
    public string UnidadMedida { get; set; }
    public List<SpComplementoRest> ComplementosRest { get; set; }
    public List<SpCombosRest> CombosRest { get; set; }
}
