using static System.Net.WebRequestMethods;

namespace blogpessoal.Security
{
    public class Settings
    {
        private static string secret = "9bfc0453a829846ff25e806e5243a36bc86305972a456dd0d249d965a1c0e70f";
        public static string Secret { get => secret; set => secret = value; }
    }
}
