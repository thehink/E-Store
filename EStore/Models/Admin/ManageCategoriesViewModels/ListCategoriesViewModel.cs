using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models.Admin.ManageCategoriesViewModels
{
    public class ListCategoriesViewModel
    {
        public IList<Category> Categories { get; set; }
    }
}
