using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InflectionServices;

namespace InflectionTests
{
    [TestClass]
    public class PluralTests
    {
        [TestMethod]
        public void TestPlural()
        {
            Inflector inflect = new Inflector();
            Assert.AreEqual("pães", inflect.Pluralize("pão"));
            Assert.AreEqual("irmãos", inflect.Pluralize("irmão"));
            Assert.AreEqual("fogões", inflect.Pluralize("fogão"));
            Assert.AreEqual("viagens", inflect.Pluralize("viagem"));
            Assert.AreEqual("fregueses", inflect.Pluralize("freguês"));
            Assert.AreEqual("juvenis", inflect.Pluralize("juvenil"));
        }

        [TestMethod]
        public void TestPluralOfUncountables()
        {
            Inflector inflect = new Inflector();
            Assert.AreEqual("tórax", inflect.Pluralize("tórax"));
            Assert.AreEqual("tênis", inflect.Pluralize("tênis"));
            Assert.AreEqual("ônibus", inflect.Pluralize("ônibus"));
            Assert.AreEqual("lápis", inflect.Pluralize("lápis"));
            Assert.AreEqual("fênix", inflect.Pluralize("fênix"));
        }

        [TestMethod]
        public void TestPluralOfIrregulars()
        {
            Inflector inflect = new Inflector();
            Assert.AreEqual("países", inflect.Pluralize("país"));
        }
    }
}
