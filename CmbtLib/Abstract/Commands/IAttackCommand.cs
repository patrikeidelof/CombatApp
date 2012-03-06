// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAttackCommand.cs" company="E&L Patrik Eidelöf">
//   Copyright (c) 2011 Patrik Eidelöf
// </copyright>
// <summary>
//   Interface for an attackCommand
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CmbtLib.Abstract.Commands
{
    using CmbtLib.Modifiers;

    using Entities;
    using Results;

    /// <summary>
    /// Interface for an attackCommand
    /// </summary>
    public interface IAttackCommand
    {
        /// <summary>
        ///   Gets Attacker.
        /// </summary>
        ICombatEntity Attacker { get; }

        /// <summary>
        ///   Gets Target.
        /// </summary>
        ICombatEntity Target { get; }

        /// <summary>
        ///   Gets or sets HitChance.
        /// </summary>
        int BaseHitChance { get; set; }

        /// <summary>
        ///   Gets or sets Description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Adds a hit modifier
        /// </summary>
        /// <param name="hitModifier">
        /// The hit Modifier.
        /// </param>
        /// <returns>
        /// The modified attack.
        /// </returns>
        IAttackCommand ModifyHit(HitModifier hitModifier);

        /// <summary>
        /// Adds a hit multiplier
        /// </summary>
        /// <param name="hitMultiplier">
        /// The hit Multiplier.
        /// </param>
        void MultiplyHit(HitMultiplier hitMultiplier);

        /// <summary>
        /// Calculates and gets the final hit chance
        /// </summary>
        /// <returns>
        /// The final modified hit chance
        /// </returns>
        int GetFinalHitChance();

        /// <summary>
        /// Performs the attack on a target.
        /// </summary>
        /// <returns>
        /// An ICombatResult with the result of the attack.
        /// </returns>
        ICombatResult CalculateAttack();
    }
}