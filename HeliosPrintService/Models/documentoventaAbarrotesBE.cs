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

public partial class documentoventaAbarrotes 
{
    public int IDItem { get; set; }
    public string TipoExistencia { get; set; }
    public Status TypeQuery { get; set; }
    public string Filter { get; set; }
    public string TipoPrinter { get; set; }
    public string ExportarPrint { get; set; }
    public string orderWeb { get; set; }

    public int idRol { get; set; }
    public enum Status
    {
        Todos,
        Visible,
        NoVisible,
        /// <summary>
        ///         ''' Status: R
        ///         ''' </summary>
        Anulado
    }
    public string GetNumberWithZeros
    {
        get
        {
            return string.Format("{0:00000000}", numeroVenta.GetValueOrDefault());
        }
    }

    public string GetMoneda
    {
        get
        {
            if ((moneda == "1"))
                return "Nuevos Soles";
            else
                return "Moneda Extranjera";
        }
    }



    public string MontoPagado { get; set; }
    public string Vuelto { get; set; }

    public bool SaveAddressCustomer { get; set; }
    public bool SelectionOrder { get; set; }
    public bool SelectionOrderEsp { get; set; }
    public bool AgregaBE { get; set; }

    public string typeConsulta { get; set; }
    public string EstadoPagoDevolucion { get; set; }

    public string idPSE { get; set; }

   
    public bool tieneNota { get; set; }
    public decimal? ImporteDevMN { get; set; }
    public decimal? ImporteDevME { get; set; }
    public decimal? SaldoVentaMN { get; set; }
    public decimal? SaldoVentaME { get; set; }
    public decimal? MontoReversion { get; set; }
    public int CpePenRe { get; set; }
    public int CpePen { get; set; }
    public int AnuPen { get; set; }

    public string nombreCliente { get; set; }
    public string rucCliente { get; set; }

    public decimal? IgvDevMN { get; set; }
    public decimal? BiDevMN { get; set; }
    public decimal? Bi2DevMN { get; set; }

    public string TipoAfectado { get; set; }

    public int CountVentas { get; set; }
    public string TipoDocNumeracion { get; set; }
    public string TipoDocumentoBE { get; set; }
    // Public Property tipoOperacion() As String
    public string tipoDocEntidad { get; set; }
    public string NroDocEntidad { get; set; }
    public string NombreEntidad { get; set; }
    public string TipoPersona { get; set; }
    public string nombreEstablecimiento { get; set; }
    public string TipoConfiguracion { get; set; }
    public int IdNumeracion { get; set; }
    public decimal Quantity { get; set; }

    public string sustentado { get; set; }
    public int? conteoCuotas { get; set; }

    public string SerieNota { get; set; }
    public string NumeroNota { get; set; }
    public string TipoDocNota { get; set; }
    public DateTime FechaNota { get; set; }
    public DateTime FechaVenta { get; set; }
    public int idAlmacenOrigen { get; set; }


    public int idAlmacenSepracion { get; set; }

    public decimal Monto30mn { get; set; }
    public decimal Monto30me { get; set; }

    public decimal Monto60mn { get; set; }
    public decimal Monto60me { get; set; }

    public decimal Monto90mn { get; set; }
    public decimal Monto90me { get; set; }

    public decimal Monto90Masmn { get; set; }
    public decimal Monto90Masme { get; set; }

    public decimal PagoSumaMN { get; set; }
    public decimal PagoSumaME { get; set; }
    public int CajaSeleccionada { get; set; }

    public decimal Pago { get; set; }
    public decimal PagoME { get; set; }

    public decimal deuda { get; set; }
    public decimal deudaME { get; set; }

    public int? IdDocumentoCotizacion { get; set; }

    public decimal montocrono { get; set; }
    public decimal montocronome { get; set; }

    public decimal montovencido { get; set; }
    public decimal montovencidome { get; set; }
    public decimal ImportePagoVencidoMN { get; set; }
    public decimal ImportePagoVencidoME { get; set; }

