using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamilNative.ViewModel;
public partial class ViewResidentsViewModel:ObservableValidator
{
    //public string FirstName { get; }
    //public string LastName { get; }

    //public string House { get; }
    public TenantDetails TenantDetails { get;  }

    public ViewResidentsViewModel() { }

    public ViewResidentsViewModel(TenantDetails tenantDetails)
    {
        //FirstName = tenantDetails.FirstName;
        //LastName = tenantDetails.LastName;
        //House = tenantDetails.TdHouse;
        TenantDetails = tenantDetails;
    }
}
