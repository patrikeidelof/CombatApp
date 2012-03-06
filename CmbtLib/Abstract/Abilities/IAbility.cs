// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAbility.cs" company="E&L Patrik Eidel�f">
//   Copyright (c) 2011 Patrik Eidel�f
// </copyright>
// <summary>
//   Defines the IAbility type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CmbtLib.Abstract.Abilities
{
    /// <summary>
    /// Interface for abilites
    /// </summary>
    public interface IAbility
    {
        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        string Description { get; set; }
    }
}
