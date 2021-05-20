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
            System.Diagnostics.Debug.WriteLine("request ", ccnumber);

            string query = "SELECT COUNT(1) FROM GTABINES";
            DataHandler handler = new DataHandler();
            OracleDataReader reader = handler.GetData(query);
            while (reader.Read())
            {
                string resp = reader.GetString(0);
                System.Diagnostics.Debug.WriteLine("1" + reader.GetString(0));
            }
            reader.Dispose();

            return new Response(12345);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
