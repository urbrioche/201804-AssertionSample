using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;

namespace AssertionSample
{
    [TestClass]
    public class AssertExceptionSample
    {
        [TestMethod]
        public void Divide_positive()
        {
            var calculator = new Calculator();
            var actual = calculator.Divide(5, 2);
            Assert.AreEqual(2.5m, actual);
        }

        //[ExpectedException(typeof(YouShallNotPassException))]
        [TestMethod]
        public void Divide_Zero()
        {
            var calculator = new Calculator();
            //var actual = calculator.Divide(5, 0);
            Action action = () => calculator.Divide(5, 0);
            action.Should().Throw<YouShallNotPassException>();
            //how to assert expected exception?
            //never use try/catch in unit test
        }
    }

    public class Calculator
    {
        public Calculator()
        {
            //throw new YouShallNotPassException();
        }

        public decimal Divide(decimal first, decimal second)
        {
            if (second == 0)
            {
                throw new YouShallNotPassException();
            }

            return first / second;
        }
    }

    public class YouShallNotPassException : Exception
    {
    }
}