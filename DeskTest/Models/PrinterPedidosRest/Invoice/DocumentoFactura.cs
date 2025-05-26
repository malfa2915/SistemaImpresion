using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DocumentoFactura
{
    public string SerieFact { get; set; }
    public string NroSerieFact { get; set; }
    public string RucPasajero { get; set; }
    public string Pasajero { get; set; }
    public string DireccionPasajero { get; set; }
    public string RucCliente { get; set; }
    public string Cliente { get; set; }
    public string Direccion { get; set; }
    public string TipoMoneda { get; set; }
    public string FechaEmision { get; set; }
    public string FechaVencimiento { get; set; }
    public string NumeroPedido { get; set; }
    public string OrdenCompra { get; set; }
    public string NumeroGuia { get; set; }
    public string CondicionPago { get; set; }
    public string OpGratuitas { get; set; }
    public string OpExonerada { get; set; }
    public string OpInafecto { get; set; }
    public string OpGravada { get; set; }
    public string TotalDescuento { get; set; }
    public string ISC { get; set; }
    public string IGV { get; set; }
    public string ICBPER { get; set; }
    public string ImporteTotal { get; set; }
    public string Obsevaciones { get; set; }
    public string CodQR { get; set; }
    public string CodBarra { get; set; }
    public string Vendedor { get; set; }
    public string Cajero { get; set; }
    public string Efectivo { get; set; }
    public string Vuelto { get; set; }
    public string Asiento { get; set; }
    public string FechaViaje { get; set; }
    public string HoraViaje { get; set; }
    public string Origen { get; set; }
    public string DireccionOrigen { get; set; }
    public string Destino { get; set; }
    public string DireccionDestino { get; set; }
    public string Servicio { get; set; }
    public string DescTerminos { get; set; }

    public List<DatosEmpresa> DatosEmpresa { get; set; }
    public List<DocumentoFacturaDetalle> DocumentoFacturaDetalle { get; set; }
    public List<CronogramaPagos> CronogramaPagos { get; set; }
    public List<CuentaDolares> CuentaDolares { get; set; }
    public List<CuentaSoles> CuentaSoles { get; set; }
    public List<CuentaSoles_Dolares> CuentaSoles_Dolares { get; set; }
    public List<Direcciones> Direcciones { get; set; }
    public List<NotaCredito> NotaCredito { get; set; }
    public List<Cuentas_Cobrar> Cuentas_Cobrar { get; set; }
    public List<spkDocumentoCajaDetalle> DocumentoCajaDetalle { get; set; }
 

}



