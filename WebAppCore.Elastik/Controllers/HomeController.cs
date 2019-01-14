using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using WebAppCore.Elastik.Models;

namespace WebAppCore.Elastik.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            //Log.Logger = new LoggerConfiguration().WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
            //{
            //    AutoRegisterTemplate = true,
            //    AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6
            //}).CreateLogger();

            //Console.WriteLine("\n\n============================== Logged to Elasticsearch (docker at hocalhost:9200) =================================");

            // scalar data
            // boolean, number, string, date and times, others: Guid, Uri, nullables
            Log.Verbose("Scalar Value: {Ten}", 10);
            Log.Debug("Scalar Value:  {Ten}", 10);
            Log.Information("Scalar Value:   {Ten}", 10);
            Log.Warning("Scalar Value:  {Ten}", 10);
            Log.Error(new IndexOutOfRangeException(), "Scalar Value:  {Ten}", 10);
            Log.Fatal(new AggregateException(), "Scalar Value:  {Ten}", 10);

            // collections
            // IEnumerable, Dictionary<TScalarKey, TVal> (key must be scalar otherwise .ToString will be called)
            var fooList = new List<int> { 1, 2, 3, 4, 5 };
            Log.Verbose("List: {FooList}", fooList);
            Log.Debug("List: {FooList}", fooList);
            Log.Information("List: {FooList}", fooList);
            Log.Warning("List: {FooList}", fooList);
            Log.Error(new IndexOutOfRangeException(), "List: {FooList}", fooList);
            Log.Fatal(new AggregateException(), "List:{FooList}", fooList);

            // object
            // @ : destructuring operator
            var foo = new Foo { Id = 2, FooName = "FooTwo" };
            Log.Verbose("Object: {@FooMan}", foo);
            Log.Debug("Object: {@FooMan}", foo);
            Log.Information("Object: {@FooMan}", foo);
            Log.Warning("Object:{@FooMan}", foo);
            Log.Error(new IndexOutOfRangeException(), "Object: {@FooMan}", foo);
            Log.Fatal(new AggregateException(), "Object: {@FooMan}", foo);

            //Console.ReadKey();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
