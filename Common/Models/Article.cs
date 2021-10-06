using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class Article : DomainObject
    {
        public string Content { get; set; }
        public string Title { get; set; }

        public Journalist Journalist { get; set; }
    }
}
