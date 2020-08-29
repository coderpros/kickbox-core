# kickbox-core

A [KickBox.io](https://kickbox.io) API wrapper for .Net Core version 5.0 written in C#.

## How to use

- Create a free account at [Kickbox.io](https://kickbox.io).
- Sign up for an API Key.
- Add your own Kickbox API key when you instantiate the KickBox object.

I've included a test client application in this project, but here is is an elaboration on how to use each of the methods.

This is available as a NuGet package here: [Nuget.org](https://www.nuget.org/packages/KickBox.Core/)

### Verify a single email address

```C#
var kickbox = new KickBoxApi("*** ADD API KEY HERE ***", "https://api.kickbox.com/v2");

var verificationResponse1 = await kickbox.VerifyEmail(new MailAddress("info@coderpro.net"))
                                    .ConfigureAwait(true);
```

### Verify multiple email addresses in a batch.

```c#
var verificationResponse2 = await kickbox.VerifyBatch(
                                            mailAddresses: new[]
                                            {
                                              new MailAddress("brandon.osborne@gamil.com"),
                                              new MailAddress("info@coderpro.net")
                                            },
                                            fileName: "test file",
                                            batchVerificationCallback: null)
                                            .ConfigureAwait(false);
```

### Check status of a bulk verification job

```c#
var verificationResponse3 = await kickbox.CheckStatus(1234567)
                                    .ConfigureAwait(true);
```
