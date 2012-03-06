namespace CmbtTest
{
    using System;
    using CmbtLib;
    using CmbtLib.Abstract.Abilities;
    using CmbtLib.Abstract.Commands;
    using CmbtLib.Abstract.Entities;
    using CmbtLib.Abstract.Results;
    using CmbtLib.Concrete;
    using CmbtLib.Concrete.Abilities;
    using CmbtLib.Concrete.Entities;
    using CmbtLib.Concrete.Results;
    using CmbtLib.Modifiers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Testclass for CmbtLib
    /// </summary>
    [TestClass]
    public class CmbtLibTest
    {
        /// <summary>
        /// Sending an attack at a target yields a result
        /// </summary>
        [TestMethod]
        public void Attacking_A_Target_Yields_A_Result()
        {
            // Arrange
            ICombatEntity target = new TargetDummy();
            ICombatEntity attacker = new TargetDummy();
            
            // Act
            ICombatResult result = attacker.PerformAttack(attacker.BasicAttack(target));
           
            // Assert            
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Test that hitting a target yields a result
        /// </summary>
        [TestMethod]
        public void Hitting_A_Target_Yields_A_Hit_Result()
        {
            // Arrange
            ICombatEntity target = new TargetDummy();
            ICombatEntity attacker = new TargetDummy();
            HitModifier guaranteedHit = new HitModifier() { Description = "GuaranteeHit", Value = 100 };

            // Act 
            ICombatResult result = attacker.PerformAttack(attacker.BasicAttack(target).ModifyHit(guaranteedHit));
            
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(HitResult));
        }

        /// <summary>
        /// Test that a hit yields some kind of damage
        /// </summary>
        [TestMethod]
        public void Hitting_A_Target_Yields_A_Result_With_Damage()
        {
            // Arrange, make target defenceless to guarantee a hit
            ICombatEntity target = new TargetDummy();
            ICombatEntity attacker = new TargetDummy();
            HitModifier guaranteedHit = new HitModifier() { Description = "GuaranteeHit", Value = 100 };

            // Act 
            HitResult result = attacker.PerformAttack(attacker.BasicAttack(target).ModifyHit(guaranteedHit)) as HitResult;

            // Assert
            Assert.IsTrue(result.InflictedDamage > 0);
        }

        /// <summary>
        /// Test that attacks are logged
        /// </summary>
        [TestMethod]
        public void An_Attack_Is_Logged_In_Global_Combat_Log()
        {
            // Arrange
            ICombatEntity target = new TargetDummy();
            ICombatEntity attacker = new TargetDummy();
            double logCount = GlobalLog.GetInstance().GetLogCount();
            
            // Act 
            attacker.PerformAttack(attacker.BasicAttack(target));

            // Assert
            Assert.AreNotEqual(GlobalLog.GetInstance().GetLogCount(), logCount);
        }

        /// <summary>
        /// Test that the hit chance can be increased
        /// </summary>
        [TestMethod]
        public void Hit_Chance_Can_Be_Increased()
        {
            // Arrange
            ICombatEntity target = new TargetDummy();
            ICombatEntity attacker = new TargetDummy();
            
            // Act
            IAttackCommand attackCommand = attacker.BasicAttack(target);
            attackCommand.ModifyHit(new HitModifier() { Description = "testMultiplier", Value = 100 });

            // Assert            
            Assert.AreEqual(attackCommand.BaseHitChance + 100, attackCommand.GetFinalHitChance());
        }

        /// <summary>
        /// Test that the hit chance can be decreased
        /// </summary>
        [TestMethod]
        public void Hit_Chance_Can_Be_Decreased()
        {
            // Arrange
            ICombatEntity target = new TargetDummy();
            ICombatEntity attacker = new TargetDummy();

            // Act
            IAttackCommand attackCommand = attacker.BasicAttack(target);
            attackCommand.ModifyHit(new HitModifier() { Description = string.Empty, Value = -10 });

            // Assert            
            Assert.AreEqual(attackCommand.BaseHitChance - 10, attackCommand.GetFinalHitChance());
        }

        /// <summary>
        /// Test that the hit chance can be increased
        /// </summary>
        [TestMethod]
        public void Hit_Chance_Can_Be_Multiplied()
        {
            // Arrange
            ICombatEntity target = new TargetDummy();
            ICombatEntity attacker = new TargetDummy();

            // Act
            IAttackCommand attackCommand = attacker.BasicAttack(target);
            attackCommand.MultiplyHit(new HitMultiplier() { Description = "testMultiplier", Value = 2 });

            // Assert            
            Assert.AreEqual(attackCommand.BaseHitChance * 2, attackCommand.GetFinalHitChance());
        }

        /// <summary>
        /// Test that the hit chance can be devided
        /// </summary>
        [TestMethod]
        public void Hit_Chance_Can_Be_Devided()
        {
            // Arrange
            ICombatEntity target = new TargetDummy();
            ICombatEntity attacker = new TargetDummy();

            // Act
            IAttackCommand attackCommand = attacker.BasicAttack(target);
            attackCommand.MultiplyHit(new HitMultiplier() { Description = "testDivider", Value = .5 });

            // Assert            
            Assert.AreEqual(attackCommand.BaseHitChance / 2, attackCommand.GetFinalHitChance());
        }

        /// <summary>
        /// Test that hit chance can be modified on an attack
        /// </summary>
        [TestMethod]
        public void Hit_Chance_Can_Be_Modified()
        {            
            // Arrange
            ICombatEntity target = new TargetDummy();
            ICombatEntity attacker = new TargetDummy();

            // Act
            IAttackCommand attackCommand = attacker.BasicAttack(target);
            attackCommand.ModifyHit(new HitModifier() { Description = string.Empty, Value = -10 });
            attackCommand.ModifyHit(new HitModifier() { Description = string.Empty, Value = 20 });
            attackCommand.MultiplyHit(new HitMultiplier() { Description = "testDivider", Value = .5 });
            attackCommand.MultiplyHit(new HitMultiplier() { Description = "testDivider", Value = .5 });

            // Assert            
            Assert.AreEqual(Convert.ToInt32(((double)attackCommand.BaseHitChance + 10) / 4), attackCommand.GetFinalHitChance());
        }

        /// <summary>
        /// Performing an attack thats created in another user yields an exception
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Performing_An_Attack_Created_By_Another_Entity_Yields_An_Exception()
        {
            // Arrange
            ICombatEntity target = new TargetDummy();
            ICombatEntity attacker = new TargetDummy();

            // Act
            // The Attacker performs an attack that is created by the target.
            // In other words the attacker commands another entity to perform an attack
            ICombatResult result = attacker.PerformAttack(target.BasicAttack(target));

            // Assert
            // Assert is made by expecting exception
            Assert.IsNull(result);
        }

        /// <summary>
        /// Drive development to where entities can have abilities added to them
        /// </summary>
        [TestMethod]
        public void Abilities_Can_Be_Added_To_An_Entity()
        {
            // Arrange
            ICombatEntity entity = new TargetDummy();

            // Act
            IAbility defend = new DefendAbility();
            entity.Abilities.Add(defend);

            // Assert
            Assert.IsTrue(entity.Abilities.Contains(defend));
        }
    }
}
