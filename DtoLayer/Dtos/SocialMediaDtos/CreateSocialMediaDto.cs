﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.SocialMediaDtos
{
    public class CreateSocialMediaDto
    {
        public int SocialMediaID { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
