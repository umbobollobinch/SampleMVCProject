using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sample001.Models
{
    public class PositiveCaseModel
    {
        [Key]
        [JsonPropertyName("日付")]
        [DisplayName("日付")]
        public string pubDate { get; set; }

        [JsonPropertyName("PCR検査陽性者数単日")]
        [DisplayName("陽性者数")]
        public string patientNum { get; set; }
    }
}
