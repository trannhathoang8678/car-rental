using BusinessObject;
using DataAccessObject;
using System.Collections.Generic;


namespace Repository
{
    public class CustomerRepository : IRepository<Customer>
    {
        public IEnumerable<Customer> GetAll()
        {
            return CustomerDAO.Instance.GetList();
        }

        public Customer GetById(string id)
        {
            return CustomerDAO.Instance.GetById(id);
        }
        public void Add(Customer t)
        {
            CustomerDAO.Instance.Add(t);
        }

        public void Update(Customer t)
        {
            CustomerDAO.Instance.Update(t);
        }

        public void Delete(Customer t)
        {
            CustomerDAO.Instance.Delete(t);
        }
        public Customer Login(string email, string password)
        {
            return CustomerDAO.Instance.LoginByCustomer(email, password);
        }

        
    }
}
