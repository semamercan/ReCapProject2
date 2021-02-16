using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IResult
    {
        bool Success { get; } // get sadece okunabilir demek. Constr ile set yapacağız.
        string Message { get; } //Success girişin başarılı olup olmadığını test eder, Message ise bilgilendirme yapar
    }
}
