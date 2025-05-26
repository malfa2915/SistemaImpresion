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

public partial class documentoventaAbarrotesDet
{
    public int AlmacenSeparacion { get; set; }
    public int IdEstableSeparacion { get; set; }
    public string IdEmpresaSeparacion { get; set; }

    // Public Property codigoLote() As Integer
   
    public string GetDetail
    {
        get
        {
            var srt = nombreItem;
            if (idVariante.GetValueOrDefault() > 0)
            {
                if (CustomVariante == null)
                {
                    if ((variantName == null))
                        srt = $"{nombreItem}";
                    else
                        srt = $"{nombreItem}{Constants.vbCrLf}{variantName.ToLower()}";
                }
                else
                    srt = $"{nombreItem}{Constants.vbCrLf}{CustomVariante.VariantName.ToLower()}";
            }

            if (idLote.GetValueOrDefault() > 0)
                srt = $"{srt}{Constants.vbCrLf}Lote-{Customlote.nroLote}";

            return srt;
        }
    }

    public int TotalRows { get; set; }
    public bool SelectionItem { get; set; }
    public totalesAlmacenOthers CustomtotalesAlmacenOthers { get; set; }

    public bool afectoANota { get; set; }
    public int idItemDestino { get; set; }
    public string CodigoCosto { get; set; }
    public decimal? ContenidoNetoUnidadComercialMaxima { get; set; }
    public detalleitems CustomProducto { get; set; }

    public almacen CustomAlmacenPartida { get; set; }
    public almacen CustomAlmacenLlegada { get; set; }

    public List<documentoguiaDetalle> CustomTotalMovimientosGuia { get; set; }

    public recursoCostoLote Customlote { get; set; }
    public List<documentoventaAbarrotesDet> CustomListaVentaDetalle { get; set; }
    public List<InventarioMovimiento> CustomListaInventarioMovimiento { get; set; }
    public detalleitem_equivalencias CustomEquivalencia { get; set; }
    public detalleitemequivalencia_catalogos CustomCatalogo { get; set; }
    public ItemGrupo CustomItemGrupo { get; set; }
    public entidad CustomEntidad { get; set; }
    public int idDocuemntoNotaInv { get; set; }
    public string NomEstablecimiento { get; set; }

    public decimal saldoVentaMN { get; set; }
    public decimal saldoVentaME { get; set; }

    public decimal? ImporteDevolucionmn { get; set; }
    public decimal? ImporteDevolucionme { get; set; }
    public int cantidadVenta { get; set; }
    public decimal? IgvDevolucionmn { get; set; }
    public decimal? BiDevolucionmn { get; set; }
    public decimal? Bi2Devolucionmn { get; set; }

    public string IdEmpresa { get; set; }
    public int IdEstablecimiento { get; set; }
    public string Glosa { get; set; }

    public string DetalleItem { get; set; }
    public DateTime? FechaDoc { get; set; }

    public string CuentaProvedor { get; set; }
    public string NombreProveedor { get; set; }

    public string NumDoc { get; set; }
    public string Serie { get; set; }
    public string TipoDoc { get; set; }
    // Public Property idPadreDTCompra() As String

    public string FechaPeriodo { get; set; }
    public decimal ImporteDBMN { get; set; }
    public decimal ImporteDBME { get; set; }

    public string TipoOperacion { get; set; }
    public string FlagBonif { get; set; }
    public bool TieneExcedente { get; set; }
    public double stock { get; set; }

    public string nameTable { get; set; }
    public decimal? VentaTotalSinIgv { get; set; }
    public decimal? CostoTotalInv { get; set; }
    public string NombreAlmacen { get; set; }

    public decimal tipoCambio { get; set; }
    public string NomMarca { get; set; }

    public DateTime? FechaLaboral { get; set; }
    public decimal cantidadEntrega { get; set; }

    public decimal montokardexDB { get; set; }
    public decimal montokardexDBUS { get; set; }

    public decimal montoCompesacion { get; set; }
    public decimal montoCompesacionme { get; set; }

    public decimal montoDevuelto { get; set; }
    public decimal montoDevueltome { get; set; }

    public decimal cantNC { get; set; }
    public decimal igvNC { get; set; }
    public decimal igvNCME { get; set; }
    public decimal biNC { get; set; }
    public decimal biNCME { get; set; }

    public decimal cantPartial { get; set; }
    public int idDetRef { get; set; }

    public string estadoPagoPadre { get; set; }


