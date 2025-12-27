using FIS.Tools.Exceptions;

namespace CMI.Model.Models
{
    public class Setting
    {
        public static string GetEnviromentVariableValue(string key)
        {
            string? enviromentVariableValue = null;
            if (Environment.GetEnvironmentVariables() != null)
                enviromentVariableValue = Environment.GetEnvironmentVariable(key);

            if (enviromentVariableValue == null)
                throw new InformationException(Model.Enums.ErrorMessage.NotFoundEnvironmentVariable);

            return enviromentVariableValue;
        }
    }
}
