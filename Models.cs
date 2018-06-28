using System;
using System.Runtime.Serialization;

namespace FizzBuzz
{
    [DataContract]
    public class FizzbuzzEvent : FizzbuzzEventBody
    {
        [DataMember]
        public string id { get; set; }

        //TODO ~ handel datetime deserialization
        //[DataMember]
        //public DateTime insert_date { get; set; }
    }

    [DataContract]
    public class FizzbuzzEventBody
    {
        [DataMember]
        public int lower_bound { get; set; }

        [DataMember]
        public int upper_bound { get; set; }

        [DataMember]
        public int fizz_at { get; set; }

        [DataMember]
        public int buzz_at { get; set; }
    }


    public class FizzbuzzData
    {
        public string fizzbuzz_event_id { get; set; }
        public string val { get; set; }
    }
}
