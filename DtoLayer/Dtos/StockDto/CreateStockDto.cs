using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.StockDto
{
    public class CreateStockDto
    {
        public int ProductID { get; set; }
        public int ColorID { get; set; }
        public int BodySizeID { get; set; }
        public int StockQuantity { get; set; }
    }
}
