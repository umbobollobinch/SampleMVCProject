using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sample001.Models.Prefs
{
    public class FukuiModel:IPlaceModel
    {
        [Key]
        [JsonPropertyName("No")]
        [DisplayName("ID")]
        public int id { get; set; }

        [JsonPropertyName("全国地方公共団体コード")]
        [DisplayName("地方公共団体コード")]
        public string prefCode { get; set; } = "";

        [JsonPropertyName("都道府県名")]
        [DisplayName("都道府県名")]
        public string prefName { get; set; } = "";

        [JsonPropertyName("市区町村名")]
        [DisplayName("市区町村名")]
        public string address { get; set; } = "";

        [JsonPropertyName("公表_年月日")]
        [DisplayName("公表年月日")]
        public string pubDate { get; set; } = "";

        [JsonPropertyName("発症_年月日")]
        [DisplayName("発症年月日")]
        public string developDate { get; set; } = "";

        [JsonPropertyName("患者_居住地")]
        [DisplayName("居住地")]
        public string patientAddress { get; set; } = "";

        [JsonPropertyName("患者_年代")]
        [DisplayName("年代")]
        public string patientAge { get; set; } = "";

        [JsonPropertyName("患者_性別")]
        [DisplayName("性別")]
        public string patientSex { get; set; } = "";

        [JsonPropertyName("患者_職業")]
        [DisplayName("職業")]
        public string patientJob { get; set; } = "";

        [JsonPropertyName("患者_状態")]
        [DisplayName("状態")]
        public string patientState { get; set; } = "";

        [JsonPropertyName("患者_症状")]
        [DisplayName("症状")]
        public string patientSymptom { get; set; } = "";

        [JsonPropertyName("患者_渡航歴の有無フラグ")]
        [DisplayName("渡航歴")]
        public string travelRecord { get; set; } = "";

        [JsonPropertyName("患者_退院済フラグ")]
        [DisplayName("退院済")]
        public string recoverOrNot { get; set; } = "";

        [JsonPropertyName("備考")]
        [DisplayName("備考")]
        public string comment { get; set; } = "";
    }
}
