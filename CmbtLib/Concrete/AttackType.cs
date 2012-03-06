// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttackType.cs" company="Microsoft">
//   Copyright (c) 2011 Patrik Eidelöf
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CmbtLib.Concrete
{
    /// <summary>
    /// Defining the different attack types
    /// </summary>
    public enum AttackType
    {
        /// <summary>
        /// Attacking at close range, direct contact
        /// </summary>
        CloseCombat,

        /// <summary>
        /// Attacking with a ranged weapon, typically by some kind of projectile wich is aimed more or less straight at the target
        /// </summary>
        Ranged,

        /// <summary>
        /// Attacking with something that must not be aimed directly at the target. For instance with a cruise missile or "voodoo".
        /// </summary>
        Indirect
    }
}