using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Data.Extensions;
using Template.Data.Mappings;
using Template.Domain.Entities;

namespace Template.Data.Context
{
    //classe de contexto
    public class TemplateContext: DbContext
    {
        //Constructor//
        public TemplateContext(DbContextOptions<TemplateContext> option) 
            : base(option) { }


        //Por n ter classe de mapeamento, foi criado esse dbset dentro dessa regiao:
        #region "DBSets"

        public DbSet<User> Users { get; set; }

        #endregion

        //Precisa setar aqui a classe de mapeamento para pegar todas as configuracoes na hora de rodar:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());

            modelBuilder.ApplyGlobalConfigurations();
            modelBuilder.SeedData();

            base.OnModelCreating(modelBuilder);
        }
    }// agora precisa setar na startup no projeto web pra rodar na aplicacao e criar uma conexao na appsettings.jason


}
