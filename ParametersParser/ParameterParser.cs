using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParametersParser {
    public class ParameterParser {        
        private string[] parametersArray;        

        public ParameterParser(string[] parameters) {            
            parametersArray = parameters;                   
        }
        
        public ParameterValue getParameterValue(string parameterKey, bool isRequired) {
            return new ParameterValue(parametersArray, parameterKey, isRequired);
        }

        public ParameterValue getParameterValue(string parameterKey) {
            return new ParameterValue(parametersArray, parameterKey, false);
        }        
    }
}
