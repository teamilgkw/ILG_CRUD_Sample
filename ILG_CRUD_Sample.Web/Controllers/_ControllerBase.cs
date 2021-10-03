using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILG_CRUD_Sample.Web.Controllers
{
    public class _ControllerBase<TSearchViewModel>:Controller  where TSearchViewModel : class

    { 
        public TSearchViewModel SearchViewModel
        {
            get
            {
                TSearchViewModel oTSearchViewModel = TempData.Get<TSearchViewModel>("TSearchViewModel");

                if (oTSearchViewModel == null)
                {
                    oTSearchViewModel = Activator.CreateInstance<TSearchViewModel>();
                }

                return oTSearchViewModel;
            }
            set
            {
                TempData.Put("TSearchViewModel", value);
            }
        }

    }
}
