using NUnit.Framework;
using TfGM_API_Wrapper.Models;

namespace TfGM_API_Wrapper_Tests.TestModels
{
    public class TestWrapperDataModel
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
        /// Test to try and create a new model of the data model.
        /// The two versions created should share the same memory address
        /// as they should be the same object.
        /// </summary>
        [Test]
        public void TestCreateDataModelSingleton()
        {
            WrapperDataModel testModelA = WrapperDataModel.Instance;
            WrapperDataModel testModelB = WrapperDataModel.Instance;
            Assert.AreSame(testModelA, testModelB);
        }
    }
}