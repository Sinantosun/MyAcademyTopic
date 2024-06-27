using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic.WebUI.Dtos.CategoryDtos
{
    public class ResultCategoryDto
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }

    }
}
