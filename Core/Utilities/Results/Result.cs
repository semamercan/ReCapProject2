using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message):this(success) //Buna const chaining(zincirleme) denir.Const içinde başka bir const'ı tetikledik.
        {
            Message = message; //message'yi const ile set ederiz.
        }

        public Result(bool success) //Mesaj göndermek istemiyorsak bu constr kullanılır.
        {
            Success=success; // success'i const ile set ederiz.
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
