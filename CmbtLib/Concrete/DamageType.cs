// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DamageType.cs" company="Microsoft">
//   Copyright (c) 2011 Patrik Eidelöf
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CmbtLib.Concrete
{
    /// <summary>
    /// Different damage types
    /// </summary>
    public enum DamageType
    {
        /// <summary>
        /// Damage caused by some blunt object being applied with quick force
        /// </summary>
        Blunt,

        /// <summary>
        /// Damage caused by something pointy piercing into the entity
        /// </summary>
        Pierce,

        /// <summary>
        /// Damage caused by something slicing into the entity
        /// </summary>
        Cut,

        /// <summary>
        /// Damage caused by some sharp edged object being applied with quick force
        /// </summary>
        Cleave,

        /// <summary>
        /// Damage caused by preasure
        /// </summary>
        Crush,

        /// <summary>
        /// Damage caused by for instance fire
        /// </summary>
        Heat,

        /// <summary>
        /// Damage caused by relatively very low temperature
        /// </summary>
        Cold 
    }
}