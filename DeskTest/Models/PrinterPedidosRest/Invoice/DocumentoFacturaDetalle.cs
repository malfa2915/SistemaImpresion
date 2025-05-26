using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public  class DocumentoFacturaDetalle
    {
        public string NroItem { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Unidad { get; set; }
        public string Cantidad { get; set; }
        public string PrecioUnitario { get; set; }
        public string Descuento { get; set; }
        public string DescuentoImporte { get; set; }
        public string Importe { get; set; }

    public List<DocumentoFacturaDetalleDescuentos> DocumentoFacturaDetalleDescuentos { get; set; }

}

