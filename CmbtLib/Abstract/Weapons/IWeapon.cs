// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWeapon.cs" company="E&L Patrik Eidelöf">
//   Copyright (c) 2011 Patrik Eidelöf
// </copyright>
// <summary>
//   Interface for a weapon class
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CmbtLib.Abstract.Weapons
{
    /// <summary>
    /// Interface for a weapon class
    /// </summary>
    public interface IWeapon
    {
        /// <summary>
        ///   Gets or sets Name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        ///   Gets or sets Description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        ///   Gets or sets BaseDamage.
        /// </summary>
        int BaseDamage { get; set; }
    }
}