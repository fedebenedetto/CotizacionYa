using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace Object
{
    public class Objeto
    {
        public partial class Moneda
        {
            [JsonProperty("result")]
            public Result Result { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }
        }

        public partial class Result
        {
            [JsonProperty("updated")]
            public DateTimeOffset Updated { get; set; }

            [JsonProperty("source")]
            public string Source { get; set; }

            [JsonProperty("target")]
            public string Target { get; set; }

            [JsonProperty("value")]
            public double Value { get; set; }

            [JsonProperty("quantity")]
            public long Quantity { get; set; }

            [JsonProperty("amount")]
            public double Amount { get; set; }
        }

        public partial class Moneda
        {
            public static Moneda FromJson(string json) => JsonConvert.DeserializeObject<Moneda>(json, Objeto.Converter.Settings);
        }

        //public static class Serialize
        //{
        //    public static string ToJson(this Moneda self) => JsonConvert.SerializeObject(self, Objeto.Converter.Settings);
        //}

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }

        public class Dolar : Result
        {
            public List<Dolar> GetDolars()
            {
                List<Dolar> dolars = new List<Dolar>();
                return dolars;
            }
        }

        public class PesoArgentino : Result
        {
            public List<PesoArgentino> GetPesoArgentinos()
            {
                List<PesoArgentino> pesos = new List<PesoArgentino>();
                return pesos;
            }
        }

        public class Euro : Result
        {
            List<Euro> GetEuros()
            {
                List<Euro> euros = new List<Euro>();
                return euros;
            }
        }

        public class Real : Result
        {
            List<Real> GetReals()
            {
                List<Real> reals = new List<Real>();
                return reals;
            }
        }
    }
}

