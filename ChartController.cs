using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VIDEA.ADMIN.Models;

namespace VIDEA.ADMIN.Controllers
{
    public class ChartController : Controller
    {
        //
        // GET: /Chart/


        public ActionResult DisplayChart()
        {

            return View();
        }



        public ActionResult DataSourceBinding(string id = "Monday")
        {
            //return "ID =" + id + "<br /> Name=" + Request.QueryString["day"].ToString();
            //return View(ChartData.GetData());
            //return View(GetWebData());
           // ViewBag.WeekDay = Request.QueryString["Id"].ToString();
            ViewBag.WeekDay = id;
            return View(GetDBChartData(id));
        }


        
        public static List<ChartData> GetWebData()
        {
            var data = new List<ChartData>();

            data.Add(new ChartData("CBS", 46, 78));
            data.Add(new ChartData("NBC", 35, 72));
            data.Add(new ChartData("CW", 68, 86));
            data.Add(new ChartData("HBO", 30, 23));
            data.Add(new ChartData("FOX", 27, 70));
            data.Add(new ChartData("NTV", 85, 60));
            data.Add(new ChartData("FX", 43, 88));
            data.Add(new ChartData("AMC", 29, 22));

            return data;
        }

        public static List<ChartData> GetDBChartData(string daystr)
        {
            var qdata = new List<ChartData>();
            using (VIDEAEntities dc = new VIDEAEntities())
            {
                var qresults = from c in dc.TVMazeShows
                          where c.day == daystr && c.network.Length < 4
                          group c.rating by c.network into g

                          select new
                          {
                              Network = g.Key,
                              MaxRatings = g.ToList().Max()
                          };

             //var rx = res.ToList();   //GetResults("Tuesday");
                foreach (var row in qresults)
                {
                    qdata.Add(new ChartData(row.Network, (int)row.MaxRatings, "Highest Rated TV Shows by Networks", "Sunday"));           
                }

                
            }

            return qdata;
        }




    }
}
