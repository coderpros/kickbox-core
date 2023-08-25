// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Status.cs" company="coderPro.net">
//   Copyright 2020 coderPro.net. All rights reserved.
// </copyright>
// <summary>
//   The status of a bulk verification.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace KickBox.Core.Models
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The status of a bulk verification.
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// Indicates that a bulk verification is queued to start.
        /// </summary>
        [EnumMember(Value = "starting")]
        Starting,

        /// <summary>
        /// Indicates that a bulk verification is currently being processed.
        /// </summary>
        [EnumMember(Value = "processing")]
        Processing,

        /// <summary>
        /// Indicates that a bulk verification is completed.
        /// </summary>
        [EnumMember(Value = "completed")]
        Completed,

        /// <summary>
        /// Indicates that a bulk verification failed.
        /// </summary>
        [EnumMember(Value = "failed")]
        Failed
    }
}
