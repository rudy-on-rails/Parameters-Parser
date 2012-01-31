using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParametersParser {
    public class ParameterValue {
        private IList<string> parametersList;
        private string parameterKey;        
        private bool isRequired;
        
        public ParameterValue(string[] parametersArray, string parameterKey, bool isRequired) {
            this.parametersList = parametersArray.ToList();
            this.parameterKey = parameterKey;
            this.isRequired = isRequired;
        }
       
        public int IntegerValue(){
            checkParameterIsPresent();
            var keyPosition = parametersList.IndexOf(parameterKey);
            var parameterValue = getStringParameterValueFor(keyPosition);
            try {                    
                return Int32.Parse(parameterValue);
            }
            catch (Exception) {
                throw new ParameterException(String.Format("Invalid value for {0} parameter!", parameterKey));
            }            
        }

        public string StringValue() {
            checkParameterIsPresent();
            var keyPosition = parametersList.IndexOf(parameterKey);
            return getStringParameterValueFor(keyPosition);            
        }
                       
        public bool BooleanValue() {
            return parametersList.Contains(parameterKey);
        }

        private string getStringParameterValueFor(int keyPosition) {
            try {
                return parametersList.ElementAt(keyPosition + 1);
            }
            catch (Exception) {
                throw new ParameterException(String.Format("Invalid parameter value for {0} parameter!", parameterKey));
            }
        }

        private void checkParameterIsPresent(){
            if (!parametersList.Contains(parameterKey) && isRequired)
                throw new ParameterNotFoundException(String.Format("Parameter {0} could not be found!", parameterKey));
        }
    }
}
