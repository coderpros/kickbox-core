﻿namespace KickBox.Core.Client
{
    using System.Net.Mail;
    using System.Threading.Tasks;

    /// <summary>
    /// The program.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">
        /// The command arguments array.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        private static async Task Main(string[] args)
        {
            var kickbox = new KickBoxApi("*** ADD API KEY HERE ***", "https://api.kickbox.com/v2");

            var verificationResponse1 = await kickbox.VerifyEmail(new MailAddress("info@coderpro.net"))
                                            .ConfigureAwait(true);

            var verificationResponse2 = await kickbox.VerifyBatch(
                                                mailAddresses: new[]
                                                                   {
                                                                       new MailAddress("brandon.osborne@gamil.com"),
                                                                       new MailAddress("info@coderpro.net")
                                                                   },
                                                fileName: "test file",
                                                batchVerificationCallback: null)
                                            .ConfigureAwait(false);

            var verificationResponse3 = await kickbox.CheckStatus(1234567)
                                            .ConfigureAwait(true);
        }
    }
}
