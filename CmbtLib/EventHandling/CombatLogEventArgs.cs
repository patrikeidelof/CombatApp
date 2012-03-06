namespace CmbtLib.EventHandling
{
    using System;

    /// <summary>
    /// Log Eventargs
    /// </summary>
    public class CombatLogEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CombatLogEventArgs"/> class.
        /// </summary>
        /// <param name="logMessage">
        /// The log message.
        /// </param>
        public CombatLogEventArgs(string logMessage)
        {
            this.Message = logMessage;
        }

        /// <summary>
        ///   Gets or sets Message.
        /// </summary>
        public string Message { get; set; }
    }
}
