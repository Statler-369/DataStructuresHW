using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresBasics.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public static Queue<string> qMyQueue = new Queue<string>();

        public static Dictionary<string, int> myDict = new Dictionary<string, int>();

        public ActionResult Index()
        {
            int queuelength = 100;
            for (int iCount = 0; iCount < queuelength; iCount++)
            {
                string newName = IndexController.randomName();
                qMyQueue.Enqueue(newName);

            }

            

            for (int iCount = 0; iCount < queuelength; iCount++)
            {
                if (myDict.ContainsKey(qMyQueue.Peek()))
                {
                    myDict[qMyQueue.Dequeue()] += randomNumberInRange();
                }
                else
                {
                    myDict.Add(qMyQueue.Dequeue(), randomNumberInRange());
                }
            }

            var items = from pair in myDict
                        orderby pair.Value descending
                        select pair;




            string output = "";
            output = "<table align='right' style='width:40%'>";
            output += "<th width='50%'>Customer</th>";
            output += "<th width='50%'>Burger Total</th>";


            foreach (KeyValuePair<string, int> entry in items)
            {
                output += "<tr>";
                output += "<td>" + entry.Key + "</td>";
                output += "<td>" + entry.Value + "</td>";
                output += "</tr>";

            }

            ViewBag.Output = output;



            return View();
        }



        public static Random random = new Random();

        public static string randomName()
        {
            string[] names = new string[8] { "Dan Morain", "Emily Bell", "Carol Roche", "Ann Rose", "John Miller", "Greg Anderson", "Arthur McKinney", "Joann Fisher" };
            int randomIndex = Convert.ToInt32(random.NextDouble() * 7);
            return names[randomIndex];

        }

        public static int randomNumberInRange()
        {
            return Convert.ToInt32(random.NextDouble() * 20);
        }

    }
}