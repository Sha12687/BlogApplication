﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL.Repository
{
    public class EmpRepository : IEmpRepository
    {
        private readonly BlogDbContext _dbContext;

        public EmpRepository(BlogDbContext blogDbContext)
        {
            this._dbContext = blogDbContext;
        }

        public EmpInfo GetEmpInfoByEmialId(string EmailId)
        {
            return _dbContext.EmpInfos.FirstOrDefault(emp=>emp.EmailId==EmailId);
        }

        public IEnumerable<EmpInfo> GetAllEmpInfos()
        {
            return _dbContext.EmpInfos.ToList();
        }

        public void AddEmpInfo(EmpInfo empInfo)
        {
            _dbContext.EmpInfos.Add(empInfo);
            _dbContext.SaveChanges();
        }
        public EmpInfo AddEmpInfoTest(EmpInfo empInfo)
        {
         var test=   _dbContext.EmpInfos.Add(empInfo);
            _dbContext.SaveChanges();
            return test;
        }
        public void UpdateEmpInfo(EmpInfo empInfo)
        {
            _dbContext.Entry(empInfo).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteEmpInfo(int empInfoId)
        {
            var empInfo = _dbContext.EmpInfos.Find(empInfoId);
            if (empInfo != null)
          _dbContext.BlogInfos.RemoveRange(_dbContext.BlogInfos.Where(b => b.Employee.EmpInfoId == empInfo.EmpInfoId));
            _dbContext.EmpInfos.Remove(empInfo);
            _dbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public EmpInfo GetEmpInfoById(int EmpInfoId)
        {
            return _dbContext.EmpInfos.Find(EmpInfoId);
           
        }

        public bool DeleteEmpInfoTest(int empId)
        {
            var emp = _dbContext.EmpInfos.Find(empId);
            if (emp == null)
            {
                return false; // Entity not found, return false or handle accordingly
            }

            _dbContext.EmpInfos.Remove(emp);
            _dbContext.SaveChanges();
            return true; // Entity removed successfully
        }
    }
}
