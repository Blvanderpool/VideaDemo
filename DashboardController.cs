using VIDEA.ADMIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIDEA.ADMIN.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/
        public ActionResult Index()
        {
            VmDashboard dummyData = getDummyData();
            return View(dummyData);
        }

        private VmDashboard getDummyData()
        {
            VmDashboard data = new VmDashboard();
            data.RateVisitors = 73;
            data.RateUsers = 52;
            data.RateOrders = 78;
            data.RatePageViews = 42;

            data.CurrentDate = DateTime.Now;

            data.MarketAccounts = new List<Tuple<int, string, string, string>>();
            data.MarketAccounts.Add(new Tuple<int, string, string, string>(1, "Atlanta", "Georgia", "753"));
            data.MarketAccounts.Add(new Tuple<int, string, string, string>(2, "Birmingham, ", "Alabama", "322"));
            data.MarketAccounts.Add(new Tuple<int, string, string, string>(3, "New York City", "New York", "255"));

            data.TopClients = new List<Tuple<int, string, DateTime, double>>();
            data.TopClients.Add(new Tuple<int, string, DateTime, double>(1, "Pepsi Cola Corp", new DateTime(2017, 2, 2), 99125.12));
            data.TopClients.Add(new Tuple<int, string, DateTime, double>(2, "Atlanta Falcons", new DateTime(2017, 2, 1), 75335.00));
            data.TopClients.Add(new Tuple<int, string, DateTime, double>(3, "Merck International", new DateTime(2017, 2, 1), 35329.00));

            data.RevenueStreams = new List<Tuple<int, string, string, string>>();
            data.RevenueStreams.Add(new Tuple<int, string, string, string>(1, "New Accounts", "10/10/2016", "$25.12"));
            data.RevenueStreams.Add(new Tuple<int, string, string, string>(2, "Ad Services", "12/12/2016", "$335.00"));
            data.RevenueStreams.Add(new Tuple<int, string, string, string>(3, "Renewals", "01/02/2017", "$29.99"));

            data.NewUsers = new List<Tuple<int, string, string, string>>();
            data.NewUsers.Add(new Tuple<int, string, string, string>(1, "Sharon", "Gordon", "Pepsi Cola"));
            data.NewUsers.Add(new Tuple<int, string, string, string>(2, "Jacob", "Thornton", "CDC Atlanta"));
            data.NewUsers.Add(new Tuple<int, string, string, string>(3, "Vincent", "Gabriel", "Ingenious Med"));

            return data;
        }
	}
}