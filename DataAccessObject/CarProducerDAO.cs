using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObject
{
    public class CarProducerDAO : IDAO<CarProducer>
    {
        private static CarProducerDAO instance = null;
        private static readonly object instanceLock = new object();

        private CarProducerDAO() { }

        public static CarProducerDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarProducerDAO();
                    }
                    return instance;
                }
            }
        }

 

        public IEnumerable<CarProducer> GetList()
        {
            IEnumerable<CarProducer> CarProducerList = null;
            try
            {
                var context = new CarRentalSystemDBContext();
                CarProducerList = context.CarProducers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return CarProducerList;
        }

        public CarProducer GetById(String carProducerID)
        {
            CarProducer CarProducer = null;
            try
            {
                var context = new CarRentalSystemDBContext();
                CarProducer = context.CarProducers.SingleOrDefault(c => c.ProducerId == carProducerID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return CarProducer;
        }

        public void Add(CarProducer carProducer)
        {
            try
            {
                var context = new CarRentalSystemDBContext();
                context.CarProducers.Add(carProducer);
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public void Update(CarProducer carProducer)
        {
            try
            {
                CarProducer _CarProducer = GetById(carProducer.ProducerId);
                if (_CarProducer != null)
                {
                    var context = new CarRentalSystemDBContext();
                    context.CarProducers.Update(carProducer);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The CarProducer does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public void Delete(CarProducer CarProducer)
        {
            try
            {
                CarProducer _CarProducer = GetById(CarProducer.ProducerId);
                if (_CarProducer != null)
                {
                    var context = new CarRentalSystemDBContext();
                    context.CarProducers.Remove(CarProducer);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The CarProducer does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
