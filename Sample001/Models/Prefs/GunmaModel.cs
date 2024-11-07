using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sample001.Models.Prefs
{
    public class GunmaModel: IPlaceModel
    {
        [Key]
        [JsonPropertyName("No")]
        [DisplayName("ID")]
        public int id { get; set; }

        [JsonPropertyName("リリース日")]
        [DisplayName("公表年月日")]
        public string pubDate { get; set; } = "";

        [JsonPropertyName("曜日")]
        [DisplayName("曜日")]
        public string day { get; set; } = "";

        [JsonPropertyName("居住地")]
        [DisplayName("居住地")]
        public string patientAddress { get; set; } = "";

        [JsonPropertyName("年代")]
        [DisplayName("年代")]
        public string patientAge { get; set; } = "";

        [JsonPropertyName("性別")]
        [DisplayName("性別")]
        public string patientSex { get; set; } = "";
    }
}
