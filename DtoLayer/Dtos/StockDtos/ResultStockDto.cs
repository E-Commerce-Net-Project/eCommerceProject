using DtoLayer.Dtos.BodySizeDtos;
using DtoLayer.Dtos.ColorDtos;
using DtoLayer.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.StockDtos
{
    public class ResultStockDto
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int ColorID { get; set; }
        public int BodySizeID { get; set; }
        public int StockQuantity { get; set; }

        public ResultProductDto Product { get; set; }
        public ResultBodySizeDto BodySize { get; set; }
        public ResultColorDto Color { get; set; }
    }
}
