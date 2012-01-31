using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParametersParser {
    public class ParameterNotFoundException : Exception {
         public ParameterNotFoundException() : base(){}
         public ParameterNotFoundException(string message) : base(message) { }
    }
}
