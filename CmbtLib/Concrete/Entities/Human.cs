// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Player.cs" company="Microsoft">
//   Copyright (c) 2011 Patrik Eidelöf
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CmbtLib.Concrete.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using CmbtLib.Abstract.Entities;

    /// <summary>
    /// A player entity
    /// </summary>
    public class Human : CombatEntityBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Human"/> class.
        /// </summary>
        public Human()
        {
            this.BaseArmor = 1;
            this.BaseDamage = 10;
            this.BaseEvadeChance = 10;
            this.BaseHitChance = 10;
        }
    }
}
