using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using gta_delivery_payment.Models;
using gta_delivery_payment.Data;
using Oracle.ManagedDataAccess.Client;

namespace gta_delivery_payment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public Response GetData(string ccnumber)
        {
            Response response = new Response();
            int bim = int.Parse(ccnumber.Trim().Substring(0, 4));
            System.Diagnostics.Debug.WriteLine("bim " + bim);

            string query = "SELECT COUNT(BIN) FROM GTABINES WHERE BIN = " + bim + " AND ESTADO = 'A'";
            System.Diagnostics.Debug.WriteLine("query " + query);
            DataHandler handler = new DataHandler();
            OracleDataReader reader = handler.GetData(query);
            while (reader.Read())
            {
                response = new Response(reader.GetInt32(0));
            }
            reader.Dispose();

            System.Diagnostics.Debug.WriteLine("response.count " + response.count);
            return response;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
