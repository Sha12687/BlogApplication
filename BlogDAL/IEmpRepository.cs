using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL
{
    public interface IEmpRepository
    {
         bool DeleteEmpInfoTest(int empId);
         EmpInfo AddEmpInfoTest(EmpInfo empInfo);
        EmpInfo GetEmpInfoByEmialId(string EmailId);
        EmpInfo GetEmpInfoById(int EmpInfoId);
        IEnumerable<EmpInfo> GetAllEmpInfos();
        void AddEmpInfo(EmpInfo empInfo);

        void UpdateEmpInfo(EmpInfo empInfo);
        void DeleteEmpInfo(int empInfoId);
        void SaveChanges();
    }
}
