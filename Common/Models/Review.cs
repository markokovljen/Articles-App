using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class Review : DomainObject
    {
        public string ReviewContent { get; set; }

        public Article Article { get; set; }

        

    }
}
