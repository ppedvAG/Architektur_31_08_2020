namespace ppedv.DiagnoseTool.Model
{
    public class Diagnose : Entity
    {
        public string Code { get; set; }
        public string Beschreibung { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Arzt Arzt { get; set; }
    }
}
