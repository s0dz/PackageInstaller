using NUnit.Framework;
using PackageInstallerUtility;

namespace PackageInstallerUnitTests
{
    [TestFixture]
    public class DependencyValidatorTests
    {
        private DependencyValidator _validator;

        [SetUp]
        public void SetUp()
        {
            _validator = new DependencyValidator();
        }

        [Test]
        public void ValidateTestInput1()
        {
            var result = _validator.Validate(_validInput1);

            Assert.AreEqual(result, _validOutput1);
        }

        [Test]
        public void ValidateTestInput2()
        {
            var result = _validator.Validate(_validInput2);

            Assert.AreEqual(result, _validOutput2);
        }

        [Test]
        public void InvalidateTestInput()
        {
            var result = _validator.Validate(invalidInput);

            Assert.AreEqual(result, invalidOutput);
        }

        //private string validInput1 = "[\"KittenService: CamelCaser\", \"CamelCaser: \"]";
        private string[] _validInput1 = { "KittenService: CamelCaser", "CamelCaser: " };
        private string _validOutput1 = "CamelCaser, KittenService";

        private string[] _validInput2 = { "KittenService: ", "Leetmeme: Cyberportal", "Cyberportal: Ice", "CamelCaser: KittenService", "Fraudstream: Leetmeme", "Ice: " };
        private string _validOutput2 = "KittenService, Ice, Cyberportal, Leetmeme, CamelCaser, Fraudstream";

        private string[] invalidInput = { "KittenService: ","Leetmeme: Cyberportal", "Cyberportal: Ice","CamelCaser: KittenService","Fraudstream: ","Ice: Leetmeme" };
        private string invalidOutput = "Invalid Input: Dependencies contain a cycle";
    }
}