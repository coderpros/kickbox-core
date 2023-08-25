// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BalanceResponse.cs" company="coderPro.net">
//   Copyright 2023 coderPro.net. All rights reserved.
// </copyright>
// <summary>
//   Defines the BalanceResponse type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#nullable enable
namespace KickBox.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The balance response.
    /// </summary>
    public class BalanceResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BalanceResponse"/> class.
        /// </summary>
        /// <param name="balance">
        /// The balance remaining.
        /// </param>
        /// <param name="success">
        /// The success is a value indicating whether successful.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public BalanceResponse(uint balance, bool success, string? message)
        {
            this.Balance = balance;
            this.Success = success;
            this.Message = message;
        }

        /// <summary>
        /// Gets or sets the balance remaining.
        /// </summary>
        [JsonProperty("balance")]
        public uint Balance { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether successful.
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        [JsonProperty("message")]
        public string? Message { get; set; }
    }
}
