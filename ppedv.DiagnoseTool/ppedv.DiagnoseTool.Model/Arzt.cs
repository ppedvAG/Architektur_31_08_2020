using System.Collections.Generic;

namespace ppedv.DiagnoseTool.Model
{
    public class Arzt : Entity
    {
        public string Name { get; set; }
        public string Betriebsstättennummer { get; set; }
        public string FacharztRichtung { get; set; }

        public virtual HashSet<Diagnose> Diagnosen { get; set; } = new HashSet<Diagnose>();
    }
}