    public decimal PagoNotaCreditoMN { get; set; }
    public decimal PagoNotaCreditoME { get; set; }
    public decimal PagoNotaDebitoMN { get; set; }
    public decimal PagoNotaDebitoME { get; set; }

    public decimal TotalFact { get; set; }
    public decimal TotalBoletas { get; set; }
    public decimal TotalNotasVenta { get; set; }
    public decimal TotalNotaCredito { get; set; }
    public int TotalAnulados { get; set; }
    public int CantFact { get; set; }
    public int CantBol { get; set; }
    public int CantNotaFact { get; set; }
    public int CantNotaBol { get; set; }
    public int CantFactAnu { get; set; }
    public int CantBolAnu { get; set; }

    // informe general
    public decimal ventaPos { get; set; }
    public decimal ventaPosContado { get; set; }
    public decimal ventaVtag { get; set; }
    public decimal ventaVtaggContado { get; set; }
    public decimal preVenta { get; set; }
    public decimal cuentasXCobrar { get; set; }

    public string formagoPago { get; set; }
    public string formagoPagoName { get; set; }
    public int idEntidad { get; set; }
    public int idEntidadDestino { get; set; }
    public string tipoEF { get; set; }
    public int idcosto { get; set; }
    public int idCajaUsuario { get; set; }
    public int secuenciaComp { get; set; }
    public int idDocumentoPadre { get; set; }
    public string GlosaPersonal { get; set; }

    public string stateFather { get; set; }

    public entidad CustomEntidad { get; set; }

   
    public List<string> ListaEstado { get; set; }

    public List<string> ListaIdDocumento { get; set; }

    public int idEstablecimientoDestino { get; set; }
    public string idEmpresaDes { get; set; }
    public List<int> listaIdEstablec { get; set; }

    public List<Cronograma> CustomCuotas { get; set; }
    //public List<documentoCajaDetalle> CustomDocuCaja { get; set; }
    public QueryPOS typeQueryPos { get; set; }
    public QueryAdmin typeQueryAdmin { get; set; }

    //public distribucionInfraestructura distribucionInfra { get; set; }

    public string url { get; set; }
    //public string GetEstadoPagoComprobante()
    //{
    //    List<string> beneficios = new List<string>();
    //    beneficios.Add("OFERTA");
    //    // beneficios.Add("DESCUENTO")

    //    var pagosPendientes = documentoventaAbarrotesDet.Where(o => o.estadoPago == "PN" & o.bonificacion == false & !beneficios.Contains(o.tipobeneficio)).Count;
    //    if (pagosPendientes > 0)
    //        return "PN";
    //    else
    //        return "DC";
    //}

    public string GetDocumentoIdentidad
    {
        get
        {
            var fullIdentidad = "N/A";
            if (CustomEntidad != null)
            {
                fullIdentidad = CustomEntidad.tipoDoc;

                switch (CustomEntidad.tipoDoc)
                {
                    case "1":
                        {
                            fullIdentidad = "Dni.";
                            break;
                        }

                    case "6":
                        {
                            fullIdentidad = "Ruc.";
                            break;
                        }

                    default:
                        {
                            fullIdentidad = "Otros";
                            break;
                        }
                }

                if (!string.IsNullOrWhiteSpace(CustomEntidad.nrodoc))
                    fullIdentidad += $"{Constants.vbCrLf}{CustomEntidad.nrodoc}";
            }

            return fullIdentidad;
        }
    }



    public decimal? SaldoReclamacion
    {
        get
        {
            return ImporteNacional.GetValueOrDefault() - ImporteDevMN.GetValueOrDefault();
        }
    }

