namespace KickBox.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The stats model used in completed batch verifications.
    /// </summary>
    public class StatsModel
    {
        /// <summary>
        /// Gets or sets the number of deliverable email addresses.
        /// </summary>
        [JsonProperty("deliverable")]
        public uint Deliverable { get; set; }

        /// <summary>
        /// Gets or sets the undeliverable email addresses.
        /// </summary>
        [JsonProperty("undeliverable")]
        public uint Undeliverable { get; set; }

        /// <summary>
        /// Gets or sets the number of risky emails in a batch.
        /// </summary>
        [JsonProperty("risky")]
        public uint Risky { get; set; }

        /// <summary>
        /// Gets or sets the number of unknown emails in a batch.
        /// </summary>
        [JsonProperty("unknown")]
        public uint Unknown { get; set; }

        /// <summary>
        /// Gets or sets the sendex of all emails in a batch.
        /// </summary>
        [JsonProperty("sendex")]
        public uint Sendex { get; set; }

        /// <summary>
        /// Gets or sets the total address count in a batch.
        /// </summary>
        [JsonProperty("addresses")]
        public uint AddressCount{ get; set; }
    }
}
