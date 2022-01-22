using NUnit.Framework;
using TfGM_API_Wrapper.Models.Services;

namespace TfGM_API_Wrapper_Tests.TestModels.TestServices
{
    public class TestTram
    {
        private string? _destination;
        private string? _carriages;
        private string? _status;
        private string? _wait;
        
        [SetUp]
        public void SetUp()
        {
            _destination = "Example Destination";
            _carriages = "Single";
            _status = "Due";
            _wait = "9";
        }

        [TearDown]
        public void TearDown()
        {
            _destination = null;
            _carriages = null;
            _status = null;
            _wait = null;
        }

        /// <summary>
        /// Test to try and get a new tram and verify the set dest, carriages, status and wait
        /// time.
        /// </summary>
        [Test]
        public void TestCreateNewTram()
        {
            Tram testTram = new Tram(_destination, _carriages, _status, _wait);
            Assert.NotNull(testTram);
            Assert.AreEqual(_destination, testTram.Destination);
            Assert.AreEqual(_carriages, testTram.Carriages);
            Assert.AreEqual(_status, testTram.Status);
            Assert.AreEqual(_wait, testTram.Wait);
        }
    }
}