using Helios.Cont.Business.Entity;
using HeliosPrintService.Api;
using HeliosPrintService.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace HeliosPrintService
{
    public partial class Service1 : ServiceBase
    {


        System.Timers.Timer timer = new System.Timers.Timer(); // name space(using System.Timers;)
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // WriteToFile("Service is started at " + DateTime.Now);
            //_ = GetOrders();
            // Start();
            try
            {
               // ProcessSpawnMethod pspawn = new ProcessSpawnMethod();
               // pspawn.Print();
                //PrintDocumentMethod printDoc = new PrintDocumentMethod();           


                // printDoc.Printing("Cocina");

                timer.Elapsed += new ElapsedEventHandler(OnElapsedTimeAsync);
                timer.Interval = 5000; //number in milisecinds
                timer.Enabled = true;
            }
            catch (Exception ex)
            {

                WriteToFile(ex.Message + ex.StackTrace + DateTime.Now);
            }


           
        }

        private void Start()
        {
            WriteToFile("calling api helios  at " + DateTime.Now);
            try
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
                        WriteToFile("imptersoras init");
                        ImprimirPedidoOrder(ordersSend, "", venta.nombreDistribucion, venta.usuarioOperacion, "", venta.cargoOperacion, venta.nombreDistribucion);
                        WriteToFile("imptersoras finsish");
                        //await OrderAPI.ConfirmPrintOrder(venta);
                    }

                }


                // conecctionSQL();
                //  await GetOrders();
            }
            catch (Exception ex)
            {
                WriteToFile(ex.Message + ex.StackTrace + DateTime.Now);
               // WriteToFile("Simple Service Error on: {0} " + ex.Message + ex.StackTrace);
            }
        }

        public void conecctionSQL()
        {
            string connectionString =
          "Server=DESKTOP-Q4PQEKA;User ID=izan;Password=1234567;Initial Catalog=HeliosWebCore2;"
          + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString =
                "SELECT * from entidad";

            // Specify the parameter value.
            int paramValue = 5;

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
                        WriteToFile(text + " " + DateTime.Now);
                        //Console.WriteLine("\t{0}\t{1}\t{2}",
                           // reader[0], reader[1], reader[2]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    WriteToFile(ex.Message + ex.StackTrace + DateTime.Now);
                }
              //  Console.ReadLine();
            }
        }

        protected override void OnStop()
        {
            timer.Enabled = false;
            WriteToFile("stopping service at  " + DateTime.Now);
        }

        private void OnElapsedTimeAsync(object source, ElapsedEventArgs e)
        {
           
            WriteToFile("Service is recall at " + DateTime.Now);
            OpenApp();
        }


        public void OpenApp()
        {
            bool instanceCountOne = false;
            try
            {
                using (var mtex = new Mutex(true, "DeskTest", out instanceCountOne))
                {
                    if (instanceCountOne)
                    {

                        var location = new Uri(Assembly.GetEntryAssembly().CodeBase).LocalPath;
                        var path = Path.GetDirectoryName(location);
                        var serverPath = Path.Combine(path, "DeskTest.exe");
                        Process cmd = new Process();
                        cmd.StartInfo.FileName = @"C:\Users\Jiuni\Desktop\DeskTest.appref-ms";// serverPath;
                        cmd.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                        //using (var f = File.Create(Path.Combine(path, "TestFile.txt")))
                        //{
                        //    filePath = f.Name;
                        //}

                        cmd.StartInfo.Arguments = @"C:\Users\Jiuni\Desktop\DeskTest.appref-ms"; ;
                        cmd.Start();
                    }
                    else
                    {
                        WriteToFile("se está ejecutando una instancia de la aplicación" + DateTime.Now);
                       // MessageBox.Show("Ya se está ejecutando una instancia de la aplicación", "Tuxedo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }


            }
            catch (Exception ex)
            {
                WriteToFile(ex.Message + DateTime.Now);
                //MessageBox.Show("Error" + ex.Message);
            }
        }

        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }



        public  async Task<List<documentoventaAbarrotes>> GetOrdenes(documentoventaAbarrotes item)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:44357/" + "api/Sale/print-pending-order", item);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.

            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<documentoventaAbarrotes>>(jsonResult);

            // WriteToFile("id is: " + result.FirstOrDefault().idDocumento.ToString() +  " " + DateTime.Now);

            return result;// response.Headers.Location;
        }

        private async Task GetOrders()
        {


            var resp = await GetOrdenes(new documentoventaAbarrotes()
            {
                idEstablecimiento = 1
            });

            WriteToFile("Service ordenes paso 1 at " + DateTime.Now);



            //Commons commons = new Commons();
            //var ordersList = await DocumentoVentaAPI.GetPreOrdersPendingPrint(new Helios.Cont.Business.Entity.documentoventaAbarrotes()
            //{
            //    idEstablecimiento = 1
            //});

          


            //foreach (var venta in ordersList)
            //{

            //    var usuarioData = await UserAPI.GetId(new Helios.Seguridad.Business.Entity.Usuario() { IDUsuario = int.Parse(venta.usuarioActualizacion) });


            //    var idList = venta.documentoventaAbarrotesDet.Select(s => Int32.TryParse(s.idItem, out int n) ? n : (int)0).ToList();
            //    var orderRecupeacion = await ImpresorasNegocioAPI.getListImpresorasXCodigoDetalle(idList);

            //    var ImpresorasList = orderRecupeacion.Select(q => new
            //    {
            //        q.idImpresora,
            //        q.aliasImpresora,
            //        q.ipImpresoraCompartida,
            //        q.cantidadPrint,
            //        q.formatoImpresion,
            //        q.relacionImpresora
            //    }).Distinct().ToList();


            //    List<detalleItemsImpresoras> ordersSend = new List<detalleItemsImpresoras>();
            //    foreach (var pr in ImpresorasList)
            //    {

            //        var objprint = new detalleItemsImpresoras()
            //        {
            //            aliasImpresora = pr.aliasImpresora,
            //            idImpresora = pr.idImpresora,
            //            ipImpresoraCompartida = pr.ipImpresoraCompartida,
            //            cantidadPrint = pr.cantidadPrint,
            //            formatoImpresion = pr.formatoImpresion,
            //            relacionImpresora = pr.relacionImpresora
            //        };

            //        objprint.listaProductos = new List<documentoventaAbarrotesDet>();
            //        var items = orderRecupeacion.Where(w => w.idImpresora == pr.idImpresora).ToList();
            //        var productsIDS = items.Select(q => q.codigodetalle.ToString()).ToList();


            //        var detalleVenta = venta.documentoventaAbarrotesDet.Where(s => productsIDS.Contains(s.idItem)).ToList();
            //        objprint.listaProductos.AddRange(detalleVenta);
            //        ordersSend.Add(objprint);
            //    }

            //    //Envio para imprimir
            //    if (ordersSend.Any())
            //    {

            //        //string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            //        //if (!Directory.Exists(path))
            //        //{
            //        //    Directory.CreateDirectory(path);
            //        //}
            //        //string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            //        //if (!File.Exists(filepath))
            //        //{
            //        //    // Create a file to write to.
            //        //    using (StreamWriter sw = File.CreateText(filepath))
            //        //    {
            //        //        sw.WriteLine(venta.usuarioOperacion);
            //        //    }
            //        //}
            //        //else
            //        //{
            //        //    using (StreamWriter sw = File.AppendText(filepath))
            //        //    {
            //        //        sw.WriteLine(venta.usuarioOperacion);
            //        //    }
            //        //}

            //        WriteToFile(venta.usuarioOperacion + " " + DateTime.Now);

            //        //commons.ImprimirPedido(ordersSend, "", venta.nombreDistribucion, venta.usuarioOperacion, "", venta.cargoOperacion, venta.nombreDistribucion);
            //    }
            //}



        }

        #region orders pendings print

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
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional}) {"(PARA LLEVAR)"}", "", "");
                                    else
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional})", "", "");
                                }
                                else
                                {
                                    if (item.tipoVenta == "PL")
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} {"(PARA LLEVAR)"}", "", "");
                                    else
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}", "", "");
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
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional}) {"(PARA LLEVAR)"}", "", "");
                                    else
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional})", "", "");
                                }
                                else
                                {
                                    if (item.tipoVenta == "PL")
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} {"(PARA LLEVAR)"}", "", "");
                                    else
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}", "", "");
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
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional}) {"(PARA LLEVAR)"}", "", "");
                                    else
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} ({item.detalleAdicional})", "", "");
                                }
                                else
                                {
                                    if (item.tipoVenta == "PL")
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem} {"(PARA LLEVAR)"}", "", "");
                                    else
                                        print.AnadirLineaElementosFactura(item.monto1.GetValueOrDefault().ToString(), $"{item.nombreItem}", "", "");
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
          "Server=DESKTOP-Q4PQEKA;User ID=izan;Password=1234567;Initial Catalog=HeliosWebCore2;"
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
                    WriteToFile(ex.Message + ex.StackTrace + DateTime.Now);
                }

                return listprint;
                //  Console.ReadLine();
            }
        }

        public List<documentoventaAbarrotes> OrdersPending()
        {
            string connectionString =
          "Server=DESKTOP-Q4PQEKA;User ID=izan;Password=1234567;Initial Catalog=HeliosWebCore2;"
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
                            idDocumento = int.Parse(reader[0].ToString()),
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
                    WriteToFile(ex.Message + ex.StackTrace + DateTime.Now);
                }

                return listOrders;
                //  Console.ReadLine();
            }
        }


        public List<documentoventaAbarrotesDet> OrdersPendingDetail(int id)
        {
            string connectionString =
          "Server=DESKTOP-Q4PQEKA;User ID=izan;Password=1234567;Initial Catalog=HeliosWebCore2;"
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
                    WriteToFile(ex.Message + ex.StackTrace + DateTime.Now);
                }

                return listOrdersDetail;
                //  Console.ReadLine();
            }
        }


        #endregion


        #region PrintExample
        public static class myPrinters

        {

            [System.Runtime.InteropServices.DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]

            public static extern bool SetDefaultPrinter(string Name);

        }



        public class PrintDocumentMethod
        {

            private Font printFont;

            private Stream IOStream;

            private void pd_PrintPage(object sender, PrintPageEventArgs ev)

            {

                ev.Graphics.DrawImage(Image.FromStream(IOStream, true, false), ev.Graphics.VisibleClipBounds);

                ev.HasMorePages = false;

            }

            public void ChangeDefaultPrinter(String pname)

            {

                myPrinters.SetDefaultPrinter(pname);

            }

            public void Printing(string pname)
            {

                try

                {

                    IOStream = new FileStream("C:\\scanned.jpeg", FileMode.Open, FileAccess.Read);

                    //streamToPrint = new StreamReader(IOStream);

                    try

                    {

                        printFont = new Font("Arial", 10);

                        PrintDocument pd = new PrintDocument();

                        pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

                        // Specify the printer to use.

                        pd.PrinterSettings.PrinterName = pname;

                        pd.Print();

                    }

                    finally

                    {

                        IOStream.Close();

                    }

                }

                catch (Exception ex)

                {

                    EventLog e = new EventLog("Print Error");

                    e.WriteEntry("Failed in Printing, Reason:" + ex.Message);

                   // WriteToFile("stopping service at  " + ex.Message);

                }

            }

        }

        class ProcessSpawnMethod

        {

            string file_name = @"D:\\izan.pdf";
            public void Print()
            {
#if USE_SHELL_EXECUTE
                Process print = new Process();
                print.StartInfo.FileName = file_name;
                print.StartInfo.UseShellExecute = true;
                print.StartInfo.Verb = "printto";
                print.StartInfo.CreateNoWindow = true;
                print.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                print.StartInfo.Arguments = "Cocina";
                print.Start();
#else
                Process print = new Process();
                print.StartInfo.FileName = "sumatrapdf.exe";
                print.StartInfo.UseShellExecute = true;
                print.StartInfo.CreateNoWindow = true;
                print.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                print.StartInfo.Arguments = "-print-to \"" + "Cocina" + "\" -exit-when-done \"" + file_name + "\"";
                print.Start();
#endif






                //PrintDialog printDialog1 = new PrintDialog();

                //printDialog1.PrinterSettings.PrinterName = "EasyCoder 91 DT (203 dpi)";

                System.Diagnostics.Process process = new System.Diagnostics.Process();
            
                process.Refresh();

                process.StartInfo.Arguments = "Cocina";
               // process.StartInfo.Arguments = "\"" + "Cocina" + "\"";

                process.StartInfo.CreateNoWindow = true;

                process.StartInfo.Verb = "PrintTo";

                process.StartInfo.FileName = @"D:\\izan.pdf";

                process.StartInfo.UseShellExecute = true;

                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

                process.Start();

            }

        }

        #endregion

    }
}
