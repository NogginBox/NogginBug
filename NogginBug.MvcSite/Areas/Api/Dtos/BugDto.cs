using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NogginBug.Data.Model;
using System;

namespace NogginBug.MvcSite.Areas.Api.Dtos
{
    public class BugDto
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public BugStatus Status { get; set; }

        public DateTime OpenedDate { get; set; }
    }
}
