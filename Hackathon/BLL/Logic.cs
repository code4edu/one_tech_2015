using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Logic
    {
        Data data;
        public Logic()
        {
            data = new Data();
        }

        //public static void GetTask(ref string condition, ref string code)
        //{
        //    Data.GetTask(ref condition, ref code);
        //}

        public static void GetTaskById(ref string condition, ref string code, int idLev, int id, int level)
        {
            Data.GetTask(ref condition, ref code, idLev, id, level);
        }
    }
}
