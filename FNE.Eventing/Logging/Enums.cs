using System;

namespace FNE.Eventing.Logging
{
    /// <summary>
    /// Specifies the severity of a log message.
    /// </summary>
    public enum Severity
    {
        /// <summary>
        /// Indicates an informative message.
        /// </summary>
        Information = 0,

        /// <summary>
        /// Indicates a potential problem, but not a fatal processing error.
        /// </summary>
        Warning,

        /// <summary>
        /// Indicates a fatal processing error.
        /// </summary>
        Error
    }
}