    public decimal montoNC;
    public decimal montoNCME;

    public decimal montoPagoFin = 0;

    public string nombreComercial { get; set; }
    public string nombreVendedor { get; set; }
    public string tipoDocumento { get; set; }
    public string serieVenta { get; set; }
    public string numeroVenta { get; set; }
    public string nombrePedido { get; set; }


    public int idCliente { get; set; }
    public List<string> ListaEstado { get; set; }
    public List<string> ListaTipoVenta { get; set; }
    public List<int> ListaIdDocumento { get; set; }
    public ventaDetalle_oferta CustomOferta_Detalle { get; set; }
    public string EstagoCobroVenta { get; set; }
    public string Status { get; set; }
    // Public Property CustomGroupCustomerDetail As GroupCustomerDetail

    public documentoventaDetalleBeneficios CustomGroupCustomerDetailV2 { get; set; }

    public string estado { get; set; }
    public decimal peso { get; set; }
    public string TipoOperacion2 { get; set; }
    public decimal IVA { get; set; }
    public bool GetSustento
    {
        get
        {
            if (NomMarca == "Doc.")
                return true;
            else
                return false;
        }
    }

    public string EstadoPagos
    {
        get
        {
            if (MontoSaldo <= 0)
                return "DC";
            else
                return "PN";
        }
    }

    public decimal MontoSaldo
    {
        get
        {
            return importeMN.GetValueOrDefault - MontoPago;
        }
    }

    public decimal MontoSaldoME
    {
        get
        {
            return importeME.GetValueOrDefault - MontoPagoME;
        }
    }

    public string ItemSaldado
    {
        get
        {
            return "DC";
        }
    }

    public string ItemPendiente
    {
        get
        {
            return "PN";
        }
    }

    private decimal _montoPago;
    private decimal _montoPagoME;
    public decimal MontoPago
    {
        get
        {
            return _montoPago;
        }
        set
        {
            _montoPago = value;
        }
    }

    public decimal MontoPagoME
    {
        get
        {
            return _montoPagoME;
        }
        set
        {
            _montoPagoME = value;
        }
    }

    public decimal RentabilidadMN
    {
        get
        {
            return VentaTotalSinIgv.GetValueOrDefault() - CostoTotalInv.GetValueOrDefault();
        }
    }


    /// <summary>
    ///     ''' Suma de cantidades distribuidas
    ///     ''' </summary>
    ///     ''' <returns></returns>
    public decimal? GetCantidadAcuenta
    {
        get
        {
            decimal sumaCantidad = 0;
            sumaCantidad = cantidadEntrega;
            // If CustomTotalMovimientosGuia IsNot Nothing Then
            // sumaCantidad = CustomTotalMovimientosGuia.Sum(Function(o) o.cantidad).GetValueOrDefault()
            // End If
            return sumaCantidad;
        }
    }

    /// <summary>
    ///     ''' Saldo pendiente en unidades o cantidad
    ///     ''' </summary>
    ///     ''' <returns></returns>
    public decimal? GetCantidadSaldo
    {
        get
        {
            return decimal.Subtract(monto1.GetValueOrDefault, GetCantidadAcuenta.GetValueOrDefault());
        }
    }

    public decimal? PrecioUnitarioVentaMN { get; set; }
    public decimal? PrecioUnitarioVentaME { get; set; }

    public decimal? PagoSumaMN { get; set; }
    public decimal? PagoSumaME { get; set; }

    public decimal? totalVentaMN { get; set; }
    public decimal? totalVentaME { get; set; }

    public decimal? Menor { get; set; }
    public decimal? Mayor { get; set; }
    public decimal? GMayor { get; set; }
    public string codigoBarra { get; set; }
    public decimal? canDisponible { get; set; }

    public decimal cantidadInventario { get; set; }
    public bool AgregarBE { get; set; }
    public bool AfectoInventario { get; set; }

    public int conteoHospedados { get; set; }
    public DateTime fechaIngreso { get; set; }
    public DateTime fechaFin { get; set; }
    public List<personaBeneficio> listaPersonaHospedada { get; set; }

    public List<detalleitems_conexo> listaConexos { get; set; }
    public ocupacionInfraestructura ocupacionInfra { get; set; }
    public List<string> listaIdDistribucion { get; set; }
    public string hora { get; set; }
    public bool _paraLlevar { get; set; }
    public string isprinter { get; set; }

