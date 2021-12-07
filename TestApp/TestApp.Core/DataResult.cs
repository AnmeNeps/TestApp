using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Core
{
    public enum ResultType
    {
        Sucess = 0,
        Failed = 1,
        Exception = 2,
    }
    public class DataResult<T> where T : class
    {
        public ResultType ResultType { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }

    public class DataResult
    {
        public ResultType ResultType { get; set;}
        public string? Message { get; set; }

    }
}
