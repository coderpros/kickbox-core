<img src="https://coderpro.net/images/logos/coderPro_logo_rounded_extra-90x90.webp" align="right" />

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Twitter](https://img.shields.io/twitter/url/https/twitter.com/cloudposse.svg?style=social&label=Follow%20%40coderProNet)](https://twitter.com/coderProNet)
[![GitHub](https://img.shields.io/github/followers/coderpros?label=Follow&style=social)](https://github.com/coderpros)

# KickBox-Core

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

[contributors-shield]: https://img.shields.io/github/contributors/coderpros/kickbox-asp.svg?style=flat-square
[contributors-url]: https://github.com/coderpros/kickbox-asp/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/coderpros/kickbox-asp?style=flat-square
[forks-url]: https://github.com/coderpros/kickbox-asp/network/members
[stars-shield]: https://img.shields.io/github/stars/coderpros/kickbox-asp.svg?style=flat-square
[stars-url]: https://github.com/coderpros/kickbox-asp/stargazers
[issues-shield]: https://img.shields.io/github/issues/coderpros/kickbox-asp?style=flat-square
[issues-url]: https://github.com/coderpros/kickbox-asp/issues
[license-shield]: https://img.shields.io/github/license/coderpros/kickbox-asp?style=flat-square
[license-url]: https://github.com/coderpros/kickbox-asp/master/blog/LICENSE
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=flat-square&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/company/coderpros
[twitter-shield]: https://img.shields.io/twitter/follow/coderpronet?style=social
[twitter-follow-url]: https://img.shields.io/twitter/follow/coderpronet?style=social
[github-shield]: https://img.shields.io/github/followers/coderpros?label=Follow&style=social
[github-follow-url]: https://img.shields.io/twitter/follow/coderpronet?style=social
