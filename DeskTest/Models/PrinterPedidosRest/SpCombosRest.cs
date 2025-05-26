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
public class SpCombosRest
    {
    public string Iddocumento { get; set; }
    public string IdordenDetalle { get; set; }
    public string ReferenciBeneficio { get; set; }
    public string ReferenciaProducto { get; set; }
    public string Afectaciontributaria { get; set; }
    public string TipoBeneficio { get; set; }
    public string TipoExistencia { get; set; }
    public string Cantidad { get; set; }
    public string NombreCombo { get; set; }
    public string DetailCombo { get; set; }
    public string UnidMedidaCombo { get; set; }
    public string UnidadComercialIdCombo { get; set; }
    public string UnidadComercialCombo { get; set; }
    public string DisCountRateCombo { get; set; }
    public string DisCountValueCombo { get; set; }
    public string UnidadComercialContenidoCombo { get; set; }
    public string PrecioCombo { get; set; }
    public string TotalCombo { get; set; }
    public string QtycookCombo { get; set; }
    public string DisCounValueCombo { get; set; }
    public List<SpAdicionalRestDet> AdicionalRestDet { get; set; }
}

