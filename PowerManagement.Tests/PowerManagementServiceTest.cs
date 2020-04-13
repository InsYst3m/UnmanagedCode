using NUnit.Framework;

namespace PowerManagement.Tests
{
    [TestFixture]
    public class PowerManagementServiceTest
    {
        private PowerManagementService _service;

        [SetUp]
        public void Setup()
        {
            _service = new PowerManagementService();
        }

        [Test]
        public void GetSystemBatteryStateTest()
        {
            var state = _service.GetSystemBatteryState();

            Assert.IsNotNull(state);
            Assert.IsFalse(state.BatteryPresent);
        }
    }
}