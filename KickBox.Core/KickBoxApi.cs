#nullable enable
namespace KickBox.Core
{
    #region USINGS
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Net.Mail;
    using System.Text;
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    #endregion
    public sealed class KickBoxApi
    {
        #region PRIVATE BACKERS
        private readonly string _apiKey;
        private readonly string _apiUrl;
        #endregion

        #region CONSTRUCTOR
        public KickBoxApi(string apiKey, string apiUrl)
        {
            this._apiKey = apiKey;
            this._apiUrl = apiUrl;
        }
        #endregion

        #region METHODS
        /// <summary>
        /// The verify email function verifies a single email address. 
        /// </summary>
        /// <param name="mailAddress">
        /// The email address to be verified.
        /// </param>
        /// <param name="timeout">
        /// The time in seconds before a timeout (default 30 seconds).
        /// </param>
        /// <returns>
        /// The <see cref="Task{KickBoxResponse}"/> from the API.
        /// </returns>
        public async Task<Models.KickBoxResponse> VerifyEmail(System.Net.Mail.MailAddress mailAddress, int? timeout = null)
        {
            using var httpClient = new HttpClient();
            using var httpResponse = await httpClient.GetAsync($"{this._apiUrl}/verify?apikey={this._apiKey}&email={mailAddress.Address}&timeout={timeout}")
                                         .ConfigureAwait(true);
            try
            {
                return JsonConvert.DeserializeObject<Models.KickBoxResponse>(
                    await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(true));
            }
            catch (Exception e)
            {
                // TODO: Add logging
                throw;
            }
        }

        /// <summary>
        /// The verify batch method queues a list of email addresses to be verified. 
        /// </summary>
        /// <param name="mailAddresses">
        /// The email addresses to be verified.
        /// </param>
        /// <param name="fileName">
        /// The *desired* fileName.
        /// </param>
        /// <param name="batchVerificationCallback">
        /// The URL to be called after verification has completed.
        /// </param>
        /// <returns>
        /// The <see cref="Task{BatchResponse}"/> from the API.
        /// </returns>
        public async Task<Models.BatchResponse> VerifyBatch(IEnumerable<MailAddress> mailAddresses, string? fileName = null, Uri? batchVerificationCallback = null)
        {
            // var addresses = mailAddresses.Aggregate(string.Empty, (current, address) => current + $"{current}\n");
            var addresses = mailAddresses.Aggregate(string.Empty, (current, address) => current + $"{address.Address}\n");

            using var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("text/csv"));

            if (!string.IsNullOrEmpty(fileName))
            {
                // Add the desired file name to the header.
                httpClient.DefaultRequestHeaders.Add("X-Kickbox-Filename", fileName);
            }

            if (batchVerificationCallback != null)
            {
                // Add the callback URL to the header
                httpClient.DefaultRequestHeaders.Add("X-Kickbox-Callback", batchVerificationCallback.ToString());
            }

            using var httpResponse = await httpClient.PutAsync($"{this._apiUrl}/verify-batch?apikey={this._apiKey}",
                                             new StringContent(addresses, Encoding.UTF8, "text/csv"))
                                         .ConfigureAwait(true);
            try
            {
                return JsonConvert.DeserializeObject<Models.BatchResponse>(
                    await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(true));
            }
            catch (Exception e)
            {
                // TODO: Add logging
                throw;
            }
        }

        /// <summary>
        /// The check status method checks the status of a bulk verification job.
        /// </summary>
        /// <param name="jobId">
        /// The id of the batch verification job.
        /// </param>
        /// <returns>
        /// The <see cref="Task{BatchResponse}"/> from the API.
        /// </returns>
        public async Task<Models.BatchResponse> CheckStatus(int jobId)
        {
            using var httpClient = new HttpClient();
            using var httpResponse = await httpClient.GetAsync($"{this._apiUrl}/verify-batch/{jobId}/?apikey={this._apiKey}")
                                         .ConfigureAwait(true);
            try
            {
                return JsonConvert.DeserializeObject<Models.BatchResponse>(
                    await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(true));
            }
            catch (Exception e)
            {
                // TODO: Add logging
                throw;
            }
        }
        #endregion
    }
}
