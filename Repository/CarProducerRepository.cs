using BusinessObject;
using DataAccessObject;
using System.Collections.Generic;


namespace Repository
{
    public class CarProducerRepository : IRepository<CarProducer>
    {
        public IEnumerable<CarProducer> GetAll()
        {
            return CarProducerDAO.Instance.GetList();
        }

        public CarProducer GetById(string id)
        {
            return CarProducerDAO.Instance.GetById(id);
        }
        public void Add(CarProducer t)
        {
            CarProducerDAO.Instance.Add(t);
        }

        public void Update(CarProducer t)
        {
            CarProducerDAO.Instance.Update(t);
        }

        public void Delete(CarProducer t)
        {
            CarProducerDAO.Instance.Delete(t);
        }
    }
}
