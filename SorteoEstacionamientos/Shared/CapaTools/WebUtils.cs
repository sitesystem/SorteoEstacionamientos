using SorteoEstacionamientos.Shared.CapaServices_BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteoEstacionamientos.Shared.CapaTools
{
    public static class WebUtils
    {
        public static async Task<List<T>> ListByStatusAsync<T>(IGenericService<T> service, short filterByStatus = 1)
        {
            List<T> result = new();

            try
            {
                var response = await service.GetAllDataByStatusAsync(filterByStatus);

                if (response is not null && response.Data is not null)
                    result = response.Data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message} ");
            }

            return result;
        }

        public class Link(string url = "#", string name = "#")
        {
            public string Url { get; set; } = url;
            public string Name { get; set; } = name;
        }
    }
}
