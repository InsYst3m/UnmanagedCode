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

        [Test]
        public void GetSystemPowerInformationTest()
        {
            var info = _service.GetSystemPowerInformation();

            Assert.IsNotNull(info);
        }

        [Test]
        public void GetLastSleepTimeTest()
        {
            var sleepTime = _service.GetLastSleepTime();

            Assert.IsTrue(sleepTime > 0);
        }

        [Test]
        public void GetLastWakeTimeTest()
        {
            var wakeTime = _service.GetLastWakeTime();

            Assert.IsTrue(wakeTime > 0);
        }
    }
}