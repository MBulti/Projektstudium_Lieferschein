using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Lieferschein.Services
{
    public interface ILoginService
    {
        Task<bool> Login(string username, string password);
    }
}
