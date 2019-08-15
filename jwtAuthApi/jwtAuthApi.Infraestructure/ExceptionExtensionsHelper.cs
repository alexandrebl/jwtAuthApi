using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace jwtAuthApi.Infraestructure
{
    public static class ExceptionExtensions
    {
        public static string ToLogString(this Exception exception, string environmentStackTrace)
        {
            var environmentStackTraceLines = ExceptionExtensions.GetUserStackTraceLines(environmentStackTrace);
            environmentStackTraceLines.RemoveAt(0);

            var stackTraceLines = ExceptionExtensions.GetStackTraceLines(exception.StackTrace);
            stackTraceLines.AddRange(environmentStackTraceLines);

            var fullStackTrace = string.Join(Environment.NewLine, stackTraceLines);
            var logMessage = exception.Message + Environment.NewLine + fullStackTrace;

            return logMessage;
        }

        private static List<string> GetStackTraceLines(string stackTrace)
        {
            return stackTrace.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
        }

        private static List<string> GetUserStackTraceLines(string fullStackTrace)
        {
            var outputList = new List<string>();
            var regex = new Regex(@"([^\)]*\)) in (.*):line (\d)*$");

            var stackTraceLines = ExceptionExtensions.GetStackTraceLines(fullStackTrace);
            foreach (var stackTraceLine in stackTraceLines)
            {
                if (!regex.IsMatch(stackTraceLine))
                {
                    continue;
                }

                outputList.Add(stackTraceLine);
            }

            return outputList;
        }
    }
}