namespace KickBox.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The processing .
    /// </summary>
    public class ProgressModel
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
        /// Gets or sets the number of unknown emails in a batch.
        /// </summary>
        [JsonProperty("total")]
        public uint Total { get; set; }

        /// <summary>
        /// Gets or sets the number of unprocessed emails in a batch.
        /// </summary>
        [JsonProperty("unprocessed")]
        public uint Unprocessed { get; set; }
    }
}
