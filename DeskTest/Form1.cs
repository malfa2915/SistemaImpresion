using DeskTest.Api;
using FastReport.Design.ToolWindows;
using Fizzler;
using Helios.Cont.Business.Entity;
using Helios.Cont.Business.Logic;
using Helios.Seguridad.Business.Entity;
using Helios.Seguridad.Business.Logic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static Helios.Cont.Business.Entity.documentocompra;
//using static Helios.General.Constantes;

namespace DeskTest
{
    public partial class Form1 : Form
    {
        //private List<datosGenerales> Datosgen = new List<datosGenerales>();
        public Form1()
        {
            InitializeComponent();


        }

        public static async Task<bool> ValidarDelete(PrintQueue obj )
        {
            var returde = await PrintQueueAPI.DeleteV2(obj.Id, obj.idEmpresa, obj.idEstablecimiento.GetValueOrDefault());
            return returde;
        }
        private async Task GetOrderQueue()
        {

      
            Commons commons = new Commons();
            //listar todo
            var ordersList = await PrintQueueAPI.GetAllV2();
            var returdelete = false;

            //listar por establecimiento
            //var ordersList = await PrintQueueAPI.GetAllVEstEmp("10765867679", 2);

            //listar por establecimiento y nombre de la amquina o IP
            //var ordersList = await PrintQueueAPI.GetAllVEstEmpHostnameIP("20606908262", 1, "WIN-UCBLSLLN1VU", "192.168.0.1");
            if (ordersList!=null)
            {

                if (ordersList.Count > 0)
                {

                    foreach (var obj in ordersList)
                    {
                        returdelete = await ValidarDelete(obj);


                        if (obj.TipoEnvioImpresion == "Comprobante")
                        {

                            if (returdelete == true)
                            {

                                var objPrint = new ImpresorasNegocio();
                                objPrint.estadoImpresora = "A";
                                objPrint.tipoImpresora = "COMPROBANTE";
                                objPrint.idEstablecimiento = obj.idEstablecimiento;
                                objPrint.idEmpresa = obj.idEmpresa;
                                

                                var VentaPrintDirect = await DocumentoVentaAPI.directPrinting(obj.IdDocumento.GetValueOrDefault(), obj.FormatoTipo, obj.idEstablecimiento.GetValueOrDefault(), obj.idEmpresa);
                                VentaPrintDirect.PrintNegocio = VentaPrintDirect.PrintNegocioLis.Where(s => s.TipoImpresora.ToUpper() == objPrint.tipoImpresora && s.printOutput==obj.Formato).FirstOrDefault();
           
                                if (VentaPrintDirect.PrintNegocio != null)

                                {

                                    var venta = new documentoventaAbarrotes();

                                    venta.idEmpresa = VentaPrintDirect.idEmpresa;
                                    venta.idEstablecimiento = VentaPrintDirect.idEstablecimiento;


                                    //var detallepagos = await DocumentoVentaAPI.GetDocumentoCajaDetalle(obj.IdDocumento.GetValueOrDefault());
                                    //if (detallepagos.Count > 0)
                                    //{
                                    //    VentaPrintDirect.Pagos = new List<rePrintResponse.mediosDePago>();
                                    //    foreach (var item in detallepagos)
                                    //    {
                                    //        var det = new rePrintResponse.mediosDePago();
                                    //        det.medioDePago = item.DescripcionBE;
                                    //        det.nombreEntidad = item.DescripcionfinacieraBE;
                                    //        det.importePago = (decimal)item.montoSoles;
                                    //        VentaPrintDirect.Pagos.Add(det);
                                    //    }
                                    //}


                                    var DatosGen = VentaPrintDirect.DatosGenLis.Where(s => s.tipoImpresion == obj.Formato).FirstOrDefault();
                                    VentaPrintDirect.DatosGen = DatosGen;

 
                                    if (VentaPrintDirect.PrintNegocio != null && DatosGen != null)
                                    {
                                        if (obj.Formato == "A4")
                                        {
                                            commons.ImprimirComprobanteA4(VentaPrintDirect, venta.usuarioOperacion, "", venta.cargoOperacion, venta.nombreDistribucion, venta.fechaDoc.ToString(), obj);

                                        }
                                        else if(obj.Formato == "A5")
                                        {
                                            commons.ImprimirComprobanteA5(VentaPrintDirect, venta.usuarioOperacion, "", venta.cargoOperacion, venta.nombreDistribucion, venta.fechaDoc.ToString(), obj);

                                        }
                                        else
                                        {
                                            commons.ImprimirComprobanteFinal(VentaPrintDirect, venta.usuarioOperacion, "", venta.cargoOperacion, venta.nombreDistribucion, venta.fechaDoc.ToString(), obj);

                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No existe impresora configurada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }

                                }
             
                            }

                        }

                        else if (obj.TipoEnvioImpresion == "Compra")
                        {
                            //var returdelete = await PrintQueueAPI.DeleteV2(obj.Id, obj.idEmpresa, obj.idEstablecimiento.GetValueOrDefault());
                            //returdelete = await ValidarDelete(obj);
                            if (returdelete == true)
                            {
                                var VentaPrintDirect = await DocumentoCompraAPI.PrintCompra(obj.IdDocumento.GetValueOrDefault());

                                var objPrint = new ImpresorasNegocio();
                                objPrint.estadoImpresora = "A";
                                objPrint.tipoImpresora = "Comprobante";
                                objPrint.idEstablecimiento = obj.idEstablecimiento;
                                objPrint.idEmpresa = obj.idEmpresa;

                                var impresoraCombrobanteFinal = await ImpresorasNegocioAPI.GetListaImpresoraPreCuenta(objPrint);
                                var ImpreNego = impresoraCombrobanteFinal.Where(s => s.PrintOutput == obj.Formato && s.idEstablecimiento == obj.idEstablecimiento && s.idEmpresa == obj.idEmpresa).FirstOrDefault();
                                commons.ImprimirCompra(VentaPrintDirect, obj.Formato, ImpreNego);
                            }

                        }
                        else if (obj.TipoEnvioImpresion == "kardex")
                        {
                            var Documnentp= new documentoventaAbarrotes();
                            Documnentp.idEmpresa = obj.idEmpresa;
                            Documnentp.idEstablecimiento = obj.idEstablecimiento.GetValueOrDefault();
                            Documnentp.usuarioActualizacion = obj.IdUsuario.ToString();
                            Documnentp.idRol = obj.IdRol.GetValueOrDefault();
                            var VentaPrintDirect = await CajasAPI.ProductosCategoria(Documnentp);

                            var objPrint = new ImpresorasNegocio();
                            objPrint.estadoImpresora = "A";
                            objPrint.tipoImpresora = "Comprobante";//para directo con el comprobante
                            objPrint.idEstablecimiento = obj.idEstablecimiento;
                            objPrint.idEmpresa = obj.idEmpresa;

                            var impresoraCombrobanteFinal = await ImpresorasNegocioAPI.GetListaImpresoraPreCuenta(objPrint);
                            var ImpreNego = impresoraCombrobanteFinal.Where(s => s.PrintOutput == "TK").FirstOrDefault();

                            commons.ImprimirProductosCategoria(VentaPrintDirect, ImpreNego);
                        }
                        else if (obj.TipoEnvioImpresion == "Cuentas_Cobrar")
                        {


                        }
                        else if (obj.TipoEnvioImpresion == "CIERRECAJA")
                        {

                            var query= new cajaUsuario();

                            var objPrint = new ImpresorasNegocio();
                            objPrint.estadoImpresora = "A";
                            objPrint.tipoImpresora = "Comprobante";
                            objPrint.idEstablecimiento = obj.idEstablecimiento;
                            objPrint.idEmpresa = obj.idEmpresa;

                            var impresoraCombrobanteFinal = await ImpresorasNegocioAPI.GetListaImpresoraPreCuenta(objPrint);
                            var ImpreNego = impresoraCombrobanteFinal.Where(s => s.PrintOutput == "TK").FirstOrDefault();


                            if (obj.NombreDistribucion=="Impresion")
                            {
                                var cierre = new cajaUsuario();
                                cierre.idEmpresa = obj.idEmpresa;
                                cierre.idEstablecimiento = obj.idEstablecimiento;
                                cierre.idPersona = obj.IdUsuario.GetValueOrDefault().ToString();
                                cierre.estadoCaja ="C";
                                cierre.IDRol = obj.IdRol;
                                cierre.tipoCaja = "POS";

                                query = await CajasAPI.ReportCierre(cierre);

                            }
                            else {
                                var listBoxActives = await CajasAPI.GetUsers(obj.idEmpresa, obj.idEstablecimiento.GetValueOrDefault());

                                 query = (from i in listBoxActives
                                             where i.idPersona == obj.IdUsuario.ToString() & i.estadoCaja == "A" & i.IDRol == int.Parse(obj.IdRol.ToString())
                                                && i.tipoCaja == "POS" && i.idEstablecimiento == obj.idEstablecimiento.GetValueOrDefault()
                                             select i).SingleOrDefault();
                            }


                            List<documentoCaja> ListaFiltrada = new List<documentoCaja>();

                            if (query != null)
                            {

                                documentoCaja box = new documentoCaja();
                                box.idEmpresa = obj.idEmpresa;
                                box.idEstablecimiento = obj.idEstablecimiento;
                                box.idCajaUsuario = query.idcajaUsuario;
                                box.fechaCobro = DateTime.Now;

                                var cjasReport = await CajasAPI.GetKardexReport(box);


                                var usersall = await UserAPI.GetUsersSecurityAll2();


                                var producto = "";
                                Decimal cantidadDeficit = 0;
                                Decimal importeDeficit = 0;
                                Decimal importeDeficitme = 0;
                                var productoCache = "";

                                Decimal ImporteSaldo = 0;
                                Decimal ImporteSaldoME = 0;

                                Decimal saldoImporteAnual = 0;
                                Decimal saldoImporteAnualME = 0;



                                foreach (var i in cjasReport)
                                {
                                    documentoCaja myitem = new documentoCaja();

                                    importeDeficit = 0;
                                    importeDeficitme = 0;

                                    myitem.idDocumento = i.idDocumento;
                                    myitem.fechaCobro = i.fechaCobro;
                                    myitem.dni = i.dni;
                                    myitem.tipousuario = i.tipousuario;
                                    myitem.formapago = i.formapago;

                                    myitem.idUserOrder = i.idUserOrder;

                                    var vendedor = (from h in usersall where h.IDUsuario == i.idUserOrder select h).FirstOrDefault();

                                    if (vendedor != null)
                                    {
                                        myitem.nameVendedor = vendedor.Full_Name;
                                    }

                                    myitem.idUserPayment = i.idUserPayment;

                                    var cajero = (from h in usersall where h.IDUsuario == i.idUserPayment select h).FirstOrDefault();
                                    if (cajero != null)
                                    {
                                        myitem.nameCajero = cajero.Full_Name;
                                    }

                                    switch (i.tipoMovimiento)
                                    {
                                        case "DC":
                                            if (producto == i.IdEntidadFinanciera.ToString())
                                            {
                                                productoCache = i.NombreCaja;
                                                ImporteSaldo += i.montoSoles.GetValueOrDefault();
                                                ImporteSaldoME += i.montoUsd.GetValueOrDefault();
                                            }
                                            else
                                            {
                                                importeDeficit = ImporteSaldo;
                                                importeDeficitme = ImporteSaldoME;
                                                ImporteSaldo = 0;
                                                ImporteSaldoME = 0;

                                                ImporteSaldo = saldoImporteAnual;
                                                ImporteSaldoME = saldoImporteAnualME;
                                                ImporteSaldo = i.montoSoles.GetValueOrDefault() + ImporteSaldo;
                                                ImporteSaldoME = i.montoUsd.GetValueOrDefault() + ImporteSaldoME;
                                            }

                                            myitem.MontoIngresosMN = i.montoSoles.GetValueOrDefault();
                                            myitem.MontoIngresosME = i.montoUsd.GetValueOrDefault();
                                            myitem.MontoEgresosMN = 0;
                                            myitem.MontoEgresosME = 0;
                                            myitem.MontoSaldoMN = ImporteSaldo;
                                            myitem.MontoSaldoME = ImporteSaldoME;
                                            myitem.idCajaUsuario = i.idCajaUsuario;
                                            myitem.NombreOperacion = i.NombreOperacion;
                                            myitem.nombreCosto = "Entrada";
                                            break;
                                        case "PG":

                                            Decimal co = 0;
                                            Decimal come = 0;
                                            co = i.montoSoles.GetValueOrDefault();
                                            come = i.montoUsd.GetValueOrDefault();

                                            if (producto == i.IdEntidadFinanciera.ToString())
                                            {
                                                productoCache = i.NombreCaja;
                                                ImporteSaldo -= co;
                                                ImporteSaldoME -= come;
                                            }
                                            else
                                            {
                                                importeDeficit = ImporteSaldo;
                                                importeDeficitme = ImporteSaldoME;

                                                ImporteSaldo = 0;
                                                ImporteSaldoME = 0;

                                                ImporteSaldo = saldoImporteAnual;
                                                ImporteSaldoME = saldoImporteAnualME;

                                                ImporteSaldo -= i.montoSoles.GetValueOrDefault();
                                                ImporteSaldoME -= i.montoUsd.GetValueOrDefault();

                                            }
                                            myitem.MontoIngresosMN = 0;
                                            myitem.MontoIngresosME = 0;
                                            myitem.MontoEgresosMN = i.montoSoles.GetValueOrDefault();
                                            myitem.MontoEgresosME = i.montoUsd.GetValueOrDefault();
                                            myitem.MontoSaldoMN = ImporteSaldo;
                                            myitem.MontoSaldoME = ImporteSaldoME;
                                            myitem.idCajaUsuario = i.idCajaUsuario;
                                            myitem.NombreOperacion = i.NombreOperacion;
                                            myitem.nombreCosto = "Salida";
                                            break;
                                        default:
                                            break;
                                    }



                                    myitem.DetalleItem = i.DetalleItem;
                                    myitem.tipoDocPago = i.tipoDocPago;
                                    myitem.NumeroDocumento = i.NumeroDocumento;
                                    myitem.moneda = i.moneda;
                                    myitem.Operacion = i.Operacion;
                                    myitem.Docsalidas = i.Docsalidas;
                                    myitem.entidadFinanciera = i.entidadFinanciera;
                                    if (i.tipoCambio != null) //If(Not IsNothing(i.tipoCambio)) Then
                                    {
                                        myitem.tipoCambio = i.tipoCambio;
                                    }
                                    else
                                    {
                                        myitem.tipoCambio = i.difTipoCambio;
                                    }

                                    producto = i.IdEntidadFinanciera.ToString();
                                    productoCache = i.NombreCaja;

                                    ListaFiltrada.Add(myitem);
                                }


                            }


                            var listaStock = (from dvd in ListaFiltrada
                                              group dvd by new
                                              {
                                                  dvd.NombreOperacion,
                                                  dvd.nombreCosto,
                                                  dvd.Operacion,
                                                  dvd.formapago,
                                                  dvd.entidadFinanciera
                                              } into g
                                              select new
                                              {
                                                  cantidadI = g.Sum(t => t.MontoIngresosMN),
                                                  cantidadE = g.Sum(S => S.MontoEgresosMN),
                                                  cantidadIMP = g.Sum(t => t.MontoIngresosMN),
                                                  g.Key.NombreOperacion,
                                                  g.Key.nombreCosto,
                                                  g.Key.Operacion,
                                                  g.Key.formapago,
                                                  g.Key.entidadFinanciera
                                              }).ToList();

                            List<documentoCaja> Lista = new List<documentoCaja>();
                            documentoCaja ObjetC = new documentoCaja();
                            var operDesc = "";
                            var FormaP = "";
                            foreach (var item in listaStock)
                            {
                                ObjetC = new documentoCaja();
                                ObjetC.NombreOperacion = item.NombreOperacion;
                                ObjetC.montoSoles = item.cantidadI;
                                ObjetC.montoMNSalida = item.cantidadE;
                                ObjetC.montoUsdTransacc = item.cantidadIMP;
                                ObjetC.nombreCosto = item.nombreCosto;
                                ObjetC.Operacion = item.Operacion;
                                ObjetC.entidadFinanciera = item.entidadFinanciera;
                                switch (item.Operacion)
                                {
                                    case "OTRS":
                                        operDesc = "OTROS";
                                        break;
                                    case "MOVS":
                                        operDesc = "MOVILIDAD";
                                        break;
                                    case "ALS":
                                        operDesc = "ALMUERZO";
                                        break;
                                    case "PPROS":
                                        operDesc = "PAGO PROVEEDORES";
                                        break;
                                    case "PTRS":
                                        operDesc = "PAGO TRABAJADORES";
                                        break;
                                    case "CIMS":
                                        operDesc = "COMPRA DE INSUMOS/MERCADERIA";
                                        break;
                                    case "INI":
                                        operDesc = "FONDO DE INICIO";
                                        break;
                                    case "OTR":
                                        operDesc = "OTRO";
                                        break;
                                    default:
                                        break;
                                }

                                switch (item.formapago)
                                {
                                    case "001":
                                        FormaP = "Deposito en Cuenta";
                                        break;
                                    case "003":
                                        FormaP = "Transferencia de Fondos";
                                        break;
                                    case "005":
                                        FormaP = "Tarjeta de Débito";
                                        break;
                                    case "006":
                                        FormaP = "Tarjeta de Crédito";
                                        break;
                                    case "109":
                                        FormaP = "Efectivo";
                                        break;
                                    case "200":
                                        FormaP = "Yape";
                                        break;
                                    case "201":
                                        FormaP = "Plin";
                                        break;
                                    case "202":
                                        FormaP = "IziPay";
                                        break;
                                    case "203":
                                        FormaP = "Culqui";
                                        break;
                                    case "204":
                                        FormaP = "OpenPay";
                                        break;
                                    case "205":
                                        FormaP = "NiuBiz";
                                        break;
                                    case "206":
                                        FormaP = "Pasarela";
                                        break;
                                    default:
                                        FormaP = item.formapago;
                                        break;
                                }

                                ObjetC.destino = operDesc;
                                ObjetC.estado = FormaP;
                                ObjetC.FechaApertura = obj.FechaEnvio.ToString();
                                ObjetC.FechaCierre = Convert.ToString(DateTime.Now);
                                Lista.Add(ObjetC);
                            }


 
                            commons.ImprimirKardex(Lista, ImpreNego,obj);

                        }
                        else if (obj.TipoEnvioImpresion == "PEDIDOSCOMERCIAL")
                        {


                            //var RetudelP = false;         
                            //var  RetudelP = await ValidarDelete(obj);                      

                            //RetudelP = await PrintQueueAPI.DeleteV2(obj.Id, obj.idEmpresa, obj.idEstablecimiento.GetValueOrDefault());


                            if (returdelete == true)
                            {

                                var venta = await documentoventaDetalleBeneficiosAPI.PrintDirectProducto(obj.IdDocumento.GetValueOrDefault());

                                var idList = venta.DetProductos.Select(s => Int32.TryParse(s.idProdcuto.ToString(), out int n) ? n : (int)0).ToList();
                                var orderRecupeacion = await ImpresorasNegocioAPI.getListImpresorasXCodigoDetalle(idList);

                                if (orderRecupeacion.Count == 0)
                                {

                                    //var RetudelPC = await ValidarDelete(obj);


                                    //await PrintQueueAPI.DeleteV2(obj.Id, obj.idEmpresa, obj.idEstablecimiento.GetValueOrDefault());




                                }
                                var ImpresorasList = orderRecupeacion.Select(q => new
                                {
                                    q.idImpresora,
                                    q.aliasImpresora,
                                    q.ipImpresoraCompartida,
                                    q.cantidadPrint,
                                    q.formatoImpresion,
                                    q.relacionImpresora
                                }).Distinct().ToList();


                                List<printProductComercial> ordersSend = new List<printProductComercial>();
                                List<printProductComercial.DetalleProductos> detallePed = new List<printProductComercial.DetalleProductos>();

                                foreach (var pr in ImpresorasList)
                                {

                                    var objprint = new printProductComercial()
                                    {
                                        aliasImpresora = pr.aliasImpresora,
                                        idImpresora = pr.idImpresora,
                                        ipImpresoraCompartida = pr.ipImpresoraCompartida,
                                        cantidadPrint = pr.cantidadPrint,
                                        formatoImpresion = pr.formatoImpresion,
                                        relacionImpresora = pr.relacionImpresora
                                    };
                                    objprint.fecha = venta.fecha;
                                    objprint.usuario = venta.usuario;
                                    objprint.cargoUsuario = venta.cargoUsuario;

                                    objprint.DetProductos = new List<printProductComercial.DetalleProductos>();
                                    var items = orderRecupeacion.Where(w => w.idImpresora == pr.idImpresora).ToList();
                                    var productsIDS = items.Select(q => q.codigodetalle.ToString()).ToList();


                                    detallePed = venta.DetProductos.Where(s => productsIDS.Contains(s.idProdcuto.ToString())).ToList();
                                    objprint.DetProductos.AddRange(detallePed);
                                    objprint.DetaBeneficios = venta.DetaBeneficios;
                                    objprint.grupoDescrip = venta.grupoDescrip;
                                    ordersSend.Add(objprint);


                                }
                                commons.ImprimirPromociones(ordersSend);
                            }

                        }
                        else if (obj.TipoEnvioImpresion == "voucher")
                        {

                            //var Retudel = await PrintQueueAPI.DeleteV2(obj.Id, obj.idEmpresa, obj.idEstablecimiento.GetValueOrDefault());
                            //var Retudel = await ValidarDelete(obj);
                            if (returdelete == true)
                            {
                                var ventaVoucher = await DocumentoVentaAPI.GetVentaIDVoucher(obj.IdDocumento.GetValueOrDefault(), obj.idEmpresa, obj.idEstablecimiento.GetValueOrDefault());
                                var orderRecupeacion = await ImpresorasNegocioAPI.GetINServicio(true, obj.idEmpresa, obj.idEstablecimiento.GetValueOrDefault());
                                var datosgenerales = await DatosGeneralesAPI.GetFormats(obj.idEmpresa, obj.idEstablecimiento.GetValueOrDefault());

                                var DatosGen = datosgenerales.Where(s => s.NombreFormato == "TK").FirstOrDefault();
                                commons.ImprimirVoucher(ventaVoucher, orderRecupeacion, DatosGen);
                            }

                        }
                        else
                        {
                           

                           

                            if (returdelete == true)
                            {
                               
                                var venta = await DocumentoVentaAPI.GetOrderIdLitePrint(obj.IdDocumento.GetValueOrDefault(), obj.idEmpresa, obj.idEstablecimiento.GetValueOrDefault());

                                var getventaProductos= venta.documentoventaAbarrotesDet.Where(s=> s.tipoExistencia!="GS").ToList();
                                if (getventaProductos.Count>0)
                                {
                                    var TipoServicio = "PRODUCTO";
                                    var getPediddo = Printpedidos(venta, obj, commons, getventaProductos, TipoServicio);
                                }
                           

                                var getventaServicios = venta.documentoventaAbarrotesDet.Where(s => s.tipoExistencia == "GS").ToList();
                                if (getventaServicios.Count > 0)
                                {
                                    var TipoServicio = "SERVICIO";
                                    var getPediddo = Printpedidos(venta, obj, commons, getventaServicios, TipoServicio);
                                }
                            }
                        }




                    }
                    ordersList = new List<PrintQueue>();
                }
            }

           
        }

        public static async Task Printpedidos(documentoventaAbarrotes venta, PrintQueue obj, Commons commons,List<documentoventaAbarrotesDet> GetProductos,string TipoServicio)
        {
            var returConfigura = await ConfiguracionInicioAPI.Getconfiguration(obj.idEmpresa, obj.idEstablecimiento.GetValueOrDefault());
            var DetImpresoAll = await ImpresorasNegocioAPI.GetDetalleImpresoras();
            var listObj = new List<documentoventaAbarrotesDet>();
            var orderRecupeacion = new List<detalleItemsImpresoras>();
            var idList = new List<int>();
           
            if (TipoServicio == "PRODUCTO")
            {
                idList = GetProductos.Select(s => Int32.TryParse(s.idItem, out int n) ? n : (int)0).ToList();
                orderRecupeacion = await ImpresorasNegocioAPI.getListImpresorasXCodigoDetalle(idList);
            }
            else
            {
                idList = GetProductos.Select(s => Int32.TryParse(s.idImpresora.ToString(), out int n) ? n : (int)0).ToList();
                orderRecupeacion = await ImpresorasNegocioAPI.getListImpresorasXIdImpresora(idList);
            }



            var ImpresorasList = orderRecupeacion.Select(q => new
            {
                q.idImpresora,
                q.aliasImpresora,
                q.ipImpresoraCompartida,
                q.cantidadPrint,
                q.formatoImpresion,
                q.relacionImpresora
            }).Distinct().ToList();




            List<detalleItemsImpresoras> ordersSend = new List<detalleItemsImpresoras>();
            List<documentoventaAbarrotesDet> detallePed = new List<documentoventaAbarrotesDet>();
            foreach (var pr in ImpresorasList)
            {

                var objprint = new detalleItemsImpresoras()
                {
                    aliasImpresora = pr.aliasImpresora,
                    idImpresora = pr.idImpresora,
                    ipImpresoraCompartida = pr.ipImpresoraCompartida,
                    cantidadPrint = pr.cantidadPrint,
                    formatoImpresion = pr.formatoImpresion,
                    relacionImpresora = pr.relacionImpresora
                };


                var items = orderRecupeacion.Where(w => w.idImpresora == pr.idImpresora).ToList();
                var productsIDS = new List<string>();
                var detBenf = "NO_tienebeneficio";
                if (TipoServicio == "PRODUCTO")
                {
                    productsIDS = items.Select(q => q.codigodetalle.ToString()).ToList();
                    switch (obj.TipoEnvioImpresion)
                    {
                        case "PEDIDOADD":
                            detallePed = GetProductos.Where(s => productsIDS.Contains(s.idItem) && s.estadoImpresion == "PI").ToList();
                            break;
                        case "Anulacion por item":
                            detallePed = GetProductos.Where(s => productsIDS.Contains(s.idItem) && s.estadoImpresion == "PA").ToList();
                            detBenf = obj.TipoEnvioImpresion;
                            break;
                        default:
                            detallePed = GetProductos.Where(s => productsIDS.Contains(s.idItem)).ToList();

                            break;
                    }
                }
                else
                {
                    productsIDS = items.Select(q => q.idImpresora.ToString()).ToList();

                    switch (obj.TipoEnvioImpresion)
                    {
                        case "PEDIDOADD":
                            detallePed = GetProductos.Where(s => productsIDS.Contains(s.idImpresora.ToString()) && s.estadoImpresion == "PI").ToList();
                            break;
                        case "Anulacion por item":
                            detallePed = GetProductos.Where(s => productsIDS.Contains(s.idImpresora.ToString()) && s.estadoImpresion == "PA").ToList();
                            detBenf = obj.TipoEnvioImpresion;
                            break;
                        default:
                            detallePed = GetProductos.Where(s => productsIDS.Contains(s.idImpresora.ToString())).ToList();
                            break;
                    }
                }






                //*****************************************************************
                var DetalleVentaVeneficio = detallePed;
                var lista = detallePed;
                //codigo para agrupar productos**
                var listaPro = (from dvd in detallePed
                                group dvd by new
                                {
                                    dvd.nombreItem,
                                    dvd.idItem,
                                    dvd.usuarioModificacion,
                                    dvd.detalleAdicional,
                                    dvd.delivery
                                } into g
                                select new
                                {
                                    cantidad = g.Count(p => p.monto1 != null),
                                    g.Key.nombreItem,
                                    g.Key.idItem,
                                    g.Key.usuarioModificacion,
                                    g.Key.detalleAdicional,
                                    g.Key.delivery
                                }).ToList();


                var ObjDoc = new documentoventaAbarrotesDet();
                var documenDetBLis = new List<documentoventaDetalleBeneficios>();
                var ObjDocDet = new documentoventaAbarrotesDet();
                var documenDetB = new documentoventaDetalleBeneficios();
                objprint.listaProductos = new List<documentoventaAbarrotesDet>();
                if (detBenf == "Anulacion por item")
                {
                    objprint.listaProductos.AddRange(DetalleVentaVeneficio);
                }
                else
                {
                    foreach (var item in listaPro)
                    {
                        listObj = new List<documentoventaAbarrotesDet>();
                        detallePed = new List<documentoventaAbarrotesDet>();
                        detBenf = "NO_tienebeneficio";


                        var newDet = DetalleVentaVeneficio.Where(s => s.nombreItem == item.nombreItem && s.detalleAdicional == item.detalleAdicional && s.delivery == item.delivery).ToList();
                        foreach (var itemP in newDet)
                        {
                            ObjDoc = new documentoventaAbarrotesDet();
                            ObjDoc.nombreItem = itemP.nombreItem;

                            ObjDoc.monto1 = item.cantidad;//cantidad agrupado

                            ObjDoc.usuarioModificacion = itemP.usuarioModificacion;
                            ObjDoc.detalleAdicional = itemP.detalleAdicional;
                            ObjDoc.delivery = itemP.delivery;

                            documenDetBLis = new List<documentoventaDetalleBeneficios>();
                            foreach (var itemDB in itemP.documentoventaDetalleBeneficios)
                            {
                                ObjDoc.monto1 = itemP.monto1;//cantidad sin agrupar

                                detBenf = "SI_tienebeneficio";
                                var ReturnImpre = DetImpresoAll.Where(p => p.codigodetalle == itemDB.ReferenciaProducto && p.nombreimpresora.ToUpper() == items[0].nombreimpresora.ToUpper()).FirstOrDefault();
                                if (ReturnImpre != null)
                                {

                                    documenDetB = new documentoventaDetalleBeneficios();
                                    documenDetB.Nombre = itemDB.Nombre;
                                    documenDetB.Cantidad = itemDB.Cantidad;
                                    documenDetB.SegmentHeader = itemDB.SegmentHeader;
                                    documenDetBLis.Add(documenDetB);
                                }

                            }
                            ObjDoc.documentoventaDetalleBeneficios = documenDetBLis;

                            //if (itemP.complementoVentaAbarrotes.Count > 0)
                            //{
                            //    ObjDoc.complementoVentaAbarrotes = itemP.complementoVentaAbarrotes;
                            //}

                            listObj.Add(ObjDoc);
                        }

                        if (detBenf == "SI_tienebeneficio")
                        {
                            objprint.listaProductos.AddRange(listObj);
                        }
                        else
                        {
                            detallePed.Add(ObjDoc);
                            objprint.listaProductos.AddRange(detallePed);
                        }


                    }
                }


                ordersSend.Add(objprint);
                //*********************************************************


                ////*************************COMPLEMENTOS************************************
                //var DetalleVentaVeneficio = detallePed;
                //var lista = detallePed;
                ////codigo para agrupar productos**

                //var newlistDocDet = new List<documentoventaAbarrotesDet>();
                //var newDocDet = new documentoventaAbarrotesDet();

                //foreach (var itemD in detallePed)
                //{
                //    var name = "";
                //    var dely = "";
                //    if (itemD.delivery == true)
                //    {
                //        dely = " (Para llevar) ";
                //    }

                //    foreach (var itemC in itemD.complementoVentaAbarrotes)
                //    {

                //        var namec = itemC.cantidadComplemento + "-" + itemC.nombreComplemento + " ";
                //        name += namec;

                //    }
                //    newDocDet = new documentoventaAbarrotesDet();
                //    newDocDet.nombreItem = itemD.nombreItem;
                //    newDocDet.idItem = itemD.idItem;
                //    newDocDet.monto1 = itemD.monto1;
                //    newDocDet.usuarioModificacion = itemD.usuarioModificacion;
                //    newDocDet.detalleAdicional = itemD.detalleAdicional;
                //    newDocDet.delivery = itemD.delivery;
                //    newDocDet.nombreComercial = name + dely + " " + itemD.detalleAdicional;
                //    newDocDet.complementoVentaAbarrotes = itemD.complementoVentaAbarrotes;
                //    newlistDocDet.Add(newDocDet);

                //}


                //var listaPro = (from dvd in newlistDocDet
                //                group dvd by new
                //                {
                //                    dvd.nombreItem,
                //                    dvd.idItem,
                //                    dvd.usuarioModificacion,
                //                    dvd.nombreComercial
                //                } into g
                //                select new
                //                {
                //                    cantidad = g.Count(p => p.monto1 != null),
                //                    g.Key.nombreItem,
                //                    g.Key.idItem,
                //                    g.Key.usuarioModificacion,
                //                    g.Key.nombreComercial
                //                }).ToList();


                //var ObjDoc = new documentoventaAbarrotesDet();
                //var documenDetBLis = new List<documentoventaDetalleBeneficios>();
                //var ObjDocDet = new documentoventaAbarrotesDet();
                //var docuCompleList = new List<complementoVentaAbarrotes>();
                //var docuComple = new complementoVentaAbarrotes();

                //var documenDetB = new documentoventaDetalleBeneficios();
                //objprint.listaProductos = new List<documentoventaAbarrotesDet>();
                //if (detBenf == "Anulacion por item")
                //{
                //    objprint.listaProductos.AddRange(DetalleVentaVeneficio);
                //}
                //else
                //{
                //    foreach (var item in listaPro)
                //    {
                //        //listObj = new List<documentoventaAbarrotesDet>();
                //        detallePed = new List<documentoventaAbarrotesDet>();
                //        detBenf = "NO_tienebeneficio";


                //        var newDet = newlistDocDet.Where(s => s.nombreComercial==item.nombreComercial && s.nombreItem== item.nombreItem).FirstOrDefault();


                //        ObjDoc = new documentoventaAbarrotesDet();
                //        ObjDoc.nombreItem = newDet.nombreItem;

                //        ObjDoc.monto1 = item.cantidad;//cantidad agrupado

                //        ObjDoc.usuarioModificacion = newDet.usuarioModificacion;
                //        ObjDoc.detalleAdicional = newDet.detalleAdicional;
                //        ObjDoc.delivery = newDet.delivery;

                //        docuCompleList = new List<complementoVentaAbarrotes>();
                //        if (newDet.complementoVentaAbarrotes.Count > 0)
                //        {
                //            foreach (var itemC in newDet.complementoVentaAbarrotes)
                //            {
                //                 docuComple = new complementoVentaAbarrotes();
                //                docuComple.cantidadComplemento = itemC.cantidadComplemento * item.cantidad;
                //                docuComple.nombreComplemento = itemC.nombreComplemento;

                //                docuCompleList.Add(docuComple);
                //            }

                //        }
                //        ObjDoc.complementoVentaAbarrotes = docuCompleList;
                //        listObj.Add(ObjDoc);

                //        //foreach (var itemP in newDet)
                //        //{
                //        //    ObjDoc = new documentoventaAbarrotesDet();
                //        //    ObjDoc.nombreItem = itemP.nombreItem;

                //        //    ObjDoc.monto1 = item.cantidad;//cantidad agrupado

                //        //    ObjDoc.usuarioModificacion = itemP.usuarioModificacion;
                //        //    ObjDoc.detalleAdicional = itemP.detalleAdicional;
                //        //    ObjDoc.delivery = itemP.delivery;

                //        //    documenDetBLis = new List<documentoventaDetalleBeneficios>();
                //        //    foreach (var itemDB in itemP.documentoventaDetalleBeneficios)
                //        //    {
                //        //        ObjDoc.monto1 = itemP.monto1;//cantidad sin agrupar

                //        //        detBenf = "SI_tienebeneficio";
                //        //        var ReturnImpre = DetImpresoAll.Where(p => p.codigodetalle == itemDB.ReferenciaProducto && p.nombreimpresora.ToUpper() == items[0].nombreimpresora.ToUpper()).FirstOrDefault();
                //        //        if (ReturnImpre != null)
                //        //        {

                //        //            documenDetB = new documentoventaDetalleBeneficios();
                //        //            documenDetB.Nombre = itemDB.Nombre;
                //        //            documenDetB.Cantidad = itemDB.Cantidad;
                //        //            documenDetB.SegmentHeader = itemDB.SegmentHeader;
                //        //            documenDetBLis.Add(documenDetB);
                //        //        }

                //        //    }
                //        //    ObjDoc.documentoventaDetalleBeneficios = documenDetBLis;

                //        //    if (itemP.complementoVentaAbarrotes.Count > 0)
                //        //    {
                //        //        ObjDoc.complementoVentaAbarrotes = itemP.complementoVentaAbarrotes;
                //        //    }



                //        //}

                //        //if (detBenf == "SI_tienebeneficio")
                //        //    {
                //        //        objprint.listaProductos.AddRange(listObj);
                //        //    }
                //        //    else
                //        //    {
                //        //        detallePed.Add(ObjDoc);
                //        //        objprint.listaProductos.AddRange(detallePed);
                //        //    }


                //    }
                //    objprint.listaProductos.AddRange(listObj);
                //}


                //ordersSend.Add(objprint);
                //********************************************************************************
            }



            //Envio para imprimir
            if (ordersSend.Any())
            {
                venta.documentoventaAbarrotesDet = GetProductos;
                var ventaData = venta;//await DocumentoVentaAPI.GetOrderIdLite(venta.idDocumento);

                var listDete = new List<documentoventaAbarrotesDet>();


                var objPrint = new ImpresorasNegocio();
                var Impresora = new ImpresorasNegocio();
                if (obj.TipoEnvioImpresion != "PRECUENTA")
                {
                    objPrint.estadoImpresora = "A";
                    objPrint.tipoImpresora = "PEDIDO";
                    objPrint.idEstablecimiento = obj.idEstablecimiento;
                    objPrint.idEmpresa = obj.idEmpresa;

                    var PEDIDO = await ImpresorasNegocioAPI.GetListaImpresoraPreCuenta(objPrint);
                    if (PEDIDO.Count > 0)
                    {
                        Impresora = PEDIDO.Where(o => o.idImpresora == ordersSend.FirstOrDefault().idImpresora && o.idEstablecimiento == obj.idEstablecimiento && o.idEmpresa == obj.idEmpresa).FirstOrDefault();
                    }

                }
                var LisUsu = await UserAPI.GetUsersSecurityAll();
                if (obj.IdUsuario != null)
                {
                    venta.usuarioActualizacion = obj.IdUsuario.ToString();
                }


                var consultaNombre = LisUsu.Where(s => s.IDUsuario == int.Parse(venta.usuarioActualizacion)).FirstOrDefault();
                ventaData.cargoOperacion = consultaNombre.UsuarioRol[0].nombrePerfil;
                ventaData.usuarioOperacion = consultaNombre.Nombres;
                var listprod = ordersSend[0].listaProductos;


                foreach (var p in ordersSend[0].listaProductos)
                {
                    var consulta = LisUsu.Where(s => s.IDUsuario == int.Parse(p.usuarioModificacion)).FirstOrDefault();
                    if (consulta != null)
                    {
                        p.usuarioModificacion = consulta.codigo;
                    }

                }

                switch (obj.TipoEnvioImpresion)
                {
                    case "PNPI":
                    case "Anulacion por item":


                        await DocumentoVentaAPI.AnulacionPrintOrderDetItem(venta);

                        commons.ImprimirPedidoReImpersionFastReport(ordersSend, obj, Impresora, ventaData, returConfigura);
                        break;

                    case "PNPR":
                    case "Reimpresion":
                    case "PNPA":
                    case "Anulacion":

                        commons.ImprimirPedidoReImpersionFastReport(ordersSend, obj, Impresora, ventaData, returConfigura);


                        break;

                    case "PREC":
                    case "PRECUENTA":
                        objPrint = new ImpresorasNegocio();

                        objPrint.estadoImpresora = "A";
                        objPrint.tipoImpresora = "PRECUENTA";
                        objPrint.idEmpresa = obj.idEmpresa;
                        objPrint.idEstablecimiento = obj.idEstablecimiento;
                        var impresoraPreCuenta = await ImpresorasNegocioAPI.GetListaImpresoraPreCuenta(objPrint);

                        if (impresoraPreCuenta != null)
                        {
                            var impresoraPreCuentaObj = impresoraPreCuenta.Where(s => s.tipoImpresora == "PRECUENTA").FirstOrDefault(); ;
                            //var Consulta = impresoraPreCuenta.Where(s => s.idImpresora == obj.idPreCuenta && s.idEstablecimiento == obj.idEstablecimiento && s.idEmpresa == obj.idEmpresa).FirstOrDefault();
                            if (obj.idPreCuenta > 0)
                            {
                                impresoraPreCuentaObj = impresoraPreCuenta.Where(s => s.idImpresora == obj.idPreCuenta).FirstOrDefault();

                            }


                            //if (Consulta != null)
                            //{
                            //Retudel = await ValidarDelete(obj);

                            //Retudel = await PrintQueueAPI.DeleteV2(obj.Id, obj.idEmpresa, obj.idEstablecimiento.GetValueOrDefault());
                            //await DocumentoVentaAPI.ConfirmPrintOrder(venta);

                            var impresionLista = venta.documentoventaAbarrotesDet.Where(s => s.estadoPago != "ANUP" && s.estadoDistribucion == "A").ToList();
                            listObj = new List<documentoventaAbarrotesDet>();
                            var listaPreCuenta = (from dvd in impresionLista
                                                  group dvd by new
                                                  {
                                                      dvd.nombreItem,
                                                      dvd.idItem,
                                                      dvd.precioUnitario,
                                                      dvd.importeMN
                                                  } into g
                                                  select new
                                                  {
                                                      cantidad = g.Count(p => p.monto1 != null),
                                                      g.Key.nombreItem,
                                                      g.Key.idItem,
                                                      g.Key.precioUnitario,
                                                      g.Key.importeMN
                                                  }).ToList();

                            foreach (var item in listaPreCuenta)
                            {
                                var ObjDoc = new documentoventaAbarrotesDet();
                                ObjDoc.nombreItem = item.nombreItem;
                                ObjDoc.monto1 = item.cantidad;
                                ObjDoc.precioUnitario = item.precioUnitario;
                                ObjDoc.importeMN = item.importeMN * item.cantidad;

                                listObj.Add(ObjDoc);
                            }



                            commons.ImprimirPrecuentaFastReport(listObj, impresoraPreCuentaObj, venta.nombreDistribucion, venta.usuarioOperacion, "", venta.cargoOperacion, venta.nombreDistribucion, venta.fechaDoc.ToString(), "", ventaData, ordersSend, returConfigura);
                            //}
                        }

                        break;

                    default:
                        if (obj.Tipo_Venta == "RAPIDA")
                        {
                            commons.ImprimirPeditoTicket(ordersSend, obj, Impresora, ventaData, returConfigura);
                        }
                        else
                        {
                            await DocumentoVentaAPI.ConfirmPrintOrderDet(venta);//Para actualizar el estado de la impresion

                            commons.ImprimirPedidoReImpersionFastReport(ordersSend, obj, Impresora, ventaData, returConfigura);
                        }



                        break;
                }

                //switch (obj.TipoEnvioImpresion)
                //{
                //    case "PNP":
                //    case "Impresion":
                //    case "PEDIDO":

                //        await DocumentoVentaAPI.ConfirmPrintOrderDet(venta);//Para actualizar el estado de la impresion

                //        commons.ImprimirPedidoReImpersionFastReport(ordersSend, "", "", "Impresion", Impresora, ventaData, returConfigura);


                //        break;

                //    case "PEDIDOADD":

                //        await DocumentoVentaAPI.ConfirmPrintOrderDet(venta);
                //        commons.ImprimirPedidoReImpersionFastReport(ordersSend, "", "", "Impresion", Impresora, ventaData, returConfigura);

                //        break;

                //    case "PNPR":
                //    case "Reimpresion":

                //        commons.ImprimirPedidoReImpersionFastReport(ordersSend, "", "", "Reimpresion", Impresora, ventaData, returConfigura);

                //        break;

                //    case "PNPA":
                //    case "Anulacion":

                //        commons.ImprimirPedidoReImpersionFastReport(ordersSend, "", "", "Anulacion", Impresora, ventaData, returConfigura);

                //        break;

                //    case "PNPU":
                //    case "nuevo item":

                //        await DocumentoVentaAPI.ConfirmPrintOrderDet(venta);

                //        commons.ImprimirPedidoReImpersionFastReport(ordersSend, "", "", "nuevo item", Impresora, ventaData, returConfigura);

                //        break;

                //    case "PNPI":
                //    case "Anulacion por item":


                //        await DocumentoVentaAPI.AnulacionPrintOrderDetItem(venta);

                //        commons.ImprimirPedidoReImpersionFastReport(ordersSend, "", "", "Anulacion por item", Impresora, ventaData, returConfigura);

                //        break;


                //    case "PREC":
                //    case "PRECUENTA":
                //        objPrint = new ImpresorasNegocio();

                //        objPrint.estadoImpresora = "A";
                //        objPrint.tipoImpresora = "PRECUENTA";
                //        objPrint.idEmpresa = obj.idEmpresa;
                //        objPrint.idEstablecimiento = obj.idEstablecimiento;
                //        var impresoraPreCuenta = await ImpresorasNegocioAPI.GetListaImpresoraPreCuenta(objPrint);

                //        if (impresoraPreCuenta != null)
                //        {
                //            //var Consulta = impresoraPreCuenta.Where(s => s.idImpresora == obj.idPreCuenta && s.idEstablecimiento == obj.idEstablecimiento && s.idEmpresa == obj.idEmpresa).FirstOrDefault();

                //            //if (Consulta != null)
                //            //{
                //                //Retudel = await ValidarDelete(obj);

                //                //Retudel = await PrintQueueAPI.DeleteV2(obj.Id, obj.idEmpresa, obj.idEstablecimiento.GetValueOrDefault());
                //                //await DocumentoVentaAPI.ConfirmPrintOrder(venta);

                //                var impresionLista = venta.documentoventaAbarrotesDet.Where(s => s.estadoPago != "ANUP" && s.estadoDistribucion == "A").ToList();
                //                listObj = new List<documentoventaAbarrotesDet>();
                //                var listaPreCuenta = (from dvd in impresionLista
                //                                      group dvd by new
                //                                      {
                //                                          dvd.nombreItem,
                //                                          dvd.idItem,
                //                                          dvd.precioUnitario,
                //                                          dvd.importeMN
                //                                      } into g
                //                                      select new
                //                                      {
                //                                          cantidad = g.Count(p => p.monto1 != null),
                //                                          g.Key.nombreItem,
                //                                          g.Key.idItem,
                //                                          g.Key.precioUnitario,
                //                                          g.Key.importeMN
                //                                      }).ToList();

                //                foreach (var item in listaPreCuenta)
                //                {
                //                    var ObjDoc = new documentoventaAbarrotesDet();
                //                    ObjDoc.nombreItem = item.nombreItem;
                //                    ObjDoc.monto1 = item.cantidad;
                //                    ObjDoc.precioUnitario = item.precioUnitario;
                //                    ObjDoc.importeMN = item.importeMN * item.cantidad;

                //                    listObj.Add(ObjDoc);
                //                }



                //                commons.ImprimirPrecuentaFastReport(listObj, impresoraPreCuenta.FirstOrDefault(), venta.nombreDistribucion, venta.usuarioOperacion, "", venta.cargoOperacion, venta.nombreDistribucion, venta.fechaDoc.ToString(), "", ventaData, ordersSend, returConfigura);
                //            //}
                //        }

                //        break;

                //    default:
                //        break;
                //}


            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //_ = GetOrders();
            _ = GetOrderQueue();
            try
            {
              //  timer1.Enabled = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            var ordersPending = OrdersPending();
            foreach (var venta in ordersPending)
            {
                venta.documentoventaAbarrotesDet = new List<documentoventaAbarrotesDet>();
                venta.documentoventaAbarrotesDet = OrdersPendingDetail(venta.idDocumento);
            }

            foreach (var venta in ordersPending)
            {
                //Impresoras
                var idList = venta.documentoventaAbarrotesDet.Select(s => Int32.TryParse(s.idItem, out int n) ? n : (int)0).ToList();
                string IdsProducts = string.Join(",", idList.ToArray());
                var orderRecupeacion = GetImpresoras(IdsProducts);

                var ImpresorasList = orderRecupeacion.Select(q => new
                {
                    q.idImpresora,
                    q.aliasImpresora,
                    q.ipImpresoraCompartida,
                    q.cantidadPrint,
                    q.formatoImpresion,
                    q.relacionImpresora
                }).Distinct().ToList();

                List<detalleItemsImpresoras> ordersSend = new List<detalleItemsImpresoras>();
                foreach (var pr in ImpresorasList)
                {

                    var objprint = new detalleItemsImpresoras()
                    {
                        aliasImpresora = pr.aliasImpresora,
                        idImpresora = pr.idImpresora,
                        ipImpresoraCompartida = pr.ipImpresoraCompartida,
                        cantidadPrint = pr.cantidadPrint,
                        formatoImpresion = pr.formatoImpresion,
                        relacionImpresora = pr.relacionImpresora
                    };

                    objprint.listaProductos = new List<documentoventaAbarrotesDet>();
                    var items = orderRecupeacion.Where(w => w.idImpresora == pr.idImpresora).ToList();
                    var productsIDS = items.Select(q => q.codigodetalle.ToString()).ToList();


                    var detalleVenta = venta.documentoventaAbarrotesDet.Where(s => productsIDS.Contains(s.idItem)).ToList();
                    objprint.listaProductos.AddRange(detalleVenta);
                    ordersSend.Add(objprint);
                }

                //Envio para imprimir
                if (ordersSend.Any())
                {
                   // await OrderAPI.ConfirmPrintOrder(venta);
                    ImprimirPedidoOrder(ordersSend, "", venta.nombreDistribucion, venta.usuarioOperacion, "", venta.cargoOperacion, venta.nombreDistribucion);
                    //await OrderAPI.ConfirmPrintOrder(venta);
                }

            }            

        }

        public void ImprimirPedidoOrder(List<detalleItemsImpresoras> order, String ISPRINTER, String nameMesa, String nameVendedor, String nameAlmacen, String namecargo, String NombreInfra)
        {
            try
            {

                //TITULO
                if (order != null)
                {

                    foreach (var itemPrint in order)
                    {
                       
                        if (itemPrint.formatoImpresion == "80MM")
                        {
                            Ticket58mm.Ticket print = new Ticket58mm.Ticket();
                            print.AnadirLineaEmpresa("PEDIDO - " + itemPrint.relacionImpresora);
                            print.AnadirLineaEmpresa("");
                            print.AnadirLineaEmpresa(nameMesa);

                            if (itemPrint.descripAdicinal != null)
                            {
                                print.AnadirLineaEmpresa("");
                                print.AnadirLineaEmpresa(itemPrint.descripAdicinal);
                            }

                            //FECHA
                            //VENDEDOR
                            //CARGO
                            var fecha = Convert.ToString(DateTime.Now);

                            print.AnadirLineaCaracteresDatosGEnerales(fecha,
                                                                  nameVendedor,
                                                                   namecargo
                                                                   );


                            //DETALLES DE LOS PEDIDOS
                            foreach (var item in itemPrint.listaProductos)
                            {
                                //i/f (item.tipoVenta == "PL")
                                //{
                                if (item.detalleAdicional != null)
                                {
                                    if (item.tipoVenta == "PL")
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional}) {"(PARA LLEVAR)"}", item.idItem, "");
                                    else
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional})", item.idItem, "");
                                }
                                else
                                {
                                    if (item.tipoVenta == "PL")
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} {"(PARA LLEVAR)"}", item.idItem, "");
                                    else
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}", item.idItem, "");
                                }
                            }

                            //NOMBRE DE LA IMPRESORA
                            //NUMERO COPIAS DE IMPRESION
                            print.ImprimeTicket(itemPrint.ipImpresoraCompartida, itemPrint.relacionImpresora, itemPrint.cantidadPrint);
                            //}
                        }
                        else if (itemPrint.formatoImpresion == "55MM")
                        {

                            Ticket58mm.Ticket58mm print = new Ticket58mm.Ticket58mm();
                            print.AnadirLineaEmpresa("PEDIDO - " + itemPrint.relacionImpresora);
                            print.AnadirLineaEmpresa("");
                            print.AnadirLineaEmpresa(nameMesa + "/" + NombreInfra);
                            if (itemPrint.descripAdicinal != null)
                            {
                                print.AnadirLineaEmpresa("");
                                print.AnadirLineaEmpresa(itemPrint.descripAdicinal);
                            }

                            //FECHA
                            //VENDEDOR
                            //CARGO
                            var fecha = Convert.ToString(DateTime.Now);

                            print.AnadirLineaCaracteresDatosGEnerales(fecha,
                                                                  nameVendedor,
                                                                   namecargo
                                                                   );


                            //DETALLES DE LOS PEDIDOS
                            foreach (var item in itemPrint.listaProductos)
                            {
                                //i/f (item.tipoVenta == "PL")
                                //{
                                if (item.detalleAdicional != null)
                                {
                                    if (item.tipoVenta == "PL")
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional}) {"(PARA LLEVAR)"}", item.idItem, "");
                                    else
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional})", item.idItem, "");
                                }
                                else
                                {
                                    if (item.tipoVenta == "PL")
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} {"(PARA LLEVAR)"}", item.idItem, "");
                                    else
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}", item.idItem, "");
                                }
                            }

                            //NOMBRE DE LA IMPRESORA
                            //NUMERO COPIAS DE IMPRESION
                            print.ImprimeTicket(itemPrint.ipImpresoraCompartida, itemPrint.relacionImpresora, itemPrint.cantidadPrint);

                        }
                        else if (itemPrint.formatoImpresion == "45MM")
                        {

                            Ticket58mm.Ticket48mm print = new Ticket58mm.Ticket48mm();
                            print.AnadirLineaEmpresa("PEDIDO - " + itemPrint.relacionImpresora);
                            print.AnadirLineaEmpresa("");
                            print.AnadirLineaEmpresa(nameMesa + "/" + NombreInfra);
                            if (itemPrint.descripAdicinal != null)
                            {
                                print.AnadirLineaEmpresa("");
                                print.AnadirLineaEmpresa(itemPrint.descripAdicinal);
                            }
                            //FECHA
                            //VENDEDOR
                            //CARGO
                            var fecha = Convert.ToString(DateTime.Now);

                            print.AnadirLineaCaracteresDatosGEnerales(fecha,
                                                                  nameVendedor,
                                                                   namecargo
                                                                   );


                            //DETALLES DE LOS PEDIDOS
                            foreach (var item in itemPrint.listaProductos)
                            {
                                //i/f (item.tipoVenta == "PL")
                                //{
                                if (item.detalleAdicional != null)
                                {
                                    if (item.tipoVenta == "PL")
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional}) {"(PARA LLEVAR)"}", item.idItem, "");
                                    else
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional})", item.idItem, "");
                                }
                                else
                                {
                                    if (item.tipoVenta == "PL")
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} {"(PARA LLEVAR)"}", item.idItem, "");
                                    else
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}", item.idItem, "");
                                }
                            }

                            //NOMBRE DE LA IMPRESORA
                            //NUMERO COPIAS DE IMPRESION
                            print.ImprimeTicket(itemPrint.ipImpresoraCompartida, itemPrint.relacionImpresora, itemPrint.cantidadPrint);

                        }



                    }
                }

            }
            catch (Exception)
            {
                throw new Exception("No se Pudo imrimir.");
            }


        }


        public List<detalleItemsImpresoras> GetImpresoras(string ids)
        {
            string connectionString =
          "Server=MAYKOL;User ID=spk;Password=1234567;Initial Catalog=HeliosWebCore;"
          + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.

            string queryString =
                "select " +
                "detImp.idItemImpresora," +
                "detImp.codigodetalle," +
                "detImp.idImpresora," +
                "detImp.nombreimpresora," +
                "detImp.usuarioActualizacion," +
                "pr.nombreimpresora," +
                "pr.IPImpresion," +
                "pr.formatoImpresion," +
                "pr.relacionImpresora," +
                "pr.numImpresion " +
                "from detalleItemsImpresoras detImp " +
                "inner join ImpresorasNegocio pr " +
                "on pr.idImpresora = detImp.idImpresora " +
                "where codigodetalle " +
                "IN(" + ids + ")";


            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                var listprint = new List<detalleItemsImpresoras>();
                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listprint.Add(new detalleItemsImpresoras()
                        {
                            idItemImpresora = int.Parse(reader[0].ToString()),
                            codigodetalle = int.Parse(reader[1].ToString()),
                            idImpresora = int.Parse(reader[2].ToString()),
                            nombreimpresora = reader[3].ToString(),
                            usuarioActualizacion = reader[4].ToString(),
                            aliasImpresora = reader[5].ToString(),
                            ipImpresoraCompartida = reader[6].ToString(),
                            formatoImpresion = reader[7].ToString(),
                            relacionImpresora = reader[8].ToString(),
                            cantidadPrint = int.Parse(reader[9].ToString())
                        });

                    }
                    reader.Close();
                    command.Dispose();
                    connection.Close();
                    connection.Dispose();
                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace + DateTime.Now);
                }

                return listprint;
                //  Console.ReadLine();
            }
        }

        public List<documentoventaAbarrotes> OrdersPending()
        {
            string connectionString =
          "Server=MAYKOL;User ID=spk;Password=1234567;Initial Catalog=HeliosWebCore;"
          + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString =
                "SELECT idDocumento, fechaDoc,usuarioOperacion,cargoOperacion, nombreDistribucion from documentoventaAbarrotes where estado ='PNP'";


            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                
                SqlCommand command = new SqlCommand(queryString, connection);
                var listOrders = new List<documentoventaAbarrotes>();
                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listOrders.Add(new documentoventaAbarrotes()
                        {
                            idDocumento = int.Parse( reader[0].ToString()),
                           fechaDoc = (DateTime)reader[1],
                           usuarioOperacion = reader[2].ToString(),
                           cargoOperacion = reader[3].ToString(),
                           nombreDistribucion = reader[4].ToString()
                        });                      
                      
                    }
                    reader.Close();
                    command.Dispose();
                    connection.Close();
                    connection.Dispose();
                }

                
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace + DateTime.Now);
                }

                return listOrders;
                //  Console.ReadLine();
            }
        }


        public List<documentoventaAbarrotesDet> OrdersPendingDetail(int id)
        {
            string connectionString =
          "Server=MAYKOL;User ID=spk;Password=1234567;Initial Catalog=HeliosWebCore;"
          + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString =
                "SELECT " +
                "idDocumento, " +
                " idItem," +
                "detalleAdicional, " +
                "tipoVenta,  " +
                "monto1," +
                " nombreItem " +
                " from documentoventaAbarrotesDet where idDocumento ='" + id + "'";


            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                var listOrdersDetail = new List<documentoventaAbarrotesDet>();
                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listOrdersDetail.Add(new documentoventaAbarrotesDet()
                        {
                            idDocumento = int.Parse(reader[0].ToString()),
                            idItem = reader[1].ToString(),
                            detalleAdicional = reader[2].ToString(),
                            tipoVenta = reader[3].ToString(),
                            monto1 = decimal.Parse(reader[4].ToString()),
                            nombreItem = reader[5].ToString()
                        });

                    }
                    reader.Close();
                    command.Dispose();
                    connection.Close();
                    connection.Dispose();
                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace + DateTime.Now);
                }

                return listOrdersDetail;
                //  Console.ReadLine();
            }
        }

        public void conecctionSQL()
        {
            string connectionString =
          "Data Source=(local);Initial Catalog=HeliosWebCore;"
          + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString =
                "SELECT * from entidad";

            // Specify the parameter value.
            //int paramValue = 5;

            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                // command.Parameters.AddWithValue("@pricePoint", paramValue);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        var text = reader[13];

                        Console.WriteLine("\t{0}\t{1}\t{2}",
                            reader[0], reader[1], reader[2]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("hi");
            try
            {
                _ = GetOrderQueue();
            }
            catch (Exception ex)
            {
                timer1.Enabled = false;
                MessageBox.Show(ex.Message);
               
            }
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
