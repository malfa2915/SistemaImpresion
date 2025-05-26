using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public class SpDocumentoCompra
    {
        public string SerieFactCompra { get; set; }
        public string NroSerieFactCompra { get; set; }
        public string RucPasajeroCompra { get; set; }
        public string PasajeroCompraCompra { get; set; }
        public string DireccionPasajeroCompra { get; set; }
        public string RucClienteCompra { get; set; }
        public string ClienteCompra { get; set; }
        public string DireccionCompra { get; set; }
        public string TipoMonedaCompra { get; set; }
        public string FechaEmisionCompra { get; set; }
        public string FechaVencimientoCompra { get; set; }
        public string NumeroPedidoCompra { get; set; }
        public string OrdenCompraCompra { get; set; }
        public string NumeroGuiaCompra { get; set; }
        public string CondicionPagoCompra { get; set; }
        public string OpGratuitasCompra { get; set; }
        public string OpExoneradaCompra { get; set; }
        public string OpInafectoCompra { get; set; }
        public string OpGravadaCompra { get; set; }
        public string TotalDescuentoCompra { get; set; }
        public string ISCCompra { get; set; }
        public string IGVCompra { get; set; }
        public string ICBPERCompra { get; set; }
        public string ImporteTotalCompra { get; set; }
        public string ObsevacionesCompra { get; set; }
        public string CodQRCompra { get; set; }
        public string CodBarraCompra { get; set; }
        public string VendedorCompra { get; set; }
        public string CajeroCompra { get; set; }
        public string EfectivoCompra { get; set; }
        public string VueltoCompra { get; set; }
        public string AsientoCompra { get; set; }
        public string FechaViajeCompra { get; set; }
        public string HoraViajeCompra { get; set; }
        public string OrigenCompra { get; set; }
        public string DireccionOrigenCompra { get; set; }
        public string DestinoCompra { get; set; }
        public string DireccionDestinoCompra { get; set; }
        public string ServicioCompra { get; set; }
        public string DescTerminosCompra { get; set; }

        public List<DatosEmpresa> DatosEmpresa { get; set; }
        public List<SpDocumentoCompraDetalle> DocumentoCompraDetalle { get; set; }
        public List<CronogramaPagos> CronogramaPagos { get; set; }
        public List<CuentaDolares> CuentaDolares { get; set; }
        public List<CuentaSoles> CuentaSoles { get; set; }
        public List<CuentaSoles_Dolares> CuentaSoles_Dolares { get; set; }
        public List<Direcciones> Direcciones { get; set; }
        public List<NotaCredito> NotaCredito { get; set; }
        public List<Cuentas_Cobrar> Cuentas_Cobrar { get; set; }
        public List<spkDocumentoCajaDetalle> DocumentoCajaDetalle { get; set; }
    }

