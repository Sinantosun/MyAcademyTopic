using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic.WebUI.Dtos.ManuelDtos
{
    public class UpdateManuelDto
    {
        public int ManuelID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
