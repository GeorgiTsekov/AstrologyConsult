﻿using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(AstrologyBlog.Web.Areas.Identity.IdentityHostingStartup))]

namespace AstrologyBlog.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => { });
        }
    }
}
