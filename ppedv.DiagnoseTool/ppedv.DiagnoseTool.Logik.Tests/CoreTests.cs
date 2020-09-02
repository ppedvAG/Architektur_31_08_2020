using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ppedv.DiagnoseTool.Model;
using ppedv.DiagnoseTool.Model.Contracts;

namespace ppedv.DiagnoseTool.Logik.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void Core_GetArztWithMostPatienten()
        {
            var core = new Core(new TestRepo());

            var result = core.GetArztWithMostPatienten();

            Assert.AreEqual("Dr. Wer", result.Name);
        }

        [TestMethod]
        public void Core_GetArztWithMostPatienten_Moq()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Arzt>()).Returns(() =>
            {
                var a1 = new Arzt() { Name = "Dr. Frankenstein" };
                a1.Diagnosen.Add(new Diagnose() { Patient = new Patient() });

                var a2 = new Arzt() { Name = "Dr. Wer" };
                a2.Diagnosen.Add(new Diagnose() { Patient = new Patient() });
                a2.Diagnosen.Add(new Diagnose() { Patient = new Patient() });

                return new[] { a1, a2 };
            });
            
            var core = new Core(mock.Object);

            var result = core.GetArztWithMostPatienten();

            Assert.AreEqual("Dr. Wer", result.Name);
        }
    }
}
