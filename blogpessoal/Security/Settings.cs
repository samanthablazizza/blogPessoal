using static System.Net.WebRequestMethods;

namespace blogpessoal.Security
{
    public class Settings
    {
        private static string secret = "c4f80cbebb67f5edfe236a51172e516a6cba8ccb178d268dda69c045feb82bc1";
        public static string Secret { get => secret; set => secret = value; }
    }
}
