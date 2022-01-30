using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;
using TfGM_API_Wrapper.Models.Services;
using TfGM_API_Wrapper.Models.Stops;

namespace TfGM_API_Wrapper_Tests.TestModels.TestServices
{
    public class TestServiceFormatter
    {
        private const string ValidApiResponsePath = "../../../Resources/ExampleApiIResponse.json";
        private UnformattedServices? _unformattedServices;
        private ServiceFormatter? _serviceFormatter;
        private List<UnformattedServices?>? _unformattedServicesList;
        
        [SetUp]
        public void SetUp()
        {
            using var reader = new StreamReader(ValidApiResponsePath);
            var jsonString = reader.ReadToEnd();
            _unformattedServices = JsonConvert.DeserializeObject<UnformattedServices>(jsonString);
            _serviceFormatter = new ServiceFormatter();
            _unformattedServicesList = new List<UnformattedServices>();
             
        }

        [TearDown]
        public void TearDown()
        {
            _unformattedServices = null;
            _serviceFormatter = null;
            _unformattedServicesList = null;
        }

        /// <summary>
        /// Test to format services into a Formatted Services object.
        /// This should return a Formatted Services object with 1 destination and 3 trams.
        /// This should also contain a message.
        /// </summary>
        [Test]
        public void TestFormatService()
        {
            _unformattedServicesList?.Add(_unformattedServices);
            Debug.Assert(_serviceFormatter != null, nameof(_serviceFormatter) + " != null");
            FormattedServices result = _serviceFormatter.FormatServices(_unformattedServicesList);
            Assert.NotNull(result);
            Assert.AreEqual(1, result.Destinations.Count);
            SortedSet<Tram> destResult = result.Destinations["Manchester Airport"];
            Assert.NotNull(destResult);
            Assert.AreEqual(3, destResult.Count);
            Assert.AreEqual(1, result.Messages.Count);
        }
    }
}