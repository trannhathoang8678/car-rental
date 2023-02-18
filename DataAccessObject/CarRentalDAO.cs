using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObject
{
    public class CarRentalDAO : IDAO<CarRental>
    {
        private static CarRentalDAO instance = null;
        private static readonly object instanceLock = new object();
        private CarRentalDAO() { }
        public static CarRentalDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarRentalDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<CarRental> GetList()
        {
            IEnumerable<CarRental> carRentalList = null;
            try
            {
                var context = new CarRentalSystemDBContext();
                carRentalList = context.CarRentals.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return carRentalList;
        }

        public CarRental GetById(String customerId)
        {
            CarRental carRental = null;
            try
            {
                var context = new CarRentalSystemDBContext();
                carRental = context.CarRentals.SingleOrDefault(c => c.CustomerId == customerId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return carRental;
        }

        public void Add(CarRental carRental)
        {
            try
            {
                var context = new CarRentalSystemDBContext();
                context.CarRentals.Add(carRental);
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public void Update(CarRental carRental)
        {
            try
            {
                var context = new CarRentalSystemDBContext();
                context.CarRentals.Update(carRental);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public void Delete(CarRental carRental)
        {
            try
            {

                var context = new CarRentalSystemDBContext();
                context.CarRentals.Remove(carRental);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<CarRental> ViewRentingHistory(string customerID)
        {
            List<CarRental> listCarRental;
            try
            {
                var context = new CarRentalSystemDBContext();
                listCarRental = context.CarRentals.Where(c => c.CustomerId.Contains(customerID)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listCarRental;
        }
    }
}
