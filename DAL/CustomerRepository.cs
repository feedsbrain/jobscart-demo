using System;
using System.Collections.Generic;
using System.Linq;
using JobsCart.Models;

namespace JobsCart.DAL {
    public class CustomerRepository : IRepository<Customer> {

        protected FakeDb DB = null;

        public CustomerRepository () => DB = new FakeDb ();

        public List<Customer> All () {
            var results = new List<Customer> ();
            foreach (var r in DB.customers) {
                r.Pricings = DB.pricings.Where (p => r.PricingIds.Contains (p.Id));
                results.Add (r);
            }
            return results;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose (bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ProductRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose () {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose (true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}