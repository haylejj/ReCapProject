using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {

        public DataResult(T data,string message,bool success):base(message,success)
        {
            this.Data = data;
        }
        public DataResult(T data,bool success):base(success)
        {
            this.Data=data;
        }
       

        public T Data { get; }
    }
}
