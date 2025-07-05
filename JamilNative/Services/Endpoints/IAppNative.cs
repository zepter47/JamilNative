using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace JamilNative.Services.Endpoints;
public  interface IAppNative
{
    [Get("/api/Tenants/MaritalStatus")]
    Task<ApiResponse<ObservableCollection<MaritalStatus>>> GetMaritalStatus();

    [Get("/api/Tenants/NokRelationship")]
    Task<ApiResponse<ObservableCollection<NokRelationship>>> GetNokRelationship();

    [Post("/api/Tenants/MaritalStatus")]
    Task<IApiResponse> AddMaritalStatus(MaritalStatus marital);

    [Post("/api/Tenants/NokRelationship")]
    Task<IApiResponse> AddNokRelatioship(NokRelationship nokRelationship);

    [Post("/api/Tenants/TenantDetails")]
    Task<IApiResponse> AddTenantDetails([Body]TenantDetails tenant, [Query]string MaritalStatus, 
        [Query]string Nok, [Query]string House);

    [Post("/api/Tenants/HouseNumber")]
    Task<IApiResponse> AddHouseNumber([Body] House HNumber);

    [Get("/api/Tenants/TenantsDetails")]
    Task<ApiResponse<ObservableCollection<TenantDetails>>> GetTenantDetails();
}
