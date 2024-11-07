using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample001.Models
{
    public class ErrorViewModel
    {
        public int statusCode { get; set; }
        public string requestId { get; set; }
        public bool showRequestId => !string.IsNullOrEmpty(requestId);
    }
}
