// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISustainedAbility.cs" company="E&L Patrik Eidelöf">
//   Copyright (c) 2011 Patrik Eidelöf
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CmbtLib.Abstract.Abilities
{
    /// <summary>
    /// Interface for a sustained ability
    /// </summary>
    public interface ISustainedAbility
    {
        /// <summary>
        /// Gets a value indicating whether the ability is Active.
        /// </summary>
        bool Active { get; }

        /// <summary>
        /// Cease using this ability
        /// </summary>
        void CeaseAbility();

        /// <summary>
        /// Start using this ability
        /// </summary>
        void StartAbility();
    }
}
