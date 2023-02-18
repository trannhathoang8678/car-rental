using BusinessObject;
using DataAccessObject;
using System.Collections.Generic;

namespace Repository
{
    public class CarRentalRepository : IRepository<CarRental>
    {
        public IEnumerable<CarRental> GetAll()
        {
            return CarRentalDAO.Instance.GetList();
        }

        public CarRental GetById(string id)
        {
            return CarRentalDAO.Instance.GetById(id);
        }
        public void Add(CarRental t)
        {
            CarRentalDAO.Instance.Add(t);
        }

        public void Update(CarRental t)
        {
            CarRentalDAO.Instance.Update(t);
        }

        public void Delete(CarRental t)
        {
            CarRentalDAO.Instance.Delete(t);
        }

        public IEnumerable<CarRental> ViewRentingHistory(string customerID)
        {
            return CarRentalDAO.Instance.ViewRentingHistory(customerID);
        }
    }
}
