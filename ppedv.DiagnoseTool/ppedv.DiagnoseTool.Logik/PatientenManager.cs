using ppedv.DiagnoseTool.Model;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.DiagnoseTool.Logik
{
    public class PatientenManager
    {
        private Core core;

        public PatientenManager(Core core)
        {
            this.core = core;
        }

        public IEnumerable<Patient> GetPatientenByFacharztrichtung(string facharztrichtung)
        {
            return core.Repository.GetAll<Arzt>().Where(x => x.FacharztRichtung
                                            .Contains(facharztrichtung))
                                            .SelectMany(x => x.Diagnosen)
                                            .Select(x => x.Patient);
        }
    }
}