    public decimal? TotalOrder
    {
        get
        {
            switch (Status)
            {
                case "DESK":
                    {
                        switch (ColumTotalEdit)
                        {
                            case true:
                                {
                                    precioUnitario = Math.Round(decimal.Divide(importeMN.GetValueOrDefault(), monto1.GetValueOrDefault()), 2);
                                    TotalOrder = importeMN;


                                    importeMN = TotalOrder;
                                    importeMN = Math.Round(decimal.Subtract(importeMN, GetGrupoCustomerValue.GetValueOrDefault()), 2);
                                    importeMN = Math.Round(decimal.Subtract(importeMN, descuentoMN.GetValueOrDefault()), 2);


                                    // precioUnitario = Decimal.Divide(importeMN.GetValueOrDefault(), monto1.GetValueOrDefault())


                                    TotalOrder = importeMN;
                                    TotalOrder = Math.Round(decimal.Subtract(TotalOrder, GetGrupoCustomerValue.GetValueOrDefault()), 2);
                                    // TotalOrder = Decimal.Subtract(TotalOrder, descuentoMN.GetValueOrDefault())
                                    if (TotalOrder >= descuentoMN.GetValueOrDefault())
                                        TotalOrder = Math.Round(decimal.Subtract(TotalOrder, descuentoMN.GetValueOrDefault()), 2);
                                    else
                                        descuentoMN = 0.00;
                                    break;
                                }

                            default:
                                {
                                    importeMN = Math.Round(decimal.Multiply(monto1.GetValueOrDefault(), precioUnitario.GetValueOrDefault()), 2);
                                    importeMN = Math.Round(decimal.Subtract(importeMN, GetGrupoCustomerValue.GetValueOrDefault()), 2);
                                    importeMN = Math.Round(decimal.Subtract(importeMN, descuentoMN.GetValueOrDefault()), 2);
                                    TotalOrder = Math.Round(decimal.Multiply(monto1.GetValueOrDefault(), precioUnitario.GetValueOrDefault()), 2);
                                    TotalOrder = Math.Round(decimal.Subtract(TotalOrder, GetGrupoCustomerValue.GetValueOrDefault()), 2);
                                    // TotalOrder = Decimal.Subtract(TotalOrder, descuentoMN.GetValueOrDefault())
                                    if (TotalOrder >= descuentoMN.GetValueOrDefault())
                                        TotalOrder = Math.Round(decimal.Subtract(TotalOrder, descuentoMN.GetValueOrDefault()), 2);
                                    else
                                        descuentoMN = 0.00;
                                    break;
                                }
                        }

                        break;
                    }

                case "WEB":
                    {

                        // importeMN = Decimal.Multiply(monto1.GetValueOrDefault(), precioUnitario.GetValueOrDefault())
                        // importeMN = Decimal.Subtract(importeMN, GetGrupoCustomerValue.GetValueOrDefault())
                        // importeMN = Decimal.Subtract(importeMN, descuentoMN.GetValueOrDefault())
                        TotalOrder = Math.Round(decimal.Multiply(monto1.GetValueOrDefault(), precioUnitario.GetValueOrDefault()), 2);
                        TotalOrder = Math.Round(decimal.Subtract(TotalOrder, GetGrupoCustomerValue.GetValueOrDefault()), 2);
                        // TotalOrder = Decimal.Subtract(TotalOrder, descuentoMN.GetValueOrDefault())
                        if (TotalOrder >= descuentoMN.GetValueOrDefault())
                            TotalOrder = Math.Round(decimal.Subtract(TotalOrder, descuentoMN.GetValueOrDefault()), 2);
                        else
                            descuentoMN = 0.00;
                        break;
                    }
            }
        }
    }

    public bool ColumTotalEdit { get; set; }

    public decimal? GetIvaOrder
    {
        get
        {
            switch (Status)
            {
                case "DESK":
                    {
                        if (TotalOrder.GetValueOrDefault() <= 0)
                        {
                            GetIvaOrder = 0;
                            montoIgv = 0;
                        }
                        else
                            switch (destino)
                            {
                                case "1":
                                    {
                                        GetIvaOrder = Math.Round(decimal.Subtract(TotalOrder.GetValueOrDefault(), GetBaseImponibleOrder.GetValueOrDefault()), 2);
                                        montoIgv = Math.Round(decimal.Subtract(TotalOrder.GetValueOrDefault(), GetBaseImponibleOrder.GetValueOrDefault()), 2);
                                        break;
                                    }

                                case "2":
                                    {
                                        GetIvaOrder = 0;
                                        montoIgv = 0;
                                        break;
                                    }
                            }

                        break;
                    }

                case "WEB":
                    {
                        if (TotalOrder.GetValueOrDefault() <= 0)
                            GetIvaOrder = 0;
                        else
                            switch (destino)
                            {
                                case "1":
                                    {
                                        GetIvaOrder = Math.Round(decimal.Subtract(TotalOrder.GetValueOrDefault(), GetBaseImponibleOrder.GetValueOrDefault()), 2);
                                        break;
                                    }

                                case "2":
                                    {
                                        GetIvaOrder = 0;
                                        break;
                                    }
                            }

                        break;
                    }
            }
        }
    }

