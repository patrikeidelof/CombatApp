namespace CombatConsoleApp
{
    using System;

    using CmbtLib;
    using CmbtLib.Concrete;
    using CmbtLib.Concrete.Entities;
    using CmbtLib.EventHandling;
    using CmbtLib.Modifiers;

    /// <summary>
    /// Test program to see what we can do
    /// </summary>
    public class Program
    {
        /// <summary>
        /// the logger
        /// </summary>
        private static GlobalLog logger = GlobalLog.GetInstance();

        /// <summary>
        /// This is the "main"
        /// </summary>
        /// <param name="args">
        /// The args. ??
        /// </param>
        public static void Main(string[] args)
        {
            logger.LogMessage += LogMessageHandler;

            var dummy1 = new TargetDummy("Kalle");
            var dummy2 = new TargetDummy("Urban");
            var drunkenness = new HitModifier() { Description = "Drunk", Value = -10 };
            for (int i = 0; i < 10; i++)
            {
                dummy1.PerformAttack(dummy1.BasicAttack(dummy2).ModifyHit(drunkenness));
                drunkenness.Value -= 10;
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Sends all combat messages to the console.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="logEventArgs">
        /// The log event args.
        /// </param>
        public static void LogMessageHandler(object sender, CombatLogEventArgs logEventArgs)
        {
            Console.WriteLine(logEventArgs.Message);
        }
    }
}
