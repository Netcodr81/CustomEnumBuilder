using CustomEnumBuilderExtensions.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CustomEnum.Tests
{
    [TestClass]
    public class CustomEnumTests
    {
        [TestMethod]
        public void EnumValue_MatchesExpectedResult()
        {

            string expected = "M";
            string actual = GenderEnum.Male.Value;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EnumValue_DoesNotMatchExpectedResult()
        {

            string expected = "F";
            string actual = GenderEnum.Male.Value;

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void EnumDisplayName_MatchesExpectedResult()
        {

            string expected = "Male";
            string actual = GenderEnum.Male.DisplayName;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EnumDisplayName_DoesNotMatchExpectedResult()
        {

            string expected = "Female";
            string actual = GenderEnum.Male.DisplayName;

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void GenerateSelectListItem()
        {
            int expcted = 3;

            SelectList list = SelectListBuilder.GenerateSelectList(GenderEnum.GetAll<GenderEnum>());
            int actual = list.Count();



            Assert.AreEqual(expcted, actual);
        }
    }
}
