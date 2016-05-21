using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AsdXMLLibrary.Tests.Helper
{
    public static class ExceptionAssert
    {
        public static void Throws<TException>(Action action, string message)
            where TException : Exception
        {
            try
            {
                action();
                Assert.Fail("Exception of type {0} expected; got none exception", typeof(TException).Name);
            }
            catch (TException ex)
            {
                Assert.AreEqual(message, ex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception of type {0} expected; got exception of type {1}", typeof(TException).Name, ex.GetType().Name);
            }
        }

        public static void Throws<TException>(Action action)
            where TException : Exception
        {
            try
            {
                action();
                Assert.Fail("Exception of type {0} expected; got none exception", typeof(TException).Name);
            }
            catch (TException ex)
            {
                // all good, we got the exception we expected.
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception of type {0} expected; got exception of type {1}", typeof(TException).Name, ex.GetType().Name);
            }
        }
    }
}
