using System;
using System.Reflection;
using CommerceClient.Api.Model;
using CommerceClient.Api.Model.RequestModels;
using CommerceClient.Api.Online;
using JetBrains.Annotations;

namespace testcmd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.Write("Hit return to start.");
            Console.ReadLine();

            var cnn = new Connection(System.Configuration.ConfigurationManager.AppSettings.Get("hostname"))
            {
                HostOverride = System.Configuration.ConfigurationManager.AppSettings.Get("hostoverride")
            };
            try
            {

                var clientState = new ClientState();
                var (setHeaders, descriptiveContext) = cnn.GetContext(clientState);
                clientState = clientState.ChangeState(setHeaders);
                clientState.ApiKey = "eseller";
                clientState.ApiSecret = "abc"; // Yes, you guessed correctly - this is not a real production key :)
                LogRequestTest(cnn, clientState);
            }
            catch (NotFoundException e)
            {
                Console.WriteLine();
                Console.WriteLine("Whoops - the resource was not found:");
                Console.WriteLine("=====================");
                Console.WriteLine(e.ErrorResponse?.ToJsonRaw());
            }
            catch (UnauthorizedException e)
            {
                Console.WriteLine();
                Console.WriteLine("Insufficient priviledges:");
                Console.WriteLine("=========================");
                Console.WriteLine(e.Challenge);
                Console.WriteLine("  - Additional info:");

                foreach (var eReason in e.Reasons)
                {
                    Console.WriteLine($"    - {eReason}");

                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Something went wrong:");
                Console.WriteLine("=====================");
                Console.WriteLine(e.ToString());
            }


            Console.Write("Hit return to exit.");
            Console.ReadLine();

        }

        private static void LogRequestTest(Connection cnn, ClientState clientState)
        {
            var response =
                cnn.WriteLog(
                clientState,
                new LogRequest() { AppComponent = "ostebutik", Header = "Jeg tester app mac" }
            );
            Console.Write(response.ToJsonRaw());
        }
    }
    public static class AppExtensions
    {
        public static string ToJsonRaw<T>(
            [CanBeNull] this T source
        ) where T : class
        {
            // Don't serialize a null object, simply return the default for that object
            if (ReferenceEquals(
                source,
                null
            ))
            {
                return null;
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(source);
        }
    }
}
