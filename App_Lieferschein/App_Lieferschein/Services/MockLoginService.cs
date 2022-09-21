using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Lieferschein.Services
{
    public class MockLoginService : ILoginService
    {
        public async Task<bool> Login(string username, string password)
        {
            await Task.Delay(10);
            return true;
        }
    }
}
