using System;
using NUnit.Framework;
using TfGM_API_Wrapper.Models.Services;

namespace TfGM_API_Wrapper_Tests.TestModels.TestServices
{
    public class TestTram
    {
        private string? _destination;
        private string? _diffDestination;
        private string? _carriages;
        private string? _diffCarriages;
        private string? _status;
        private string? _diffStatus;
        private string? _wait;
        private string? _diffWait;

        private Tram? _tram;
        private Tram? _diffTram;
        
        [SetUp]
        public void SetUp()
        {
            _destination = "Example Destination";
            _diffDestination = "Different Destination";
            _carriages = "Single";
            _diffCarriages = "Double";
            _status = "Due";
            _diffStatus = "Departing";
            _wait = "9";
            _diffWait = "0";
            
            _tram = new Tram(_destination, _carriages, _status, _wait);
            _diffTram = new Tram(_diffDestination, _diffCarriages, _diffStatus, _diffWait);
        }

        [TearDown]
        public void TearDown()
        {
            _destination = null;
            _diffDestination = null;
            _carriages = null;
            _diffCarriages = null;
            _status = null;
            _diffStatus = null;
            _wait = null;
            _diffWait = null;

            _tram = null;
            _diffTram = null;
        }

        /// <summary>
        /// Test to try and get a new tram and verify the set dest, carriages, status and wait
        /// time.
        /// </summary>
        [Test]
        public void TestCreateNewTram()
        {
            Assert.NotNull(_tram);
            Assert.AreEqual(_destination, _tram?.Destination);
            Assert.AreEqual(_carriages, _tram?.Carriages);
            Assert.AreEqual(_status, _tram?.Status);
            Assert.AreEqual(_wait, _tram?.Wait);
        }

        /// <summary>
        /// Test to create a new tram with different values.
        /// This resulting tram should have the new values and not the values
        /// from the previous test.
        /// </summary>
        [Test]
        public void TestCreateDifferentTram()
        {
            Assert.NotNull(_diffTram);
            Assert.AreEqual(_diffDestination, _diffTram?.Destination);
            Assert.AreEqual(_diffCarriages, _diffTram?.Carriages);
            Assert.AreEqual(_diffStatus, _diffTram?.Status);
            Assert.AreEqual(_diffWait, _diffTram?.Wait);
        }

        /// <summary>
        /// Create a tram with a null destination
        /// This should throw an null args exception
        /// </summary>
        [Test]
        public void TestTramNullDest()
        {
            Assert.Throws(Is.TypeOf<ArgumentNullException>()
                    .And.Message.EqualTo("Value cannot be null. (Parameter 'destination')"),
                delegate
                {
                    Tram tram = new Tram(null, _carriages, _status, _wait);
                });
        }

        /// <summary>
        /// Create a tram with null carriages.
        /// This should throw a Arg null exception.
        /// </summary>
        [Test]
        public void TestTramNullCarriages()
        {
            Assert.Throws(Is.TypeOf<ArgumentNullException>()
                    .And.Message.EqualTo("Value cannot be null. (Parameter 'carriages')"),
                delegate
                {
                    Tram tram = new Tram(_destination, null, _status, _wait);
                });
        }

        /// <summary>
        /// Creates a tram with a null status.
        /// This should throw an arg null exception
        /// </summary>
        [Test]
        public void TestTramNullStatus()
        {
            Assert.Throws(Is.TypeOf<ArgumentNullException>()
                    .And.Message.EqualTo("Value cannot be null. (Parameter 'status')"),
                delegate
                {
                    Tram tram = new Tram(_destination, _carriages, null, _wait);
                });
        }


        /// <summary>
        /// Create a tram with a null wait.
        /// This should throw a arg null exception.
        /// </summary>
        [Test]
        public void TestTramNullWait()
        {
            Assert.Throws(Is.TypeOf<ArgumentNullException>()
                    .And.Message.EqualTo("Value cannot be null. (Parameter 'wait')"),
                delegate
                {
                    Tram tram = new Tram(_destination, _carriages, _status, null);
                });
        }
    }
}