// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttackCommandBase.cs" company="E&L Patrik Eidelöf">
//   Copyright (c) 2011 Patrik Eidelöf
// </copyright>
// <summary>
//   CalculateAttack command base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CmbtLib.Abstract.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CmbtLib.Concrete.Results;
    using CmbtLib.Modifiers;

    using Entities;
    using Results;

    /// <summary>
    /// CalculateAttack command base.
    /// </summary>
    public abstract class AttackCommandBase : IAttackCommand
    {
        /// <summary>
        ///   List of hit modifiers
        /// </summary>
        private readonly List<HitModifier> hitModifiers = new List<HitModifier>();

        /// <summary>
        ///   List of hit multipliers
        /// </summary>
        private readonly List<HitMultiplier> hitMultipliers = new List<HitMultiplier>();

        /// <summary>
        ///   Object for randoming
        /// </summary>
        private readonly Random random;

        /// <summary>
        ///   the base chance to hit
        /// </summary>
        private int baseHitChance;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttackCommandBase"/> class.
        /// </summary>
        /// <param name="attacker">
        /// The attacker.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        protected AttackCommandBase(ICombatEntity attacker, ICombatEntity target)
        {
            this.random = new Random();
            this.Description = string.Empty;
            this.Attacker = attacker;
            this.Target = target;
            this.BaseHitChance = attacker.BaseHitChance;            
        }

        #region IAttackCommand Members

        /// <summary>
        ///   Gets or sets Attacker.
        /// </summary>
        public ICombatEntity Attacker { get; set; }

        /// <summary>
        ///   Gets or sets Target.
        /// </summary>
        public ICombatEntity Target { get; set; }

        /// <summary>
        ///   Gets or sets HitChance.
        /// </summary>
        public int BaseHitChance
        {
            get { return this.baseHitChance; }
            set { this.baseHitChance = value; }
        }

        /// <summary>
        ///   Gets or sets Description.
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        ///   Gets Random.
        /// </summary>
        protected Random Random
        {
            get { return this.random; }
        }
        
        /// <summary>
        /// Adds a hit modifier
        /// </summary>
        /// <param name="hitModifier">
        /// The hit Modifier.
        /// </param>
        /// <returns>
        /// The modified attack.
        /// </returns>
        public IAttackCommand ModifyHit(HitModifier hitModifier)
        {
            this.hitModifiers.Add(hitModifier);
            return this;
        }

        /// <summary>
        /// Adds a hit multiplier
        /// </summary>
        /// <param name="hitMultiplier">
        /// The hit Multiplier.
        /// </param>
        public void MultiplyHit(HitMultiplier hitMultiplier)
        {
            this.hitMultipliers.Add(hitMultiplier);
        }

        /// <summary>
        /// Calculates and gets the final hit chance
        /// </summary>
        /// <returns>
        /// The final modified hit chance
        /// </returns>
        public int GetFinalHitChance()
        {
            double hitChance = this.baseHitChance + this.hitModifiers.Sum(hitModifier => hitModifier.Value);

            hitChance = this.hitMultipliers.Aggregate(hitChance, (current, hitMultiplier) => current * hitMultiplier.Value);

            return Convert.ToInt32(hitChance);
        }

        /// <summary>
        /// Performs an attack
        /// </summary>
        /// <returns>
        /// ICombatResult with the result of the attack
        /// </returns>
        public virtual ICombatResult CalculateAttack()
        {
            int randomNumber = this.Random.Next(100);
            if (randomNumber < (this.Attacker.BaseHitChance - this.Target.BaseEvadeChance))
            {
                ICombatResult result = new HitResult { InflictedDamage = this.Attacker.BaseDamage, AbsorbedDamage = this.Target.BaseArmor };
                return result;
            }

            return new MissResult();
        }

        #endregion
    }
}