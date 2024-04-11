using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SorteoEstacionamientos.Shared.CapaEntities.Response;

namespace SorteoEstacionamientos.Shared.CapaServices_BusinessLogic
{
    public interface IGenericService<T>
    {
        public Task<Response<List<T>>?> GetAllDataByStatusAsync(short filterByStatus);
        public Task<Response<T>?> GetDataByIdAsync(int? id);
        public Task<HttpResponseMessage> AddDataAsync(T oObject);
        public Task<HttpResponseMessage> EditDataAsync(T oObject);
        public Task<HttpResponseMessage> EnableDisableDataByIdAsync(int id, short isActivate);
    }
}
