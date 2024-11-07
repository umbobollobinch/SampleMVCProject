using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sample001.Models
{
    public interface IPlaceModel
    {
        public int id { get; set; }
        public string pubDate { get; set; }
        //IEnumerable<string> GetValue();
    }
}
