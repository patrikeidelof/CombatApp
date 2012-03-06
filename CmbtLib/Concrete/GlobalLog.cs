// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GlobalLog.cs" company="E&L Patrik Eidelöf">
//   Copyright (c) 2011 Patrik Eidelöf
// </copyright>
// <summary>
//   The global log.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CmbtLib.Concrete
{
    using Abstract.Commands;
    using Abstract.Results;
    using EventHandling;
    using log4net;
    using log4net.Config;

    /// <summary>
    /// The global log.
    /// </summary>
    public class GlobalLog
    {
        /// <summary>
        ///   Define a static logger variable so that it references the
        ///   Logger instance named "GlobalLog".
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(GlobalLog));

        /// <summary>
        ///   The the instance.
        /// </summary>
        private static GlobalLog theInstance;

        /// <summary>
        ///   The log counter.
        /// </summary>
        private long logCounter;

        /// <summary>
        ///   Prevents a default instance of the <see cref = "GlobalLog" /> class from being created.
        /// </summary>
        private GlobalLog()
        {
            this.logCounter = 0;
            BasicConfigurator.Configure();
        }

        /// <summary>
        ///   Eventhandler for combat log
        /// </summary>
        public event CombatLogEventHandler LogMessage;

        /// <summary>
        ///   Gets or sets LastMessage.
        /// </summary>
        public string LastMessage { get; set; }

        /// <summary>
        /// The get instance.
        /// </summary>
        /// <returns>
        /// The only instance of global log
        /// </returns>
        public static GlobalLog GetInstance()
        {
            if (theInstance == null)
            {
                theInstance = new GlobalLog();
            }

            return theInstance;
        }

        /// <summary>
        /// Get the log count
        /// </summary>
        /// <returns>
        /// result of how many log items have been created
        /// </returns>
        public long GetLogCount()
        {
            return this.logCounter;
        }

        /// <summary>
        /// The log attack.
        /// </summary>
        /// <param name="attack">
        /// The attack.
        /// </param>
        /// <param name="result">
        /// The result.
        /// </param>
        public void LogAttack(IAttackCommand attack, ICombatResult result)
        {
            this.logCounter++;
            string logMessage = string.Format("{0} performed {1} on {2} with the result: \n\r {3}.", attack.Attacker.Name, attack.Description, attack.Target.Name, result.ResultDescription());
            Log.Info("log4net: " + logMessage);
            this.LastMessage = logMessage;
            this.InvokeLogMessage(logMessage);
        }

        /// <summary>
        /// Invokes a log message
        /// </summary>
        /// <param name="logMessage">
        /// The log Message.
        /// </param>
        private void InvokeLogMessage(string logMessage)
        {
            var handler = this.LogMessage;
            if (handler != null)
            {
                handler(this, new CombatLogEventArgs(logMessage));
            }
        }
    }
}