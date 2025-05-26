using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintTestCurrent
{
    class Program
    {
        static void Main(string[] args)
        {

            _ = GetOrders();

        }

        private static async Task GetOrders()
        {
            
            var ordersList = await DocumentoVentaAPI.GetPreOrdersPendingPrint(new Helios.Cont.Business.Entity.documentoventaAbarrotes() { 
                idEstablecimiento = 1
            });
           
        }
    }
}
