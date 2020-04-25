using System;
using Evercraft.Web.Common.Storage;
using Microsoft.EntityFrameworkCore;

namespace Evercraft.Web.Test.Support
{
    public static class EvercraftContextFactory
    {
        public static EvercraftContext Create()
        {
            var options = new DbContextOptionsBuilder<EvercraftContext>()
                .UseInMemoryDatabase($"{Guid.NewGuid()}")
                .Options;

            return new EvercraftContext(options);
        }
    }
}