using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Serilogging.Consol
{
    class Program
    {
        static void Main(string[] args)
        {

            SetupSerilog();

            // scalar data
            // boolean, number, string, date and times, others: Guid, Uri, nullables
            Console.WriteLine("\n\n============================== Logging Scalar Value =================================");
            Log.Verbose("Scalar Value: {Ten}", 10);
            Log.Debug("Scalar Value:  {Ten}", 10);
            Log.Information("Scalar Value:   {Ten}", 10);
            Log.Warning("Scalar Value:  {Ten}", 10);
            Log.Error(new IndexOutOfRangeException(), "Scalar Value:  {Ten}", 10);
            Log.Fatal(new AggregateException(), "Scalar Value:  {Ten}", 10);

            // collections
            // IEnumerable, Dictionary<TScalarKey, TVal> (key must be scalar otherwise .ToString will be called)
            Console.WriteLine("\n\n============================== Logging List =================================");
            var fooList = new List<int>{ 1, 2, 3, 4, 5};
            Log.Verbose("List: {FooList}", fooList);
            Log.Debug("List: {FooList}", fooList);
            Log.Information("List: {FooList}", fooList);
            Log.Warning("List: {FooList}", fooList);
            Log.Error(new IndexOutOfRangeException(), "List: {FooList}", fooList);
            Log.Fatal(new AggregateException(), "List:{FooList}", fooList);

            // object
            // @ : destructuring operator
            Console.WriteLine("\n\n============================== Logging Object =================================");
            var foo = new Foo { Id = 2, FooName = "FooTwo"};
            Log.Verbose("Object: {@FooMan}", foo);
            Log.Debug("Object: {@FooMan}", foo);
            Log.Information("Object: {@FooMan}", foo);
            Log.Warning("Object:{@FooMan}", foo);
            Log.Error(new IndexOutOfRangeException(), "Object: {@FooMan}", foo);
            Log.Fatal(new AggregateException(), "Object: {@FooMan}", foo);

            Console.ReadKey();
        }

        private static void SetupSerilog()
        {
            var configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
    }
}
