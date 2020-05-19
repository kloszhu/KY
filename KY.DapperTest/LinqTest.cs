using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace KY.DapperTest
{
    public class LinqTest
    {
        //var where = PredicateBuilder.True<BaoGaiTouBit>();
        //where = where.And(e => e.IsEnable);
        //where = where.And(e => e.DeadLine >= mindate);
        //where = where.And(e => e.DeadLine<maxdate);
        //list = OperateContext.Current.BLLSession.IBaoGaiTouBitBLL.GetMoreParamesPagedList(pageIndex, pageSize, where, b => b.CreateTime);
        //return Json(list);

         [Fact]
        void TestLinq() {
            var where = PredicateBuilder.True<Student>();
            where = where.And(e => e.Name.Contains("周杰伦"));
            where = where.And(e => e.Student_id >= 1);
            list = OperateContext.Current.BLLSession.IBaoGaiTouBitBLL.GetMoreParamesPagedList(pageIndex, pageSize, where, b => b.CreateTime);
            return Json(list);
        }

    }
}
