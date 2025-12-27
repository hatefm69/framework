using FIS.ServiceBus.Models;

namespace CMI.Service.HelperClasses
{
    public class ServiceBusResult
    {
        public static T Validate<T>(ServiceBusResponse<T> result) where T : class
        {
            if (result == null ||
                result.Data == null ||
                result.StatusCode != System.Net.HttpStatusCode.OK)
                return null;

            return result.Data;
        }

        public static List<T> Validate<T>(ServiceBusResponse<List<T>> result) where T : class
        {
            if (result == null ||
                result.Data == null ||
                result.Data.Count == 0 ||
                result.StatusCode != System.Net.HttpStatusCode.OK)
                return new();

            return result.Data;
        }
    }
}
