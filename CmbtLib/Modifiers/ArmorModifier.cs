// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArmorModifier.cs" company="E&L Patrik Eidelöf">
//   Copyright (c) 2011 Patrik Eidelöf
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CmbtLib.Modifiers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Modifier to entity armor. Value is added to entitys base armor and can be positive or negative
    /// </summary>
    public class ArmorModifier : ModifierBase
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
