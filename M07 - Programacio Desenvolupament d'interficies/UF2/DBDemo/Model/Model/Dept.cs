using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class Dept
    {
        public Dept(int deptNo, string dName, string loc)
        {
            DeptNo = deptNo;
            DName = dName;
            Loc = loc;
        }

        public int DeptNo { get; set; }
        public string DName { get; set; }
        public string Loc { get; set; }
    }
}
