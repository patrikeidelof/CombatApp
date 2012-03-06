// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BasicAttack.cs" company="E&L Patrik Eidelöf">
//   Copyright (c) 2011 Patrik Eidelöf
// </copyright>
// <summary>
//   A basic attack
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CmbtLib.Concrete.Commands
{
    using Abstract.Commands;
    using Abstract.Entities;
    using Abstract.Results;
    using Results;

    /// <summary>
    /// A basic attack
    /// </summary>
    public class BasicAttack : AttackCommandBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicAttack"/> class.
        /// </summary>
        /// <param name="attacker">
        /// The attacker.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        public BasicAttack(ICombatEntity attacker, ICombatEntity target) : base(attacker, target)
        {
            this.Description = "Basic CalculateAttack";
            this.BaseHitChance = attacker.BaseHitChance;
        }

        /// <summary>
        /// Performs the attack
        /// </summary>
        /// <returns>
        /// a result of the attack
        /// </returns>
        public override ICombatResult CalculateAttack()
        {
            int randomNumber = this.Random.Next(100);
            if (randomNumber < (this.GetFinalHitChance() - Target.BaseEvadeChance))
            {
                ICombatResult result = new HitResult { InflictedDamage = Attacker.BaseDamage, AbsorbedDamage = Target.BaseArmor };
                return result;
            }

            return new MissResult();
        }
    }
}