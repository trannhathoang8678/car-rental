using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObject
{
    public class StaffDAO : IDAO<StaffAccount>
    {
        private static StaffDAO instance = null;
        private static readonly object instanceLock = new object();

        private StaffDAO() { }

        public static StaffDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new StaffDAO();
                    }
                    return instance;
                }
            }
        }

        public StaffAccount LoginByStaffAccount(String email, String password)
        {
            StaffAccount staff = null;
            var context = new CarRentalSystemDBContext();
            staff = context.StaffAccounts.SingleOrDefault(c => c.Email == email && c.Password == password);
            return staff;
        }

        public IEnumerable<StaffAccount> GetListByIdOrName(string searchString)
        {
            IEnumerable<StaffAccount> staffList = null;
            try
            {
                var context = new CarRentalSystemDBContext();
                staffList = context.StaffAccounts.Where(s => s.StaffId.Contains(searchString) || s.FullName.Contains(searchString)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return staffList;
        }

        public IEnumerable<StaffAccount> GetList()
        {
            IEnumerable<StaffAccount> staffList = null;
            try
            {
                var context = new CarRentalSystemDBContext();
                staffList = context.StaffAccounts.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return staffList;
        }

        public StaffAccount GetById(String staffID)
        {
            StaffAccount staff = null;
            try
            {
                var context = new CarRentalSystemDBContext();
                staff = context.StaffAccounts.SingleOrDefault(c => c.StaffId == staffID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return staff;
        }

        public void Add(StaffAccount staff)
        {
                var context = new CarRentalSystemDBContext();
                context.StaffAccounts.Add(staff);
                context.SaveChanges();
        }
        public void Update(StaffAccount staff)
        {
            try
            {
                StaffAccount _staff = GetById(staff.StaffId);
                if (_staff != null)
                {
                    var context = new CarRentalSystemDBContext();
                    context.StaffAccounts.Update(staff);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Staff does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public void Delete(StaffAccount staff)
        {
            try
            {
                StaffAccount _staff = GetById(staff.StaffId);
                if (_staff != null)
                {
                    var context = new CarRentalSystemDBContext();
                    context.StaffAccounts.Remove(staff);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Staff does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
