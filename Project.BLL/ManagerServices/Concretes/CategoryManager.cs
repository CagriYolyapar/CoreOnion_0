using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Concretes
{
    public class CategoryManager : BaseManager<Category>, ICategoryManager
    {

        ICategoryRepository _cRep;

        public CategoryManager(ICategoryRepository crep):base(crep)
        {
            _cRep = crep;
        }

        public override string Add(Category item)
        {
            if (item.CategoryName!=null)
            {
                _cRep.Add(item);
                return "Kategori Eklendi";
            }
            return "Kategori ismi girilmemiş";
        }


        public void BaskaMetot()
        {
            _cRep.BaskaMetot();
        }

        public void SpecialCategoryCreation()
        {
            _cRep.SpecialCategoryCreation();
        }
    }
}
