using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParametersParser;
namespace ParametersParserTests {
    [TestClass]
    public class ParametersParserTest {
        [TestMethod]
        public void ParametersParserTest_BooleanValue_shouldReturnTrue_IfParameterIsPresent() {
            string[] parameters = new string[] {"-p"};
            Assert.IsTrue(new ParameterParser(parameters).getParameterValue("-p").BooleanValue());
        }

        [TestMethod]
        public void ParametersParserTest_BooleanValue_shouldReturnFalse_IfParameterValueIsNotPresent() {
            string[] parameters = new string[] { "-p" };
            Assert.IsFalse(new ParameterParser(parameters).getParameterValue("-x").BooleanValue());
        }

        [TestMethod]
        public void ParametersParserTest_IntegerValue_shouldReturnParamterAsInt_IfIsValid() {
            string[] parameters = new string[] { "-p", "1220" };
            Assert.AreEqual(1220, new ParameterParser(parameters).getParameterValue("-p").IntegerValue());
        }

        [ExpectedException(typeof(ParameterException))]
        [TestMethod]
        public void ParametersParserTest_IntegerValue_shouldThrownParameterException_IfParameterValueIsNotPresent() {
            string[] parameters = new string[] { "-p" };
            new ParameterParser(parameters).getParameterValue("-p").IntegerValue();
        }

        [ExpectedException(typeof(ParameterException))]
        [TestMethod]
        public void ParametersParserTest_IntegerValue_shouldThrownParameterExceptionInt_IfParameterValueIsNotValid() {
            string[] parameters = new string[] { "-p", "ssss" };
            new ParameterParser(parameters).getParameterValue("-p").IntegerValue();
        }

        [ExpectedException(typeof(ParameterNotFoundException))]
        [TestMethod]
        public void ParametersParserTest_IntegerValue_shouldThrownParameterNotFoundExceptionInt_IfParameterIsNotPresentAndIsRequired() {
            string[] parameters = new string[] { "-x", "ssss" };
            new ParameterParser(parameters).getParameterValue("-p", true).IntegerValue();
        }

        [TestMethod]
        public void ParametersParserTest_MultipleParametersValues() {
            string[] parameters = new string[] { "-x", "localhost", "-p", "8080" };
            var parser = new ParameterParser(parameters);
            Assert.AreEqual("localhost", parser.getParameterValue("-x").StringValue());
            Assert.AreEqual(8080, parser.getParameterValue("-p").IntegerValue());
        }
    }
}
