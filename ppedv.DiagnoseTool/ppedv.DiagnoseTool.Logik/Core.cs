using ppedv.DiagnoseTool.Model.Contracts;

namespace ppedv.DiagnoseTool.Logik
{
    public class Core
    {
        public IRepository Repository { get; private set; }

        public Core(IRepository repository)
        {
            Repository = repository;
            _demoManager = new DemoManager(this);
        }

        private DemoManager _demoManager = null;
        public DemoManager DemoManager { get => _demoManager; }

        public PatientenManager PatientenManager { get => new PatientenManager(this); }
        public ArztManager ArztManager { get => new ArztManager(this); }

    }
}
