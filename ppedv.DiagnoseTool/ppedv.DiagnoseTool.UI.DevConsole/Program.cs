using ppedv.DiagnoseTool.Logik;
using ppedv.DiagnoseTool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.DiagnoseTool.UI.DevConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** DiagnoseTool v0.1 ***");

            var core = new Core(new Data.Ef.EfRepository());

            if (core.Repository.GetAll<Patient>().Count() == 0)
                core.DemoManager.CreateDemoDaten();

            foreach (var p in core.Repository.GetAll<Patient>())
            {
                ShowPatient(p);
            }

            Console.WriteLine("********************************************************");

            foreach (var p in core.PatientenManager.GetPatientenByFacharztrichtung("Clothing"))
            {
                Console.WriteLine(p.Name);
            }

            Console.WriteLine($"Arzt mit meisten Patienten: {core.ArztManager.GetArztWithMostPatienten().Name}");


            Console.WriteLine("Ende");
            Console.ReadLine();
        }

        private static void ShowPatient(Patient p)
        {
            Console.WriteLine($"Name: {p.Name} [{p.GebDatum:d}] {p.Geschlecht}");
            foreach (var d in p.Diagnosen)
            {
                Console.WriteLine($"\t{d.Code} - {d.Beschreibung} Arzt: {d.Arzt.Name} [{d.Arzt.FacharztRichtung}]");
            }
        }
    }
}
