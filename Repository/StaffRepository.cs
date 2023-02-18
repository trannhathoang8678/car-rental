using BusinessObject;
using DataAccessObject;
using System.Collections.Generic;

namespace Repository
{
    public class StaffRepository : IRepository<StaffAccount>
    {
        public IEnumerable<StaffAccount> GetAll()
        {
            return StaffDAO.Instance.GetList();
        }

        public IEnumerable<StaffAccount> SearchByIdOrName(string searchString)
        {
            return StaffDAO.Instance.GetListByIdOrName(searchString);
        }

        public StaffAccount GetById(string id)
        {
            return StaffDAO.Instance.GetById(id);
        }
        public void Add(StaffAccount t)
        {
            StaffDAO.Instance.Add(t);
        }

        public void Update(StaffAccount t)
        {
            StaffDAO.Instance.Update(t);
        }

        public void Delete(StaffAccount t)
        {
            StaffDAO.Instance.Delete(t);
        }

        public StaffAccount Login(string email, string password)
        {
            return StaffDAO.Instance.LoginByStaffAccount(email, password);
        }
    }
}
