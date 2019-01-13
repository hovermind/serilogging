using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;

namespace Serilogging.Fyle
{
    class Program
    {
        static void Main(string[] args)
        {

            SetupSerilog();

            Console.WriteLine("\n\n============================== Logged to c:\\serilog\\serifile.log =================================");

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
            var bar = new Bar { Id = 2, BarName = "FooTwo" };
            Log.Verbose("Object: {@BarMan}", bar);
            Log.Debug("Object: {@BarMan}", bar);
            Log.Information("Object: {@BarMan}", bar);
            Log.Warning("Object:{@BarMan}", bar);
            Log.Error(new IndexOutOfRangeException(), "Object: {@BarMan}", bar);
            Log.Fatal(new AggregateException(), "Object: {@BarMan}", bar);

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
