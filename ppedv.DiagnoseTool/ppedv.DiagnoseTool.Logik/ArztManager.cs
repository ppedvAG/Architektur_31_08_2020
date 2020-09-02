using ppedv.DiagnoseTool.Model;
using System.Linq;

namespace ppedv.DiagnoseTool.Logik
{
    public class ArztManager
    {
        private Core core;

        public ArztManager(Core core)
        {
            this.core = core;
        }

        public Arzt GetArztWithMostPatienten()
        {
            return core.Repository.GetAll<Arzt>().OrderByDescending(x => x.Diagnosen.Select(y => y.Patient).Count()).FirstOrDefault();
        }
    }
}
