using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;

namespace FizzBuzz
{
    public class CallApi
    {
        readonly int LowerBound;
        readonly int UpperBound;
        readonly int FizzAt;
        readonly int BuzzAt;
        readonly string ApiUrl;

        readonly List<string> Data;

        public CallApi(int lowerBound, int upperBound, int fizzAt, int buzzAt, string apiUrl, List<string> data)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
            FizzAt = fizzAt;
            BuzzAt = buzzAt;
            ApiUrl = apiUrl;
            Data = data;
        }

        public void Go()
        {
            if (string.IsNullOrEmpty(ApiUrl))
                return;

            if (Data == null)
                return;

            try
            {
                //insert event
                var obj = new FizzbuzzEventBody() {
                    buzz_at = BuzzAt,
                    fizz_at = FizzAt,
                    lower_bound = LowerBound,
                    upper_bound = UpperBound
                };
                var endPoint = string.Format("{0}/fizzbuzz_event", ApiUrl);
                var json = Serialize<FizzbuzzEventBody>(obj);
                var response = DoCall(json, endPoint, Verb.post);

                //read event id
                endPoint = string.Format("{0}/fizzbuzz_event?order=id.desc&limit=1", ApiUrl);
                response = DoCall("[]", endPoint, Verb.get);
                var result = response.Content.ReadAsStringAsync()
                    .Result;
                var newObj = DeSerialize<FizzbuzzEvent>(result);

                //insert event data lines
                endPoint = string.Format("{0}/fizzbuzz_data", ApiUrl);
                foreach (var item in Data)
                {
                    var objData = new FizzbuzzData()
                    {
                        fizzbuzz_event_id = newObj.id,
                        val = item
                    };
                    var jsonData = Serialize<FizzbuzzData>(objData);
                    DoCall(jsonData, endPoint, Verb.post);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        #region helpers
        public T DeSerialize<T>(string result)
        {
            var json = result
                .Replace("[", "")
                .Replace("]", ""); //api returns an array, manually clean it up for de-serialize

            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                ms.Position = 0;
                var js = new DataContractJsonSerializer(typeof(T));
                var obj = (T)js.ReadObject(ms);
                ms.Close();
                return obj;
            }
        }
        public string Serialize<T>(object obj)
        {
            var json = "[]";
            var js = new DataContractJsonSerializer(typeof(T));
            using (var ms = new MemoryStream())
            {
                js.WriteObject(ms, obj);
                ms.Position = 0;
                using (var sr = new StreamReader(ms))
                {
                    json = sr.ReadToEnd();
                    sr.Close();
                }
                ms.Close();
            }
            return json;
        }
        public HttpResponseMessage DoCall(string json, string endPoint, Verb verb)
        {
            var result = new HttpResponseMessage();
            using (var client = new HttpClient())
            {
                using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    if (verb.Equals(Verb.post))
                        result = client.PostAsync(endPoint, content).Result;

                    if (verb.Equals(Verb.get))
                        result = client.GetAsync(endPoint).Result;
                }
            }
            return result;
        }
        public enum Verb
        {
            post,
            get
        }
        #endregion
    }
}
