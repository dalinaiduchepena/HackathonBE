using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WelfareScheme.Model;

namespace WelfareScheme.Concrete_Classs
{
    public interface Ischeme
    {
        Task<SchemeModel>  GetSchemeDetails(string words);
    }
}
