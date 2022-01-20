using NUnit.Framework;

namespace TfGM_API_Wrapper_Tests.TestModels.TestServices
{
    /// <summary>
    /// Test class for the ServiceProcessor.
    /// </summary>
    public class TestServiceProcessor
    {
        private MockServiceRequester? _mockServiceRequester;
        [SetUp]
        public void SetUp()
        {
            _mockServiceRequester = new MockServiceRequester();
        }

        [TearDown]
        public void TearDown()
        {
            _mockServiceRequester = null;
        }
    }
}