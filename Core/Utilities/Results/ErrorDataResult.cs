using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)//işlem sonucu,mesaj ve datayı istersek
        {

        }
        public ErrorDataResult(T data) : base(data, false) //mesaj göndermek istemezsek
        {

        }
        public ErrorDataResult(string message) : base(default, false, message) //sadece mesaj göndermek istersek
        {

        }
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
