using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult //Mesaj ve işlem sonucu döndürülür.
    {
        T Data { get; } //Mesaj ve işlem sonucuna ek olarak data döndürülür.
    }
}
