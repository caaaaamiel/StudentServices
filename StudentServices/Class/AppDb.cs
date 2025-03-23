namespace StudentServices.Class
{
    public class AppDb
    {

        public IConfiguration Configuration { get; set; }

        public string GetConnnection() => Configuration.GetSection("ConnectionStrings").GetSection("DbConString").Value;


        public AppDb(IConfiguration configuration)
        {
            Configuration = configuration;
        }


    }
}
 