// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HitResult.cs" company="E&L Patrik Eidelöf">
//   Copyright (c) 2011 Patrik Eidelöf
// </copyright>
// <summary>
//   The hit result.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CmbtLib.Concrete.Results
{
    using Abstract.Results;

    /// <summary>
    /// The hit result.
    /// </summary>
    public class HitResult : CombatResultBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HitResult"/> class.
        /// </summary>
        public HitResult()
        {
            this.Result = "Hit";
        }

        /// <summary>
        /// Gets or sets Result.
        /// </summary>
        public override sealed string Result { get; set; }
    }
}