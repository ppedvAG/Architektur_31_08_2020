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


        public IEnumerable<Patient> GetPatientenByFacharztrichtung(string facharztrichtung)
        {
            return Repository.GetAll<Arzt>().Where(x => x.FacharztRichtung
                                            .Contains(facharztrichtung))
                                            .SelectMany(x => x.Diagnosen)
                                            .Select(x => x.Patient);
        }
    }
}
