namespace CmbtLib.EventHandling
{
    /// <summary>
    /// Delegate for combat log events
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The log event args.
    /// </param>
    public delegate void CombatLogEventHandler(object sender, CombatLogEventArgs e);
}