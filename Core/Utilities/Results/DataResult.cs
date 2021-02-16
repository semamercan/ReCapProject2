using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T>:Result, IDataResult<T>
    {
        public DataResult(T data, bool success, string message):base(success,message)
        {
            Data = data; //data'yı constr ile set ederiz.
        }
        public DataResult(T data, bool success) : base(success) //Mesaj istemezsek
        {
            Data = data; //data'yı constr ile set ederiz.
        }

        public T Data { get; }
    }
}
