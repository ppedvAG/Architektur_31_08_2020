using System;
using System.Collections.Generic;

namespace ppedv.DiagnoseTool.Model
{
    public class Patient : Entity
    {
        public string Name { get; set; }
        public DateTime GebDatum { get; set; }
        public string Adresse { get; set; }
        public Geschlecht Geschlecht { get; set; }

        public virtual HashSet<Diagnose> Diagnosen { get; set; } = new HashSet<Diagnose>();
    }

    public enum Geschlecht
    {
        Divers,
        Männlich,
        Weiblich
    }
}
