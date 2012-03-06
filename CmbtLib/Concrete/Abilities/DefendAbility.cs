// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefendAbility.cs" company="E&L Patrik Eidelöf">
//   Copyright (c) 2011 Patrik Eidelöf
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CmbtLib.Concrete.Abilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using CmbtLib.Abstract.Abilities;
    using CmbtLib.Abstract.Entities;

    /// <summary>
    /// Ability that tries to improve the defence of an entity
    /// </summary>
    public class DefendAbility : IAbility, ISustainedAbility
    {
        /// <summary>
        /// Entity that has control over this ability
        /// </summary>
        private ICombatEntity abilityOwner;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefendAbility"/> class.
        /// </summary>
        public DefendAbility()
        {
            this.Name = "Defend";
        }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets a value indicating whether the ability is Active.
        /// </summary>
        public bool Active { get; private set; }

        /// <summary>
        /// Gets or sets the entity that has control over this ability
        /// </summary>
        public ICombatEntity AbilityOwner
        {
            get
            {
                return this.abilityOwner;
            }

            set
            {
                this.abilityOwner = value;
            }
        }

        /// <summary>
        /// Cease using this ability
        /// </summary>
        public void CeaseAbility()
        {
            this.Active = false;
        }

        /// <summary>
        /// Start using this ability
        /// </summary>
        public void StartAbility()
        {
            this.Active = true;
        }
    }
}
