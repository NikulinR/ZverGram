using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZverGram.Db.Context
{
    public class DbContextOptionsFactory
    {
        public static Action<DbContextOptionsBuilder> Configure(string connectionString)
        {
            return (builder) => { builder.UseSqlServer(connectionString, opt =>
            {
                opt.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
            }); };
        }
        public static DbContextOptions<MainDbContext> Create(string connectionString)
        {
            var builder = new DbContextOptionsBuilder<MainDbContext>();
            Configure(connectionString).Invoke(builder);
            return builder.Options;
        }
    }
}
