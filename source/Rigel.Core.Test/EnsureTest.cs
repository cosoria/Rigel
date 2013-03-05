using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Rigel.Core.Test
{
    [TestFixture]
    public class EnsureTest
    {
        [Test]
        public void That_Can_Handle_Expression()
        {
            object param;
            param = Guid.NewGuid();
            var s = string.Empty;
            var i = 7;

            Ensure.That(param is Guid);
            Ensure.That(string.IsNullOrEmpty(s));
            Ensure.That(i == 7);
        }

        [Test]
        public void That_Throws_And_Has_Correct_Message()
        {
            try
            {
                Guid param = Guid.NewGuid();
                Ensure.That(param == Guid.Empty);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                var argEx = (ex as InvalidOperationException);
                Assert.IsNotNull(argEx);
                Assert.AreEqual(argEx.Message, "Condition specified was not met for the expression");
            }
        }


        [Test]
        public void Argument_NotNull_Can_Handle_Expression()
        {
            try
            {
                object param = null;
                Ensure.Argument.NotNull(() => param);
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }


        [Test]
        public void Argument_NotNull_Throws_And_Has_Correct_Parameter_Name_And_Message()
        {
            try
            {
                string paramName = null;
                Ensure.Argument.NotNull(() => paramName);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                var argEx = (ex as ArgumentNullException);
                Assert.IsNotNull(argEx);
                Assert.AreEqual(argEx.ParamName, "paramName");
                Assert.AreEqual(argEx.Message, "Parameter of type 'String' can't be null\r\nParameter name: paramName");
            }
        }

        [Test]
        public void Argument_NotNullOrEmpty_Can_Handle_IEnumerable_Expressions()
        {
            try
            {
                IEnumerable<string> param = null;
                Ensure.Argument.NotNullOrEmpty(() => param);
                Assert.Fail();
            }
            catch (Exception ex)
            {
               Assert.Pass();
            }
        }

        [Test]
        public void Argument_NotNullOrEmpty_Throws_With_Null_And_Has_Correct_Parameter_Name_And_Message()
        {
            try
            {
                IEnumerable<string> paramName = null;
                Ensure.Argument.NotNullOrEmpty(() => paramName);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                var argEx = (ex as ArgumentNullException);
                Assert.IsNotNull(argEx);
                Assert.AreEqual(argEx.ParamName, "paramName");
                Assert.AreEqual(argEx.Message, "Parameter of type 'IEnumerable`1' can't be null or empty\r\nParameter name: paramName");
            }
        }

        [Test]
        public void Argument_NotNullOrEmpty_Throws_With_Empty_And_Has_Correct_Parameter_Name_And_Message()
        {
            try
            {
                IEnumerable<string> paramName = Enumerable.Empty<string>();
                Ensure.Argument.NotNullOrEmpty(() => paramName);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                var argEx = (ex as ArgumentNullException);
                Assert.IsNotNull(argEx);
                Assert.AreEqual(argEx.ParamName, "paramName");
                Assert.AreEqual(argEx.Message, "Parameter of type 'IEnumerable`1' can't be null or empty\r\nParameter name: paramName");
            }
        }

    }
}