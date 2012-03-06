// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EvadeModifier.cs" company="E&L Patrik Eidelöf">
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
    /// Modifier to entity evade chance. Value is added to entitys base evade chance and can be positive or negative
    /// </summary>
    public class EvadeModifier : ModifierBase
    {
        /// <summary>
        ///   Gets or sets Value.
        /// </summary>
        public override int Value
        {
            get; set;
        }

        /// <summary>
        ///   Gets or sets Description.
        /// </summary>
        public override string Description
        {
            get; set;
        }
    }
}
