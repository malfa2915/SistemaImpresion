using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class DocumentoGuiaP
    {
        public string Ruc { get; set; }
        public string Serie { get; set; }
        public string NroSerie { get; set; }
        public string FechaEmision { get; set; }
        public string FechaInicioTraslado { get; set; }
        public string MotivoTraslado { get; set; }
        public string ModalidadTransporte { get; set; }
        public string TipoTraslado { get; set; }
        public string PesoBruto { get; set; }
        public string RazonDestinatario { get; set; }
        public string DocDestinatario { get; set; }
        public string PuntoPartida { get; set; }
        public string PuntoLlegada { get; set; }
        public string ObervacionesGuias { get; set; }
        public string ObervacionesOtros { get; set; }
        public List<Conductores> Conductores { get; set; }
        public List<DocumentoGuiaDetalleP> DocumentoGuiaDetalle { get; set; }
        public List<DatosEmpresa> DatosEmpresa { get; set; }
        public List<Placas> Placas { get; set; }
    }