    public string GetStatusOrder
    {
        get
        {
            switch (estado)
            {
                case "PN":
                    {
                        return "Pediente";
                    }

                case "AP":
                    {
                        return "Esperando el Pago";
                    }

                case "PC":
                    {
                        return "Esperando el Cumplimiento";
                    }

                case "PE":
                    {
                        return "Esperando Envio";
                    }

                case "AR":
                    {
                        return "Alto Riesgo";
                    }

                case "PO":
                    {
                        return "Orden Anticipada";
                    }

                case "ET":
                    {
                        return "Entregado";
                    }

                case "EP":
                    {
                        return "Entrega Parcial";
                    }
            }

            return "";
        }
    }

  
    public string GetTipoVenta
    {
        get
        {
            var str = "Venta normal";
            switch (tipoVenta)
            {
                case "VELC":
                case "NTCE":
                case "AELC":
                    {
                        str = "Electrónica";
                        break;
                    }

                case "NOTE":
                case "ANT":
                    {
                        str = "Nota venta";
                        break;
                    }

                case "VTAG":
                    {
                        str = "Venta normal";
                        break;
                    }

                case "OSA":
                    {
                        str = "Sálida de almacén";
                        break;
                    }

                case "OEA":
                    {
                        str = "Entrada a almacén";
                        break;
                    }

                case "VNC":
                    {
                        str = "Voucher";
                        break;
                    }

                case "TEA":
                    {
                        str = "Transferencia interna";
                        break;
                    }

                case "CTZ":
                    {
                        str = "Cotización";
                        break;
                    }
            }

            return str;
        }
    }

    public enum QueryAdmin
    {
        All,
        PendingPayment,
        PendingfulFillment,
        PendingShipping,
        Shipped,
        PendingApprobed,
        HighRisk,
        PreOrder,
        Deleted
    }

    public enum QueryPOS
    {
        Sales,
        SalesFull,
        OrdersPending,
        DeleteSingle,
        DeleteBulk,
        SalesByCustomer,
        SalesByCustomerPaginate,
        SalesCancelled,
        SalesByCustomerCancelled,
        Quote,
        Proforma,
        AllSales,
        ByReceipt,
        SalesByProducts,
        SalesByProductsPaginate,
        SalesByProductsDiscount,
        SalesByProductsDiscountPaginate,
        SalesByProductsProvider,
        SalesByProductsProviderPaginate,
        CustomersRecurring,
        CustomersRecurringPaginate,
        CustomersOneTime,
        CustomersOneTimePaginate,
        CustomersLoyal,
        CustomersLoyalPaginate,

        /// <summary>
        ///         ''' Otras Salidas de almacén
        ///         ''' </summary>
        OtherOutlets,
        SalesDetailedParametersPaginate,
        SalesDetailedParametersFull,

        /// <summary>
        ///         ''' Ventas Por Usuario
        ///         ''' </summary>
        SalesFullByUser
    }


    public bool ActivarConteo { get; set; }
    public int UltimoConteo { get; set; }
    public int Skip { get; set; }

    public int Limit { get; set; }

    public int TotalRows { get; set; }

    public int Residuo { get; set; }

    public string UsuarioVendedor { get; set; }

    public string nombreAlmacenOrigen { get; set; }

    public string nombreAlmacenDestino { get; set; }

    public string estadoDistribucion { get; set; }
    // Public Property idDistribucion As Integer

    public int VentasUltimos30Dias { get; set; }
    public int ClientesUltimos30Dias { get; set; }
    public int VentaXLargoTiempo { get; set; }
    public int VentaXProducto { get; set; }
    public int VentaXProveedor { get; set; }
    public int VentaXDescuento { get; set; }
    public int VentaXNombreCliente { get; set; }

    public int VentaXClientePrimeraVez { get; set; }
    public int VentaXClienteRecurrente { get; set; }
    public int VentaXClienteLeales { get; set; }
    public int VentaXClienteRegresan { get; set; }
    public int ClienteLargoTiempo { get; set; }
    public int RentabilidadMes { get; set; }
}
