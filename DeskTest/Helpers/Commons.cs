using FastReport;
using Helios.Cont.Business.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using QRCoder;


using Font = System.Drawing.Font;
using System.Drawing.Text;
using FastReport.Barcode;
using System.Drawing.Printing;
using FastReport.Table;
using Newtonsoft.Json;
using System.Windows.Forms;
using Helios.Web.Core.Models.Order.PrinterPedidosRest.BaseCaja;
using DeskTest.Models.PrinterPedidosRest.BaseCaja;


public class Commons
    {

    //public void ImprimirPedido(List<detalleItemsImpresoras> order, String ISPRINTER, String nameMesa, String nameVendedor, String nameAlmacen, String namecargo, String NombreInfra, String NombreAdicional)
    //    {
    //        try
    //        {

    //            //TITULO
    //            if (order != null)
    //            {

    //                foreach (var itemPrint in order)
    //                {

    //                    if (itemPrint.formatoImpresion == "80MM")
    //                    {
    //                        Ticket58mm.Ticket print = new Ticket58mm.Ticket();

    //                    if (nameMesa == null) {
    //                        nameMesa = "";
    //                    }

    //                    print.AnadirLineaEmpresa("PEDIDO - " + itemPrint.aliasImpresora);
    //                    print.AnadirLineaEmpresa("");
    //                    print.AnadirLineaEmpresa(nameMesa);


    //                    if (NombreAdicional != null)
    //                        {
    //                            print.AnadirLineaEmpresa("");
    //                            //print.AnadirLineaEmpresa(itemPrint.descripAdicinal);
    //                        print.AnadirLineaEmpresa(NombreAdicional);
    //                    }

    //                        //FECHA
    //                        //VENDEDOR
    //                        //CARGO
    //                        var fecha = Convert.ToString(DateTime.Now);

    //                        print.AnadirLineaCaracteresDatosGEnerales(fecha,
    //                                                              nameVendedor,
    //                                                               namecargo
    //                                                               );


    //                        //DETALLES DE LOS PEDIDOS
    //                        foreach (var item in itemPrint.listaProductos)
    //                        {
    //                            //i/f (item.tipoVenta == "PL")
    //                            //{
    //                            if (item.detalleAdicional != null)
    //                            {
    //                                if (item.delivery == true)
    //                                    print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional}) {"(PARA LLEVAR)"}", item.secuencia.ToString () , "");
    //                                else
    //                                    print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional})", item.secuencia.ToString (), "");
    //                            }
    //                            else
    //                            {
    //                                if (item.delivery == true)
    //                                    print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                                else
    //                                    print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}", item.secuencia.ToString (), "");
    //                            }
    //                        foreach (var itemComplemento in item.complementoVentaAbarrotes)
    //                        {
    //                            print.AnadirLineaElementosComplementoFactura(itemComplemento.cantidadComplemento.GetValueOrDefault().ToString(), $"{itemComplemento.nombreComplemento}", itemComplemento.secuencia.ToString(), itemComplemento.idDocumentoDet.ToString());
    //                        }

    //                    }



    //                        //NOMBRE DE LA IMPRESORA
    //                        //NUMERO COPIAS DE IMPRESION
    //                        print.ImprimeTicket(itemPrint.ipImpresoraCompartida, itemPrint.relacionImpresora, itemPrint.cantidadPrint);
    //                        //}
    //                    }
    //                    else if (itemPrint.formatoImpresion == "55MM")
    //                    {

    //                    if (nameMesa == null)
    //                    {
    //                        nameMesa = "";
    //                    }

    //                    if (NombreInfra == null)
    //                    {
    //                        NombreInfra = "";
    //                    }

    //                    Ticket58mm.Ticket58mm print = new Ticket58mm.Ticket58mm();
    //                        print.AnadirLineaEmpresa("PEDIDO - " + itemPrint.aliasImpresora);
    //                        print.AnadirLineaEmpresa("");
    //                        print.AnadirLineaEmpresa(nameMesa + "/" + NombreInfra);
    //                        if (itemPrint.descripAdicinal != null)
    //                        {
    //                            print.AnadirLineaEmpresa("");
    //                            print.AnadirLineaEmpresa(itemPrint.descripAdicinal);
    //                        }

    //                        //FECHA
    //                        //VENDEDOR
    //                        //CARGO
    //                        var fecha = Convert.ToString(DateTime.Now);

    //                        print.AnadirLineaCaracteresDatosGEnerales(fecha,
    //                                                              nameVendedor,
    //                                                               namecargo
    //                                                               );


    //                        //DETALLES DE LOS PEDIDOS
    //                        foreach (var item in itemPrint.listaProductos)
    //                        {
    //                            //i/f (item.tipoVenta == "PL")
    //                            //{
    //                            if (item.detalleAdicional != null)
    //                            {
    //                            if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional}) {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                                else
    //                                    print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional})", item.secuencia.ToString (), "");
    //                            }
    //                            else
    //                            {
    //                            if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                                else
    //                                    print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}", item.secuencia.ToString (), "");
    //                            }

    //                        foreach (var itemComplemento in item.complementoVentaAbarrotes)
    //                        {
    //                            print.AnadirLineaElementosComplementoFactura(itemComplemento.cantidadComplemento.GetValueOrDefault().ToString(), $"{itemComplemento.nombreComplemento}", itemComplemento.secuencia.ToString(), itemComplemento.idDocumentoDet.ToString());
    //                        }

    //                    }

    //                        //NOMBRE DE LA IMPRESORA
    //                        //NUMERO COPIAS DE IMPRESION
    //                        print.ImprimeTicket(itemPrint.ipImpresoraCompartida, itemPrint.relacionImpresora, itemPrint.cantidadPrint);

    //                    }
    //                    else if (itemPrint.formatoImpresion == "45MM")
    //                    {

    //                    if (nameMesa == null)
    //                    {
    //                        nameMesa = "";
    //                    }

    //                    if (NombreInfra == null)
    //                    {
    //                        NombreInfra = "";
    //                    }

    //                    Ticket58mm.Ticket48mm print = new Ticket58mm.Ticket48mm();
    //                        print.AnadirLineaEmpresa("PEDIDO - " + itemPrint.aliasImpresora);
    //                        print.AnadirLineaEmpresa("");
    //                        print.AnadirLineaEmpresa(nameMesa + "/" + NombreInfra);
    //                        if (itemPrint.descripAdicinal != null)
    //                        {
    //                            print.AnadirLineaEmpresa("");
    //                            print.AnadirLineaEmpresa(itemPrint.descripAdicinal);
    //                        }
    //                        //FECHA
    //                        //VENDEDOR
    //                        //CARGO
    //                        var fecha = Convert.ToString(DateTime.Now);

    //                        print.AnadirLineaCaracteresDatosGEnerales(fecha,
    //                                                              nameVendedor,
    //                                                               namecargo
    //                                                               );


    //                        //DETALLES DE LOS PEDIDOS
    //                        foreach (var item in itemPrint.listaProductos)
    //                        {
    //                            //i/f (item.tipoVenta == "PL")
    //                            //{
    //                            if (item.detalleAdicional != null)
    //                            {
    //                            if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional}) {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                                else
    //                                    print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional})", item.secuencia.ToString (), "");
    //                            }
    //                            else
    //                            {
    //                            if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                                else
    //                                    print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}", item.secuencia.ToString (), "");
    //                            }

    //                        foreach (var itemComplemento in item.complementoVentaAbarrotes)
    //                        {
    //                            print.AnadirLineaElementosComplementoFactura(itemComplemento.cantidadComplemento.GetValueOrDefault().ToString(), $"{itemComplemento.nombreComplemento}", itemComplemento.secuencia.ToString(), itemComplemento.idDocumentoDet.ToString());
    //                        }

    //                    }

    //                        //NOMBRE DE LA IMPRESORA
    //                        //NUMERO COPIAS DE IMPRESION
    //                        print.ImprimeTicket(itemPrint.ipImpresoraCompartida, itemPrint.relacionImpresora, itemPrint.cantidadPrint);

    //                    }



    //                }
    //            }

    //        }
    //        catch (Exception)
    //        {
    //            throw new Exception("No se Pudo imrimir.");
    //        }


    //    }
    //    public void ImprimirPedidoItem(List<detalleItemsImpresoras> order, String ISPRINTER, String nameMesa, String nameVendedor, String nameAlmacen, String namecargo, String NombreInfra)
    //{
    //    try
    //    {

    //        //TITULO
    //        if (order != null)
    //        {

    //            foreach (var itemPrint in order)
    //            {

    //                if (itemPrint.formatoImpresion == "80MM")
    //                {
    //                    Ticket58mm.Ticket print = new Ticket58mm.Ticket();

    //                    if (nameMesa == null)
    //                    {
    //                        nameMesa = "";
    //                    }
                                            
    //                    print.AnadirLineaEmpresa("PEDIDO - " + itemPrint.aliasImpresora);
    //                    print.AnadirLineaEmpresa("");
    //                    print.AnadirLineaEmpresa(nameMesa);

    //                    if (itemPrint.descripAdicinal != null)
    //                    {
    //                        print.AnadirLineaEmpresa("");
    //                        print.AnadirLineaEmpresa(itemPrint.descripAdicinal);
    //                    }

    //                    //FECHA
    //                    //VENDEDOR
    //                    //CARGO
    //                    var fecha = Convert.ToString(DateTime.Now);

    //                    print.AnadirLineaCaracteresDatosGEnerales(fecha,
    //                                                          nameVendedor,
    //                                                           namecargo
    //                                                           );

    //                    var conteo = 0;

    //                    //DETALLES DE LOS PEDIDOS
    //                    foreach (var item in itemPrint.listaProductos.Where(S => S.estadoImpresion == "PI"))
    //                    {
    //                        //i/f (item.tipoVenta == "PL")
    //                        //{
    //                        conteo += 1;

    //                        if (item.detalleAdicional != null)
    //                        {
    //                             if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional}) {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                            else
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional})", item.secuencia.ToString (), "");
    //                        }
    //                        else
    //                        {
    //                             if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                            else
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}", item.secuencia.ToString (), "");
    //                        }

    //                        foreach (var itemComplemento in item.complementoVentaAbarrotes)
    //                        {
    //                            print.AnadirLineaElementosComplementoFactura(itemComplemento.cantidadComplemento.GetValueOrDefault().ToString(), $"{itemComplemento.nombreComplemento}", itemComplemento.secuencia.ToString(), itemComplemento.idDocumentoDet.ToString());
    //                        }

    //                    }

    //                    //NOMBRE DE LA IMPRESORA
    //                    //NUMERO COPIAS DE IMPRESION

    //                    if (conteo >= 1) {
    //                        print.ImprimeTicket(itemPrint.ipImpresoraCompartida, itemPrint.relacionImpresora, itemPrint.cantidadPrint);
    //                        //}
    //                    }
    //                }
    //                else if (itemPrint.formatoImpresion == "55MM")
    //                {

    //                    Ticket58mm.Ticket58mm print = new Ticket58mm.Ticket58mm();


    //                    if (nameMesa == null)
    //                    {
    //                        nameMesa = "";
    //                    }

    //                    if (NombreInfra == null)
    //                    {
    //                        NombreInfra = "";
    //                    }

    //                    print.AnadirLineaEmpresa("PEDIDO - " + itemPrint.aliasImpresora);
    //                    print.AnadirLineaEmpresa("");
    //                    print.AnadirLineaEmpresa(nameMesa + "/" + NombreInfra);
    //                    if (itemPrint.descripAdicinal != null)
    //                    {
    //                        print.AnadirLineaEmpresa("");
    //                        print.AnadirLineaEmpresa(itemPrint.descripAdicinal);
    //                    }

    //                    //FECHA
    //                    //VENDEDOR
    //                    //CARGO
    //                    var fecha = Convert.ToString(DateTime.Now);

    //                    print.AnadirLineaCaracteresDatosGEnerales(fecha,
    //                                                          nameVendedor,
    //                                                           namecargo
    //                                                           );

    //                    var conteo = 0;
    //                    //DETALLES DE LOS PEDIDOS
    //                    foreach (var item in itemPrint.listaProductos.Where(S => S.estadoImpresion == "PI"))
    //                    {
    //                        //i/f (item.tipoVenta == "PL")
    //                        //{
    //                        conteo += 1;
    //                        if (item.detalleAdicional != null)
    //                        {
    //                             if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional}) {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                            else
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional})", item.secuencia.ToString (), "");
    //                        }
    //                        else
    //                        {
    //                             if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                            else
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}", item.secuencia.ToString (), "");
    //                        }

    //                        foreach (var itemComplemento in item.complementoVentaAbarrotes)
    //                        {
    //                            print.AnadirLineaElementosComplementoFactura(itemComplemento.cantidadComplemento.GetValueOrDefault().ToString(), $"{itemComplemento.nombreComplemento}", itemComplemento.secuencia.ToString(), itemComplemento.idDocumentoDet.ToString());
    //                        }

    //                    }

    //                    //NOMBRE DE LA IMPRESORA
    //                    //NUMERO COPIAS DE IMPRESION

    //                    if (conteo >= 1)
    //                    {
    //                        print.ImprimeTicket(itemPrint.ipImpresoraCompartida, itemPrint.relacionImpresora, itemPrint.cantidadPrint);
    //                        //}
    //                    }

    //                }
    //                else if (itemPrint.formatoImpresion == "45MM")
    //                {

    //                    Ticket58mm.Ticket48mm print = new Ticket58mm.Ticket48mm();

    //                    if (nameMesa == null)
    //                    {
    //                        nameMesa = "";
    //                    }

    //                    if (NombreInfra == null)
    //                    {
    //                        NombreInfra = "";
    //                    }

    //                    print.AnadirLineaEmpresa("PEDIDO - " + itemPrint.aliasImpresora);
    //                    print.AnadirLineaEmpresa("");
    //                    print.AnadirLineaEmpresa(nameMesa + "/" + NombreInfra);
    //                    if (itemPrint.descripAdicinal != null)
    //                    {
    //                        print.AnadirLineaEmpresa("");
    //                        print.AnadirLineaEmpresa(itemPrint.descripAdicinal);
    //                    }
    //                    //FECHA
    //                    //VENDEDOR
    //                    //CARGO
    //                    var fecha = Convert.ToString(DateTime.Now);

    //                    print.AnadirLineaCaracteresDatosGEnerales(fecha,
    //                                                          nameVendedor,
    //                                                           namecargo
    //                                                           );

    //                    var conteo = 0;
    //                    //DETALLES DE LOS PEDIDOS
    //                    foreach (var item in itemPrint.listaProductos.Where(S => S.estadoImpresion == "PI"))
    //                    {
    //                        //i/f (item.tipoVenta == "PL")
    //                        //{
    //                        conteo += 1;
    //                        if (item.detalleAdicional != null)
    //                        {
    //                             if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional}) {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                            else
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional})", item.secuencia.ToString (), "");
    //                        }
    //                        else
    //                        {
    //                             if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                            else
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}", item.secuencia.ToString (), "");
    //                        }

    //                        foreach (var itemComplemento in item.complementoVentaAbarrotes)
    //                        {
    //                            print.AnadirLineaElementosComplementoFactura(itemComplemento.cantidadComplemento.GetValueOrDefault().ToString(), $"{itemComplemento.nombreComplemento}", itemComplemento.secuencia.ToString(), itemComplemento.idDocumentoDet.ToString());
    //                        }

    //                    }

    //                    //NOMBRE DE LA IMPRESORA
    //                    //NUMERO COPIAS DE IMPRESION

    //                    if (conteo >= 1)
    //                    {
    //                        print.ImprimeTicket(itemPrint.ipImpresoraCompartida, itemPrint.relacionImpresora, itemPrint.cantidadPrint);
    //                        //}
    //                    }

    //                }



    //            }
    //        }

    //    }
    //    catch (Exception)
    //    {
    //        throw new Exception("No se Pudo imrimir.");
    //    }


    //}

    //public void ImprimirPedidoReImpersion(List<detalleItemsImpresoras> order, String ISPRINTER, String nameMesa, String nameVendedor, String nameAlmacen, String namecargo, String NombreInfra)
    //{
    //    try
    //    {

    //        //TITULO
    //        if (order != null)
    //        {

    //            foreach (var itemPrint in order)
    //            {

    //                if (itemPrint.formatoImpresion == "80MM")
    //                {
    //                    Ticket58mm.Ticket print = new Ticket58mm.Ticket();

    //                    if (nameMesa == null)
    //                    {
    //                        nameMesa = "";
    //                    }                                        

    //                    print.AnadirLineaEmpresa("REIMPRESION");
    //                    print.AnadirLineaEmpresa("");
    //                    print.AnadirLineaEmpresa("PEDIDO - " + itemPrint.aliasImpresora);
    //                    print.AnadirLineaEmpresa("");
    //                    print.AnadirLineaEmpresa(nameMesa);

    //                    if (itemPrint.descripAdicinal != null)
    //                    {
    //                        print.AnadirLineaEmpresa("");
    //                        print.AnadirLineaEmpresa(itemPrint.descripAdicinal);
    //                    }

    //                    //FECHA
    //                    //VENDEDOR
    //                    //CARGO
    //                    var fecha = Convert.ToString(DateTime.Now);

    //                    print.AnadirLineaCaracteresDatosGEnerales(fecha,
    //                                                          nameVendedor,
    //                                                           namecargo
    //                                                           );


    //                    //DETALLES DE LOS PEDIDOS
    //                    foreach (var item in itemPrint.listaProductos)
    //                    {
    //                        //i/f (item.tipoVenta == "PL")
    //                        //{
    //                        if (item.detalleAdicional != null)
    //                        {
    //                             if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional}) {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                            else
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional})", item.secuencia.ToString (), "");
    //                        }
    //                        else
    //                        {
    //                             if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                            else
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}", item.secuencia.ToString (), "");
    //                        }

    //                        foreach (var itemComplemento in item.complementoVentaAbarrotes)
    //                        {
    //                            print.AnadirLineaElementosComplementoFactura(itemComplemento.cantidadComplemento.GetValueOrDefault().ToString(), $"{itemComplemento.nombreComplemento}", itemComplemento.secuencia.ToString(), itemComplemento.idDocumentoDet.ToString());
    //                        }

    //                    }

    //                    //NOMBRE DE LA IMPRESORA
    //                    //NUMERO COPIAS DE IMPRESION
    //                    print.ImprimeTicket(itemPrint.ipImpresoraCompartida, itemPrint.relacionImpresora, itemPrint.cantidadPrint);
    //                    //}
    //                }
    //                else if (itemPrint.formatoImpresion == "55MM")
    //                {

    //                    Ticket58mm.Ticket58mm print = new Ticket58mm.Ticket58mm();

    //                    if (nameMesa == null)
    //                    {
    //                        nameMesa = "";
    //                    }

    //                    if (NombreInfra == null)
    //                    {
    //                        NombreInfra = "";
    //                    }

    //                    print.AnadirLineaEmpresa("REIMPRESION");
    //                    print.AnadirLineaEmpresa("");
    //                    print.AnadirLineaEmpresa("PEDIDO - " + itemPrint.aliasImpresora);
    //                    print.AnadirLineaEmpresa("");
    //                    print.AnadirLineaEmpresa(nameMesa + "/" + NombreInfra);
    //                    if (itemPrint.descripAdicinal != null)
    //                    {
    //                        print.AnadirLineaEmpresa("");
    //                        print.AnadirLineaEmpresa(itemPrint.descripAdicinal);
    //                    }

    //                    //FECHA
    //                    //VENDEDOR
    //                    //CARGO
    //                    var fecha = Convert.ToString(DateTime.Now);

    //                    print.AnadirLineaCaracteresDatosGEnerales(fecha,
    //                                                          nameVendedor,
    //                                                           namecargo
    //                                                           );


    //                    //DETALLES DE LOS PEDIDOS
    //                    foreach (var item in itemPrint.listaProductos)
    //                    {
    //                        //i/f (item.tipoVenta == "PL")
    //                        //{
    //                        if (item.detalleAdicional != null)
    //                        {
    //                             if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional}) {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                            else
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional})", item.secuencia.ToString (), "");
    //                        }
    //                        else
    //                        {
    //                             if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                            else
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}", item.secuencia.ToString (), "");
    //                        }

    //                        foreach (var itemComplemento in item.complementoVentaAbarrotes)
    //                        {
    //                            print.AnadirLineaElementosComplementoFactura(itemComplemento.cantidadComplemento.GetValueOrDefault().ToString(), $"{itemComplemento.nombreComplemento}", itemComplemento.secuencia.ToString(), itemComplemento.idDocumentoDet.ToString());
    //                        }

    //                    }

    //                    //NOMBRE DE LA IMPRESORA
    //                    //NUMERO COPIAS DE IMPRESION
    //                    print.ImprimeTicket(itemPrint.ipImpresoraCompartida, itemPrint.relacionImpresora, itemPrint.cantidadPrint);

    //                }
    //                else if (itemPrint.formatoImpresion == "45MM")
    //                {

    //                    Ticket58mm.Ticket48mm print = new Ticket58mm.Ticket48mm();

    //                    if (nameMesa == null)
    //                    {
    //                        nameMesa = "";
    //                    }

    //                    if (NombreInfra == null)
    //                    {
    //                        NombreInfra = "";
    //                    }

    //                    print.AnadirLineaEmpresa("REIMPRESION");
    //                    print.AnadirLineaEmpresa("");
    //                    print.AnadirLineaEmpresa("PEDIDO - " + itemPrint.aliasImpresora);
    //                    print.AnadirLineaEmpresa("");
    //                    print.AnadirLineaEmpresa(nameMesa + "/" + NombreInfra);
    //                    if (itemPrint.descripAdicinal != null)
    //                    {
    //                        print.AnadirLineaEmpresa("");
    //                        print.AnadirLineaEmpresa(itemPrint.descripAdicinal);
    //                    }
    //                    //FECHA
    //                    //VENDEDOR
    //                    //CARGO
    //                    var fecha = Convert.ToString(DateTime.Now);

    //                    print.AnadirLineaCaracteresDatosGEnerales(fecha,
    //                                                          nameVendedor,
    //                                                           namecargo
    //                                                           );


    //                    //DETALLES DE LOS PEDIDOS
    //                    foreach (var item in itemPrint.listaProductos)
    //                    {
    //                        //i/f (item.tipoVenta == "PL")
    //                        //{
    //                        if (item.detalleAdicional != null)
    //                        {
    //                             if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional}) {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                            else
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional})", item.secuencia.ToString (), "");
    //                        }
    //                        else
    //                        {
    //                             if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                            else
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}", item.secuencia.ToString (), "");
    //                        }

    //                        foreach (var itemComplemento in item.complementoVentaAbarrotes)
    //                        {
    //                            print.AnadirLineaElementosComplementoFactura(itemComplemento.cantidadComplemento.GetValueOrDefault().ToString(), $"{itemComplemento.nombreComplemento}", itemComplemento.secuencia.ToString(), itemComplemento.idDocumentoDet.ToString());
    //                        }

    //                    }

    //                    //NOMBRE DE LA IMPRESORA
    //                    //NUMERO COPIAS DE IMPRESION
    //                    print.ImprimeTicket(itemPrint.ipImpresoraCompartida, itemPrint.relacionImpresora, itemPrint.cantidadPrint);

    //                }



    //            }
    //        }

    //    }
    //    catch (Exception)
    //    {
    //        throw new Exception("No se Pudo imrimir.");
    //    }


    //}

    //public void ImprimirPedidoAnulacion(List<detalleItemsImpresoras> order, String ISPRINTER, String nameMesa, String nameVendedor, String nameAlmacen, String namecargo, String NombreInfra)
    //{
    //    try
    //    {

    //        //TITULO
    //        if (order != null)
    //        {

    //            foreach (var itemPrint in order)
    //            {

    //                if (itemPrint.formatoImpresion == "80MM")
    //                {
    //                    Ticket58mm.Ticket print = new Ticket58mm.Ticket();

    //                    if (nameMesa == null)
    //                    {
    //                        nameMesa = "";
    //                    }
                          
    //                    print.AnadirLineaEmpresa("ANULACIÓN");
    //                    print.AnadirLineaEmpresa("");
    //                    print.AnadirLineaEmpresa("PEDIDO - " + itemPrint.aliasImpresora);
    //                    print.AnadirLineaEmpresa("");
    //                    print.AnadirLineaEmpresa(nameMesa);

    //                    if (itemPrint.descripAdicinal != null)
    //                    {
    //                        print.AnadirLineaEmpresa("");
    //                        print.AnadirLineaEmpresa(itemPrint.descripAdicinal);
    //                    }

    //                    //FECHA
    //                    //VENDEDOR
    //                    //CARGO
    //                    var fecha = Convert.ToString(DateTime.Now);

    //                    print.AnadirLineaCaracteresDatosGEnerales(fecha,
    //                                                          nameVendedor,
    //                                                           namecargo
    //                                                           );


    //                    //DETALLES DE LOS PEDIDOS
    //                    foreach (var item in itemPrint.listaProductos)
    //                    {
    //                        //i/f (item.tipoVenta == "PL")
    //                        //{
    //                        if (item.detalleAdicional != null)
    //                        {
    //                             if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional}) {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                            else
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional})", item.secuencia.ToString (), "");
    //                        }
    //                        else
    //                        {
    //                             if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                            else
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}", item.secuencia.ToString (), "");
    //                        }

    //                        foreach (var itemComplemento in item.complementoVentaAbarrotes)
    //                        {
    //                            print.AnadirLineaElementosComplementoFactura(itemComplemento.cantidadComplemento.GetValueOrDefault().ToString(), $"{itemComplemento.nombreComplemento}", itemComplemento.secuencia.ToString(), itemComplemento.idDocumentoDet.ToString());
    //                        }

    //                    }

    //                    //NOMBRE DE LA IMPRESORA
    //                    //NUMERO COPIAS DE IMPRESION
    //                    print.ImprimeTicket(itemPrint.ipImpresoraCompartida, itemPrint.relacionImpresora, itemPrint.cantidadPrint);
    //                    //}
    //                }
    //                else if (itemPrint.formatoImpresion == "55MM")
    //                {

    //                    Ticket58mm.Ticket58mm print = new Ticket58mm.Ticket58mm();

    //                    if (nameMesa == null)
    //                    {
    //                        nameMesa = "";
    //                    }

    //                    if (NombreInfra == null)
    //                    {
    //                        NombreInfra = "";
    //                    }

    //                    print.AnadirLineaEmpresa("ANULACIÓN");
    //                    print.AnadirLineaEmpresa("");
    //                    print.AnadirLineaEmpresa("PEDIDO - " + itemPrint.aliasImpresora);
    //                    print.AnadirLineaEmpresa("");
    //                    print.AnadirLineaEmpresa(nameMesa + "/" + NombreInfra);
    //                    if (itemPrint.descripAdicinal != null)
    //                    {
    //                        print.AnadirLineaEmpresa("");
    //                        print.AnadirLineaEmpresa(itemPrint.descripAdicinal);
    //                    }

    //                    //FECHA
    //                    //VENDEDOR
    //                    //CARGO
    //                    var fecha = Convert.ToString(DateTime.Now);

    //                    print.AnadirLineaCaracteresDatosGEnerales(fecha,
    //                                                          nameVendedor,
    //                                                           namecargo
    //                                                           );


    //                    //DETALLES DE LOS PEDIDOS
    //                    foreach (var item in itemPrint.listaProductos)
    //                    {
    //                        //i/f (item.tipoVenta == "PL")
    //                        //{
    //                        if (item.detalleAdicional != null)
    //                        {
    //                             if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional}) {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                            else
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional})", item.secuencia.ToString (), "");
    //                        }
    //                        else
    //                        {
    //                             if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                            else
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}", item.secuencia.ToString (), "");
    //                        }

    //                        foreach (var itemComplemento in item.complementoVentaAbarrotes)
    //                        {
    //                            print.AnadirLineaElementosComplementoFactura(itemComplemento.cantidadComplemento.GetValueOrDefault().ToString(), $"{itemComplemento.nombreComplemento}", itemComplemento.secuencia.ToString(), itemComplemento.idDocumentoDet.ToString());
    //                        }

    //                    }

    //                    //NOMBRE DE LA IMPRESORA
    //                    //NUMERO COPIAS DE IMPRESION
    //                    print.ImprimeTicket(itemPrint.ipImpresoraCompartida, itemPrint.relacionImpresora, itemPrint.cantidadPrint);

    //                }
    //                else if (itemPrint.formatoImpresion == "45MM")
    //                {

    //                    Ticket58mm.Ticket48mm print = new Ticket58mm.Ticket48mm();

    //                    if (nameMesa == null)
    //                    {
    //                        nameMesa = "";
    //                    }

    //                    if (NombreInfra == null)
    //                    {
    //                        NombreInfra = "";
    //                    }

    //                    print.AnadirLineaEmpresa("ANULACIÓN");
    //                    print.AnadirLineaEmpresa("");
    //                    print.AnadirLineaEmpresa("PEDIDO - " + itemPrint.aliasImpresora);
    //                    print.AnadirLineaEmpresa("");
    //                    print.AnadirLineaEmpresa(nameMesa + "/" + NombreInfra);
    //                    if (itemPrint.descripAdicinal != null)
    //                    {
    //                        print.AnadirLineaEmpresa("");
    //                        print.AnadirLineaEmpresa(itemPrint.descripAdicinal);
    //                    }
    //                    //FECHA
    //                    //VENDEDOR
    //                    //CARGO
    //                    var fecha = Convert.ToString(DateTime.Now);

    //                    print.AnadirLineaCaracteresDatosGEnerales(fecha,
    //                                                          nameVendedor,
    //                                                           namecargo
    //                                                           );


    //                    //DETALLES DE LOS PEDIDOS
    //                    foreach (var item in itemPrint.listaProductos)
    //                    {
    //                        //i/f (item.tipoVenta == "PL")
    //                        //{
    //                        if (item.detalleAdicional != null)
    //                        {
    //                             if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional}) {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                            else
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional})", item.secuencia.ToString (), "");
    //                        }
    //                        else
    //                        {
    //                             if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                            else
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}", item.secuencia.ToString (), "");
    //                        }

    //                        foreach (var itemComplemento in item.complementoVentaAbarrotes)
    //                        {
    //                            print.AnadirLineaElementosComplementoFactura(itemComplemento.cantidadComplemento.GetValueOrDefault().ToString(), $"{itemComplemento.nombreComplemento}", itemComplemento.secuencia.ToString(), itemComplemento.idDocumentoDet.ToString());
    //                        }

    //                    }

    //                    //NOMBRE DE LA IMPRESORA
    //                    //NUMERO COPIAS DE IMPRESION
    //                    print.ImprimeTicket(itemPrint.ipImpresoraCompartida, itemPrint.relacionImpresora, itemPrint.cantidadPrint);

    //                }



    //            }
    //        }

    //    }
    //    catch (Exception)
    //    {
    //        throw new Exception("No se Pudo imrimir.");
    //    }


    //}

    //public void ImprimirPedidoAnulacionItem(List<detalleItemsImpresoras> order, String ISPRINTER, String nameMesa, String nameVendedor, String nameAlmacen, String namecargo, String NombreInfra)
    //{
    //    try
    //    {

    //        //TITULO
    //        if (order != null)
    //        {

    //            foreach (var itemPrint in order)
    //            {

    //                if (itemPrint.formatoImpresion == "80MM")
    //                {
    //                    Ticket58mm.Ticket print = new Ticket58mm.Ticket();

    //                    if (nameMesa == null)
    //                    {
    //                        nameMesa = "";
    //                    }
                                             
    //                    print.AnadirLineaEmpresa("ANULACIÓN");
    //                    print.AnadirLineaEmpresa("");
    //                    print.AnadirLineaEmpresa("PEDIDO - " + itemPrint.aliasImpresora);
    //                    print.AnadirLineaEmpresa("");
    //                    print.AnadirLineaEmpresa(nameMesa);

    //                    if (itemPrint.descripAdicinal != null)
    //                    {
    //                        print.AnadirLineaEmpresa("");
    //                        print.AnadirLineaEmpresa(itemPrint.descripAdicinal);
    //                    }

    //                    //FECHA
    //                    //VENDEDOR
    //                    //CARGO
    //                    var fecha = Convert.ToString(DateTime.Now);

    //                    print.AnadirLineaCaracteresDatosGEnerales(fecha,
    //                                                          nameVendedor,
    //                                                           namecargo
    //                                                           );

    //                    var conteo = 0;
    //                    //DETALLES DE LOS PEDIDOS
    //                    foreach (var item in itemPrint.listaProductos.Where(S => S.estadoImpresion == "PA"))
    //                    {
    //                        conteo += 1;
    //                        //i/f (item.tipoVenta == "PL")
    //                        //{
    //                        if (item.detalleAdicional != null)
    //                        {
    //                             if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional}) {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                            else
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional})", item.secuencia.ToString (), "");
    //                        }
    //                        else
    //                        {
    //                             if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                            else
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}", item.secuencia.ToString (), "");
    //                        }

    //                        foreach (var itemComplemento in item.complementoVentaAbarrotes)
    //                        {
    //                            print.AnadirLineaElementosComplementoFactura(itemComplemento.cantidadComplemento.GetValueOrDefault().ToString(), $"{itemComplemento.nombreComplemento}", itemComplemento.secuencia.ToString(), itemComplemento.idDocumentoDet.ToString());
    //                        }

    //                    }

    //                    //NOMBRE DE LA IMPRESORA
    //                    //NUMERO COPIAS DE IMPRESION
    //                    if (conteo >= 1) {
    //                        print.ImprimeTicket(itemPrint.ipImpresoraCompartida, itemPrint.relacionImpresora, itemPrint.cantidadPrint);
    //                        //}
    //                    }

    //                }
    //                else if (itemPrint.formatoImpresion == "55MM")
    //                {

    //                    Ticket58mm.Ticket58mm print = new Ticket58mm.Ticket58mm();

    //                    if (nameMesa == null)
    //                    {
    //                        nameMesa = "";
    //                    }

    //                    if (NombreInfra == null)
    //                    {
    //                        NombreInfra = "";
    //                    }

    //                    print.AnadirLineaEmpresa("ANULACIÓN");
    //                    print.AnadirLineaEmpresa("");
    //                    print.AnadirLineaEmpresa("PEDIDO - " + itemPrint.aliasImpresora);
    //                    print.AnadirLineaEmpresa("");
    //                    print.AnadirLineaEmpresa(nameMesa + "/" + NombreInfra);
    //                    if (itemPrint.descripAdicinal != null)
    //                    {
    //                        print.AnadirLineaEmpresa("");
    //                        print.AnadirLineaEmpresa(itemPrint.descripAdicinal);
    //                    }

    //                    //FECHA
    //                    //VENDEDOR
    //                    //CARGO
    //                    var fecha = Convert.ToString(DateTime.Now);

    //                    print.AnadirLineaCaracteresDatosGEnerales(fecha,
    //                                                          nameVendedor,
    //                                                           namecargo
    //                                                           );


    //                    var conteo = 0;
    //                    //DETALLES DE LOS PEDIDOS
    //                    foreach (var item in itemPrint.listaProductos.Where(S => S.estadoImpresion == "PA"))
    //                    {
    //                        conteo += 1;
    //                        //i/f (item.tipoVenta == "PL")
    //                        //{
    //                        if (item.detalleAdicional != null)
    //                        {
    //                             if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional}) {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                            else
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional})", item.secuencia.ToString (), "");
    //                        }
    //                        else
    //                        {
    //                             if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                            else
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}", item.secuencia.ToString (), "");
    //                        }

    //                        foreach (var itemComplemento in item.complementoVentaAbarrotes)
    //                        {
    //                            print.AnadirLineaElementosComplementoFactura(itemComplemento.cantidadComplemento.GetValueOrDefault().ToString(), $"{itemComplemento.nombreComplemento}", itemComplemento.secuencia.ToString(), itemComplemento.idDocumentoDet.ToString());
    //                        }

    //                    }

    //                    //NOMBRE DE LA IMPRESORA
    //                    //NUMERO COPIAS DE IMPRESION
    //                    if (conteo >= 1)
    //                    {
    //                        print.ImprimeTicket(itemPrint.ipImpresoraCompartida, itemPrint.relacionImpresora, itemPrint.cantidadPrint);
    //                        //}
    //                    }
    //                }
    //                else if (itemPrint.formatoImpresion == "45MM")
    //                {

    //                    Ticket58mm.Ticket48mm print = new Ticket58mm.Ticket48mm();

    //                    if (nameMesa == null)
    //                    {
    //                        nameMesa = "";
    //                    }

    //                    if (NombreInfra == null)
    //                    {
    //                        NombreInfra = "";
    //                    }

    //                    print.AnadirLineaEmpresa("ANULACIÓN");
    //                    print.AnadirLineaEmpresa("");
    //                    print.AnadirLineaEmpresa("PEDIDO - " + itemPrint.aliasImpresora);
    //                    print.AnadirLineaEmpresa("");
    //                    print.AnadirLineaEmpresa(nameMesa + "/" + NombreInfra);
    //                    if (itemPrint.descripAdicinal != null)
    //                    {
    //                        print.AnadirLineaEmpresa("");
    //                        print.AnadirLineaEmpresa(itemPrint.descripAdicinal);
    //                    }
    //                    //FECHA
    //                    //VENDEDOR
    //                    //CARGO
    //                    var fecha = Convert.ToString(DateTime.Now);

    //                    print.AnadirLineaCaracteresDatosGEnerales(fecha,
    //                                                          nameVendedor,
    //                                                           namecargo
    //                                                           );


    //                    var conteo = 0;
    //                    //DETALLES DE LOS PEDIDOS
    //                    foreach (var item in itemPrint.listaProductos.Where(S => S.estadoImpresion == "PA"))
    //                    {
    //                        //i/f (item.tipoVenta == "PL")
    //                        //{
    //                        conteo += 1;

    //                        if (item.detalleAdicional != null)
    //                        {
    //                             if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional}) {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                            else
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional})", item.secuencia.ToString (), "");
    //                        }
    //                        else
    //                        {
    //                             if (item.delivery == true)
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} {"(PARA LLEVAR)"}", item.secuencia.ToString (), "");
    //                            else
    //                                print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}", item.secuencia.ToString (), "");
    //                        }

    //                        foreach (var itemComplemento in item.complementoVentaAbarrotes)
    //                        {
    //                            print.AnadirLineaElementosComplementoFactura(itemComplemento.cantidadComplemento.GetValueOrDefault().ToString(), $"{itemComplemento.nombreComplemento}", itemComplemento.secuencia.ToString(), itemComplemento.idDocumentoDet.ToString());
    //                        }

    //                    }

    //                    //NOMBRE DE LA IMPRESORA
    //                    //NUMERO COPIAS DE IMPRESION
    //                    if (conteo >= 1)
    //                    {
    //                        print.ImprimeTicket(itemPrint.ipImpresoraCompartida, itemPrint.relacionImpresora, itemPrint.cantidadPrint);
    //                        //}
    //                    }
    //                }



    //            }
    //        }

    //    }
    //    catch (Exception)
    //    {
    //        throw new Exception("No se Pudo imrimir.");
    //    }


    //}


    //public void ImprimirPreCuenta(List<documentoventaAbarrotesDet> order, ImpresorasNegocio ISPRINTER, String nameMesa, String nameVendedor, String nameAlmacen, String namecargo, String NombreInfra)
    //{
    //    try
    //    {

    //        //TITULO
         

    //                if (ISPRINTER.formatoImpresion == "80MM")
    //                {
    //                    PRE_CUENTA_2.TicketPreCuenta print = new PRE_CUENTA_2.TicketPreCuenta();


    //                    print.AnadirLineaEmpresa("PRE CUENTA");
    //                    print.AnadirLineaEmpresa("");
    //                    print.AnadirLineaEmpresa(nameMesa);

    //                    //FECHA
    //                    //VENDEDOR
    //                    //CARGO
    //                    var fecha = Convert.ToString(DateTime.Now);

    //                    print.AnadirLineaCaracteresDatosGEnerales(fecha,
    //                                                          nameVendedor,
    //                                                           namecargo
    //                                                           );


    //                    double totalImporte = 0.0;
    //                    decimal cantidadTotal = 0;
    //            decimal totalImporteDet = 0;


    //            //DETALLES DE LOS PEDIDOS
    //            foreach (var item in order)
    //                    {
    //                cantidadTotal = item.monto1.GetValueOrDefault() - item.cantidadCredito.GetValueOrDefault();

    //                totalImporteDet = cantidadTotal * item.precioUnitario.GetValueOrDefault();

    //                      print.AnadirLineaElementosFactura(cantidadTotal.ToString(), $"{item.nombreItem}", item.unidad1, item.precioUnitario.GetValueOrDefault().ToString () , totalImporteDet.ToString());
    //                        totalImporte = totalImporte + Convert.ToDouble(totalImporteDet);
    //                    }


    //                    print.AnadirDatosGenerales("S/ ", Convert.ToString(totalImporte));

    //                    print.AnadirLineaDatos("R.U.C.:",
    //                                        "R. Social:",
    //                                      "Dirección:");

    //                    //NOMBRE DE LA IMPRESORA
    //                    //NUMERO COPIAS DE IMPRESION

    //                    print.ImprimeTicket(ISPRINTER.IPImpresion , ISPRINTER.relacionImpresora, (int)ISPRINTER.numImpresion);                                           

                       
    //                }
    //                else if (ISPRINTER.formatoImpresion == "55MM")
    //                {

    //                    PRE_CUENTA_2.TicketPreCuenta58mm  print = new PRE_CUENTA_2.TicketPreCuenta58mm();


    //                    print.AnadirLineaEmpresa("PRE CUENTA");
    //                    print.AnadirLineaEmpresa("");
    //                    print.AnadirLineaEmpresa(nameMesa);

    //                    //FECHA
    //                    //VENDEDOR
    //                    //CARGO
    //                    var fecha = Convert.ToString(DateTime.Now);

    //                    print.AnadirLineaCaracteresDatosGEnerales(fecha,
    //                                                          nameVendedor,
    //                                                           namecargo
    //                                                           );


    //                    double totalImporte = 0.0;

    //                    //DETALLES DE LOS PEDIDOS
    //                    foreach (var item in order)
    //                    {


    //                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}", item.unidad1, item.precioUnitario.GetValueOrDefault().ToString(), item.importeMN.GetValueOrDefault().ToString());
    //                        totalImporte = totalImporte + Convert.ToDouble(item.importeMN);
    //                    }


    //                    print.AnadirDatosGenerales("S/ ", Convert.ToString(totalImporte));

    //                    print.AnadirLineaDatos("R.U.C.:",
    //                                        "R. Social:",
    //                                      "Dirección:");

    //            //NOMBRE DE LA IMPRESORA
    //            //NUMERO COPIAS DE IMPRESION

    //            print.ImprimeTicket(ISPRINTER.IPImpresion, ISPRINTER.relacionImpresora, (int)ISPRINTER.numImpresion);

    //        }
    //                else if (ISPRINTER.formatoImpresion == "45MM")
    //                {

    //                    PRE_CUENTA_2.TicketPreCuenta48mm  print = new PRE_CUENTA_2.TicketPreCuenta48mm();


    //                    print.AnadirLineaEmpresa("PRE CUENTA");
    //                    print.AnadirLineaEmpresa("");
    //                    print.AnadirLineaEmpresa(nameMesa);

    //                    //FECHA
    //                    //VENDEDOR
    //                    //CARGO
    //                    var fecha = Convert.ToString(DateTime.Now);

    //                    print.AnadirLineaCaracteresDatosGEnerales(fecha,
    //                                                          nameVendedor,
    //                                                           namecargo
    //                                                           );


    //                    double totalImporte = 0.0;

    //                    //DETALLES DE LOS PEDIDOS
    //                    foreach (var item in order)
    //                    {


    //                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}", item.unidad1, item.precioUnitario.GetValueOrDefault().ToString(), item.importeMN.GetValueOrDefault().ToString());
    //                        totalImporte = totalImporte + Convert.ToDouble(item.importeMN);
    //                    }


    //                    print.AnadirDatosGenerales("S/ ", Convert.ToString(totalImporte));

    //                    print.AnadirLineaDatos("R.U.C.:",
    //                                        "R. Social:",
    //                                      "Dirección:");

    //            //NOMBRE DE LA IMPRESORA
    //            //NUMERO COPIAS DE IMPRESION

    //            print.ImprimeTicket(ISPRINTER.IPImpresion, ISPRINTER.relacionImpresora, (int)ISPRINTER.numImpresion);

    //        }



          

    //    }
    //    catch (Exception)
    //    {
    //        throw new Exception("No se Pudo imrimir.");
    //    }


    //}


    //-----------------------------------------------fast report -----------------------------------------------------

    public void ImprimirVoucher(documentoventaAbarrotes order,ImpresorasNegocio printImp,datosGenerales datosGenera)
    {

        try
        {

            var Report = new FastReport.Report();
            MemoryStream strm = new MemoryStream();


            //TITULO
            if (order != null)
            {

                    var pathReport = "";

                    var listGeneral = new List<DocumentoFactura>();

                if(printImp != null)
                {
                    if (printImp.formatoImpresion == "45MM")
                    {
                        pathReport = @"formatos\Reports\Printer\InfDocfacturaVoucher.frx";
                    }
                    else if (printImp.formatoImpresion == "55MM")
                    {
                        pathReport = @"formatos\Reports\Printer\InfDocfacturaVoucher55mm.frx";
                    }
                    else if (printImp.formatoImpresion == "80MM")
                    {
                        pathReport = @"formatos\reports\printer\InfDocfacturaVoucher.frx"; ;
                    }


                    //listGeneral.AddRange(GetPedido(ventaData.fechaDoc.ToString(), consultaNombre.CustomListaUsuarioRol.FirstOrDefault().nombrePerfil, consultaNombre.Full_Name, ventaData.nombreDistribucion, p, "nuevo item"));
                    listGeneral.AddRange(GetVoucher(order));

                    var pathD = "";
                    if (datosGenera.logo != null)
                    {
                        if (datosGenera.logo.Length > 0)
                        {

                            switch (datosGenera.idEstablecimiento)
                            {
                                case 1:
                                    if (datosGenera.logo == "1")
                                    {
                                        pathD = "C:\\logo\\logo.jpg";
                                        //pathD = $"{Directory.GetCurrentDirectory()}{@"\formatos\Logo\logo.jpg"}";
                                    }
                                    else if (datosGenera.logo == "2")
                                    {
                                        pathD = "C:\\logo\\logo2.jpg";
                                        //pathD = $"{Directory.GetCurrentDirectory()}{@"\formatos\Logo\logo2.jpg"}";
                                    }
                                    else if (datosGenera.logo == "3")
                                    {
                                        pathD = "C:\\logo\\logo3.jpg";
                                        //pathD = $"{Directory.GetCurrentDirectory()}{@"\formatos\Logo\logo3.jpg"}";
                                    }
                                    break;
                                case 2:
                                    if (datosGenera.logo == "1")
                                    {
                                        pathD = "C:\\logo\\establecimiento2\\logo.jpg";
                                        //pathD = $"{Directory.GetCurrentDirectory()}{@"\formatos\Logo\establecimiento2\logo.jpg"}";

                                    }
                                    else if (datosGenera.logo == "2")
                                    {
                                        pathD = "C:\\logo\\establecimiento2\\logo2.jpg";
                                        //pathD = $"{Directory.GetCurrentDirectory()}{@"\formatos\Logo\establecimiento2\logo2.jpg"}";

                                    }
                                    else if (datosGenera.logo == "3")
                                    {
                                        pathD = "C:\\logo\\establecimiento2\\logo3.jpg";
                                        //pathD = $"{Directory.GetCurrentDirectory()}{@"\formatos\Logo\establecimiento2\logo3.jpg"}";

                                    }
                                    break;
                                case 3:
                                    if (datosGenera.logo == "1")
                                    {
                                        pathD = "C:\\logo\\establecimiento3\\logo.jpg";
                                        //pathD = $"{Directory.GetCurrentDirectory()}{@"\formatos\Logo\establecimiento3\logo.jpg"}";
                                    }
                                    else if (datosGenera.logo == "2")
                                    {
                                        pathD = "C:\\logo\\establecimiento3\\logo2.jpg";
                                        //pathD = $"{Directory.GetCurrentDirectory()}{@"\formatos\Logo\establecimiento3\logo2.jpg"}";
                                    }
                                    else if (datosGenera.logo == "3")
                                    {
                                        pathD = "C:\\logo\\establecimiento3\\logo3.jpg";
                                        //pathD = $"{Directory.GetCurrentDirectory()}{@"\formatos\Logo\establecimiento3\logo3.jpg"}";
                                    }
                                    break;
                                default:
                                    if (datosGenera.logo == "1")
                                    {
                                        pathD = "C:\\logo\\establecimiento4\\logo.jpg";
                                        //pathD = $"{Directory.GetCurrentDirectory()}{@"\formatos\Logo\establecimiento4\logo.jpg"}";
                                    }
                                    else if (datosGenera.logo == "2")
                                    {
                                        pathD = "C:\\logo\\establecimiento4\\logo2.jpg";
                                        //pathD = $"{Directory.GetCurrentDirectory()}{@"\formatos\Logo\establecimiento4\logo2.jpg"}";
                                    }
                                    else if (datosGenera.logo == "3")
                                    {
                                        pathD = "C:\\logo\\establecimiento4\\logo3.jpg";
                                        //pathD = $"{Directory.GetCurrentDirectory()}{@"\formatos\Logo\establecimiento4\logo3.jpg"}";
                                    }
                                    break;

                            }



                        }
                    }

                  

                    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathReport);
                    Report.Load(path);

                    if (File.Exists(pathD))
                    {
                        if (datosGenera.logo.Length > 0)
                        {
                            PictureObject Logo02 = (PictureObject)Report.Report.FindObject("Logo02");
                            Logo02.Image = System.Drawing.Image.FromFile(pathD);

                            ReportTitleBand dtRazonsocial = Report.Report.FindObject("HeaderInforme") as ReportTitleBand;
                            dtRazonsocial.Visible = true;

                        }
                    }
                     

                    Report.Report.SetParameterValue("SimboloMoneda", "S/");
                    Report.RegisterData(listGeneral, "DocumentoFacturas");
                    Report.Prepare();


                    var pdfExport = new FastReport.Export.Pdf.PDFExport();
                    pdfExport.ShowProgress = false;
                    pdfExport.Subject = "Subject";
                    pdfExport.Title = "xxxxxxx";
                    pdfExport.Compressed = true;
                    pdfExport.AllowPrint = true;
                    pdfExport.EmbeddingFonts = true;
                    Report.Report.Report.Export(pdfExport, strm);

                    pdfExport.Dispose();
                    strm.Position = 0;

                    Report.PrintSettings.Printer = printImp.relacionImpresora;
                    int numprin = (int)printImp.numImpresion;
                    if (printImp != null)
                    {

                        for (int i = 0; i < numprin; i++)
                        {
                            Report.Report.PrintSettings.ShowDialog = false;
                            Report.Print();
                        }


                    }
                }

                   

            }

        }
        catch (Exception ex)
        {
            throw new Exception("No se Pudo imrimir.");
        }


    }

    public List<DocumentoFactura> GetVoucher(documentoventaAbarrotes ventaData)
    {
        var objCuenta = new DocumentoFactura();
        var listInvoice = new List<DocumentoFactura>();

        objCuenta.SerieFact = ventaData.serieVenta + " - " + ventaData.GetNumberWithZeros;
        objCuenta.FechaEmision = ventaData.fechaDoc.GetValueOrDefault().ToString("dd-MM-yyyy HH:mm tt");
        objCuenta.ImporteTotal = String.Format("{0:0.00}", ventaData.ImporteNacional);



        listInvoice.Add(objCuenta);

        return listInvoice;
    }

    //public void ImprimirPromociones(List<detalleItemsImpresoras> PrinDet, printProductComercial order, PrintQueue printQ ,ImpresorasNegocio ImpresoraN)
          public void ImprimirPromociones(List<printProductComercial> PrinDet)
    {

        try
        {

            var Report = new FastReport.Report();
            MemoryStream strm = new MemoryStream();

            //var consultaNombre = userdata;// await UserAPI.GetId(new Helios.Seguridad.Business.Entity.Usuario() { IDUsuario = iduser });


            //TITULO
            if (PrinDet != null)
            {
                foreach(var dt in PrinDet)
                {
                    if (PrinDet != null)
                    {


                        var pathReport = "";

                        var listGeneral = new List<SpPedidosRest>();

                        if (dt.formatoImpresion == "45MM")
                        {
                            pathReport = @"formatos\Reports\promociones\infPedidosRest45mm.frx";
                        }
                        else if (dt.formatoImpresion == "55MM")
                        {
                            pathReport = @"formatos\Reports\promociones\infPedidosRest55mm.frx";
                        }
                        else if (dt.formatoImpresion == "80MM")
                        {
                            pathReport = @"formatos\reports\promociones\infPromocionesComercial88mm.frx";
                        }

                        //listGeneral.AddRange(GetPedido(ventaData.fechaDoc.ToString(), consultaNombre.CustomListaUsuarioRol.FirstOrDefault().nombrePerfil, consultaNombre.Full_Name, ventaData.nombreDistribucion, p, "nuevo item"));
                        //listGeneral.AddRange(GetPedido(ventaData, consultaNombre.CustomListaUsuarioRol.FirstOrDefault().nombrePerfil, consultaNombre.Full_Name, p, "nuevo item"));
                        listGeneral.AddRange(GetPromociones(dt));


                        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathReport);
                        Report.Load(path);

                        //Report.Report.SetParameterValue("Promociones", order.grupoProducto);
                        
                        Report.RegisterData(listGeneral, "RestPedidos");
                        Report.Prepare();


                        var pdfExport = new FastReport.Export.Pdf.PDFExport();
                        pdfExport.ShowProgress = false;
                        pdfExport.Subject = "Subject";
                        pdfExport.Title = "xxxxxxx";
                        pdfExport.Compressed = true;
                        pdfExport.AllowPrint = true;
                        pdfExport.EmbeddingFonts = true;
                        Report.Report.Report.Export(pdfExport, strm);

                        pdfExport.Dispose();
                        strm.Position = 0;

                        Report.PrintSettings.Printer = dt.relacionImpresora;
                        int cantida = dt.cantidadPrint;
                        if (PrinDet != null)
                        {

                            for (int i = 0; i < cantida; i++)
                            {
                                Report.Report.PrintSettings.ShowDialog = false;
                                Report.Print();
                            }


                        }




                    }
                }
            }

        

        }
        catch (Exception ex)
        {
            throw new Exception("No se Pudo imrimir.");
        }


    }


    public List<SpPedidosRest> GetPromociones(printProductComercial ventaData)
    {
        var produc="";
        var listInvoice = new List<SpPedidosRest>();
        var objCuenta = new SpPedidosRest();

        var listComplemento = new List<SpComplementoRest>();
        var ObjComple = new SpComplementoRest();

        objCuenta.FechaPedido = ventaData.fecha.ToString();
        objCuenta.CargoPedido = ventaData.cargoUsuario + " :";
        objCuenta.Usuario = ventaData.usuario;
        objCuenta.Moviliario = ventaData.relacionImpresora;
        //objCuenta.Moviliario = ventaData.nombreDistribucion;
        //objCuenta.TotalImporte = "0";
        //objCuenta.Cliente = "-";
        //objCuenta.DocCliente = p.titleInput;

        objCuenta.PedidosRestDet = new List<SpPedidosRestDet>();
        foreach (var det in ventaData.DetProductos)
        {
            produc = det.producto.ToUpper();
            listComplemento = new List<SpComplementoRest>();

            if (ventaData.DetaBeneficios != null)
            {
                if (ventaData.DetaBeneficios.Count > 0)
                {
                    foreach (var comp in ventaData.DetaBeneficios.Where(s => s.IdOrdenDetalleBene == det.IdOrdenDetalleProd))
                    {
                        ObjComple = new SpComplementoRest();
                        ObjComple.NombreComplemento = comp.productoBene;
                        ObjComple.CantidadComplemento = "( "+ comp.CantidadBene.ToString("N0") + " )";
                        listComplemento.Add(ObjComple);
                    }

                }
            }


            objCuenta.PedidosRestDet.Add(new SpPedidosRestDet()
            {
                CantidadDet = det.Cantidad.ToString("N0"),
                DescPediDet = produc,
                UnidadMedida=det.UMedida,
                ComplementosRest = listComplemento
            });

        }

        listInvoice.Add(objCuenta);

        return listInvoice;
    }



    public void ImprimirPedidoReImpersionFastReport(List<detalleItemsImpresoras> order,  PrintQueue tipo, ImpresorasNegocio ImpresoraN, documentoventaAbarrotes ventaData, configuracionInicio ConfigInicio)
    {
 
        try
        {

            var Report = new FastReport.Report();
            MemoryStream strm = new MemoryStream();

            //var consultaNombre = userdata;// await UserAPI.GetId(new Helios.Seguridad.Business.Entity.Usuario() { IDUsuario = iduser });


            //TITULO
            if (order != null)
            {

                foreach (var p in order)
                {
                    var pathReport = "";
       
                    var listGeneral = new List<SpPedidosRest>();

                    if (p.formatoImpresion == "45MM")
                    {
                        pathReport = @"formatos\Reports\Printer\infPedidosRest45mm.frx";
                    }
                    else if (p.formatoImpresion == "55MM")
                    {
                        pathReport = @"formatos\Reports\Printer\infPedidosRest55mm.frx";
                    }
                    else if (p.formatoImpresion == "80MM")
                    {
                        pathReport = @"formatos\reports\printer\infPedidosRest.frx";
                        //pathReport = @"formatos\reports\printer\infPedidosRestMatricial.frx";
                    }
                    else if (p.formatoImpresion == "80MMLP")
                    {
                        pathReport = @"formatos\reports\printer\infPedidosRest.frx";
                    }

                    if (tipo.TipoEnvioImpresion == "nuevo item")
                    {

                        //listGeneral.AddRange(GetPedido(ventaData, p, "nuevo item", ConfigInicio));
                    }
                    else if (tipo.TipoEnvioImpresion == "Anulacion")
                    {
                        p.titleInput = "ANULACIÓN " +" - "+ p.aliasImpresora;

                        //listGeneral.AddRange(GetPedido(ventaData, p, "Anulacion", ConfigInicio));
                    }
                    else if (tipo.TipoEnvioImpresion == "Anulacion por item")
                    {
                        p.titleInput = "ANULACIÓN " + " - " + p.aliasImpresora;
                        //listGeneral.AddRange(GetPedido(ventaData, p, "Anulacion por item", ConfigInicio));
                    }
                    else if (tipo.TipoEnvioImpresion == "Reimpresion")
                    {
                        p.titleInput = "REIMPRESIÓN PEDIDO " + " - " + p.aliasImpresora;
                        //listGeneral.AddRange(GetPedido(ventaData, p, "Reimpresion", ConfigInicio));
                    }
                    else
                    {
                        p.titleInput = "PEDIDO " + " - " + p.aliasImpresora;
                        //listGeneral.AddRange(GetPedido(ventaData, p, "", ConfigInicio));
                    }

                    listGeneral.AddRange(GetPedido(ventaData, p, tipo, ConfigInicio));


                    if (p.listaProductos.Count > 0)
                    {
                        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathReport);
                        Report.Load(path);
                        //Report.Report.SetParameterValue("UbicacionPedido", p.relacionImpresora);

                        Report.RegisterData(listGeneral, "RestPedidos");      
                        Report.Prepare();

                        if (ventaData.descripAdicinalPedido != null)
                        {

                            DataBand dtClie = Report.Report.FindObject("dtClie") as DataBand;
                            dtClie.Visible = true;
                            LineObject Line14 = Report.Report.FindObject("Line14") as LineObject;
                            Line14.Visible = true;
                        }

                        if (!String.IsNullOrWhiteSpace(ventaData.nombreDistribucion))
                        {
                            DataBand dtMoviliario = Report.Report.FindObject("dtMoviliario") as DataBand;
                            dtMoviliario.Visible = true;
                        }
                        if (String.IsNullOrWhiteSpace(ventaData.descripAdicinalPedido))
                        {
                            DataBand dtClie = Report.Report.FindObject("dtClie") as DataBand;
                            dtClie.Visible = false;
                        }
                        if (ConfigInicio.InicioVenta !=null)
                        {
                            DataBand dtubicacion = Report.Report.FindObject("dtubicacion") as DataBand;
                            dtubicacion.Visible = false;
                            DataBand dtCargo = Report.Report.FindObject("dtCargo") as DataBand;
                            dtCargo.Visible = false;

                        }

                        var pdfExport = new FastReport.Export.Pdf.PDFExport();
                        pdfExport.ShowProgress = false;
                        pdfExport.Subject = "Subject";
                        pdfExport.Title = "xxxxxxx";
                        pdfExport.Compressed = true;
                        pdfExport.AllowPrint = true;
                        pdfExport.EmbeddingFonts = true;
                        Report.Report.Report.Export(pdfExport, strm);

                        pdfExport.Dispose();
                        strm.Position = 0;

                        Report.PrintSettings.Printer = p.relacionImpresora;
                        int printNr = (int)ImpresoraN.numImpresion;
                        if (ImpresoraN != null)
                        {
                         
                            for (int i = 0; i < printNr; i++)
                            {
                                Report.Report.PrintSettings.ShowDialog = false;
                                Report.Print();
                            }


                        }
                    }

                }

            }

        }
        catch (Exception ex)
        {
            throw new Exception("No se Pudo imrimir.");
        }


    }

    public List<SpPedidosRest> GetPedido(documentoventaAbarrotes ventaData, detalleItemsImpresoras p, PrintQueue tipo, configuracionInicio ConfigInicio)
    {
        var listInvoice = new List<SpPedidosRest>();
        var objCuenta = new SpPedidosRest();

        //objCuenta.ComplementosRest = new List<SpComplementoRest>();
        var listComplemento = new List<SpComplementoRest>();
        var ObjComple = new SpComplementoRest();
        var listpromociones = new List<SpCombosRest>();
        var ObjPromo = new SpCombosRest();
        var ObjAdcional = new SpAdicionalRestDet();
        var listAdciona = new List<SpAdicionalRestDet>();
        var item = "";//f
        var ImpresorasList = new List<documentoventaDetalleBeneficios>();
        var Distribucion="";
        var CantiComplemento = "";
        //objCuenta.FechaPedido = fecha;
        objCuenta.FechaPedido = tipo.FechaEnvio.GetValueOrDefault().ToString("dd-MM-yyyy") + "  Hora: " + tipo.FechaEnvio.GetValueOrDefault().ToString("HH:mm:tt");
        objCuenta.CargoPedido = ventaData.cargoOperacion + " :";
        objCuenta.Usuario = ventaData.usuarioOperacion;
        Distribucion= ventaData.nombreDistribucion;
        if (ventaData.nombreDistribucion == null)
        {
            Distribucion = "Venta directa   |";
        }
        objCuenta.Moviliario = Distribucion;
        objCuenta.TotalImporte = "0";
        objCuenta.Cliente = "-";
        //var NroPedido = p.titleInput.Substring(0, 7);
        objCuenta.DocCliente = p.aliasImpresora;//p.relacionImpresora;//p.titleInput;//EN DONDE VA IMPRIMIR SEGUN LA TABLA DE detalleItemsImpresoras
        if (tipo.TipoEnvioImpresion == "Reimpresion" || tipo.TipoEnvioImpresion == "Anulacion" || tipo.TipoEnvioImpresion == "Anulacion por item")
        {
            objCuenta.DocCliente = p.titleInput;
        }
      
        //objCuenta.DocCliente = NroPedido +" Nro:  "+  ventaData.numeroVenta;

        objCuenta.PedidosRestDet = new List<SpPedidosRestDet>();

        if (ventaData.descripAdicinalPedido != null)
        {
            objCuenta.Cliente = ventaData.descripAdicinalPedido;

        }






        if (tipo.TipoEnvioImpresion == "Anulacion por item")
        {

            objCuenta.FechaPedido = Convert.ToString(DateTime.Now);
            foreach (var det in p.listaProductos.Where(S => S.estadoImpresion == "PA"))
            {
                item = det.nombreItem.ToUpper();

                listComplemento = new List<SpComplementoRest>();
                listpromociones = new List<SpCombosRest>();

                if (det.complementoVentaAbarrotes.Count > 0)
                {
                    foreach (var comp in det.complementoVentaAbarrotes)
                    {
                        ObjComple = new SpComplementoRest();
                        ObjComple.NombreComplemento = comp.nombreComplemento;
                        if (comp.cantidadComplemento.ToString() != "0")
                        {
                            CantiComplemento = comp.cantidadComplemento.ToString();
                        }
                        ObjComple.CantidadComplemento = CantiComplemento;
                        listComplemento.Add(ObjComple);
                    }

                }
                if (det.documentoventaDetalleBeneficios.Count > 0)
                {
                    var DocumBene = det.documentoventaDetalleBeneficios.Select(q => new
                    {
                        q.SegmentHeader
                    }).Distinct().ToList();

                    ImpresorasList = new List<documentoventaDetalleBeneficios>();
                    foreach (var item2 in DocumBene)
                    {
                        var objprint = new documentoventaDetalleBeneficios()
                        {
                            SegmentHeader = item2.SegmentHeader,
                        };
                        ImpresorasList.Add(objprint);
                    }

                    foreach (var Comple in ImpresorasList)
                    {

                        ObjPromo = new SpCombosRest();
                        ObjPromo.NombreCombo = Comple.SegmentHeader;

                        ObjPromo.AdicionalRestDet = new List<SpAdicionalRestDet>();
                        foreach (var adicio in det.documentoventaDetalleBeneficios.Where(s => s.SegmentHeader == Comple.SegmentHeader))
                        {
                            ObjAdcional = new SpAdicionalRestDet();
                            ObjAdcional.DescPediAdicDet = adicio.Nombre;
                            ObjAdcional.CantidadAdicDet = "( " + adicio.Cantidad.GetValueOrDefault().ToString("N0") + " )";
                            ObjPromo.AdicionalRestDet.Add(ObjAdcional);
                        }
                        listpromociones.Add(ObjPromo);
                    }
                }
                //if (det.documentoventaDetalleBeneficios.Count > 0)
                //{
                //    foreach (var Comple in det.documentoventaDetalleBeneficios)
                //    {
                //        ObjPromo = new SpCombosRest();
                //        ObjPromo.NombreCombo = Comple.Nombre;
                //        ObjPromo.Cantidad = "( "+  Comple.Cantidad.GetValueOrDefault().ToString("N0") + " )";
                //        listpromociones.Add(ObjPromo);
                //    }
                //}
                if (det.detalleAdicional.Length > 0)
                {
                    item = det.nombreItem.ToUpper() + " (" + det.detalleAdicional + ")";
                    if (det.delivery == true)
                    {
                        item = det.nombreItem.ToUpper() + " (" + det.detalleAdicional + ")" + " <LLEVAR>";
                    }
                    else if (det.delivery == false)
                    {
                        //item = det.nombreItem.ToUpper() + " (" + det.detalleAdicional + ")" + "  [PARA LA MESA]";
                        item = det.nombreItem.ToUpper() + " (" + det.detalleAdicional + ")";
                    }
                }
                else
                {
                    if (det.delivery == true)
                    {
                        item = det.nombreItem.ToUpper() + "  <LLEVAR>";
                    }
                    else if (det.delivery == false)
                    {
                        //item = det.nombreItem.ToUpper() + "  [PARA LA MESA]";
                        item = det.nombreItem.ToUpper();
                    }
                }
                objCuenta.PedidosRestDet.Add(new SpPedidosRestDet()
                {
                    CantidadDet = det.monto1.GetValueOrDefault().ToString("N0"),
                    DescPediDet = item,
                    Precio = det.precioUnitario.GetValueOrDefault().ToString("N2"),
                    Importe = det.importeMN.GetValueOrDefault().ToString("N2"),
                    ComplementosRest = listComplemento,
                    CombosRest = listpromociones
                });
            }
        }
        else if (tipo.TipoEnvioImpresion == "Reimpresion")
        {
            foreach (var det in p.listaProductos.Where(S => S.estadoPago != "ANUP"))
            {
                item = det.nombreItem.ToUpper();
                listComplemento = new List<SpComplementoRest>();
                listpromociones = new List<SpCombosRest>();

                if (det.complementoVentaAbarrotes.Count > 0)
                {
                    foreach (var comp in det.complementoVentaAbarrotes)
                    {
                        ObjComple = new SpComplementoRest();
                        ObjComple.NombreComplemento = comp.nombreComplemento;

                        if (comp.cantidadComplemento.ToString() != "0")
                        {
                            CantiComplemento = comp.cantidadComplemento.ToString();
                        }
                        ObjComple.CantidadComplemento = CantiComplemento;
                        listComplemento.Add(ObjComple);
                    }

                }

                if (det.documentoventaDetalleBeneficios.Count > 0)
                {
                    var DocumBene = det.documentoventaDetalleBeneficios.Select(q => new
                    {
                        q.SegmentHeader
                    }).Distinct().ToList();

                    ImpresorasList = new List<documentoventaDetalleBeneficios>();
                    foreach (var item2 in DocumBene)
                    {
                        var objprint = new documentoventaDetalleBeneficios()
                        {
                            SegmentHeader = item2.SegmentHeader,
                        };
                        ImpresorasList.Add(objprint);
                    }

                    foreach (var Comple in ImpresorasList)
                    {

                        ObjPromo = new SpCombosRest();
                        ObjPromo.NombreCombo = Comple.SegmentHeader;

                        ObjPromo.AdicionalRestDet = new List<SpAdicionalRestDet>();
                        foreach (var adicio in det.documentoventaDetalleBeneficios.Where(s => s.SegmentHeader == Comple.SegmentHeader))
                        {
                            ObjAdcional = new SpAdicionalRestDet();
                            ObjAdcional.DescPediAdicDet = adicio.Nombre;
                            ObjAdcional.CantidadAdicDet = "( " + adicio.Cantidad.GetValueOrDefault().ToString("N0") + " )";
                            ObjPromo.AdicionalRestDet.Add(ObjAdcional);
                        }
                        listpromociones.Add(ObjPromo);
                    }
                }

                if (det.detalleAdicional !=null)
                {
                    if (det.detalleAdicional.Length > 0)
                    {
                        item = det.nombreItem.ToUpper() + " (" + det.detalleAdicional + ")";
                        if (det.delivery == true)
                        {
                            item = det.nombreItem.ToUpper() + " (" + det.detalleAdicional + ")" + " <LLEVAR>";
                        }
                        else if (det.delivery == false)
                        {
                            //item = det.nombreItem.ToUpper() + " (" + det.detalleAdicional + ")" + "  [PARA LA MESA]";
                            item = det.nombreItem.ToUpper() + " (" + det.detalleAdicional + ")";
                        }

                    }
                    else
                    {
                        if (det.delivery == true)
                        {
                            item = det.nombreItem.ToUpper() + "  <LLEVAR>";
                        }
                        else if (det.delivery == false)
                        {
                            //item = det.nombreItem.ToUpper() + "  [PARA LA MESA]";
                            item = det.nombreItem.ToUpper();
                        }
                    }
                }
                else{
                    if (det.delivery == true)
                    {
                        item = det.nombreItem.ToUpper() + "  <LLEVAR>";
                    }
                    else if (det.delivery == false)
                    {
                        //item = det.nombreItem.ToUpper() + "  [PARA LA MESA]";
                        item = det.nombreItem.ToUpper();
                    }
                }
               

                objCuenta.PedidosRestDet.Add(new SpPedidosRestDet()
                {
                    CantidadDet = det.monto1.GetValueOrDefault().ToString("N0"),
                    DescPediDet = item,
                    //Precio = det.precioUnitario.GetValueOrDefault().ToString("N2"),
                    Importe = det.usuarioModificacion,
                    ComplementosRest = listComplemento,
                    CombosRest = listpromociones
                });

            }
        }
        else if (tipo.TipoEnvioImpresion == "nuevo item")
        {
            foreach (var det in p.listaProductos.Where(S => S.estadoImpresion == "PI"))
            {
                objCuenta.PedidosRestDet.Add(new SpPedidosRestDet()
                {
                    CantidadDet = det.monto1.GetValueOrDefault().ToString("N0"),
                    DescPediDet = det.nombreItem.ToUpper(),
                    Precio = det.precioUnitario.GetValueOrDefault().ToString("N2"),
                    Importe = det.importeMN.GetValueOrDefault().ToString("N2")
                });
            }
        }
        else if (tipo.TipoEnvioImpresion == "Anulacion")
        {
            objCuenta.FechaPedido = Convert.ToString(DateTime.Now);
            foreach (var det in p.listaProductos.Where(S => S.estadoImpresion != "RI"))
            {
                item = det.nombreItem.ToUpper();

                listComplemento = new List<SpComplementoRest>();
                listpromociones = new List<SpCombosRest>();
                if (det.complementoVentaAbarrotes.Count > 0)
                {
                    foreach (var comp in det.complementoVentaAbarrotes)
                    {
                        ObjComple = new SpComplementoRest();
                        ObjComple.NombreComplemento = comp.nombreComplemento;
                        if (comp.cantidadComplemento.ToString() != "0")
                        {
                            CantiComplemento = comp.cantidadComplemento.ToString();
                        }
                        ObjComple.CantidadComplemento = CantiComplemento;
                        listComplemento.Add(ObjComple);
                    }

                }
                if (det.documentoventaDetalleBeneficios.Count > 0)
                {
                    var DocumBene = det.documentoventaDetalleBeneficios.Select(q => new
                    {
                        q.SegmentHeader
                    }).Distinct().ToList();

                    ImpresorasList = new List<documentoventaDetalleBeneficios>();
                    foreach (var item2 in DocumBene)
                    {
                        var objprint = new documentoventaDetalleBeneficios()
                        {
                            SegmentHeader = item2.SegmentHeader,
                        };
                        ImpresorasList.Add(objprint);
                    }

                    foreach (var Comple in ImpresorasList)
                    {

                        ObjPromo = new SpCombosRest();
                        ObjPromo.NombreCombo = Comple.SegmentHeader;

                        ObjPromo.AdicionalRestDet = new List<SpAdicionalRestDet>();
                        foreach (var adicio in det.documentoventaDetalleBeneficios.Where(s => s.SegmentHeader == Comple.SegmentHeader))
                        {
                            ObjAdcional = new SpAdicionalRestDet();
                            ObjAdcional.DescPediAdicDet = adicio.Nombre;
                            ObjAdcional.CantidadAdicDet = "( " + adicio.Cantidad.GetValueOrDefault().ToString("N0") + " )";
                            ObjPromo.AdicionalRestDet.Add(ObjAdcional);
                        }
                        listpromociones.Add(ObjPromo);
                    }
                }
                //if (det.documentoventaDetalleBeneficios.Count > 0)
                //{
                //    foreach (var Comple in det.documentoventaDetalleBeneficios)
                //    {
                //        ObjPromo = new SpCombosRest();
                //        ObjPromo.NombreCombo = Comple.Nombre;
                //        ObjPromo.Cantidad = "( "+  Comple.Cantidad.GetValueOrDefault().ToString("N0")+ " )";
                //        listpromociones.Add(ObjPromo);
                //    }
                //}
                if (det.detalleAdicional!=null)
                {
                    if (det.detalleAdicional.Length > 0)
                    {
                        item = det.nombreItem.ToUpper() + " (" + det.detalleAdicional + ")";
                        if (det.delivery == true)
                        {
                            item = det.nombreItem.ToUpper() + " (" + det.detalleAdicional + ")" + " <LLEVAR>";
                        }
                        else if (det.delivery == false)
                        {
                            //item = det.nombreItem.ToUpper() + " (" + det.detalleAdicional + ")" + "  [PARA LA MESA]";
                            item = det.nombreItem.ToUpper() + " (" + det.detalleAdicional + ")";
                        }
                    }
                    else
                    {
                        if (det.delivery == true)
                        {
                            item = det.nombreItem.ToUpper() + "  <LLEVAR>";
                        }
                        else if (det.delivery == false)
                        {
                            //item = det.nombreItem.ToUpper() + "  [PARA LA MESA]";
                            item = det.nombreItem.ToUpper();
                        }
                    }
                }
              
                objCuenta.PedidosRestDet.Add(new SpPedidosRestDet()
                {
                    CantidadDet = det.monto1.GetValueOrDefault().ToString("N0"),
                    DescPediDet = item,
                    Precio = det.precioUnitario.GetValueOrDefault().ToString("N2"),
                    Importe = det.importeMN.GetValueOrDefault().ToString("N2"),
                    ComplementosRest = listComplemento,
                    CombosRest = listpromociones
                });
            }
        }
        else
        {

            foreach (var det in p.listaProductos)
            {
                item = det.nombreItem.ToUpper();
                listComplemento = new List<SpComplementoRest>();
                listpromociones = new List<SpCombosRest>();
                if (det.complementoVentaAbarrotes.Count > 0)
                {
                    foreach (var comp in det.complementoVentaAbarrotes)
                    {
                        ObjComple = new SpComplementoRest();
                        ObjComple.NombreComplemento = comp.nombreComplemento;
                        if (comp.cantidadComplemento.ToString() != "0")
                        {
                            CantiComplemento = comp.cantidadComplemento.ToString();
                        }
                        ObjComple.CantidadComplemento = CantiComplemento;
                        listComplemento.Add(ObjComple);
                    }

                }

                if (det.documentoventaDetalleBeneficios.Count > 0)
                {
                    var DocumBene = det.documentoventaDetalleBeneficios.Select(q => new
                    {
                        q.SegmentHeader
                    }).Distinct().ToList();

                    ImpresorasList = new List<documentoventaDetalleBeneficios>();
                    foreach (var item2 in DocumBene)
                    {
                        var objprint = new documentoventaDetalleBeneficios()
                        {
                            SegmentHeader = item2.SegmentHeader,
                        };
                        ImpresorasList.Add(objprint);
                    }

                    foreach (var Comple in ImpresorasList)
                    {

                        ObjPromo = new SpCombosRest();
                        ObjPromo.NombreCombo = Comple.SegmentHeader;

                        ObjPromo.AdicionalRestDet = new List<SpAdicionalRestDet>();
                        foreach (var adicio in det.documentoventaDetalleBeneficios.Where(s => s.SegmentHeader == Comple.SegmentHeader))
                        {
                            ObjAdcional = new SpAdicionalRestDet();
                            ObjAdcional.DescPediAdicDet = adicio.Nombre;
                            ObjAdcional.CantidadAdicDet = "( " + adicio.Cantidad.GetValueOrDefault().ToString("N0") + " )";
                            ObjPromo.AdicionalRestDet.Add(ObjAdcional);
                        }
                        listpromociones.Add(ObjPromo);
                    }
                }

                if (det.detalleAdicional != null)
                {
                    if (det.detalleAdicional.Length > 0 )
                    {
                        item = det.nombreItem.ToUpper() + " (" + det.detalleAdicional + ")";
                        if (det.delivery == true)
                        {
                            item = det.nombreItem.ToUpper() + " (" + det.detalleAdicional + ")" + " <LLEVAR>";
                        }
                        else if (det.delivery == false)
                        {
                            //item = det.nombreItem.ToUpper() + " (" + det.detalleAdicional + ")" + "  [PARA LA MESA]";
                            item = det.nombreItem.ToUpper() + " (" + det.detalleAdicional + ")";
                        }
                    }
                    else
                    {
                        if (det.delivery == true)
                        {
                            item = det.nombreItem.ToUpper() + "  <LLEVAR>";
                        }
                        else if (det.delivery == false)
                        {
                            //item = det.nombreItem.ToUpper() + "  [PARA LA MESA]";
                            item = det.nombreItem.ToUpper();
                        }
                    }

                }
                else
                {   
                        if (det.delivery == true)
                        {
                            item = det.nombreItem.ToUpper() + "  <LLEVAR>";
                        }
                        else if (det.delivery == false)
                        {
                            //item = det.nombreItem.ToUpper() + "  [PARA LA MESA]";
                            item = det.nombreItem.ToUpper();
                        }

                }
                objCuenta.PedidosRestDet.Add(new SpPedidosRestDet()
                    {
                        CantidadDet = det.monto1.GetValueOrDefault().ToString("N0"),
                        DescPediDet = item,
                        //Precio = det.precioUnitario.GetValueOrDefault().ToString("N2"),
                        Importe = det.usuarioModificacion,
                        ComplementosRest = listComplemento,
                        CombosRest = listpromociones
                    });
      
              

            }
        }


        listInvoice.Add(objCuenta);

        return listInvoice;
    }




    public void ImprimirPrecuentaFastReport(List<documentoventaAbarrotesDet> order, ImpresorasNegocio ISPRINTER, String nameMesa, String nameVendedor, String nameAlmacen, String namecargo, String NombreInfra, string fecha, string tipo, documentoventaAbarrotes DatosV, List<detalleItemsImpresoras> DetImpre,configuracionInicio Config)

    {
        var pathReport = "";
        var Report = new FastReport.Report();
        MemoryStream strm = new MemoryStream();
        try
        {

            var listGeneral = new List<SpPedidosRest>();

            //var consultaNombre = userdata;// await UserAPI.GetId(new Helios.Seguridad.Business.Entity.Usuario() { IDUsuario = iduser });



            //TITULO
            if (order != null)
            {                                           

                    if (ISPRINTER.formatoImpresion == "45MM")
                    {
                    pathReport = @"formatos\reports\printer\infPreVentaRest45m.frx";
                    }
                    else if (ISPRINTER.formatoImpresion == "55MM")
                    {
                    pathReport = @"formatos\reports\printer\infPreVentaRest55m.frx";
                    }
                    else if (ISPRINTER.formatoImpresion == "80MM")
                    {
                    pathReport = @"formatos\reports\printer\infPreVentaRest.frx";
                    //pathReport = @"formatos\reports\printer\infPreVentaRestMatricial.frx";
                }

                //listGeneral.AddRange(GetPreCuenta(fecha, consultaNombre.CustomListaUsuarioRol.FirstOrDefault().nombrePerfil, consultaNombre.Full_Name, nameMesa, order, "", DatosV));
                listGeneral.AddRange(GetPreCuenta(fecha, nameMesa, order, "", DatosV));
             

                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathReport);
                Report.Load(path);
                Report.RegisterData(listGeneral, "RestPedidos");

                Report.Report.SetParameterValue("SimboloMoneda","S/");
                Report.Prepare();

                if (Config.InicioVenta != null)
                {
                    DataBand DtCargoPC = Report.Report.FindObject("DtCargoPC") as DataBand;
                    DtCargoPC.Visible = false;
                    TableColumn Column11 = Report.Report.FindObject("Column11") as TableColumn;
                    Column11.Visible = false;
                    TextObject Text28 = Report.Report.FindObject("Text28") as TextObject;
                    Text28.Visible = false;
                    TextObject Text23 = Report.Report.FindObject("Text23") as TextObject;
                    Text23.Left = 195.5f;
                }

                var pdfExport = new FastReport.Export.Pdf.PDFExport();
                pdfExport.ShowProgress = false;
                pdfExport.Subject = "Subject";
                pdfExport.Title = "xxxxxxx";
                pdfExport.Compressed = true;
                pdfExport.AllowPrint = true;
                pdfExport.EmbeddingFonts = true;
                Report.Report.Report.Export(pdfExport, strm);

                pdfExport.Dispose();
                strm.Position = 0;


                Report.PrintSettings.Printer = ISPRINTER.relacionImpresora;
                int numPrint = (int)ISPRINTER.numImpresion;
                if (ISPRINTER != null)
                {

                    for (int i = 0; i < numPrint; i++)
                    {
                    Report.Report.PrintSettings.ShowDialog = false;
                    Report.Print();
                        }
                }

                
                 
            }

        }
        catch (Exception ex)
        {
            throw new Exception("No se Pudo imrimir.");
        }


    }



        public List<SpPedidosRest> GetPreCuenta(string fecha, string NroMesa, List<documentoventaAbarrotesDet> p, string tipo,documentoventaAbarrotes DatosV)
    {
        var listInvoice = new List<SpPedidosRest>();

        var objCuenta = new SpPedidosRest();
        objCuenta.FechaPedido = fecha;
        objCuenta.CargoPedido = DatosV.cargoOperacion + " :";
        objCuenta.Usuario = DatosV.usuarioOperacion;
        //objCuenta.CargoPedido = nomPerfil;// consultaNombre.CustomListaUsuarioRol.FirstOrDefault().nombrePerfil;
        //objCuenta.Usuario = nameUser;// consultaNombre.Full_Name;
        objCuenta.Moviliario = NroMesa; // colocar pisoy anu
        //objCuenta.TotalImporte = importe.ToString("N2");
        objCuenta.Cliente = "-";
        objCuenta.DocCliente ="";

        objCuenta.PedidosRestDet = new List<SpPedidosRestDet>();

        var impor = 0.00;
            foreach (var det in p)
            {
                objCuenta.PedidosRestDet.Add(new SpPedidosRestDet()
                {
                    CantidadDet = det.monto1.GetValueOrDefault().ToString("N0"),
                    DescPediDet = det.nombreItem,
                    Precio = det.precioUnitario.GetValueOrDefault().ToString("N2"),
                    Importe = det.importeMN.GetValueOrDefault().ToString("N2")

                });
            impor = impor + Convert.ToDouble(det.importeMN);
            }
        objCuenta.TotalImporte = impor.ToString("N2");

        listInvoice.Add(objCuenta);

        return listInvoice;
    }

    public void ImprimirCompra(documentocompra compras,string formato, ImpresorasNegocio PrintNeg)
    {
        var pathReport = "";
        var conver = "";
        var Report = new FastReport.Report();
        MemoryStream strm = new MemoryStream();
        try
        {

            var listGeneral = new List<SpDocumentoCompra>();


            //TITULO
        

                    switch (formato)
                    {

                        case "TK":
                            break;

                        case "A4":
                         pathReport = @"formatos\reports\printerSales\InfDocumentoCompraWebA4.frx";

                            break;

                        case "A5":
                            break;

                        default:
                            break;
                    }

         
              
                listGeneral.AddRange(GetCompraFinal(compras));

                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathReport);
                Report.Load(path);
     
                var DesFactura = "";
     
                if (compras.tipoDoc == "01")
                {

                    DesFactura = "Factura de compra";
                }
                else if (compras.tipoDoc == "03")
                {
                    DesFactura = "Boleta de compra";
                }
                else if (compras.tipoDoc == "9907")
                {
                    DesFactura = "Nota de compra";
                }

                Report.Report.SetParameterValue("Descfactura", DesFactura);
                Report.Report.SetParameterValue("SimboloMoneda", "S/");
                Report.Report.SetParameterValue("DescripcionMonto", conver);


                Report.RegisterData(listGeneral, "DocumentoCompras");
                Report.Prepare();


                //ValidarCompraTrueFalse();



                var pdfExport = new FastReport.Export.Pdf.PDFExport();

                Report.Report.Report.Export(pdfExport, strm);

                pdfExport.Dispose();
                strm.Position = 0;



                Report.PrintSettings.Printer = PrintNeg.relacionImpresora;
                int numeroPr = (int)PrintNeg.numImpresion;
                if (PrintNeg != null)
                {
                    for (int i = 0; i < numeroPr; i++)
                    {
                        Report.Report.PrintSettings.ShowDialog = false;
                        Report.Print();
                    }
                }


        }
        catch (Exception ex)
        {
            throw new Exception("No se Pudo imrimir.");
        }

    }

    public List<SpDocumentoCompra> GetCompraFinal(documentocompra compra)

    {


        var listInvoice = new List<SpDocumentoCompra>();
        var objCuenta = new SpDocumentoCompra();
        var listInvoiceDet = new List<SpDocumentoCompraDetalle>();
        var InvoiceDet = new SpDocumentoCompraDetalle();
      

        //switch (p.tipoDocumentoCliente)
        //{
        //    case "1":
        //        DocumentD = "DNI     ";
        //        break;
        //    case "6":
        //        DocumentD = "RUC     ";
        //        break;
        //    default:
        //        DocumentD = "Otros";
        //        break;
        //}

        objCuenta.RucClienteCompra = compra.CustomEntidad.nrodoc;
        objCuenta.ClienteCompra = compra.CustomEntidad.nombreCompleto;
        objCuenta.SerieFactCompra = compra.serie + " - " + String.Format("{0:00000000}", Convert.ToInt32(compra.numeroDoc));
        objCuenta.FechaEmisionCompra = compra.fechaDoc.GetValueOrDefault().ToString("dd-MM-yyyy HH:mm");

        var Moden="";
        if (compra.monedaDoc == "1")
        {
            Moden = "SOLES";
        }
        else if (compra.monedaDoc == "2")
        {
            Moden = "DOLARES";
        }

        

        var TipoDoc="";
        if (compra.tipoDoc == "01")
        {
            TipoDoc = "FACTURA";
        }
        else if (compra.tipoDoc == "03")
        {
            TipoDoc = "BOLETA";
        }
        else if (compra.tipoDoc == "9907")
        {
            TipoDoc = "NOTA DE VENTA";
        }

        objCuenta.TipoMonedaCompra = Moden;
        objCuenta.CondicionPagoCompra = TipoDoc;

        foreach (var det in compra.documentocompradetalle)
        {
            InvoiceDet = new SpDocumentoCompraDetalle();

            InvoiceDet.NroItemDetCompra = det.idItem;
            InvoiceDet.UnidadDetCompra = det.unidad1;
            InvoiceDet.DescripcionDetCompra = det.descripcionItem.ToUpper();
            InvoiceDet.PrecioUnitarioDetCompra = det.precioUnitario.GetValueOrDefault().ToString("N2");
            InvoiceDet.CantidadDetCompra = det.monto1.GetValueOrDefault().ToString("N2");
            InvoiceDet.ImporteDetCompra = det.importe.GetValueOrDefault().ToString("N2");


            listInvoiceDet.Add(InvoiceDet);
        }

        objCuenta.OpGravadaCompra = String.Format("{0:0.00}", compra.bi01);
        objCuenta.IGVCompra = String.Format("{0:0.00}", compra.igv01);
        objCuenta.ImporteTotalCompra = String.Format("{0:0.00}", compra.importeTotal);



        objCuenta.DocumentoCompraDetalle = listInvoiceDet;

        listInvoice.Add(objCuenta);



        return listInvoice;
    }



    public void ImprimirComprobanteFinal(rePrintResponse order, String nameVendedor, String nameAlmacen, String namecargo, String NombreInfra, string fecha, PrintQueue address)
    {
        var pathReport = "";
        var conver = "";
        var Report = new FastReport.Report();
        MemoryStream strm = new MemoryStream();
        try
        {

            var listGeneral = new List<DocumentoFactura>();

            //var consultaNombre = userdata;// await UserAPI.GetId(new Helios.Seguridad.Business.Entity.Usuario() { IDUsuario = iduser });
            //var consultaNombre = "";


            //TITULO
            if (order != null)
            {
      
                    switch (order.PrintNegocio.printOutput)
                    {
                      
                        case "TK":

              
                             if (order.PrintNegocio.formatoImpresion == "45MM")
                                {
                                pathReport = @"formatos\reports\printer\InfDocfacturaTicket45mm.frx";
                            }
                            else if (order.PrintNegocio.formatoImpresion == "55MM")
                            {
                                pathReport = @"formatos\reports\printer\InfDocfacturaTicket55mm.frx";
                            }
                            else if (order.PrintNegocio.formatoImpresion == "80MM")
                            {
                                pathReport = @"formatos\reports\printer\InfDocfacturaTicketWeb.frx";
                                //pathReport = @"formatos\reports\printer\InfDocfacturaTicketWebMatricial.frx";
                            }
                            else if (order.PrintNegocio.formatoImpresion == "80MMLP")
                            {
                                pathReport = @"formatos\reports\printer\InfDocfacturaTicketWebLP.frx";
                            }
             

                            break;
                     
                        case "A4":

                            if (order.PrintNegocio.formatoImpresion == "NOA4")
                            {
                                pathReport = @"formatos\reports\printerSales\InfDocumentoFacturasWebA4.frx";
                            }
                            else if (order.PrintNegocio.formatoImpresion == "BNA4")
                            {
                               
                            }
                            else if (order.PrintNegocio.formatoImpresion == "CVA4")
                            {
                              
                            }
                            else if (order.PrintNegocio.formatoImpresion == "TGA4")
                            {
                                pathReport = @"formatos\reports\printerSales\InfDocumentoFacturasWebBingText.frx";
                            }
                            else if (order.PrintNegocio.formatoImpresion == "CGA4")
                            {
                                pathReport = @"formatos\reports\printerSales\InfDocumentoFacturasWeb4_GRIS.frx";
                            }
                            else
                            {
                                pathReport = @"formatos\reports\printerSales\InfDocumentoFacturasWebA4.frx";
                            }
            
                            break;
                        
                        case "A5":
                            if (order.PrintNegocio.formatoImpresion == "HOA5" || order.PrintNegocio.formatoImpresion=="1")
                            {
                                pathReport = @"formatos\reports\printerSales\InfDocumentoFacturasWebA5_Horizontal.frx";
                            }
                            else if (order.PrintNegocio.formatoImpresion == "VEA5")
                            {
                                pathReport = @"formatos\reports\printerSales\InfDocumentoFacturasWebA5.frx";
                            }
              
   
                            break;                       

                        default:
                            break;
                    }


                var Moden = "";
                var simboloMoneda = "";
                if (order.moneda == "1")
                {
                    Moden = "SOLES";
                    simboloMoneda  = "S/.";
                }
                else if (order.moneda == "2")
                {
                    Moden = "DOLARES";
                    simboloMoneda = "$";
                }

                //listGeneral.AddRange(GetComprobanteFinal(fecha, consultaNombre.Full_Name, order, "", userdata, LISTACRONOGRAMA, Moden, datosGenera, address, ImpreNego, UsuOrder));
                //listGeneral.AddRange(GetComprobanteFinal(fecha, consultaNombre, order, "", Moden, datosGenera, address, ImpreNego));
                //listGeneral.AddRange(GetComprobanteFinal(fecha, consultaNombre, order, "", Moden, address));
                listGeneral.AddRange(GetComprobanteFinal(fecha, order, "", Moden, address));

                //zona report
                //Report.Report.RegisterData(listInvoice, "DocumentoFacturas");
                //Report.Report.Load(pathReport);
                var pathD = "";
                if (order.DatosGen.logo != null)
                {
                    if (order.DatosGen.logo.Length > 0)
                    {
                    
                        switch (order.idEstablecimiento)
                        {
                            case 1:
                                if (order.DatosGen.logo == "1")
                                {
                                    pathD = "C:\\logo\\logo.jpg";
                        
                                }
                                else if (order.DatosGen.logo == "2")
                                {
                                    pathD = "C:\\logo\\logo2.jpg";
                          
                                }
                                else if (order.DatosGen.logo == "3")
                                {
                                    pathD = "C:\\logo\\logo3.jpg";
                                    //pathD = $"{Directory.GetCurrentDirectory()}{@"\formatos\Logo\logo3.jpg"}";
                                }
                                break;
                            case 2:
                                if (order.DatosGen.logo == "1")
                                {
                                    pathD = "C:\\logo\\establecimiento2\\logo.jpg";
                 
                                }
                                else if (order.DatosGen.logo == "2")
                                {
                                    pathD = "C:\\logo\\establecimiento2\\logo2.jpg";
                       
                                }
                                else if (order.DatosGen.logo == "3")
                                {
                                    pathD = "C:\\logo\\establecimiento2\\logo3.jpg";
                      
                                }
                                break;
                            case 3:
                                if (order.DatosGen.logo == "1")
                                {
                                    pathD = "C:\\logo\\establecimiento3\\logo.jpg";
   
                                }
                                else if (order.DatosGen.logo == "2")
                                {
                                    pathD = "C:\\logo\\establecimiento3\\logo2.jpg";

                                }
                                else if (order.DatosGen.logo == "3")
                                {
                                    pathD = "C:\\logo\\establecimiento3\\logo3.jpg";

                                }
                                break;
                            default:
                                if (order.DatosGen.logo == "1")
                                {
                                    pathD = "C:\\logo\\establecimiento4\\logo.jpg";
         
                                }
                                else if (order.DatosGen.logo == "2")
                                {
                                    pathD = "C:\\logo\\establecimiento4\\logo2.jpg";

                                }
                                else if (order.DatosGen.logo == "3")
                                {
                                    pathD = "C:\\logo\\establecimiento4\\logo3.jpg";
   
                                }
                                break;

                        }



                    }
                }

                var descuenT = order.ImporteDescGlobal;
                if (descuenT == 0)
                {
                    descuenT = order.totaldescuento;
                }

                //var numeroConverson = Convert.ToDecimal(order.ImporteNacional);
                var numeroConverson = Convert.ToDecimal(order.importeTotal - descuenT);
                conver = Conversiones.Enletras(numeroConverson) + " " + Moden;


             

                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathReport);
                Report.Load(path);
            
                    if (File.Exists(pathD))
                {
                    if (order.DatosGen.logo.Length > 0)
                    {
                        PictureObject Logo02 = (PictureObject)Report.Report.FindObject("Logo02");
                        Logo02.Image = System.Drawing.Image.FromFile(pathD);
                    }
                }

                if (order.DatosGen.logoFooter!=null)
                {
                    if (order.DatosGen.logoFooter.Length > 0)
                    {
                        string pathfood = "";
                        if (order.DatosGen.logoFooter == "1")
                        {
                            pathfood = $"{Directory.GetCurrentDirectory()}{@"\formatos\Logo\logofood.jpg"}";
                        }

                        PictureObject LogoFood = Report.Report.FindObject("LogoFood") as PictureObject;
                        LogoFood.Image = System.Drawing.Image.FromFile(pathfood);

                    }
                }
               
                var PorIgv = order.tasaIgv.ToString("N0");
                //var PorIgv = order.tasaIgv.GetValueOrDefault().ToString("N0");

                //var DesFactura = order.GetNameComprobante;
                //if (order.tipoOperacion == "PRF")
                //{
                //    DesFactura = "PROFORMA";
                //}
                var DesFactura = "";
                var DescrionPrint = "";
                switch (order.tipoDocumento)
                {
                    case "07":
                        DesFactura = "Nota de Crédito Electrónico";
                        break;
                    case "08":
                        DesFactura = "Nota de Dédito";
                        break;
                    case "09":
                        DesFactura = "Guía de remisión";
                        break;
                    case "03":
                        DesFactura = "Boleta de Venta Electrónica";
                        DescrionPrint = "BOLETA DE VENTA";
                        break;
                    case "01":
                        DesFactura = "Factura Electrónica";
                        DescrionPrint = "FACTURA";
                        break;
                    case "9907":
                        DesFactura = "Nota de Venta";
                        break;
                    case "9903":
                        DesFactura = "Cotización";
                        break;
                    default:
                        DesFactura = "Otro";
                        break;
                }

                if (order.tipoOperacion == "PRF")
                {
                    DesFactura = "PROFORMA";
                }
                else if (order.tipoOperacion == "ORV")
                {
                    DesFactura = "PEDIDO";
                }
                Report.Report.SetParameterValue("Descfactura", DesFactura);
                Report.Report.SetParameterValue("IGV", " ("+ PorIgv + " %)");
                Report.Report.SetParameterValue("SimboloMoneda", simboloMoneda);
                Report.Report.SetParameterValue("DescripcionMonto", conver);
                //Report.Report.SetParameterValue("nombregiro", datosGenera.nombreGiro);
                Report.Report.SetParameterValue("nombregiro", order.DatosGen.publicidad4);
                Report.Report.SetParameterValue("Nromesa", order.nombreDistribucion);
                Report.Report.SetParameterValue("DescrPrint", "REPRESENTACIÓN IMPRESA DE LA " + DescrionPrint + " ELECTRÓNICA");
                Report.Report.SetParameterValue("ObersvacionDG", order.DatosGen.ObservacionDG);
                Report.Report.SetParameterValue("Devoluciones", order.DatosGen.DescripcionExchangeReturns);

                //Detraccion
                Report.Report.SetParameterValue("LeyendaDetraccion", order.TipoOpDescDetraccion);
                Report.Report.SetParameterValue("BienDetraccion", order.BSDescDetraccion);
                Report.Report.SetParameterValue("MpagoDetraccion", order.MedioPagoDescDetraccion);
                Report.Report.SetParameterValue("BNDetraccion", order.CuentaBNDetraccion);
                Report.Report.SetParameterValue("PorcentrajeDetraccion", order.PorcentajeDetraccion);
                Report.Report.SetParameterValue("MontoDetraccion", order.MontoDetraccion);

                //PictureObject imagen = Report.Report.FindObject("Logo02") as PictureObject;
                //imagen.Image = System.Drawing.Image.FromFile(pathD);

                Report.RegisterData(listGeneral, "DocumentoFacturas");
                Report.Prepare();

                //ValidarTrueFalse(datosGenera, order, Report, address, listGeneral, ImpreNego, returConfigura, pathD, UsuOrder);
                //ValidarTrueFalse(datosGenera, order, Report, address, listGeneral, ImpreNego, returConfigura, pathD);

                ValidarTrueFalse(order, Report, address, listGeneral, pathD);


                var qr = "";
                PictureObject imageLogoCompany = (PictureObject)Report.Report.FindObject("CodQRDes");
                QRCodeGenerator gen = new QRCodeGenerator();
                //var dt = gen.CreateQrCode(codigoQr.Hash, QRCodeGenerator.ECCLevel.Q);
                qr = order.idEmpresa + "|" + order.tipoDocumento + "|" + order.serieVenta + "|" + order.numero + "|" +
                       order.importeTotal + "|" + order.fechaDoc.ToString("yyyy-MM-dd") + "|" +
                       order.tipoDocumentoCliente + "|" + order.numeroDocumentoCliente;


                var dt = gen.CreateQrCode(qr, QRCodeGenerator.ECCLevel.Q);
                QRCode code = new QRCode(dt);
                imageLogoCompany.Image = code.GetGraphic(6);

                var pdfExport = new FastReport.Export.Pdf.PDFExport();
                //pdfExport.ShowProgress = false;
                //pdfExport.Subject = "Subject";
                //pdfExport.Title = "xxxxxxx";
                //pdfExport.Compressed = true;
                //pdfExport.AllowPrint = true;
                //pdfExport.EmbeddingFonts = true;
                Report.Report.Report.Export(pdfExport, strm);

                pdfExport.Dispose();
                strm.Position = 0;

                //Report.PrintSettings.Printer = ISPRINTER.nombreimpresora;

                //Report.PrintSettings.Printer = ImpreNego.relacionImpresora;
                //int numeroPr = (int)ImpreNego.numImpresion;
                //if (ImpreNego != null)
                Report.PrintSettings.Printer = order.PrintNegocio.relacionImpresora;
                //int numeroPr = (int)ImpreNego.numImpresion;
                int numeroPr = (int)order.PrintNegocio.numeroImpresora;
                if (order.PrintNegocio != null)
                {
                    for (int i = 0; i < numeroPr; i++)
                    {
                        Report.Report.PrintSettings.ShowDialog = false;
                        Report.Print();
                    }
                }
               
                
            }

        }
        catch (Exception ex)
        {
            throw new Exception("No se Pudo imrimir.");
        }

    }

         public List<DocumentoFactura> GetComprobanteFinal(string fecha, rePrintResponse p, string tipo, string Moden, PrintQueue address)

    {

        //var pathReport = "";
        var gravMN = 0.00;
        var gravME = 0.00;
        var ExoMN = 0.00;
        var ExoME = 0.00;
        var InaMN = 0.00;
        var InaME = 0.00;
        
 
        var efec = 0.0;
        //var vuelt = 0.0;
        var OperaGrat = 0.0;
        var telefon = "";
        var direcc = "";     
        var cuentaSoles = "";
        var cuentaDolares = "";

        //if (datosGen != null)
        if (p.DatosGen != null)
        {
            if (p.DatosGen.telefono4 != null && p.DatosGen.telefono4.Length > 0)
            {
                telefon = p.DatosGen.telefono1 + " - " + p.DatosGen.telefono2 + " - " + p.DatosGen.telefono3 + " - " + p.DatosGen.telefono4;
            }
            else if (p.DatosGen.telefono3 != null && p.DatosGen.telefono3.Length > 0)
            {
                telefon = p.DatosGen.telefono1 + " - " + p.DatosGen.telefono2 + " - " + p.DatosGen.telefono3;
            }
            else if (p.DatosGen.telefono2 != null && p.DatosGen.telefono2.Length > 0)
            {
                telefon = p.DatosGen.telefono1 + " - " + p.DatosGen.telefono2;
            }
            else
            {
                if (p.DatosGen.telefono1 != null)
                {
                    telefon = p.DatosGen.telefono1;
                }

            }

            //if (!String.IsNullOrWhiteSpace(datosGen.nroCuentaSoles2))
            if (!String.IsNullOrWhiteSpace(p.DatosGen.nroCuentaEmpresaSoles2))
            {

                //cuentaSoles = $"{datosGen.nroCuentaSoles}{Environment.NewLine}{datosGen.nroCuentaSoles2}";

                cuentaSoles = $"{p.DatosGen.nroCuentaEmpresaSoles}{Environment.NewLine}{p.DatosGen.nroCuentaEmpresaSoles2}";
            }
            //else if (!String.IsNullOrWhiteSpace(datosGen.nroCuentaSoles))
            else if (!String.IsNullOrWhiteSpace(p.DatosGen.nroCuentaEmpresaSoles))
            {

                //cuentaSoles = $"{datosGen.nroCuentaSoles}";
                cuentaSoles = $"{p.DatosGen.nroCuentaEmpresaSoles}";

            }
            if (!String.IsNullOrWhiteSpace(p.DatosGen.nroCuentaEmpresaDolares2))
            {

                cuentaDolares = $"{p.DatosGen.nroCuentaEmpresaDolares}{Environment.NewLine}{p.DatosGen.nroCuentaEmpresaDolares2}";
            }
            else if (!String.IsNullOrWhiteSpace(p.DatosGen.nroCuentaEmpresaDolares))
            {

                cuentaDolares = $"{p.DatosGen.nroCuentaEmpresaDolares}";
            }
       

            if (!String.IsNullOrWhiteSpace(address.Direccion))
            {
                direcc = address.Direccion;
            }

            if (p.efectivo != 0.00)
            {
                efec = p.efectivo;
            }
            else
            {
                efec = 0.00;
            }



            var cajadeDoc = new spkDocumentoCajaDetalle();
            var ListcajadeDoc = new List<spkDocumentoCajaDetalle>();
            var notacredito = new NotaCredito();
            var Listnotacredito = new List<NotaCredito>();

            if (p.tipoDocumento == "07")
            {


                var tipoEmisionNC = "";
                //switch (p.notaCredito)
                switch (p.tipoNotaCredito)
                {
                    case "01":
                        tipoEmisionNC = "Anulación de la Operación";
                        break;
                    case "02":
                        tipoEmisionNC = "Anulación por error en el RUC";
                        break;
                    case "03":
                        tipoEmisionNC = "Anulación por error en la descripción";
                        break;
                    case "04":
                        tipoEmisionNC = "Descuento global";
                        break;
                    case "05":
                        tipoEmisionNC = "Descuento por item";
                        break;
                    case "06":
                        tipoEmisionNC = "Devolución total";
                        break;
                    case "07":
                        tipoEmisionNC = "Devolución por item";
                        break;
                    case "08":
                        tipoEmisionNC = "Bonificación";
                        break;
                    case "09":
                        tipoEmisionNC = "Disminución en el valor";
                        break;
                    case "10":
                        tipoEmisionNC = "Otros conceptos";
                        break;
                    case "11":
                        tipoEmisionNC = "Ajustes de Operaciones de exportación";
                        break;
                }

                if (p.serieVenta.Substring(0, 1) == "F")
                {
                    notacredito.DescripNC = $"FACTURA ELECTRONICA {p.serieNota} - {p.numeroNota} {Environment.NewLine} {p.fechaNotaAfectado}";
                }
                else if (p.serieVenta.Substring(0, 1) == "B")
                {
                    notacredito.DescripNC = $"BOLETA ELECTRONICA {p.serieNota} - {p.numeroNota} {Environment.NewLine} {p.fechaNotaAfectado}";
                }
                else
                {
                    notacredito.DescripNC = $"NOTA DE VENTA {p.serieNota} - {p.numeroNota} {Environment.NewLine} {p.fechaNotaAfectado}";
                }


                notacredito.TipoNC = tipoEmisionNC;
                notacredito.MotivoNC = p.glosa;

                Listnotacredito.Add(notacredito);

            }



            var Empresa = new DatosEmpresa();
            var ListEmpresa = new List<DatosEmpresa>();
            Empresa.Ruc = p.idEmpresa;
            //if (datosGen.logo != null)
            if (p.DatosGen.logo != null)
            {
                if (p.DatosGen.logo.Length > 0)
                {

                }

            }

            Empresa.RazonSocial = p.DatosGen.razonSocial;
            Empresa.Domicilio = p.DatosGen.direccionEmpresa1;
            Empresa.Domicilio02 = p.DatosGen.direccionEmpresa2;
            Empresa.Telefeno = telefon;
            Empresa.Publicidad = p.DatosGen.publicidad2;
            Empresa.NombreComercial = p.DatosGen.publicidad1;
            Empresa.DescripcionFoot03 = p.DatosGen.publicidad3;
            //Empresa.Publicidad = datosGen.publicidad;
            //Empresa.NombreComercial = datosGen.nombreCorto;
            //Empresa.DescripcionFoot03 = datosGen.glosario;
            ListEmpresa.Add(Empresa);


            var listInvoice = new List<DocumentoFactura>();
            var listInvoiceDet = new List<DocumentoFacturaDetalle>();
            var InvoiceDet = new DocumentoFacturaDetalle();
            var INdescuento = new DocumentoFacturaDetalleDescuentos();
            var descuentoList = new List<DocumentoFacturaDetalleDescuentos>();
            var objCuenta = new DocumentoFactura();

            var listInvoiceDetDesc = new List<DocumentoFacturaDetalleDescuentos>();
            var InvoiceDetDesc = new DocumentoFacturaDetalleDescuentos();

            var DocumentD = "";
            switch (p.tipoDocumentoCliente)
            {
                case "1":
                    DocumentD = "";
                    break;
                case "6":
                    DocumentD = "";
                    break;
                default:
                    DocumentD = "";
                    break;
            }
            objCuenta.RucCliente = "";
            if (p.tipoDocumentoCliente != "0")
            {
                objCuenta.RucCliente = DocumentD + p.numeroDocumentoCliente;
            }
            objCuenta.Cliente = p.nombreCliente;
            objCuenta.Direccion = direcc;
            //objCuenta.SerieFact = p.serieVenta + " - " + p.GetNumberWithZeros;
            objCuenta.SerieFact = p.serieVenta + " - " + String.Format("{0:00000000}", p.numero);
            //objCuenta.FechaEmision = p.fechaDoc.GetValueOrDefault().ToString("dd-MM-yyyy HH:mm");
            objCuenta.FechaEmision = p.fechaDoc.ToString("dd-MM-yyyy HH:mm");
            objCuenta.Obsevaciones = p.glosa;
            objCuenta.TipoMoneda = Moden;
            objCuenta.CondicionPago = p.terminos;

            if (p.PorConsumo == false)
            {
                //foreach (var det in p.documentoventaAbarrotesDet)

                foreach (var det in p.DetalleVenta)
                {
                    InvoiceDet = new DocumentoFacturaDetalle();
                    InvoiceDet.DocumentoFacturaDetalleDescuentos = new List<DocumentoFacturaDetalleDescuentos>();
                    if (det.detalleAdicional == "")
                    {
                        if (p.PrintNegocio.formatoImpresion == "TGA4")
                        {
                            InvoiceDet.Descripcion = det.nombreItem.ToUpper();
                        }
                        else
                        {
                            InvoiceDet.Descripcion = det.nombreItem;
                        }

                    }
                    else
                    {
                        if (p.PrintNegocio.formatoImpresion == "TGA4")
                        {
                            InvoiceDet.Descripcion = det.nombreItem.ToUpper() + " " + (det.detalleAdicional.ToUpper());
                        }
                        else
                        {
                            InvoiceDet.Descripcion = det.nombreItem + " " + (det.detalleAdicional);
                        }

                    }




                    InvoiceDet.Unidad = det.umDescripcion;


                    InvoiceDet.Cantidad = det.cantidadDet.ToString("N2");
                    InvoiceDet.PrecioUnitario = det.precioUnitario.ToString("N2");
                    InvoiceDet.Importe = det.importeMN.ToString("N2");
                    InvoiceDet.Codigo = det.CodigoBI;
                    if (det.CodigoBI != null)
                    {
                        objCuenta.ISC = "SI";//SI TIENE CODIGO INTERNO
                    }
                    //InvoiceDetDesc = new DocumentoFacturaDetalleDescuentos();
                    //InvoiceDetDesc.ImporteDescuentos = det.descuentos.importeDescuento.ToString() + " -";
                    //InvoiceDet.DocumentoFacturaDetalleDescuentos.Add(InvoiceDetDesc);

                    if (det.descuentos != null)
                    {
                        //if (datosGen.NombreFormato == "TK")
                        if (p.DatosGen.tipoImpresion == "TK")
                        {
                            //var NewImpor = det.precioUnitario + det.descuentos.importeDescuento;
                            //InvoiceDet.PrecioUnitario = NewImpor.ToString("N2");

                            var NewPrecio = (det.importeMN + det.descuentos.importeDescuento) / det.cantidadDet;
                            InvoiceDet.PrecioUnitario = NewPrecio.ToString("N2");
                            var NewImpor = NewPrecio * det.cantidadDet;
                            InvoiceDet.Importe = NewImpor.ToString("N2");

                            InvoiceDetDesc = new DocumentoFacturaDetalleDescuentos();
                            if (det.descuentos.importeDescuento == 0)
                            {

                            }
                            else
                            {
                                InvoiceDetDesc.ImporteDescuentos = det.descuentos.importeDescuento.ToString() + " -";
                                InvoiceDet.DocumentoFacturaDetalleDescuentos.Add(InvoiceDetDesc);
                            }

                        }
                        else
                        {
                            var NewPrecio = (det.importeMN + det.descuentos.importeDescuento) / det.cantidadDet;
                            InvoiceDet.PrecioUnitario = NewPrecio.ToString("N2");
                            var NewImpor = NewPrecio * det.cantidadDet;
                            InvoiceDet.Importe = NewImpor.ToString("N2");
                            if (det.descuentos.importeDescuento == 0)
                            {
                                InvoiceDet.DescuentoImporte = det.descuentos.importeDescuento.ToString("N2");

                            }
                            else
                            {
                                InvoiceDet.DescuentoImporte = det.descuentos.importeDescuento.ToString("N2") + " -";
                            }


                        }

                    }

                    switch (det.destino)
                    {
                        case "1":
                            gravMN += double.Parse(det.montokardex.ToString("N2"));
                            gravME += double.Parse(det.montokardex.ToString("N2"));
                            break;

                        case "2":

                            ExoMN += double.Parse(det.montokardex.ToString("N2"));
                            ExoME += double.Parse(det.montokardex.ToString("N2"));
                            break;

                        case "3":
                            InaMN += double.Parse(det.montokardex.ToString("N2"));
                            InaME += double.Parse(det.montokardex.ToString("N2"));
                            break;
                    }


                    listInvoiceDet.Add(InvoiceDet);
                }
            }
            else
            {
                InvoiceDet.DocumentoFacturaDetalleDescuentos = new List<DocumentoFacturaDetalleDescuentos>();
                InvoiceDet.Descripcion = "POR CONSUMO";

                InvoiceDet.Unidad = "UNIDAD";
                InvoiceDet.Cantidad = "1";
                InvoiceDet.PrecioUnitario = p.importeTotal.ToString("N2");
                InvoiceDet.Importe = p.importeTotal.ToString("N2");
                gravMN = Convert.ToDouble(p.bi01);
                ExoMN = Convert.ToDouble(p.bi02);
                if (p.totaldescuento > 0)
                {
                    var NewImporPC = p.importeTotal + p.totaldescuento;
                    InvoiceDet.PrecioUnitario = NewImporPC.ToString("N2");

                    InvoiceDetDesc.ImporteDescuentos = p.totaldescuento.ToString() + " -";
                    InvoiceDet.DocumentoFacturaDetalleDescuentos.Add(InvoiceDetDesc);
                }


                listInvoiceDet.Add(InvoiceDet);
            }
            //Medios de pago
            if (p.Pagos != null)
            {
                foreach (var deF in p.Pagos)
                {
                    cajadeDoc = new spkDocumentoCajaDetalle();
                    cajadeDoc.DescripcionFiancieraDC = deF.medioDePago + "  " + deF.nombreEntidad;
                    cajadeDoc.MontoSolesDC = String.Format("{0:0.00}", deF.importePago);
                    ListcajadeDoc.Add(cajadeDoc);
                }
            }




            //CRONOGRAMA
            //var cont = 0;
            var cronograma = new CronogramaPagos();
            var Listcronograma = new List<CronogramaPagos>();
            if (p.CronogramaPagos != null)
            {
                foreach (var cro in p.CronogramaPagos)
                {
                    cronograma = new CronogramaPagos();
                    //cont += 1;
                    //cronograma.NroItemCronogramas = cont.ToString();
                    cronograma.NroItemCronogramas = cro.nrocuota.ToString();
                    cronograma.ImporteCronograma = cro.montoAutorizadoMN.ToString();
                    cronograma.FechaVencimientoCronograma = cro.fechaPago.ToString("dd-MM-yyy");
                    objCuenta.FechaVencimiento = cro.fechaPago.ToString();
                    Listcronograma.Add(cronograma);
                }
            }

            var CuentaSoleslist = new List<CuentaSoles>();
            var CuentaSolesObj = new CuentaSoles();
            var CuentaDolareslist = new List<CuentaDolares>();
            var CuentaDolaresObj = new CuentaDolares();

            //if (ImpreNego.PrintOutput == "TK" || ImpreNego.PrintOutput == "A5")
            if (p.PrintNegocio.printOutput == "TK" || p.PrintNegocio.printOutput == "A5")
            {
                //CUENTAS EN SOLES Y DOLARES

                var CuentaDolares = new CuentaDolares();

                var CuentaSoles = new CuentaSoles();

                CuentaSoles.DescripcionCuentaSoles = cuentaSoles;
                CuentaSoleslist.Add(CuentaSoles);


                CuentaDolares = new CuentaDolares();

                CuentaDolares.DescripcionCuentaDolares = cuentaDolares;
                CuentaDolareslist.Add(CuentaDolares);


            }
            else
            {
                //CUENTAS EN SOLES Y DOLARES
                if (p.DatosGen.nroCuentaEmpresaSoles2 != null && p.DatosGen.nroCuentaEmpresaSoles2.Length > 0)
                {
                    CuentaSolesObj.DescripcionCuentaSoles = p.DatosGen.nroCuentaEmpresaSoles;
                    CuentaSolesObj.DescripcionCCICuentaSoles = p.DatosGen.nroCuentaEmpresaSoles2;

                    CuentaSoleslist.Add(CuentaSolesObj);
                }
                else if (p.DatosGen.nroCuentaEmpresaSoles != null && p.DatosGen.nroCuentaEmpresaSoles.Length > 0)
                {
                    CuentaSolesObj.DescripcionCuentaSoles = p.DatosGen.nroCuentaEmpresaSoles;

                    CuentaSoleslist.Add(CuentaSolesObj);
                }
                //if (datosGen.nroCuentaSoles2 != null && datosGen.nroCuentaSoles2.Length > 0)
                //{
                //    CuentaSolesObj.DescripcionCuentaSoles = datosGen.nroCuentaSoles;
                //    CuentaSolesObj.DescripcionCCICuentaSoles = datosGen.nroCuentaSoles2;

                //    CuentaSoleslist.Add(CuentaSolesObj);
                //}
                //else if (datosGen.nroCuentaSoles != null && datosGen.nroCuentaSoles.Length > 0)
                //{
                //    CuentaSolesObj.DescripcionCuentaSoles = datosGen.nroCuentaSoles;

                //    CuentaSoleslist.Add(CuentaSolesObj);
                //}



                if (p.DatosGen.nroCuentaEmpresaDolares2 != null && p.DatosGen.nroCuentaEmpresaSoles2.Length > 0)
                {
                    CuentaDolaresObj.DescripcionCuentaDolares = p.DatosGen.nroCuentaEmpresaDolares;
                    CuentaDolaresObj.DescripcionCCICuentaDolares = p.DatosGen.nroCuentaEmpresaDolares2;

                    CuentaDolareslist.Add(CuentaDolaresObj);
                }
                else if (p.DatosGen.nroCuentaEmpresaDolares != null && p.DatosGen.nroCuentaEmpresaDolares.Length > 0)
                {
                    CuentaDolaresObj.DescripcionCuentaDolares = p.DatosGen.nroCuentaEmpresaDolares;

                    CuentaDolareslist.Add(CuentaDolaresObj);
                }


                //if (datosGen.nroCuentaDolares2 != null && datosGen.nroCuentaDolares2.Length > 0)
                //{
                //    CuentaDolaresObj.DescripcionCuentaDolares = datosGen.nroCuentaDolares;
                //    CuentaDolaresObj.DescripcionCCICuentaDolares = datosGen.nroCuentaDolares2;

                //    CuentaDolareslist.Add(CuentaDolaresObj);
                //}
                //else if (datosGen.nroCuentaDolares != null && datosGen.nroCuentaDolares.Length > 0)
                //{
                //    CuentaDolaresObj.DescripcionCuentaDolares = datosGen.nroCuentaDolares;

                //    CuentaDolareslist.Add(CuentaDolaresObj);
                //}


            }



            objCuenta.OpExonerada = String.Format("{0:0.00}", ExoMN);
            objCuenta.OpExonerada = String.Format("{0:0.00}", ExoMN);
            objCuenta.OpInafecto = String.Format("{0:0.00}", InaMN);
            objCuenta.OpGravada = String.Format("{0:0.00}", gravMN);
            objCuenta.OpGratuitas = String.Format("{0:0.00}", OperaGrat);
            objCuenta.IGV = String.Format("{0:0.00}", p.igv01);

            //objCuenta.IGV = String.Format("{0:0.00}", p.igv01.GetValueOrDefault());
            //objCuenta.ICBPER = String.Format("{0:0.00}", p.icbper.GetValueOrDefault());
            //objCuenta.ImporteTotal = String.Format("{0:0.00}", p.ImporteNacional);
            objCuenta.Efectivo = String.Format("{0:0.00}", address.Efectivo);
            objCuenta.Vuelto = String.Format("{0:0.00}", address.Vuelto);

            if (p.ImporteDescGlobal > 0)
            {
                var ImportDescToal = p.importeTotal - p.ImporteDescGlobal;
                objCuenta.TotalDescuento = String.Format("{0:0.00}", p.ImporteDescGlobal) + " -";
                objCuenta.ImporteTotal = String.Format("{0:0.00}", ImportDescToal);

            }
            else
            {
                objCuenta.TotalDescuento = String.Format("{0:0.00}", p.totaldescuento) + " -";
                objCuenta.ImporteTotal = String.Format("{0:0.00}", p.importeTotal);
            }


            objCuenta.Vendedor = p.nombreUsuario.ToUpper();
            if (p.nombreUsuarioPedidos != null && p.nombreUsuarioPedidos != "0")
            {
                //if (UsuOrder.Full_Name.Trim().Length > 0)
                //{
                objCuenta.Vendedor = p.nombreUsuarioPedidos.ToUpper();
                objCuenta.Cajero = p.nombreUsuario.ToUpper();
                //}
            }

            if (address.TipoNegocio == "RESTAURANTE")
            {
              

                var listaPro = (from dvd in listInvoiceDet
                                group dvd by new
                                {
                                    dvd.Descripcion,
                                    dvd.Unidad,
                                    dvd.Cantidad,
                                    dvd.PrecioUnitario,
                                    dvd.Importe
                                } into g
                                select new
                                {
                                    cantidad = g.Count(t => t.Cantidad != null),
                                    g.Key.Descripcion,
                                    g.Key.Unidad,
                                    g.Key.Cantidad,
                                    g.Key.PrecioUnitario,
                                    g.Key.Importe
                                }).ToList();

                listInvoiceDet = new List<DocumentoFacturaDetalle>();
                foreach (var item in listaPro)
                {
                    var ObjDoc = new DocumentoFacturaDetalle();
                    ObjDoc.Descripcion = item.Descripcion;
                    ObjDoc.Unidad = item.Unidad;
                    ObjDoc.Cantidad = item.cantidad.ToString();
                    ObjDoc.PrecioUnitario = item.PrecioUnitario;

                    var prodImpor = item.cantidad * decimal.Parse(item.PrecioUnitario);
                    ObjDoc.Importe = prodImpor.ToString();

                    listInvoiceDet.Add(ObjDoc);
                }

            }



            //objCuenta.DocumentoFacturaDetalleDescuentos = listInvoiceDetDesc;
            objCuenta.DocumentoCajaDetalle = ListcajadeDoc;
            objCuenta.CuentaDolares = CuentaDolareslist;
            objCuenta.CuentaSoles = CuentaSoleslist;
            objCuenta.CronogramaPagos = Listcronograma;
            objCuenta.NotaCredito = Listnotacredito;
            objCuenta.DocumentoFacturaDetalle = listInvoiceDet;
            objCuenta.DatosEmpresa = ListEmpresa;

            listInvoice.Add(objCuenta);

            return listInvoice;
        
        }
        else
        {
                MessageBox.Show("No existe imppresora configurada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return null;
        }
      
 
    }

    //private string GetIdentidadCliente(entidad lenDocCustomer)
    //{
    //   var  GetIdentidadClien = "";
    //    switch (lenDocCustomer.nrodoc.Length)// _sale.customCustomer.numberDocument.Length
    //    {
    //        case 8:
    //            {
    //                GetIdentidadClien = $"D.N.I.                          {lenDocCustomer.nrodoc}";
    //                break;
    //            }
    //        case 11:
    //            {
    //                GetIdentidadClien = $"R.U.C.                          {lenDocCustomer.nrodoc}";
    //                break;
    //            }

    //    }
    //    return GetIdentidadClien;
    //}

           //private void ValidarTrueFalse(datosGenerales Vobj, rePrintResponse docV, FastReport.Report webReportValidar, PrintQueue address, List<DocumentoFactura> Docfact, ImpresorasNegocio ImpreNego, configuracionInicio returnoConf, string pathD)
             private void ValidarTrueFalse(rePrintResponse docV, FastReport.Report webReportValidar, PrintQueue address, List<DocumentoFactura> Docfact, string pathD)
    {
        var dt = Docfact.FirstOrDefault().DatosEmpresa.FirstOrDefault();
        if (File.Exists(pathD))
        {
            if (docV.DatosGen.logo.Length > 0)
            {

                if (docV.PrintNegocio.printOutput == "TK")
                {
                    ReportTitleBand dtRazonsocial = webReportValidar.Report.FindObject("HeaderInforme") as ReportTitleBand;
                    dtRazonsocial.Visible = true;
                }



            }
            else
            {

                if (docV.PrintNegocio.printOutput == "A4" || docV.PrintNegocio.printOutput == "A5")
                {
                    ShapeObject ShRazonSocial = webReportValidar.Report.FindObject("ShRazonSocial") as ShapeObject;
                    ShRazonSocial.Visible = true;

                    TextObject txtRazonSocialTitulo = webReportValidar.Report.FindObject("txtRazonSocialTitulo") as TextObject;
                    txtRazonSocialTitulo.Visible = true;

                    ChildBand dtRazonsocial = webReportValidar.Report.FindObject("dtRazonsocial") as ChildBand;
                    dtRazonsocial.Visible = false;
                }


            }
        }

        switch (docV.tipoDocumento)
        {
            case "07":
            case "03":
            case "01":
                DataBand Monto = webReportValidar.Report.FindObject("Monto") as DataBand;
                Monto.Visible = true;

                switch (docV.PrintNegocio.printOutput)
                {
                    case "TK":                  
                        LineObject Line16 = webReportValidar.Report.FindObject("Line16") as LineObject;
                        Line16.Visible = false;

                        DataBand dbDescPrint = webReportValidar.Report.FindObject("dbDescPrint") as DataBand;
                        dbDescPrint.Visible = true;

                        break;
                    case "A5":
                    case "A4":
                        if (docV.glosa.Trim().Length > 0 && docV.glosa.Trim() != "N/A" && docV.glosa.Trim() != "Observaciones:")
                        {

                            TextObject obdet = webReportValidar.Report.FindObject("txtObservacionesDesc") as TextObject;
                            obdet.Visible = true;

                        }
                        if (docV.tipoDocumento == "07")
                        {
                            ChildBand CNC = webReportValidar.Report.FindObject("CNC") as ChildBand;
                            CNC.Visible = true;

                            //if (!String.IsNullOrWhiteSpace(Vobj.publicidad))
                            if (!String.IsNullOrWhiteSpace(docV.DatosGen.publicidad2))

                            {
                                ChildBand dtPublicidad = webReportValidar.Report.FindObject("dtPublicidad") as ChildBand;
                                dtPublicidad.Visible = true;

                            }
                        }
                        break;
                }
           
                break;
            default:

                switch (docV.PrintNegocio.printOutput)
                {
                    case "TK":

                        if (!string.IsNullOrWhiteSpace(docV.DatosGen.DescripcionExchangeReturns))
                        {
                      

                            DataBand ExchangesRet = webReportValidar.Report.FindObject("ExchangeReturns") as DataBand;
                            ExchangesRet.Visible = true;
                        }
                     

                        DataBand codQr = webReportValidar.Report.FindObject("codQr") as DataBand;
                        codQr.Visible = false;
                       
                      

                        DataBand FootMensaje02 = webReportValidar.Report.FindObject("FootMensaje02") as DataBand;
                        FootMensaje02.Visible = true;
                        DataBand RUC = webReportValidar.Report.FindObject("RUC") as DataBand;
                        RUC.Visible = false;
                        DataBand FootMensaje01 = webReportValidar.Report.FindObject("FootMensaje01") as DataBand;
                        FootMensaje01.Visible = true;
                        break;
                    case "A5":
                    case "A4":
                        if (!string.IsNullOrWhiteSpace(docV.DatosGen.DescripcionExchangeReturns))
                        {

                            TextObject Text161 = webReportValidar.Report.FindObject("Text161") as TextObject;
                            Text161.Visible = true;

                            TextObject Text160 = webReportValidar.Report.FindObject("Text160") as TextObject;
                            Text160.Visible = true;

                        }

                        //if (returnoConf.SaleNotaAddress == true)
                        if (docV.ConfInicio.FirstOrDefault().saleNotaAddress == true)
                        {

                                ChildBand dtdireccionEmpresa02 = webReportValidar.Report.FindObject("dtdireccionEmpresa02") as ChildBand;
                                dtdireccionEmpresa02.Visible = false;
                            }
                            
                        DataBand MontoTota = webReportValidar.Report.FindObject("MontoTota") as DataBand;
                        MontoTota.Visible = true;
                        TextObject txtFootMensaje02 = webReportValidar.Report.FindObject("txtFootMensaje02") as TextObject;
                        txtFootMensaje02.Visible = true;

                        if (docV.glosa.Trim().Length > 0 && docV.glosa.Trim() != "N/A" && docV.glosa.Trim() != "Observaciones:")
                        {
  
                            TextObject obdet = webReportValidar.Report.FindObject("txtObservacionesDesc") as TextObject;
                            obdet.Visible = true;
      
                        }
                        break;
                }

                break;
        }

        switch (docV.PrintNegocio.printOutput)
        {
            case "TK":
                if (!String.IsNullOrWhiteSpace(dt.Domicilio))
                {
                    DataBand dtDirecc = webReportValidar.Report.FindObject("dtDirecc") as DataBand;
                    dtDirecc.Visible = true;


                }
                if (docV.ConfInicio.FirstOrDefault().saleNotaAddress == true)//PARA QUE NO SE MUESTRE LA DIRECCION 
                {

                    DataBand dtDirecc = webReportValidar.Report.FindObject("dtDirecc") as DataBand;
                    dtDirecc.Visible = false;
                }
                if (docV.AfectoDetracion)
                {
                    DataBand detraccion = webReportValidar.Report.FindObject("Detraccion") as DataBand;
                    detraccion.Visible = true;
                }
                if (Docfact.FirstOrDefault().ISC == "SI")
                {
                    DataBand DHInformeCodigos = webReportValidar.Report.FindObject("DHInformeCodigos") as DataBand;
                    DHInformeCodigos.Visible = true;
                    DataBand DocFacDetCodigo = webReportValidar.Report.FindObject("DocFacDetCodigo") as DataBand;
                    DocFacDetCodigo.Visible = true;

                    DataHeaderBand DHInforme = webReportValidar.Report.FindObject("DHInforme") as DataHeaderBand;
                    DHInforme.Visible = false;
                    DataBand DocFacDet = webReportValidar.Report.FindObject("DocFacDet") as DataBand;
                    DocFacDet.Visible = false;
                }

                //if (returnoConf.InicioVenta != null)
                if (docV.ConfInicio.FirstOrDefault().inicioVenta != null)
                {
                    DataBand DVendedor = webReportValidar.Report.FindObject("DVendedor") as DataBand;
                    DVendedor.Visible = false;
                }
                    

                if (docV.totaldescuento>0)
                {
                    DataBand ImporDescuento = webReportValidar.Report.FindObject("ImporDescuento") as DataBand;
                    ImporDescuento.Visible = true;
                    DataBand Totaldescuento = webReportValidar.Report.FindObject("Totaldescuento") as DataBand;
                    Totaldescuento.Visible = true;

                    LineObject Line16 = webReportValidar.Report.FindObject("Line16") as LineObject;
                    Line16.Visible = false;
                }
                if (docV.ImporteDescGlobal > 0)
                {
                    DataBand Totaldescuento = webReportValidar.Report.FindObject("Totaldescuento") as DataBand;
                    Totaldescuento.Visible = true;

                    LineObject Line16 = webReportValidar.Report.FindObject("Line16") as LineObject;
                    Line16.Visible = false;

                    TextObject Text47 = webReportValidar.Report.FindObject("Text47") as TextObject;
                    Text47.Text = "DESCUENTO";
                }
                if (address.TipoNegocio != null)
                {
                   if (address.TipoNegocio == "RESTAURANTE")
                                {
                                    DataBand DHInformeRestaurant = webReportValidar.Report.FindObject("DHInformeRestaurant") as DataBand;
                                    DHInformeRestaurant.Visible = true;
                                    DataBand DocFacDetRestaurant = webReportValidar.Report.FindObject("DocFacDetRestaurant") as DataBand;
                                    DocFacDetRestaurant.Visible = true;
                                    DataHeaderBand DHInforme = webReportValidar.Report.FindObject("DHInforme") as DataHeaderBand;
                                    DHInforme.Visible = false;
                                    DataBand DocFacDet = webReportValidar.Report.FindObject("DocFacDet") as DataBand;
                                    DocFacDet.Visible = false;

                        if (!String.IsNullOrWhiteSpace(docV.nombreDistribucion))
                        {
                            DataBand dtNromesa = webReportValidar.Report.FindObject("dtNromesa") as DataBand;
                            dtNromesa.Visible = true;
                        }
                    }
                }
                 
                

                    if (docV.tipoDocumento == "ORV")
                {
                    DataBand MontoPedido = webReportValidar.Report.FindObject("MontoPedido") as DataBand;
                    MontoPedido.Visible = true;

                    DataBand MontoTotal = webReportValidar.Report.FindObject("MontoTotal") as DataBand;
                    MontoTotal.Visible = false;
                    DataBand codQr = webReportValidar.Report.FindObject("codQr") as DataBand;
                    codQr.Visible = false;
                    DataBand Monto = webReportValidar.Report.FindObject("Monto") as DataBand;
                    Monto.Visible = false;
                    DataBand FootMensaje01 = webReportValidar.Report.FindObject("FootMensaje01") as DataBand;
                    FootMensaje01.Visible = false;
                    DataBand FootMensaje02 = webReportValidar.Report.FindObject("FootMensaje02") as DataBand;
                    FootMensaje02.Visible = false;
                    DataBand dtFood03 = webReportValidar.Report.FindObject("dtFood03") as DataBand;
                    dtFood03.Visible = false;
                    DataBand dtnombregiro = webReportValidar.Report.FindObject("dtnombregiro") as DataBand;
                    dtnombregiro.Visible = false;
                    DataBand dtCondpago = webReportValidar.Report.FindObject("dtCondpago") as DataBand;
                    dtCondpago.Visible = false;

                }
                if (docV.Pagos != null)
                {
                    if (docV.Pagos.Count > 0)
                    {
                        DataHeaderBand dtHeadMediospagos = webReportValidar.Report.FindObject("dtHeadMediospagos") as DataHeaderBand;
                        dtHeadMediospagos.Visible = true;
                        DataBand dtMediospagos = webReportValidar.Report.FindObject("dtMediospagos") as DataBand;
                        dtMediospagos.Visible = true;
                    }
                }
               

                //if (docV.CustomDocuCaja.Count > 0)
                //{
                //    DataHeaderBand dtHeadMediospagos = webReportValidar.Report.FindObject("dtHeadMediospagos") as DataHeaderBand;
                //    dtHeadMediospagos.Visible = true;
                //    DataBand dtMediospagos = webReportValidar.Report.FindObject("dtMediospagos") as DataBand;
                //    dtMediospagos.Visible = true;
                //}
                if (docV.nombreUsuarioPedidos != null && docV.nombreUsuarioPedidos != "0")
                {
                    //if (returnoConf.InicioVenta == null)
                    if (docV.ConfInicio.FirstOrDefault().inicioVenta == null)
                    {
                        DataBand Dcajero = webReportValidar.Report.FindObject("Dcajero") as DataBand;
                        Dcajero.Visible = true;
                    }
                       
                }
                //if (UsuOrder.Full_Name.Trim().Length > 0)
                //{
                //    DataBand Dcajero = webReportValidar.Report.FindObject("Dcajero") as DataBand;
                //    Dcajero.Visible = true;
                //}

                if (!String.IsNullOrWhiteSpace(address.Direccion) && address.Direccion != "N/A")
                {
                    DataBand dtRazonsocial = webReportValidar.Report.FindObject("DHDireccionClienteDeta") as DataBand;
                    dtRazonsocial.Visible = true;
                    DataHeaderBand DHDireccionCliente = webReportValidar.Report.FindObject("DHDireccionCliente") as DataHeaderBand;
                    DHDireccionCliente.Visible = true;

                }
               



                if (!String.IsNullOrWhiteSpace(dt.RazonSocial))
                    {
                        DataBand dtrazonSocial = webReportValidar.Report.FindObject("dtrazonSocial") as DataBand;
                        dtrazonSocial.Visible = true;

                    }
                    if (!String.IsNullOrWhiteSpace(dt.NombreComercial))
                    {
                        DataBand dtNombreComercial = webReportValidar.Report.FindObject("dtNombreComercial") as DataBand;
                        dtNombreComercial.Visible = true;

                }

                if (!String.IsNullOrWhiteSpace(dt.Domicilio02))
                    {
                        DataBand dtDirecc2 = webReportValidar.Report.FindObject("dtDirecc2") as DataBand;
                         dtDirecc2.Visible = true;

                    }
                    if (!String.IsNullOrWhiteSpace(dt.Telefeno))
                    {
                        DataBand dtTelefono = webReportValidar.Report.FindObject("dtTelefono") as DataBand;
                        dtTelefono.Visible = true;

                    }




                if (docV.tipoDocumento != "ORV")
                {
                    if (Docfact.FirstOrDefault().CronogramaPagos.Count > 0)
                    {
                        DataHeaderBand DhCronogPagos = webReportValidar.Report.FindObject("DhCronogPagos") as DataHeaderBand;
                        DhCronogPagos.Visible = true;
                        DataBand DetCronogrPagos = webReportValidar.Report.FindObject("DetCronogrPagos") as DataBand;
                        DetCronogrPagos.Visible = true;
                    }
                }
                    
                    if (!String.IsNullOrWhiteSpace(docV.glosa) && docV.glosa != "N/A")
                    {
                        DataBand dObservaciones = webReportValidar.Report.FindObject("dObservaciones") as DataBand;
                        dObservaciones.Visible = true;

                    }


                //if (!String.IsNullOrWhiteSpace(Vobj.glosario))
                if (!String.IsNullOrWhiteSpace(docV.DatosGen.publicidad3))
                {
                        DataBand dtFood03 = webReportValidar.Report.FindObject("dtFood03") as DataBand;
                        dtFood03.Visible = true;

                    }
                //if (!String.IsNullOrWhiteSpace(Vobj.nombreGiro))
                if (!String.IsNullOrWhiteSpace(docV.DatosGen.publicidad4))
                {
                        DataBand dtnombregiro = webReportValidar.Report.FindObject("dtnombregiro") as DataBand;
                        dtnombregiro.Visible = true;

                    }
                //if (!String.IsNullOrWhiteSpace(Vobj.publicidad))
                if (!String.IsNullOrWhiteSpace(docV.DatosGen.publicidad2))
                {
                        DataBand dtPublicidad = webReportValidar.Report.FindObject("dtPublicidad") as DataBand;
                    dtPublicidad.Visible = true;

                    }
                //if (docV.CustomEntidad.tipoEntidad == "VR")
                if (docV.tipoEntidad == "VR")
                {
                        DataBand DtRucClie = webReportValidar.Report.FindObject("DtRucClie") as DataBand;
                        DtRucClie.Visible = false;

                    }
                    if (Docfact.FirstOrDefault().NotaCredito.Count > 0)
                    {
                        DataHeaderBand DHTituloNC = webReportValidar.Report.FindObject("DHTituloNC") as DataHeaderBand;
                        DHTituloNC.Visible = true;
                        DataBand dtNotaCreditoTipo = webReportValidar.Report.FindObject("dtNotaCreditoTipo") as DataBand;
                        dtNotaCreditoTipo.Visible = true;

                        DataHeaderBand DhTitulAfecNC = webReportValidar.Report.FindObject("DhTitulAfecNC") as DataHeaderBand;
                        DhTitulAfecNC.Visible = true;
                        DataBand dtNotaCreditoDesc = webReportValidar.Report.FindObject("dtNotaCreditoDesc") as DataBand;
                        dtNotaCreditoDesc.Visible = true;

                        DataHeaderBand DhTitulMotivoNC = webReportValidar.Report.FindObject("DhTitulMotivoNC") as DataHeaderBand;
                        DhTitulMotivoNC.Visible = true;
                        DataBand dtNotaCreditoMot = webReportValidar.Report.FindObject("dtNotaCreditoMot") as DataBand;
                        dtNotaCreditoMot.Visible = true;

                    }

                break;
            case "A5":
            case "A4":
                //if (!String.IsNullOrWhiteSpace(Vobj.glosario))
                if (!String.IsNullOrWhiteSpace(docV.DatosGen.publicidad3))
                {
                    DataBand DescFood = webReportValidar.Report.FindObject("DescFood") as DataBand;
                    DescFood.Visible = true;
                }
                if (docV.AfectoDetracion)
                {
                    ChildBand Detraccion = webReportValidar.Report.FindObject("Detraccion") as ChildBand;
                    Detraccion.Visible = true;
                }
                if (docV.tipoDocumento == "ORV")
                {
                    DataBand MontoPedido = webReportValidar.Report.FindObject("MontoPedido") as DataBand;
                    MontoPedido.Visible = true;

                    DataBand Monto = webReportValidar.Report.FindObject("Monto") as DataBand;
                    Monto.Visible = false;
                    DataBand MontoTota = webReportValidar.Report.FindObject("MontoTota") as DataBand;
                    MontoTota.Visible = false;
                    ChildBand dtRazonsocial = webReportValidar.Report.FindObject("dtRazonsocial") as ChildBand;
                    dtRazonsocial.Visible = false;
                    DataHeaderBand DhCronogPagos = webReportValidar.Report.FindObject("DhCronogPagos") as DataHeaderBand;
                    DhCronogPagos.Visible = false;
                    DataBand DetCronogrPagos = webReportValidar.Report.FindObject("DetCronogrPagos") as DataBand;
                    DetCronogrPagos.Visible = false;
                    PictureObject CodQRDes = webReportValidar.Report.FindObject("CodQRDes") as PictureObject;
                    CodQRDes.Visible = false;
                }
                if (!String.IsNullOrWhiteSpace(dt.NombreComercial))
                {
                    ChildBand dtNombreComercial = webReportValidar.Report.FindObject("dtNombreComercial") as ChildBand;
                    dtNombreComercial.Visible = true;
                }
                if (!String.IsNullOrWhiteSpace(dt.Domicilio02))
                {
                    ChildBand dtAnexoEmpresa02 = webReportValidar.Report.FindObject("dtAnexoEmpresa02") as ChildBand;
                    dtAnexoEmpresa02.Visible = true;
                }

                if (!String.IsNullOrWhiteSpace(dt.Telefeno))
                {
                    ChildBand dttelefonEmpresa02 = webReportValidar.Report.FindObject("dttelefonEmpresa02") as ChildBand;
                    dttelefonEmpresa02.Visible = true;

                }
                //if (!String.IsNullOrWhiteSpace(Vobj.publicidad))
                if (!String.IsNullOrWhiteSpace(docV.DatosGen.publicidad2))

                {
                    ChildBand dtPublicidad = webReportValidar.Report.FindObject("dtPublicidad") as ChildBand;
                    dtPublicidad.Visible = true;

                }
                //if (!String.IsNullOrWhiteSpace(Vobj.formaLogo))
                if (!String.IsNullOrWhiteSpace(docV.DatosGen.logoFooter))
                {
                    ColumnFooterBand ShRazonSocial = webReportValidar.Report.FindObject("FootLogo") as ColumnFooterBand;
                    ShRazonSocial.Visible = true;
                }

                break;
        }

        //switch (ImpreNego.PrintOutput)
        switch (docV.PrintNegocio.printOutput)
        {
            case "A5":
            case "TK":
                if (docV.tipoDocumento != "ORV")
                {
                    if(docV.PrintNegocio.formatoImpresion != "VEA5")
                    {
                        //if (!String.IsNullOrWhiteSpace(Vobj.nroCuentaSoles) || !String.IsNullOrWhiteSpace(Vobj.nroCuentaSoles2))
                        if (!String.IsNullOrWhiteSpace(docV.DatosGen.nroCuentaEmpresaSoles) || !String.IsNullOrWhiteSpace(docV.DatosGen.nroCuentaEmpresaSoles2))
                        {
                            DataHeaderBand DhSoles = webReportValidar.Report.FindObject("DhSoles") as DataHeaderBand;
                            DhSoles.Visible = true;
                            DataBand DetalleCSoles = webReportValidar.Report.FindObject("DetalleCSoles") as DataBand;
                            DetalleCSoles.Visible = true;

                        }
                        //if (!String.IsNullOrWhiteSpace(Vobj.nroCuentaDolares) || !String.IsNullOrWhiteSpace(Vobj.nroCuentaDolares2))
                        if (!String.IsNullOrWhiteSpace(docV.DatosGen.nroCuentaEmpresaDolares) || !String.IsNullOrWhiteSpace(docV.DatosGen.nroCuentaEmpresaDolares2))
                        {
                            DataHeaderBand DhDolares = webReportValidar.Report.FindObject("DhDolares") as DataHeaderBand;
                            DhDolares.Visible = true;
                            DataBand DetalleCDolares = webReportValidar.Report.FindObject("DetalleCDolares") as DataBand;
                            DetalleCDolares.Visible = true;

                        }
                    }

                }
                 
                break;
            case "A4":
                //if (!string.IsNullOrWhiteSpace(Vobj.DescripcionExchangeReturns))
                if (!string.IsNullOrWhiteSpace(docV.DatosGen.DescripcionExchangeReturns))
                {

                    ChildBand ExchangeReturns = webReportValidar.Report.FindObject("ExchangeReturns") as ChildBand;
                    ExchangeReturns.Visible = true;

                }

                //if (ImpreNego.formatoImpresion != "CGA4")
                if (docV.PrintNegocio.formatoImpresion != "CGA4")
                {
                    if (Docfact.FirstOrDefault().ISC == "SI")
                    {
                        ChildBand EncabezadoDetfacturaCod = webReportValidar.Report.FindObject("EncabezadoDetfacturaCod") as ChildBand;
                        EncabezadoDetfacturaCod.Visible = true;
                        DataBand DocFacDetCod = webReportValidar.Report.FindObject("DocFacDetCod") as DataBand;
                        DocFacDetCod.Visible = true;

                        ChildBand EncabezadoDetfactura = webReportValidar.Report.FindObject("EncabezadoDetfactura") as ChildBand;
                        EncabezadoDetfactura.Visible = false;
                        DataBand DocFacDet = webReportValidar.Report.FindObject("DocFacDet") as DataBand;
                        DocFacDet.Visible = false;
                    }
                }


                //if (!String.IsNullOrWhiteSpace(Vobj.nroCuentaSoles) || !String.IsNullOrWhiteSpace(Vobj.nroCuentaSoles2) || !String.IsNullOrWhiteSpace(Vobj.nroCuentaDolares) || !String.IsNullOrWhiteSpace(Vobj.nroCuentaDolares2))

                if (!String.IsNullOrWhiteSpace(docV.DatosGen.nroCuentaEmpresaSoles) || !String.IsNullOrWhiteSpace(docV.DatosGen.nroCuentaEmpresaSoles2) || !String.IsNullOrWhiteSpace(docV.DatosGen.nroCuentaEmpresaDolares) || !String.IsNullOrWhiteSpace(docV.DatosGen.nroCuentaEmpresaDolares2))
                {

                    //if (!String.IsNullOrWhiteSpace(Vobj.nroCuentaSoles) || !String.IsNullOrWhiteSpace(Vobj.nroCuentaSoles2))
                    if (!String.IsNullOrWhiteSpace(docV.DatosGen.nroCuentaEmpresaSoles) || !String.IsNullOrWhiteSpace(docV.DatosGen.nroCuentaEmpresaSoles2))
                    {

                        ShapeObject Shape13 = webReportValidar.Report.FindObject("Shape13") as ShapeObject;
                        Shape13.Visible = true;
                        TextObject txtCuentSoles = webReportValidar.Report.FindObject("txtCuentSoles") as TextObject;
                        txtCuentSoles.Visible = true;
                        TableObject TSoles01 = webReportValidar.Report.FindObject("TSoles01") as TableObject;
                        TSoles01.Visible = true;
                        TableObject TSoles02 = webReportValidar.Report.FindObject("TSoles02") as TableObject;
                        TSoles02.Visible = true;

                        ShapeObject Shape22 = webReportValidar.Report.FindObject("Shape22") as ShapeObject;
                        Shape22.Visible = true;
                        TextObject txtCuentSolesNota = webReportValidar.Report.FindObject("txtCuentSolesNota") as TextObject;
                        txtCuentSolesNota.Visible = true;
                        TableObject TSolesNota01 = webReportValidar.Report.FindObject("TSolesNota01") as TableObject;
                        TSolesNota01.Visible = true;
                        TableObject TSolesNota02 = webReportValidar.Report.FindObject("TSolesNota02") as TableObject;
                        TSolesNota02.Visible = true;

                    }
                    //if (!String.IsNullOrWhiteSpace(Vobj.nroCuentaDolares) || !String.IsNullOrWhiteSpace(Vobj.nroCuentaDolares2))
                    if (!String.IsNullOrWhiteSpace(docV.DatosGen.nroCuentaEmpresaDolares) || !String.IsNullOrWhiteSpace(docV.DatosGen.nroCuentaEmpresaDolares2))
                    {
                        ShapeObject Shape14 = webReportValidar.Report.FindObject("Shape14") as ShapeObject;
                        Shape14.Visible = true;
                        TextObject txtCuentDolares = webReportValidar.Report.FindObject("txtCuentDolares") as TextObject;
                        txtCuentDolares.Visible = true;
                        TableObject TDolares01 = webReportValidar.Report.FindObject("TDolares01") as TableObject;
                        TDolares01.Visible = true;
                        TableObject TDolares02 = webReportValidar.Report.FindObject("TDolares02") as TableObject;
                        TDolares02.Visible = true;

                        ShapeObject Shape21 = webReportValidar.Report.FindObject("Shape21") as ShapeObject;
                        Shape21.Visible = true;
                        TextObject txtCuentDolaresNota = webReportValidar.Report.FindObject("txtCuentDolaresNota") as TextObject;
                        txtCuentDolaresNota.Visible = true;
                        TableObject TDolaresNota01 = webReportValidar.Report.FindObject("TDolaresNota01") as TableObject;
                        TDolaresNota01.Visible = true;
                        TableObject TDolaresNota02 = webReportValidar.Report.FindObject("TDolaresNota02") as TableObject;
                        TDolaresNota02.Visible = true;

                    }

                }
                break;
        }

        //INDIDUAL CADA FORMATO
        //switch (ImpreNego.PrintOutput)

        switch (docV.PrintNegocio.printOutput)
        {
            case "A5":
                if (docV.PrintNegocio.formatoImpresion == "HOA5")
                {
                    if (Docfact.FirstOrDefault().ISC == "SI")
                    {
                        ChildBand EncabezadoDetfacturaCod = webReportValidar.Report.FindObject("EncabezadoDetfacturaCod") as ChildBand;
                        EncabezadoDetfacturaCod.Visible = true;
                        DataBand DocFacDetCod = webReportValidar.Report.FindObject("DocFacDetCod") as DataBand;
                        DocFacDetCod.Visible = true;

                        PageHeaderBand EncabezadoDetfactura = webReportValidar.Report.FindObject("EncabezadoDetfactura") as PageHeaderBand;
                        EncabezadoDetfactura.Visible = false;
                        DataBand DocFacDet = webReportValidar.Report.FindObject("DocFacDet") as DataBand;
                        DocFacDet.Visible = false;
                    }
                }
                break;
            case "TK":

                break;
            case "A4":
               
                break;
        }




}


    public void ImprimirKardex(List<documentoCaja> ListKardex,ImpresorasNegocio PrintNegoc, PrintQueue ValidarF)
    {
        var pathReport = "";
        var Report = new FastReport.Report();
        MemoryStream strm = new MemoryStream();
        try
        {

            var listGeneral = new List<CajaReport>();


            //TITULO

            switch (ValidarF.Formato)
            {
                case "TK":
                    pathReport = @"formatos\reports\Caja\infCajasKardex.frx";
                    break;
                default:
                    break;
            }



            listGeneral.AddRange(GetKardex(ListKardex, ValidarF));

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathReport);
            Report.Load(path);

            var INgreT = listGeneral.FirstOrDefault().OtrosEgresos;
            var EgreT = listGeneral.FirstOrDefault().OtrosIngresos;
            var otroT = listGeneral.FirstOrDefault().CobranzasDeudas;
            var SaldCaja = listGeneral.FirstOrDefault().FondoInicio;

            
            Report.Report.SetParameterValue("TotalIngresos", INgreT);
            Report.Report.SetParameterValue("TotalEgresos", EgreT);
            Report.Report.SetParameterValue("TotalOtrosPagos", otroT);

            Report.Report.SetParameterValue("SaldoCaja", SaldCaja);

            Report.RegisterData(listGeneral, "Cajas");
            Report.Prepare();

            validarCajas(ValidarF,Report);
            var pdfExport = new FastReport.Export.Pdf.PDFExport();

            Report.Report.Report.Export(pdfExport, strm);

            pdfExport.Dispose();
            strm.Position = 0;



            Report.PrintSettings.Printer = PrintNegoc.relacionImpresora;
            int numeroPr = (int)PrintNegoc.numImpresion;
            if (PrintNegoc != null)
            {
                for (int i = 0; i < numeroPr; i++)
                {
                    Report.Report.PrintSettings.ShowDialog = false;
                    Report.Print();
                }
            }


        }
        catch (Exception ex)
        {
            throw new Exception("No se Pudo imrimir.");
        }

    }

    private void validarCajas(PrintQueue valid, FastReport.Report webReportValidar)
    {
       
        if (valid.NombreDistribucion  =="Impresion")
        {

            webReportValidar.Report.SetParameterValue("Titulocaja", "CIERRE DE CAJA");

            DataBand dtFechaApertura = webReportValidar.Report.FindObject("dtFechaApertura") as DataBand;
            dtFechaApertura.Visible = true;
            DataBand dtFechaCierre = webReportValidar.Report.FindObject("dtFechaCierre") as DataBand;
            dtFechaCierre.Visible = true;
            DataBand dtCargo = webReportValidar.Report.FindObject("dtCargo") as DataBand;
            dtCargo.Visible = true;
        }
        else
        {
            webReportValidar.Report.SetParameterValue("Titulocaja", "PRE VISUALIZAR");
        }
    }
    public List<CajaReport> GetKardex(List<documentoCaja> ListaKard,PrintQueue Printq)
    {
        var TotalEgresos = 0.0;
        var TotalIngresos = 0.0;
        var TotalOtros = 0.0;
        var caja = new CajaReport();
        var cajaList= new List<CajaReport>();
        var listInvoiceSalida = new List<CierreGeneralDetalleReportSalida>();     
        var listInvoiceEntrada = new List<CierreGeneralDetalleReport>();
        var listInvoiceOtros = new List<CierreGeneralDetalleReportOtros>();
        var fechaApertura="";
        var FechaCierre="";
        foreach (var item in ListaKard)
        {
            fechaApertura = item.FechaApertura;
            FechaCierre = item.FechaCierre;
            if (item.entidadFinanciera=="EP")//efectivo
            {
                if (item.nombreCosto == "Salida")
                {
                    var objCuentaEntrada = new CierreGeneralDetalleReport();
                    objCuentaEntrada.DescripcionCaja = item.NombreOperacion;
                    if (item.destino != "")
                    {
                        objCuentaEntrada.DescripcionCaja = item.destino;
                    }
                    objCuentaEntrada.DescripcionCaja = item.destino;
                    objCuentaEntrada.MontoSolesCaja = item.montoMNSalida.ToString();
                    listInvoiceEntrada.Add(objCuentaEntrada);

                    TotalIngresos += double.Parse(item.montoMNSalida.ToString());
                }
                else if (item.nombreCosto == "Entrada")
                {
                    var objCuentaSalida = new CierreGeneralDetalleReportSalida();
                    objCuentaSalida.DescripcionCajaS = item.NombreOperacion;
                    if (item.destino != "")
                    {
                        objCuentaSalida.DescripcionCajaS = item.destino;
                    }

                    objCuentaSalida.MontoSolesCajaS = item.montoSoles.ToString();
                    listInvoiceSalida.Add(objCuentaSalida);

                    TotalEgresos += double.Parse(item.montoSoles.ToString());
                }
            }
            else//otros pagos
            {
                var objCuentaotros = new CierreGeneralDetalleReportOtros();
                objCuentaotros.DescripcionCajaOtros = item.estado;
                objCuentaotros.MontoSolesCajaOtros = item.montoUsdTransacc.ToString();
                listInvoiceOtros.Add(objCuentaotros);

                TotalOtros += double.Parse(item.montoUsdTransacc.ToString());
            }
        }

        caja.FechaApertura =fechaApertura;
        caja.FechaCierre = FechaCierre;

        var totalC = TotalEgresos - TotalIngresos;
        var GeneralTotal = totalC + TotalOtros;
        caja.CierreGeneralDetalle = listInvoiceEntrada;
        caja.CierreGeneralDetalleSalida = listInvoiceSalida;
        caja.CierreGeneralDetalleOtros = listInvoiceOtros;

        caja.OtrosEgresos = TotalEgresos.ToString("N2");
        caja.OtrosIngresos = TotalIngresos.ToString("N2");
        caja.CobranzasDeudas= TotalOtros.ToString("N2");//total de otros pagos
        caja.FondoInicio = totalC.ToString("N2"); //total de egresos e ingresos
        caja.Total = GeneralTotal.ToString("N2");
        caja.Usuario = Printq.UsuarioEnvio;
        cajaList.Add(caja);



        return cajaList;
    }
}








