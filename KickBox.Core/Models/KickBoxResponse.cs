// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KickBoxResponse.cs" company="coderPro.net">
//   Copyright 2020 coderPro.net. All rights reserved.
// </copyright>
// <summary>
//   The kick box response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace KickBox.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The kick box response.
    /// </summary>
    public class KickBoxResponse
    {
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        [JsonProperty("result")]
        public Result Result { get; set; }

        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether role.
        /// </summary>
        [JsonProperty("role")]
        public bool Role { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether free.
        /// </summary>
        [JsonProperty("free")]
        public bool Free { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether disposable.
        /// </summary>
        [JsonProperty("disposable")]
        public bool Disposable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether accept all.
        /// </summary>
        [JsonProperty("accept_all")]
        public bool AcceptAll { get; set; }

        /// <summary>
        /// Gets or sets the did you mean.
        /// </summary>
        [JsonProperty("did_you_mean")]
        public string DidYouMean { get; set; }

        /// <summary>
        /// Gets or sets the quality of the email address.
        /// </summary>
        [JsonProperty("sendex")]
        public float Sendex { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        [JsonProperty("user")]
        public string User { get; set; }

        /// <summary>
        /// Gets or sets the domain.
        /// </summary>
        [JsonProperty("domain")]
        public string Domain { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether success.
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
