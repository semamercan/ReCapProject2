using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data, string message):base(data, true,message)//işlem sonucu,mesaj ve datayı istersek
        {

        }
        public SuccessDataResult(T data) : base(data, true) //mesaj göndermek istemezsek
        {

        }
        public SuccessDataResult(string message) : base(default, true, message) //sadece mesaj göndermek istersek
        {

        }
        public SuccessDataResult() : base(default, true)
        {

        }
    }
}
