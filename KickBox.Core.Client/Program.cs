namespace KickBox.Core.Client
{
    using System;
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
            var kickbox = new KickBoxApi("***Your API Key***", "https://api.kickbox.com/v2");

            var balanceResponse = await kickbox.GetBalanceAsync().ConfigureAwait(true);

            var verificationResponse1 = await kickbox.VerifyEmailAsync(new MailAddress("info@coderpro.net"))
                                            .ConfigureAwait(true);

            var verificationResponse2 = await kickbox.VerifyBatchAsync(
                                                mailAddresses: new[]
                                                                   {
                                                                       new MailAddress("brandon.osborne@gamil.com"),
                                                                       new MailAddress("info@coderpro.net")
                                                                   },
                                                fileName: "test file",
                                                batchVerificationCallback: null)
                                            .ConfigureAwait(false);

            var verificationResponse3 = await kickbox.CheckStatusAsync(1234567)
                                            .ConfigureAwait(true);

            Console.WriteLine($"Your remaining balance is: {balanceResponse}");
            Console.WriteLine($"Verification Response 1: {verificationResponse1}");
            Console.WriteLine($"Verification Response 2: {verificationResponse2}");
            Console.WriteLine($"Verification Response 3: {verificationResponse3}");
        }
    }
}