    public decimal? GetBaseImponibleOrder
    {
        get
        {
            switch (Status)
            {
                case "DESK":
                    {
                        switch (destino)
                        {
                            case "1":
                                {
                                    // GetBaseImponibleOrder = Math.Round(Decimal.Divide(TotalOrder.GetValueOrDefault(), 1.18), 2)
                                    // montokardex = Math.Round(Decimal.Divide(TotalOrder.GetValueOrDefault(), 1.18), 2)
                                    GetBaseImponibleOrder = Math.Round(decimal.Divide(TotalOrder.GetValueOrDefault(), ((IVA / (double)100) + 1)), 2);
                                    montokardex = Math.Round(decimal.Divide(TotalOrder.GetValueOrDefault(), ((IVA / (double)100) + 1)), 2);
                                    break;
                                }

                            case "2":
                                {
                                    GetBaseImponibleOrder = 0; // TotalOrder.GetValueOrDefault()
                                    montokardex = TotalOrder.GetValueOrDefault();
                                    break;
                                }
                        }

                        break;
                    }

                case "WEB":
                    {
                        switch (destino)
                        {
                            case "1":
                                {
                                    // GetBaseImponibleOrder = Math.Round(Decimal.Divide(TotalOrder.GetValueOrDefault(), 1.18), 2)
                                    GetBaseImponibleOrder = Math.Round(decimal.Divide(TotalOrder.GetValueOrDefault(), ((IVA / (double)100) + 1)), 2);
                                    break;
                                }

                            case "2":
                                {
                                    GetBaseImponibleOrder = 0; // TotalOrder.GetValueOrDefault()
                                    break;
                                }
                        }

                        break;
                    }
            }
        }
    }
    public decimal? GetExoneradoOrder
    {
        get
        {
            switch (destino)
            {
                case "1":
                    {
                        GetExoneradoOrder = 0;
                        break;
                    }

                case "2":
                    {
                        GetExoneradoOrder = Math.Round(TotalOrder.GetValueOrDefault(), 2);
                        break;
                    }
            }
        }
    }


    public decimal? GetGrupoCustomerValue
    {
        get
        {
            decimal valorDsctoGrupo = 0;
            if (CustomGroupCustomerDetailV2 != null)
            {
                switch (CustomGroupCustomerDetailV2.DiscountRate)
                {
                    case "Descuento porcentual":
                        {
                            var total = decimal.Multiply(monto1, precioUnitario);
                            var DiscountPercent = Math.Round(decimal.Divide(CustomGroupCustomerDetailV2.DiscountValue, 100), 2);
                            var totalDiscountEval = Math.Round(decimal.Multiply(total, DiscountPercent), 2);
                            // valorDsctoGrupo = Decimal.Subtract(importeMN, totalDiscountEval)
                            valorDsctoGrupo = totalDiscountEval;
                            break;
                        }

                    case "Descuento en el precio":
                        {
                            var DiscountEval = Math.Round(System.Convert.ToDecimal(CustomGroupCustomerDetailV2.DiscountValue), 2);
                            // Dim totalDiscountEval = Decimal.Multiply(importeMN, DiscountEval)
                            // valorDsctoGrupo = Decimal.Subtract(importeMN, DiscountEval)
                            valorDsctoGrupo = DiscountEval;
                            break;
                        }
                }
            }

            switch (Status)
            {
                case "DESK":
                    {
                        descuentoGrupoMN = valorDsctoGrupo;
                        break;
                    }

                case "WEB":
                    {
                        break;
                    }
            }


            return valorDsctoGrupo;
        }
    }

