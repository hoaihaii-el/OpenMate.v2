namespace OpenMate.API.Infrastructure.Configuration
{
    public class CloudinarySetting
    {
        public static void LoadEnv()
        {
            DotNetEnv.Env.Load(".env");
        }

        public static string CloudName => "dx6aim1qs";
        public static string ApiKey => "751787178615129";
        public static string ApiSecret => "X0k_V6sQjPjLdcdZ5g3yIw-Gojo";
    }
}
