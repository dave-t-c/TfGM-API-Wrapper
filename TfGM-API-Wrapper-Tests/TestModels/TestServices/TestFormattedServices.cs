using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using TfGM_API_Wrapper.Models.Services;

namespace TfGM_API_Wrapper_Tests.TestModels.TestServices
{
    public class TestFormattedServices
    {
        private string? _destination;
        private string? _diffDestination;
        private string? _carriages;
        private string? _status;
        private string? _wait;
        private string? _diffWait;
        private Tram? _tram;
        private Tram? _tramDiffDestination;
        private Tram? _tramSameDestinationDiffWait;
        private FormattedServices? _formattedServices;

        [SetUp]
        public void SetUp()
        {
            _destination = "Example Destination";
            _diffDestination = "Different Destination";
            _carriages = "Single";
            _status = "Due";
            _wait = "9";
            _diffWait = "1";
            _tram = new Tram(_destination, _carriages, _status, _wait);
            _tramDiffDestination = new Tram(_diffDestination, _carriages, _status, _wait);
            _tramSameDestinationDiffWait = new Tram(_destination, _carriages, _status, _diffWait);
            _formattedServices = new FormattedServices();
        }

        [TearDown]
        public void TearDown()
        {
            _destination = null;
            _diffDestination = null;
            _carriages = null;
            _status = null;
            _wait = null;
            _diffWait = null;
            _tram = null;
            _tramDiffDestination = null;
            _tramSameDestinationDiffWait = null;
            _formattedServices = null;
        }

        /// <summary>
        /// Test to add a tram service to the Formatted Services.
        /// This should add a new entry in the destinations dictionary
        /// and should contain a set of length 1.
        /// </summary>
        [Test]
        public void TestAddTramService()
        {
            _formattedServices?.AddService(_tram);
            Dictionary<string, SortedSet<Tram?>?>? result = _formattedServices?.Destinations;
            Assert.NotNull(result);
            Debug.Assert(_destination != null, nameof(_destination) + " != null");
            Assert.IsTrue(result?.ContainsKey(_destination));
            SortedSet<Tram?>? trams = result?[_destination];
            Assert.IsNotNull(trams);
            Assert.IsTrue(trams?.Count == 1);
            Assert.IsTrue(trams?.Contains(_tram));
            
        }

        /// <summary>
        /// Test to add a tram with a different destination.
        /// This should mean the dict still contains 1 item, but contains
        /// the different key.
        /// </summary>
        [Test]
        public void TestAddDifferentDestination()
        {
            _formattedServices?.AddService(_tramDiffDestination);
            Dictionary<string, SortedSet<Tram?>?>? result = _formattedServices?.Destinations;
            Assert.NotNull(result);
            Debug.Assert(_diffDestination != null, nameof(_diffDestination) + " != null");
            Assert.IsTrue(result?.ContainsKey(_diffDestination));
            SortedSet<Tram?>? trams = result?[_diffDestination];
            Assert.IsNotNull(trams);
            Assert.IsTrue(trams?.Count == 1);
            Assert.IsTrue(trams?.Contains(_tramDiffDestination));
        }

        /// <summary>
        /// Test to add two trams with the same destination.
        /// This should return a sorted set with two items.
        /// </summary>
        [Test]
        public void TestAddTramSameDestination()
        {
            _formattedServices?.AddService(_tram);
            _formattedServices?.AddService(_tramSameDestinationDiffWait);
            Dictionary<string, SortedSet<Tram?>?>? result = _formattedServices?.Destinations;
            Assert.NotNull(result);
            Debug.Assert(_destination != null, nameof(_destination) + " != null");
            Assert.IsTrue(result?.ContainsKey(_destination));
            SortedSet<Tram?>? trams = result?[_destination];
            Assert.AreEqual(2, trams?.Count);
            Assert.IsTrue(trams?.Contains(_tram));
            Assert.IsTrue(trams?.Contains(_tramSameDestinationDiffWait));
        }
    }
}