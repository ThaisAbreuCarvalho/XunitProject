using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiDomain.Utilities
{
    public static class ErrorFormatter
    {
        public static List<string> FormatException(Exception e)
        {
            var result = new List<string>();

            result.Add($"Exception: {e.Message}");
            result.Add($"Stack Trace: {e.StackTrace}");
            result.Add($"Inner Exception: {e.InnerException}");

            return result;
        }
    }
}
