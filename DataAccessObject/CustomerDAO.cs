using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObject
{
    public class CustomerDAO : IDAO<Customer>
    {
        private static CustomerDAO instance = null;
        private static readonly object instanceLock = new object();

        private CustomerDAO() { }

        public static CustomerDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CustomerDAO();
                    }
                    return instance;
                }
            }
        }


        public IEnumerable<Customer> GetList()
        {
            IEnumerable<Customer> customerList = null;
            try
            {
                var context = new CarRentalSystemDBContext();
                customerList = context.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customerList;
        }

        public Customer GetById(String CustomerId)
        {
            Customer customer = null;
            try
            {
                var context = new CarRentalSystemDBContext();
                customer = context.Customers.SingleOrDefault(c => c.CustomerId == CustomerId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customer;
        }

        public void Add(Customer customer)
        {
            try
            {
                var context = new CarRentalSystemDBContext();
                context.Customers.Add(customer);
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public void Update(Customer customer)
        {
            try
            {
                Customer _customer = GetById(customer.CustomerId);
                if (_customer != null)
                {
                    var context = new CarRentalSystemDBContext();
                    context.Customers.Update(customer);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The customer does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public void Delete(Customer customer)
        {
            try
            {
                Customer _customer = GetById(customer.CustomerId);
                if (_customer != null)
                {
                    var context = new CarRentalSystemDBContext();
                    context.Customers.Remove(customer);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The customer does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public Customer LoginByCustomer(String email, String password)
        {
            Customer customer = null;
            var context = new CarRentalSystemDBContext();
            customer = context.Customers.SingleOrDefault(c => c.CustomerEmail == email && c.CustomerPassword == password);
            return customer;
        }
    }
}
