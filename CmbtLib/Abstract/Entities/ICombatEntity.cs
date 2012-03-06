// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICombatEntity.cs" company="E&L Patrik Eidelöf">
//   Copyright (c) 2011 Patrik Eidelöf
// </copyright>
// <summary>
//   Base interface for a CombatEntity
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CmbtLib.Abstract.Entities
{
    using System.Collections.Generic;

    using CmbtLib.Abstract.Abilities;

    using Commands;
    using Results;
using CmbtLib.Concrete;

    /// <summary>
    /// Base interface for a CombatEntity
    /// </summary>
    public interface ICombatEntity
    {
        /// <summary>
        /// Gets DamagePoints wich indicate how much damage the entity can take before it is neutralized
        /// </summary>
        long DamagePoints { get; }

        /// <summary>
        /// Gets MaxDamagePoints.
        /// </summary>
        long MaxDamagePoints { get; }

        /// <summary>
        ///   Gets Name.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///   Gets BaseHitChance.
        /// </summary>
        int BaseHitChance { get; }

        /// <summary>
        ///   Gets BaseEvadeChance.
        /// </summary>
        int BaseEvadeChance { get; }

        /// <summary>
        /// Gets BaseDamage.
        /// </summary>
        int BaseDamage { get; }

        /// <summary>
        /// Gets BaseArmor.
        /// </summary>
        int BaseArmor { get; }

        /// <summary>
        /// Gets Abilities.
        /// </summary>
        IList<IAbility> Abilities { get; }

        /// <summary>
        /// Creates a BasicAttack out of this entitys base attack values
        /// </summary>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <returns>
        /// An IattackCommand representing a basic attack
        /// </returns>
        IAttackCommand BasicAttack(ICombatEntity target);

        /// <summary>
        /// Issues an attack on the target
        /// </summary>
        /// <param name="attack">
        /// The attack.
        /// </param>
        /// <returns>
        /// A combat result
        /// </returns>
        ICombatResult PerformAttack(IAttackCommand attack);

        /// <summary>
        /// Inflict damage to this entity
        /// </summary>
        /// <param name="damageType">
        /// The damage Type.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        void InflictDamage(DamageType damageType, long value);
    }
}