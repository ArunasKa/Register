﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterApi.Domain.Models
{
    public class Image
    {
        public int Id { get; set; }
        public byte[] ImageBytes { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
    }
}