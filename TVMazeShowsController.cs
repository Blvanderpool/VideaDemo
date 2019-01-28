using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using VIDEA.ADMIN;

namespace VIDEA.ADMIN.Controllers
{
    public class TVMazeShowsController : Controller
    {
        private VIDEAEntities db = new VIDEAEntities();

        // GET: TVMazeShows
        public ActionResult Index()
        {
            return View(db.TVMazeShows.ToList());
        }

        // GET: TVMazeShows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVMazeShow tVMazeShow = db.TVMazeShows.Find(id);
            if (tVMazeShow == null)
            {
                return HttpNotFound();
            }
            return View(tVMazeShow);
        }

        public ActionResult ReloadShows()
        {
            var rezult = getUriData("http://api.tvmaze.com/shows");


            List<TVMazeShow> ShowList = new List<TVMazeShow>();

            dynamic jsonObj = JsonConvert.DeserializeObject(rezult);
            
            var x = 0;
            foreach (var obj in jsonObj)
            {
                var aTVShow = new TVMazeShow();

                x++;
                // Filter for several TV Shows only
                if (x == 24 || x == 25 || x == 26 || x == 32 || x == 73 || x == 115 || x == 163 || x == 167 || x == 176 || x == 189)
                    continue;


                if (obj.name != null)
                {
                    aTVShow.id = (int)x; //(int)obj.id;
                    aTVShow.name = (string)obj.name;
                    aTVShow.status = (string)obj.status;
                    aTVShow.runtime = (int)obj.runtime;
                    aTVShow.premiered = (string)obj.premiered;

                    aTVShow.day = (string)obj.schedule.days[0];
                    aTVShow.time = (string)obj.schedule.time;
                    aTVShow.status = (string)obj.status;
                    aTVShow.network = (string)obj.network.name;

                    var tempRating = (string)obj.rating.average;
                    decimal? tvrating = !string.IsNullOrEmpty(tempRating) ?
                         decimal.Parse(tempRating.Replace(",", "")) :
                         (decimal?)null;

                    aTVShow.rating = tvrating;  //(decimal)obj.rating.average;
                    aTVShow.photo = (string)obj.image.original;

                    using (var dbc = new VIDEAEntities())
                    {
                        dbc.TVMazeShows.Add(aTVShow);
                        dbc.SaveChanges();
                    }
                }


            }
         
            return RedirectToAction("Index");
        }

        public ActionResult TruncateShows()
        {
            VIDEAEntities dbx = new VIDEAEntities();
            dbx.Database.ExecuteSqlCommand("truncate table [VIDEA].[dbo].[TVMazeShows]");

            return RedirectToAction("Index");
        }

        static string getUriData(string webserviceUri)
        {
            string jsonResults = "";
            if (webserviceUri != "")
            {
                using (WebClient webConnect = new WebClient())
                {
                    using (Stream responseStream = webConnect.OpenRead(webserviceUri))
                    {
                        using (StreamReader respStreamReader = new StreamReader(responseStream))
                        {
                            jsonResults = respStreamReader.ReadToEnd();
                        }
                    }
                }
            }

            return jsonResults;

        }


       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
