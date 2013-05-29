using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNE.Eventing.Logging
{
    /// <summary>
    /// Provides a set of static logging methods to extend the <see cref="FNE.Eventing.Logging.ILogginProvider"/> interface.
    /// </summary>
    public static class LoggingProviderExtensions
    {
        /// <summary>
        /// Logs a message at severity <see cref="FNE.Eventing.Logging.Severity.Information"/>.
        /// </summary>
        /// <param name="loggingProvider">An <see cref="FNE.Eventing.Logging.ILoggingProvider"/> to delegate to.</param>
        /// <param name="message">A composite format log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public static void LogInformation(this ILoggingProvider loggingProvider, string message, params object[] args)
        {
            loggingProvider.Log(Severity.Information, message, args);
        }

        /// <summary>
        /// Logs a message at severity <see cref="FNE.Eventing.Logging.Severity.Warning"/>.
        /// </summary>
        /// <param name="loggingProvider">An <see cref="FNE.Eventing.Logging.ILoggingProvider"/> to delegate to.</param>
        /// <param name="message">A composite format log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public static void LogWarning(this ILoggingProvider loggingProvider, string message, params object[] args)
        {
            loggingProvider.Log(Severity.Warning, message, args);
        }

        /// <summary>
        /// Logs a message at severity <see cref="FNE.Eventing.Logging.Severity.Error"/>.
        /// </summary>
        /// <param name="loggingProvider">An <see cref="FNE.Eventing.Logging.ILoggingProvider"/> to delegate to.</param>
        /// <param name="message">A composite format log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public static void LogError(this ILoggingProvider loggingProvider, string message, params object[] args)
        {
            loggingProvider.Log(Severity.Error, message, args);
        }
    }
}
