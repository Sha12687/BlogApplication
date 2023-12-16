using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL
{
    public interface IEmpRepository
    {
        EmpInfo GetEmpInfoByEmialId(string EmailId);
        IEnumerable<EmpInfo> GetAllEmpInfos();
        void AddEmpInfo(EmpInfo empInfo);
        void UpdateEmpInfo(EmpInfo empInfo);
        void DeleteEmpInfo(int empInfoId);
        void SaveChanges();
    }
}
