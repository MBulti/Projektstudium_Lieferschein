using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Lieferschein.Services
{
    public class DataService : IDataService
    {
        public async Task<Stream> GetPDFStream(string deliveryNote)
        {
            await Task.Delay(1);
            return null;
        }
    }
}
