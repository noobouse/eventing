using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FNE.Eventing.Logging;

namespace FNE.Eventing.Samples.ConsoleServer
{
    internal class NLogLoggingProvider : ILoggingProvider
    {
        //
        // Fields

        private NLog.Logger logger;

        //
        // Constructors

        internal NLogLoggingProvider()
            : base()
        {
            this.logger = NLog.LogManager.GetLogger("NLogLoggingProvider");
        }

        public void Log(Severity severity, string message, params object[] args)
        {
            switch (severity)
            {
                default:
                case Severity.Information:
                    this.logger.Info(message, args);
                    break;

                case Severity.Warning:
                    this.logger.Warn(message, args);
                    break;

                case Severity.Error:
                    this.logger.Error(message, args);
                    break;
            }
        }
    }
}
