// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICombatResult.cs" company="E&L Patrik Eidelöf">
//   Copyright (c) 2011 Patrik Eidelöf
// </copyright>
// <summary>
//   The i combat result.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CmbtLib.Abstract.Results
{
    /// <summary>
    /// The i combat result.
    /// </summary>
    public interface ICombatResult
    {
        /// <summary>
        ///   Gets or sets InflictedDamage.
        /// </summary>
        int InflictedDamage { get; set; }

        /// <summary>
        /// Gets or sets AbsorbedDamage.
        /// </summary>
        int AbsorbedDamage { get; set; }

        /// <summary>
        /// Gets or sets Result.
        /// </summary>
        string Result { get; set; }

        /// <summary>
        /// Get some description of the combat result
        /// </summary>
        /// <returns>
        /// a string describing the combat result
        /// </returns>
        string ResultDescription();
    }
}