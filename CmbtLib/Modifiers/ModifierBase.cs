// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModifierBase.cs" company="Microsoft">
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
    /// base class for add or subtract modifiers
    /// </summary>
    public abstract class ModifierBase
    {
        /// <summary>
        ///   Gets or sets Value.
        /// </summary>
        public abstract int Value { get; set; }

        /// <summary>
        ///   Gets or sets Description.
        /// </summary>
        public abstract string Description { get; set; }
    }
}
