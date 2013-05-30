using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNE.Eventing.Logging
{
    /// <summary>
    /// Provides methods to log information, warnings and errors during event processing.
    /// </summary>
    public interface ILoggingProvider
    {
        /// <summary>
        /// Logs an exception as <see cref="LCC.Eventing.Logging.Severity.Error"/>.
        /// </summary>
        /// <param name="exception">The <see cref="Exception"/> to log.</param>
        void Log(Exception exception);

        /// <summary>
        /// Logs a message.
        /// </summary>
        /// <param name="severity">The <see cref="LCC.Eventing.Logging.Severity"/> of the message.</param>
        /// <param name="message">A composite format log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void Log(Severity severity, string message, params object[] args);
    }
}
