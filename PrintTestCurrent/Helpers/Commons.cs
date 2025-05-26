using Helios.Cont.Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


  public class Commons
    {
        public void ImprimirPedido(List<detalleItemsImpresoras> order, String ISPRINTER, String nameMesa, String nameVendedor, String nameAlmacen, String namecargo, String NombreInfra, String formatoPrint, Int16 cantidadPrint, String COMPARTIDO)
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
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional}) {"(PARA LLEVAR)"}");
                                    else
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional})");
                                }
                                else
                                {
                                    if (item.tipoVenta == "PL")
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} {"(PARA LLEVAR)"}");
                                    else
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}");
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
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional}) {"(PARA LLEVAR)"}");
                                    else
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional})");
                                }
                                else
                                {
                                    if (item.tipoVenta == "PL")
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} {"(PARA LLEVAR)"}");
                                    else
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}");
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
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional}) {"(PARA LLEVAR)"}");
                                    else
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional})");
                                }
                                else
                                {
                                    if (item.tipoVenta == "PL")
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} {"(PARA LLEVAR)"}");
                                    else
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}");
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
    }

