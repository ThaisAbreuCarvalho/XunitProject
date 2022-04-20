using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XunitTest.Utilities
{
    public static class AssertExtension
    {
        public static void MessageValidation(this ArgumentException exception, string message)
        {
            if (exception.Message == message)
                Assert.True(true);
            else
                Assert.False(true, $"Esperava a mensagem: {message}");
        }
    }
}
