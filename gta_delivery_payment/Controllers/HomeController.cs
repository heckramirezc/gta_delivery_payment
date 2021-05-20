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

            string query = "SELECT * FROM GTA_CPMS_APP";
            DataHandler handler = new DataHandler();
            OracleDataReader reader = handler.GetData(query);
            while (reader.Read())
            {
                System.Diagnostics.Debug.WriteLine("1" + reader.GetString(0));
                System.Diagnostics.Debug.WriteLine("2" + reader.GetString(1));
                System.Diagnostics.Debug.WriteLine("3" + reader.GetString(3));
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
