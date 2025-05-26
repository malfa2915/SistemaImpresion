
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

public partial class entidad
{
    public int idEntidad { get; set; }
    public string idEmpresa { get; set; }
    public Nullable<int> idOrganizacion { get; set; }
    public Nullable<int> IdGroup { get; set; }
    public string tipoEntidad { get; set; }
    public string tipoPersona { get; set; }
    public string tipoDoc { get; set; }
    public string nrodoc { get; set; }
    public string nombre { get; set; }
    public string appat { get; set; }
    public string apmat { get; set; }
    public string nombre1 { get; set; }
    public string nombre2 { get; set; }
    public string nombreCompleto { get; set; }
    public string direccion { get; set; }
    public string telefono { get; set; }
    public string celular { get; set; }
    public string nextel { get; set; }
    public string email { get; set; }
    public string estado { get; set; }
    public string cuentaAsiento { get; set; }
    public string nombreContacto { get; set; }
    public byte[] huella { get; set; }
    public Nullable<bool> tieneBeneficio { get; set; }
    public Nullable<decimal> CreditInStore { get; set; }
    public string usuarioModificacion { get; set; }
    public Nullable<DateTime> fechaModificacion { get; set; }
    public Nullable<DateTime> dateBirth { get; set; }
    public string ubigeo { get; set; }
    public string vinc_mediocontacto { get; set; }
    public string vinc_nrodoc { get; set; }
    public string vinc_fullName { get; set; }
    public string vinc_cargo { get; set; }
    public Nullable<DateTime> vinc_fecha { get; set; }
    public string vinc_tipodoc { get; set; }

    //public virtual List<activosFijos> activosFijos { get; set; } = new HashSet<activosFijos>().ToList();
    //public virtual List<beneficio> beneficio { get; set; } = new HashSet<beneficio>().ToList();
    //public virtual List<beneficioConsumo> beneficioConsumo { get; set; } = new HashSet<beneficioConsumo>().ToList();
    //public virtual List<contract> contract { get; set; } = new HashSet<contract>().ToList();
    //public virtual List<documentocompra> documentocompra { get; set; } = new HashSet<documentocompra>().ToList();
    //public virtual List<entidadAddressBook> entidadAddressBook { get; set; } = new HashSet<entidadAddressBook>().ToList();
    //public virtual EntidadAfiliacionBeneficio EntidadAfiliacionBeneficio { get; set; }
    //public virtual List<entidadAtributos> entidadAtributos { get; set; } = new HashSet<entidadAtributos>().ToList();
    //public virtual List<EntidadFile> EntidadFile { get; set; } = new HashSet<EntidadFile>().ToList();
    //public virtual List<Entidadmembresia_Gym> Entidadmembresia_Gym { get; set; } = new HashSet<Entidadmembresia_Gym>().ToList();
}
