using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class CarDAO : IDAO<Car>
    {
        private static CarDAO instance = null;
        private static readonly object instanceLock = new object();

        private CarDAO() { }

        public static CarDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Car> GetListByIdOrName(string searchString)
        {
            IEnumerable<Car> CarList = null;
            try
            {
                var context = new CarRentalSystemDBContext();
                CarList = context.Cars.Where(s => (s.CarId.Contains(searchString) || s.CarName.Contains(searchString)) && s.Status == 1).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return CarList;
        }

        public IEnumerable<Car> GetList()
        {
            IEnumerable<Car> carList = null;
            try
            {
                var context = new CarRentalSystemDBContext();
                carList = context.Cars.Where(s => s.Status == 1).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return carList;
        }

        public Car GetById(String carID)
        {
            Car Car = null;
            try
            {
                var context = new CarRentalSystemDBContext();
                Car = context.Cars.SingleOrDefault(c => c.CarId == carID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Car;
        }

        public void Add(Car car)
        {
            var context = new CarRentalSystemDBContext();
            context.Cars.Add(car);
            context.SaveChanges();
        }
        public void Update(Car car)
        {
            try
            {
                Car _car = GetById(car.CarId);
                if (_car != null)
                {
                    var context = new CarRentalSystemDBContext();
                    context.Cars.Update(car);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Car does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public void Delete(Car car)
        {
            try
            {
                Car _car = GetById(car.CarId);
                if (_car != null)
                {
                    var context = new CarRentalSystemDBContext();
                    car.Status = 0;
                    context.Cars.Update(car);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Car does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
