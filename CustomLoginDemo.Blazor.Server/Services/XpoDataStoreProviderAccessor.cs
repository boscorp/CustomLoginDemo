using System;
using DevExpress.ExpressApp.Xpo;

namespace CustomLoginDemo.Blazor.Server.Services {
    public class XpoDataStoreProviderAccessor {
        public IXpoDataStoreProvider DataStoreProvider { get; set; }
    }
}
