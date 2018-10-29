using MediaLibrary.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediaLibraryTest
{
    [TestClass]
    public class GiantBombTest
    {
        [TestMethod]
        public void TestSearch()
        {
            var provider = new GiantBombProvider("", "");
            var games = provider.SearchByNameAsync("metroid prime").Result;
            Assert.IsNotNull(games);
        }
    }
}
