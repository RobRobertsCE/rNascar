using System;

namespace NascarFeed.Data.Models
{
    public class SessionModel
    {
        public int id { get; set; }
        public int name { get; set; }
        public int sequence { get; set; }
        public DateTime date { get; set; }
        public SessionTypeModel sessionType { get; set; }
    }
}
