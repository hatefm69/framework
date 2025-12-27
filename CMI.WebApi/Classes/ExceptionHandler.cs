using FIS.WebAPIFramework.Enums;

namespace CMI.WebApi.Classes
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
            // ToDo: Replace the below code with your code to save the exceptions
            return $"Type: {exceptionType}\r\n\r\nMessage: {exception.Message}\r\n\r\nStack Trace: {exception.StackTrace}";
        }
    }
}