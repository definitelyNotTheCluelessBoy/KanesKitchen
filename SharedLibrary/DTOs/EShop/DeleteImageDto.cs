﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.DTOs.EShop
{
    public class DeleteImageDto
    {
        public int productId { get; set; }

        public string imageUrl { get; set; }
    }
}
