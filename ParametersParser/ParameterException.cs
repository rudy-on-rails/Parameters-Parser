using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParametersParser {
    public class ParameterException : Exception {
        public ParameterException() : base(){}
        public ParameterException(string message) : base(message){}
    }
}
