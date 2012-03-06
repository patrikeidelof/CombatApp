// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HitMultiplier.cs" company="E&L Patrik Eidelöf">
//   Copyright (c) 2011 Patrik Eidelöf
// </copyright>
// <summary>
//   Class holding a hit chance multiplier
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CmbtLib.Modifiers
{
    /// <summary>
    /// Class holding a hit chance multiplier
    /// </summary>
    public class HitMultiplier : MultiplierBase
    {
        /// <summary>
        ///   Gets or sets Value.
        /// </summary>
        public override double Value { get; set; }

        /// <summary>
        ///   Gets or sets Description.
        /// </summary>
        public override string Description { get; set; }
    }
}