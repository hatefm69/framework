using FIS.SQL_Oracle.HelperClasses;
using FIS.WebAPIFramework.Enums;

namespace InternalAudit.WebApi.Classes
{
    /// <summary>
    /// Handles all exceptions.
    /// </summary>
    public class ExceptionHandler : ErrorHandler
    {
        // Events.
        /// <summary>
        /// Excutes the exception method.
        /// </summary>
        /// <param name="request">The http request object</param>
        /// <param name="exception">The exception object</param>
        /// <param name="exceptionType">The exception type</param>
        /// <returns></returns>
        public override string Log(HttpRequest request, Exception exception, ExceptionType exceptionType)
        {
            string? trackingCode;

            if (request == null)
                trackingCode = ErrorLogger.Log(exception, exceptionType.ToString(), CmiDataContext.AppName);
            else
                trackingCode = ErrorLogger.Log(request, exception, request.Headers, CmiDataContext.AppName);
            var message = $"Tracking codes: '{trackingCode}'";

            Console.WriteLine(message);
            return message;
        }
    }
}