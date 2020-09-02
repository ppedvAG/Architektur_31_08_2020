using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ppedv.DiagnoseTool.UI.WebCore30.Models
{
    public class ArztAPI
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Fachrichtung { get; set; }
        public IEnumerable<string> Patienten { get; set; }

    }
}
