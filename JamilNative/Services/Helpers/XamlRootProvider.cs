using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamilNative.Services.Helpers
{
    public static class XamlRootProvider
    {
        private static XamlRoot _xamlRoot;

        public static void Initialize(XamlRoot xamlRoot)
        {
            _xamlRoot = xamlRoot;
        }

        public static XamlRoot GetXamlRoot()
        {
            if (_xamlRoot == null)
            {
                throw new InvalidOperationException("XamlRoot has not been Initialized. Call INitialize() first.");
            }

            return _xamlRoot;
        }

    }
}
