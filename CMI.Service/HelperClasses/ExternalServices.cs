using FIS.AfraServices;
using FIS.Sana;
using Microsoft.Extensions.Hosting;

namespace CMI.Service.HelperClasses
{
    public class ExternalServices
    {
        // Constants.
        const string AspnetcoreEnvironment = "ASPNETCORE_ENVIRONMENT";

        // Propeties.
        public static bool IsDevelopmentMode => Environment.GetEnvironmentVariable(AspnetcoreEnvironment) == Environments.Development;

        public static bool IgnoreSSL
        {
            get
            {
                var value = Environment.GetEnvironmentVariable("IGNORE_SSL");

                return string.IsNullOrEmpty(value) == false && value.ToUpper().Equals("TRUE");
            }
        }

        // Functions.
        public static IAfra GetAfra()
        {
            var afra = Afra.Instance;
            afra.IgnoreCustomCertifacateValidation = IsDevelopmentMode || IgnoreSSL;
            return afra;
        }
        public static ISana GetSana()
        {
            var sana = Sana.Instance;

            sana.IgnoreCustomCertifacateValidation = IsDevelopmentMode || IgnoreSSL;
            return sana;
        }
    }
}
