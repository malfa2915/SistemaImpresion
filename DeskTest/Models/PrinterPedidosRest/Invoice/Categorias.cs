using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Categorias
    {
    public string IdEmpresa { get; set; }
    public string IdEstablecimiento { get; set; }
    public string IdItem { get; set; }
    public string Descripcion { get; set; }
    public string Tipo { get; set; }
    public string Estado { get; set; }
    public string fechaActualizacion { get; set; }
    public List<DocumentoFacturaDetalle> DocumentoFacturaDetalle { get; set; }
}

