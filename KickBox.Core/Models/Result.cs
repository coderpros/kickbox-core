// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Result.cs" company="coderPro.net">
//   Copyright 2020 coderPro.net. All rights reserved.
// </copyright>
// <summary>
//   The result from KickBox.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace KickBox.Core.Models
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The result from KickBox.
    /// </summary>
    public enum Result
    {
        /// <summary>
        /// The email address was identified as deliverable.
        /// </summary>
        [EnumMember(Value = "deliverable")]
        Deliverable,

        /// <summary>
        /// The email address was identified as undeliverable.
        /// </summary>
        [EnumMember(Value = "undeliverable")]
        Undeliverable,

        /// <summary>
        /// The email address was identified as risky.
        /// </summary>
        [EnumMember(Value = "risky")]
        Risky,

        /// <summary>
        /// The email address was identified as unknown.
        /// </summary>
        [EnumMember(Value = "unknown")]
        Unknown
    }
}
