using Bogus;
using ppedv.DiagnoseTool.Data.Ef;
using ppedv.DiagnoseTool.Model;
using ppedv.DiagnoseTool.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ppedv.DiagnoseTool.Logik
{
    public class Core
    {
        public IRepository Repository { get; private set; }

        public Core(IRepository repository)
        {
            Repository = repository;
        }

        internal IEnumerable<Patient> CreateDemoPatienten()
        {
            var ärzte = new Faker<Arzt>().RuleFor(x => x.Name, (f, u) => f.Name.FullName())
                                             .RuleFor(x => x.FacharztRichtung, (f, u) => f.Commerce.Department())
                                             .RuleFor(x => x.Betriebsstättennummer, (f, u) => f.Random.String2(12))
                                             .Generate(10);

            var diagFaker = new Faker<Diagnose>().RuleFor(x => x.Code, f => f.Random.String2(4))
                                             .RuleFor(x => x.Beschreibung, f => f.Vehicle.Model())
                                             .RuleFor(x => x.Arzt, f => f.PickRandom(ärzte));


            var pFaker = new Faker<Patient>().RuleFor(x => x.Name, (f, u) => f.Name.FullName())
                                            .RuleFor(x => x.Geschlecht, f => f.PickRandom<Geschlecht>())
                                            .RuleFor(x => x.GebDatum, f => f.Date.Past(40))
                                            .RuleFor(x => x.Adresse, f => f.Address.FullAddress());

            Random ran = new Random();

            for (int i = 0; i < 100; i++)
            {
                var p = pFaker.Generate();
                for (int di = 0; di < ran.Next(1, 5); di++)
                {
                    p.Diagnosen.Add(diagFaker.Generate());
                }
                yield return p;
            }
        }

        public void CreateDemoDaten()
        {
            foreach (var p in CreateDemoPatienten())
            {
                Repository.Add(p);
            }
            Repository.SaveAll();
        }



        public IEnumerable<Patient> GetPatientenByFacharztrichtung(string facharztrichtung)
        {
            return Repository.GetAll<Arzt>().Where(x => x.FacharztRichtung
                                            .Contains(facharztrichtung))
                                            .SelectMany(x => x.Diagnosen)
                                            .Select(x => x.Patient);
        }
    }
}
