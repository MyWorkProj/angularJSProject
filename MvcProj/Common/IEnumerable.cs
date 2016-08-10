using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MvcProj.Common
{  
    // 摘要: 
    //     公开枚举器，该枚举器支持在非泛型集合上进行简单迭代。
    [ComVisible(true)]
    [Guid("496B0ABE-CDEE-11d3-88E8-00902754C43A")]
    public interface IEnumerable
    {
        // 摘要: 
        //     返回一个循环访问集合的枚举器。
        //
        // 返回结果: 
        //     可用于循环访问集合的 System.Collections.IEnumerator 对象。
        [DispId(-4)]
        IEnumerator GetEnumerator();
    }
}
