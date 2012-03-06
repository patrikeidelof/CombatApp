// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MissResult.cs" company="E&L Patrik Eidelöf">
//   Copyright (c) 2011 Patrik Eidelöf
// </copyright>
// <summary>
//   A combat result representing a miss
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CmbtLib.Concrete.Results
{
    using Abstract.Results;

    /// <summary>
    /// A combat result representing a miss
    /// </summary>
    public class MissResult : CombatResultBase
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref = "MissResult" /> class.
        /// </summary>
        public MissResult()
        {
            this.InflictedDamage = 0;
            this.Result = "Miss";
        }

        /// <summary>
        /// Gets or sets Result.
        /// </summary>
        public override sealed string Result { get; set; }
    }
}