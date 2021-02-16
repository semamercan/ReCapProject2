using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        public ErrorResult(string message) : base(false, message) //tek bir parametre veririz:message
        {
        }

        public ErrorResult() : base(false) //parametresiz
        {
        }
    }
}
