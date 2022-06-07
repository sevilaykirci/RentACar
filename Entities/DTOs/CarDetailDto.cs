using Core;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto : Car , IDTo
    {
        public string BrandName { get; set; }
        public string ColorName { get; set; }
    }
}
