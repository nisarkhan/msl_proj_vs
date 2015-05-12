using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSL.Models
{
    public class DisplayMessage
    {
        public int Count { get; set; }
        public int UpdateMessageCount { get; set; }
        public int InsertFirstTimeMessageCount { get; set; }
        public int AddNewRecordMessageCount { get; set; }
        public int NoChangesCount { get; set; }

        public string Type { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }        
    }
}