using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureSample.Shared.Result
{
#nullable disable
    public class ResultModel<T>
    {
        public int Statuscode { get; set; }
        public string Message { get; set; }
        public T Data{ get; set; }

    }
}
