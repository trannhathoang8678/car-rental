using BusinessObject;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CarRepository : IRepository<Car>
    {
        public IEnumerable<Car> GetAll()
        {
            return CarDAO.Instance.GetList();
        }

        public Car GetById(string id)
        {
            return CarDAO.Instance.GetById(id);
        }
        public void Add(Car t)
        {
            CarDAO.Instance.Add(t);
        }

        public void Update(Car t)
        {
            CarDAO.Instance.Update(t);
        }

        public void Delete(Car t)
        {
            CarDAO.Instance.Delete(t);
        }

        public IEnumerable<Car> SearchByIdOrName(string searchString)
        {
            return CarDAO.Instance.GetListByIdOrName(searchString);
        }
    }
}
