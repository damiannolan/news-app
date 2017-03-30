﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Models
{
    public class NewsSource
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Category { get; set; }
        public Dictionary<string, string> UrlsToLogos { get; set; }
    }
}
