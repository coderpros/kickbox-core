// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BatchResponse.cs" company="coderPro.net">
//   Copyright 2020 coderPro.net All rights reserved.
// </copyright>
// <summary>
//   The batch response from the KickBox API.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#nullable enable
namespace KickBox.Core.Models
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// The batch response from the KickBox API.
    /// </summary>
    public class BatchResponse
    {
        /// <summary>
        /// Gets or sets the id of the job.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the download url.
        /// </summary>
        [JsonProperty("download_url")]
        public string? DownloadUrl { get; set; }

        /// <summary>
        /// Gets or sets the created at date and time.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the status of the job.
        /// </summary>
        [JsonProperty("status")]
        public Models.Status Status { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the job was successful.
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the description of any error associated with the request.
        /// </summary>
        [JsonProperty("error")]
        public string? Error { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        [JsonProperty("message")]
        public string? Message { get; set; }

        /// <summary>
        /// Gets or sets the progress of a batch verification.
        /// </summary>
        [JsonProperty("progress")]
        public Models.ProgressModel? Progress { get; set; }

        /// <summary>
        /// Gets or sets the status of a completed batch verification.
        /// </summary>
        [JsonProperty("stats")]
        public Models.StatsModel? Stats { get; set; }
    }
}
