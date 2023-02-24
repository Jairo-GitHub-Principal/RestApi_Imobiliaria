using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_ImobiliariaSantos.Models
{
    public class ContextoDataBase:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;DataBase=ImobiliariaSantos;Uid=root;Pwd=;");
        }

        public DbSet <Imoveis> imoveis{get;set;}
        public DbSet <Locatarios> locatarios{get;set;}
        
    }
}