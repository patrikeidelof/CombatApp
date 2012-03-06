// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CombatResultBase.cs" company="E&L Patrik Eidelöf">
//   Copyright (c) 2011 Patrik Eidelöf
// </copyright>
// <summary>
//   The combat result base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CmbtLib.Abstract.Results
{
    /// <summary>
    /// The combat result base.
    /// </summary>
    public abstract class CombatResultBase : ICombatResult
    {
        /// <summary>
        ///   Gets or sets InflictedDamage.
        /// </summary>
        public int InflictedDamage { get; set; }

        /// <summary>
        /// Gets or sets AbsorbedDamage.
        /// </summary>
        public int AbsorbedDamage { get; set; }

        /// <summary>
        /// Gets or sets Result.
        /// </summary>
        public abstract string Result { get; set; }

        /// <summary>
        /// Get some description of the combat result
        /// </summary>
        /// <returns>
        /// a string describing the combat result
        /// </returns>
        public virtual string ResultDescription()
        {
            return string.Format("Inflicted {0} damage. {1} damage was absorbed.", this.InflictedDamage, this.AbsorbedDamage);
        }
    }
}