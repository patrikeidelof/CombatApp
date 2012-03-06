// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CombatEntityBase.cs" company="E&L Patrik Eidelöf">
//   Copyright (c) 2011 Patrik Eidelöf
// </copyright>
// <summary>
//   Abstract base for a combat entity
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CmbtLib.Abstract.Entities
{
    using System;
    using System.Collections.Generic;

    using CmbtLib.Abstract.Abilities;
    using CmbtLib.Abstract.Commands;
    using CmbtLib.Abstract.Results;
    using CmbtLib.Concrete;
    using CmbtLib.Concrete.Commands;

    /// <summary>
    /// Abstract base for a combat entity
    /// </summary>
    public class CombatEntityBase : ICombatEntity
    {
        #region Constants and Fields

        /// <summary>
        ///   Contains a list of abilities for this entity
        /// </summary>
        private readonly IList<IAbility> abilities;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///   Initializes a new instance of the <see cref = "CombatEntityBase" /> class.
        /// </summary>
        protected CombatEntityBase()
        {
            this.BaseDamage = 10;
            this.BaseArmor = 0;
            this.abilities = new List<IAbility>();
        }

        #endregion

        #region Properties

        /// <summary>
        ///   Gets Abilities.
        /// </summary>
        public IList<IAbility> Abilities
        {
            get
            {
                return this.abilities;
            }
        }

        /// <summary>
        ///   Gets or sets BaseArmor.
        /// </summary>
        public int BaseArmor { get; protected set; }

        /// <summary>
        ///   Gets or sets BaseDamage.
        /// </summary>
        public int BaseDamage { get; protected set; }

        /// <summary>
        ///   Gets or sets BaseEvadeChance.
        /// </summary>
        public int BaseEvadeChance { get; protected set; }

        /// <summary>
        ///   Gets or sets BaseHitChance.
        /// </summary>
        public int BaseHitChance { get; protected set; }

        /// <summary>
        /// Gets DamagePoints wich indicate how much damage the entity can take before it is neutralized
        /// </summary>
        public long DamagePoints
        {
            get; private set;
        }

        /// <summary>
        /// Gets MaxDamagePoints.
        /// </summary>
        public long MaxDamagePoints
        {
            get; private set;
        }

        /// <summary>
        ///   Gets or sets Name.
        /// </summary>
        public string Name { get; protected set; }

        #endregion

        #region Implemented Interfaces

        #region ICombatEntity

        /// <summary>
        /// Creates a BasicAttack out of this entitys base attack values
        /// </summary>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <returns>
        /// An IAttackCommand
        /// </returns>
        public IAttackCommand BasicAttack(ICombatEntity target)
        {
            return new BasicAttack(this, target);
        }

        /// <summary>
        /// Issues an attack on the target
        /// </summary>
        /// <param name="attack">
        /// The attack.
        /// </param>
        /// <returns>
        /// A combat result
        /// </returns>
        public ICombatResult PerformAttack(IAttackCommand attack)
        {
            if (attack.Attacker != this)
            {
                throw new ArgumentException(
                    "The attacking entity in the attack command is not the same as the performing attacker. In other words the attack was created by another entity");
            }

            ICombatResult result = attack.CalculateAttack();
            GlobalLog.GetInstance().LogAttack(attack, result);
            return result;
        }

        /// <summary>
        /// Inflict damage to this entity
        /// </summary>
        public void InflictDamage(DamageType damageType, long value)
        {
            // TODO fix this
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}