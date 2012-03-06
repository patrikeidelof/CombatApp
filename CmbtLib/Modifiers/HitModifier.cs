// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HitModifier.cs" company="E&L Patrik Eidelöf">
//   Copyright (c) 2011 Patrik Eidelöf
// </copyright>
// <summary>
//   Class holding a hit chance modifier
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CmbtLib.Modifiers
{
    /// <summary>
    /// Class holding a hit chance modifier
    /// </summary>
    public class HitModifier : ModifierBase
    {
        /// <summary>
        ///   Gets or sets Value.
        /// </summary>
        public override int Value { get; set; }

        /// <summary>
        ///   Gets or sets Description.
        /// </summary>
        public override string Description { get; set; }
    }
}