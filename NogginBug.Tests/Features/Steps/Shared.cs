using System;

namespace NogginBug.Tests.Features.Steps
{
    internal static class Shared
    {
        /// <summary>
        /// Static date that test bugs are created on
        /// </summary>
        public static readonly DateTime MayThe4th = new DateTime(2019, 5, 4, 23, 0, 0);

        public const string SiteUrl = "https://localhost:44314/";
    }
}
