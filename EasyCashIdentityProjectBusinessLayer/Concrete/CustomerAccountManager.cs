using EasyCashIdentityProjectBusinessLayer.Abstract;
using EasyCashIdentityProjectDataAccessLayer.Abstract;
using EasyCashIdentityProjectEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProjectBusinessLayer.Concrete
{
    internal class CustomerAccountManager : ICustomerAccountService
    {
        private readonly ICustomerAccountDal _customerAccountDal;

        public CustomerAccountManager(ICustomerAccountDal customerAccountDal)
        {
            _customerAccountDal = customerAccountDal;
        }

        public void TDelete(CustomerAccount t)
        {
            _customerAccountDal.Delete(t);
        }

        public CustomerAccount TGetByID(int id)
        {
           _customerAccountDal.GetByID(id);
        }

        public List<CustomerAccount> TGetList()
        {
            _customerAccountDal.GetList();
        }

        public void TInsert(CustomerAccount t)
        {
            _customerAccountDal.Insert(t);
        }

        public void TUpdate(CustomerAccount t)
        {
           _customerAccountDal.Update(t);
        }
    }
}
