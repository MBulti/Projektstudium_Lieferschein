using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Lieferschein.Services
{
    public class MockDataService : IDataService
    {
        public async Task<Stream> GetPDFStream(string deliveryNote)
        {
            var file = await FilePicker.PickAsync();
            return await file.OpenReadAsync();
        }
    }
}
