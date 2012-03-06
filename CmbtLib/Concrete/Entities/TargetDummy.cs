// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TargetDummy.cs" company="E&L Patrik Eidelöf">
//   Copyright (c) 2011 Patrik Eidelöf
// </copyright>
// <summary>
//   Represents a basic Entity. A target dummy.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CmbtLib.Concrete.Entities
{
    using Abstract.Entities;

    /// <summary>
    /// Represents a basic Entity. A target dummy.
    /// </summary>
    public class TargetDummy : CombatEntityBase
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref = "TargetDummy" /> class.
        /// </summary>
        public TargetDummy()
            : this("TargetDummy")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TargetDummy"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public TargetDummy(string name) 
        {
            this.Name = name;
            this.BaseHitChance = 1;
            this.BaseEvadeChance = 1;
        }
    }
}