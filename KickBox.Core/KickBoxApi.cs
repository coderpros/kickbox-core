// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Status.cs" company="coderPro.net">
//   Copyright 2020 coderPro.net. All rights reserved.
// </copyright>
// <summary>
//   The status of a bulk verification.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
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
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    #endregion

    /// <summary>
    /// The KickBox API Wrapper.
    /// </summary>
    public sealed class KickBoxApi
    {
        #region PRIVATE FIELDS

        /// <summary>
        /// The API key.
        /// </summary>
        private readonly string apiKey;

        /// <summary>
        /// The API url.
        /// </summary>
        private readonly string apiUrl;
        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="KickBoxApi"/> class.
        /// </summary>
        /// <param name="apiKey">
        /// The api key.
        /// </param>
        /// <param name="apiUrl">
        /// The api url.
        /// </param>
        public KickBoxApi(string apiKey, string apiUrl)
        {
            this.apiKey = apiKey;
            this.apiUrl = apiUrl;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// The check status method asynchronously checks the status of a bulk verification job.
        /// </summary>
        /// <param name="jobId">
        /// The id of the batch verification job.
        /// </param>
        /// <returns>
        /// The <see cref="Task{BatchResponse}"/> from the API.
        /// </returns>
        public async Task<Models.BatchResponse> CheckStatusAsync(int jobId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var httpResponse = await httpClient
                                              .GetAsync($"{this.apiUrl}/verify-batch/{jobId}/?apikey={this.apiKey}")
                                              .ConfigureAwait(true))
                {
                    try
                    {
                        return JsonConvert.DeserializeObject<Models.BatchResponse>(await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(true));
                    }
                    catch (Exception e)
                    {
                        // TODO: Add logging
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// The check status method synchronously checks the status of a bulk verification job.
        /// </summary>
        /// <param name="jobId">
        /// The id of the batch verification job.
        /// </param>
        /// <returns>
        /// The <see cref="Models.BatchResponse"/> from the API.
        /// </returns>
        [Obsolete("Use async version wherever possible.")]
        public Models.BatchResponse CheckStatus(int jobId)
        {
            return Task.Run(async () => await this.CheckStatusAsync(jobId).ConfigureAwait(false)).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Asynchronously gets the remaining balance.
        /// </summary>
        /// <returns>
        /// The <see cref="Task{BalanceResponse}"/>.
        /// </returns>
        public async Task<Models.BalanceResponse> GetBalanceAsync()
        {
            using (var httpClient = new HttpClient())
            {
                using (var httpResponse = await httpClient
                                              .GetAsync($"{this.apiUrl}/balance?apikey={this.apiKey}")
                                              .ConfigureAwait(true))
                {
                    try
                    {
                        return JsonConvert.DeserializeObject<Models.BalanceResponse>(await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(true));
                    }
                    catch (Exception e)
                    {
                        // TODO: Add logging
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Synchronously gets the remaining balance.
        /// </summary>
        /// <returns>
        /// The <see cref="Models.BalanceResponse"/>.
        /// </returns>
        [Obsolete("Use async version wherever possible.")]
        public Models.BalanceResponse GetBalance()
        {
            return Task.Run(async () => await this.GetBalanceAsync().ConfigureAwait(false)).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// The verify batch method asynchronously queues a list of email addresses to be verified. 
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
        public async Task<Models.BatchResponse> VerifyBatchAsync(IEnumerable<MailAddress> mailAddresses, string? fileName = null, Uri? batchVerificationCallback = null)
        {
            // var addresses = mailAddresses.Aggregate(string.Empty, (current, address) => current + $"{current}\n");
            var addresses = mailAddresses.Aggregate(string.Empty, (current, address) => current + $"{address.Address}\n");

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/csv"));

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

                using (var httpResponse = await httpClient.PutAsync($"{this.apiUrl}/verify-batch?apikey={this.apiKey}", new StringContent(addresses, Encoding.UTF8, "text/csv"))
                                              .ConfigureAwait(true))
                {
                    try
                    {
                        return JsonConvert.DeserializeObject<Models.BatchResponse>(await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(true));
                    }
                    catch (Exception e)
                    {
                        // TODO: Add logging
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// The verify batch method synchronously queues a list of email addresses to be verified. 
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
        /// The <see cref="Models.BatchResponse"/> from the API.
        /// </returns>
        [Obsolete("Use async version wherever possible.")]
        public Models.BatchResponse VerifyBatch (IEnumerable<MailAddress> mailAddresses, string? fileName = null, Uri? batchVerificationCallback = null)
        {
            return Task.Run(async () => await this.VerifyBatchAsync(mailAddresses, fileName, batchVerificationCallback).ConfigureAwait(false)).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// The verify email function asynchronously verifies a single email address. 
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
        public async Task<Models.KickBoxResponse> VerifyEmailAsync(System.Net.Mail.MailAddress mailAddress, int? timeout = null)
        {
            using (var httpClient = new HttpClient())
            {
                using (var httpResponse = await httpClient.GetAsync($"{this.apiUrl}/verify?apikey={this.apiKey}&email={mailAddress.Address}&timeout={timeout}")
                                              .ConfigureAwait(true))
                {
                    try
                    {
                        return JsonConvert.DeserializeObject<Models.KickBoxResponse>(await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(true));
                    }
                    catch (Exception e)
                    {
                        // TODO: Add logging
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// The verify email function synchronously verifies a single email address. 
        /// </summary>
        /// <param name="mailAddress">
        /// The email address to be verified.
        /// </param>
        /// <param name="timeout">
        /// The time in seconds before a timeout (default 30 seconds).
        /// </param>
        /// <returns>
        /// The <see cref="Models.KickBoxResponse"/> from the API.
        /// </returns>
        [Obsolete("Use async version wherever possible.")]
        public Models.KickBoxResponse VerifyEmail(System.Net.Mail.MailAddress mailAddress, int timeout)
        {
            return Task.Run(async () => await this.VerifyEmailAsync(mailAddress, timeout).ConfigureAwait(false)).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        #endregion
    }
}
