using System;
using System.Collections.Generic;
using JobsCart.Models;

namespace JobsCart.DAL {
    public interface IRepository<T> : IDisposable where T : IDataModel {
        List<T> All ();
    }
}