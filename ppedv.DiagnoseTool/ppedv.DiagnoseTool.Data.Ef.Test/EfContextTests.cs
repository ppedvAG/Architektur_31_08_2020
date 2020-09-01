using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ppedv.DiagnoseTool.Data.Ef.Test
{
    [TestClass]
    public class EfContextTests
    {
        [TestMethod]
        public void EfContext_can_create_database()
        {
            using (var con = new EfContext())
            {
                if (con.Database.Exists())
                    con.Database.Delete();

                con.Database.Create();

                Assert.IsTrue(con.Database.Exists());
            }
        }
    }
}
