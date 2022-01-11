using NUnit.Framework;
using TfGM_API_Wrapper.Models.Resources;

namespace TfGM_API_Wrapper_Tests.TestModels.TestResources
{
    /// <summary>
    /// Test class for the ImportedResources class.
    /// </summary>
    public class TestImportedResources
    {
        [SetUp]
        public void SetUp()
        {
            
        }

        [TearDown]
        public void TearDown()
        {
            
        }

        /// <summary>
        /// Test to create a new ImportedResources.
        /// This should contain an empty List of stops for ImportedStops.
        /// </summary>
        [Test]
        public void TestCreateEmptyImportedStops()
        {
            ImportedResources importedResources = new ImportedResources();
            Assert.IsNotNull(importedResources.ImportedStops);
            Assert.AreEqual(0, importedResources.ImportedStops.Count);
        }

        /// <summary>
        /// Test to try and get the StationNamesToTlarefs dict.
        /// This should not be null and should be empty.
        /// </summary>
        [Test]
        public void TestCreateEmptyStationNamesToTlarefs()
        {
            ImportedResources importedResources = new ImportedResources();
            Assert.IsNotNull(importedResources.StationNamesToTlaref);
            Assert.AreEqual(0, importedResources.StationNamesToTlaref.Count);
        }
    }
}