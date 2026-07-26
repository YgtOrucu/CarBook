namespace CarBook.WebUI.Extensions
{
    public static class ServiceRegistrations
    {
        public static void UIServiceRegister(this IServiceCollection services, IConfiguration builder)
        {
            services.AddHttpClient("CarBookAPI", opt =>
            {
                var address = builder.GetSection("SwaggerApıAddress").Value;
                if (address == null)
                    throw new Exception("The ApıAddress could not be found");

                opt.BaseAddress = new Uri(address);
            });
        }
    }
}
