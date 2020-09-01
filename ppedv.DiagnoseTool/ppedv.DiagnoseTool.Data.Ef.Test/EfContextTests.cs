using System;
using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.DiagnoseTool.Model;

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

        [TestMethod]
        public void EfContext_can_add_Patient()
        {
            var p = new Patient()
            {
                Name = $"Fred_{Guid.NewGuid()}",
                GebDatum = DateTime.Now.AddYears(-50),
                Geschlecht = Geschlecht.Männlich,
                Adresse = "Steinstr. 12"
            };

            using (var con = new EfContext())
            {
                con.Patienten.Add(p);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Patienten.Find(p.Id);
                Assert.IsNotNull(loaded);
                Assert.AreEqual(p.Name, loaded.Name);
            }
        }

        [TestMethod]
        public void EfContext_can_update_Patient()
        {
            var p = new Patient()
            {
                Name = $"Fred_{Guid.NewGuid()}",
                GebDatum = DateTime.Now.AddYears(-50),
                Geschlecht = Geschlecht.Männlich,
                Adresse = "Steinstr. 13"
            };

            var newName = $"Wilma_{Guid.NewGuid()}";

            using (var con = new EfContext())
            {
                con.Patienten.Add(p);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Patienten.Find(p.Id);
                loaded.Name = newName;
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Patienten.Find(p.Id);
                Assert.AreEqual(newName, loaded.Name);
            }

        }

        [TestMethod]
        public void EfContext_can_delete_Patient()
        {
            var p = new Patient()
            {
                Name = $"Fred_{Guid.NewGuid()}",
                GebDatum = DateTime.Now.AddYears(-50),
                Geschlecht = Geschlecht.Männlich,
                Adresse = "Steinstr. 13"
            };

            using (var con = new EfContext())
            {
                con.Patienten.Add(p);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Patienten.Find(p.Id);
                con.Patienten.Remove(loaded);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Patienten.Find(p.Id);
                Assert.IsNull(loaded);
            }
        }


        [TestMethod]
        public void EfContext_can_add_Patient_AutoFixture_FluentAssertions()
        {
            var fix = new Fixture();

            fix.Behaviors.Add(new OmitOnRecursionBehavior());

            var p = fix.Create<Patient>();

            using (var con = new EfContext())
            {
                con.Patienten.Add(p);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Patienten.Find(p.Id);
                loaded.Should().NotBeNull(); //Assert.IsNotNull(loaded);
                loaded.Name.Should().Be(p.Name);// Assert.AreEqual(p.Name, loaded.Name);

                loaded.Should().BeEquivalentTo(p, x => x.IgnoringCyclicReferences());
            }
        }
    }
}