    public string GetGrupoCustomerInformation
    {
        get
        {
            string Info = "N/A";
            if (CustomGroupCustomerDetailV2 != null)
            {
                switch (CustomGroupCustomerDetailV2.DiscountRate)
                {
                    case "Descuento porcentual":
                        {
                            Info = $"{CustomGroupCustomerDetailV2.DiscountRate}";
                            var DiscountPercent = Math.Round(decimal.Divide(CustomGroupCustomerDetailV2.DiscountValue, 100), 2);
                            // ' Dim totalDiscountEval = Math.Round(Decimal.Multiply(importeMN, DiscountPercent), 2)
                            // 'valorDsctoGrupo = Decimal.Subtract(importeMN, totalDiscountEval)
                            Info += $"{Constants.vbCrLf}Valor: {CustomGroupCustomerDetailV2.DiscountValue} %";
                            break;
                        }

                    case "Descuento en el precio":
                        {
                            Info = $"{CustomGroupCustomerDetailV2.DiscountRate}";

                            var DiscountEval = Math.Round(System.Convert.ToDecimal(CustomGroupCustomerDetailV2.DiscountValue), 2);
                            // Dim totalDiscountEval = Decimal.Multiply(importeMN, DiscountEval)
                            // valorDsctoGrupo = Decimal.Subtract(importeMN, DiscountEval)
                            Info += $"{Constants.vbCrLf}Valor: {DiscountEval}";
                            break;
                        }
                }
            }

            return Info;
        }
    }

    public string GetNameWithUnit
    {
        get
        {
            if (nombreItem != null)
            {
                string strProduct = nombreItem;
                // If nombreItem.ToString.Trim.Length > 40 Then
                // strProduct = nombreItem.Substring(0, 40) & "..."
                // End If
                if (tipoExistencia == "GS")
                    return $" {strProduct}{Environment.NewLine}";
                else if (CustomProducto != null)
                    return $" {strProduct}{Environment.NewLine}UM: {CustomProducto.unidad1}";
                else
                    return $" {strProduct}";
            }
            else
                return "";
        }
    }


    public string GetResumen
    {
        get
        {
            if (nombreItem != null)
            {
                string strProduct = nombreItem;
                if (nombreItem.ToString.Trim.Length > 40)
                    strProduct = nombreItem.Substring(0, 40) + "...";

                if (tipoExistencia == "GS")
                    return $" {strProduct}{Environment.NewLine} {importeMN.GetValueOrDefault().ToString("N2")}";
                else
                    return $" {monto1.GetValueOrDefault().ToString("N2")} {strProduct}{Environment.NewLine} {importeMN.GetValueOrDefault().ToString("N2")}";
            }
            else
                return "";
        }
    }

    public string GetResumenUnidadComercial
    {
        get
        {
            if (nombreItem != null)
            {
                string strProduct = nombreItem;
                if (nombreItem.ToString.Trim.Length > 40)
                    strProduct = nombreItem.Substring(0, 40) + "...";

                if (CustomVariante != null)
                    return $" {GetDetail}{Environment.NewLine} {importeMN.GetValueOrDefault().ToString("N2")}";
                else if (tipoExistencia == "GS")
                    return $" {strProduct}{Environment.NewLine} {importeMN.GetValueOrDefault().ToString("N2")}";
                else if (tipoExistencia == "09")
                    return $" {monto1.GetValueOrDefault().ToString("N2")} {strProduct}{Environment.NewLine} {importeMN.GetValueOrDefault().ToString("N2")} ";
                else if (CustomEquivalencia != null)
                {
                    if (idLote.GetValueOrDefault > 0)
                        return $" {monto1.GetValueOrDefault().ToString("N2")} {strProduct}{Environment.NewLine} {importeMN.GetValueOrDefault().ToString("N2")}  ({CustomEquivalencia.unidadComercial})-Lote:{Customlote.codigoLote}";
                    else
                        return $" {monto1.GetValueOrDefault().ToString("N2")} {strProduct}{Environment.NewLine} {importeMN.GetValueOrDefault().ToString("N2")}  ({CustomEquivalencia.unidadComercial})";
                }
                else
                    return "";
            }
            else
                return "";
        }
    }


    public string GetInfoBeneficio
    {
        get
        {
            var str = "";
            if (documentoventaDetalleBeneficios != null)
            {
                foreach (var ben in documentoventaDetalleBeneficios)
                    str += $"{ben.Cantidad} {ben.UnidadComercial} {ben.Nombre}{Environment.NewLine}";
            }
            return str;
        }
    }

    public List<string> ListaImpresion { get; set; }

    public string TransferenciaOrigen { get; set; }
    public string TranferenciaDestino { get; set; }
}
