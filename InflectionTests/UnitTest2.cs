using Microsoft.VisualStudio.TestTools.UnitTesting;
using InflectionServices;

namespace InflectionTests
{
    [TestClass]
    public class StringUtilTests
    {
        [TestMethod]
        public void TestPluralize()
        {
            Assert.AreEqual("cavalo", StringUtil.Pluralize("cavalo", 1));
            Assert.AreEqual("cavalos", StringUtil.Pluralize("cavalo", 2));
        }
    }
}
