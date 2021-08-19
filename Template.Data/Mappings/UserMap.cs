using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Entities;

namespace Template.Data.Mappings
{
    /* NuGet: EntityFrameworkCore, SqlServer, SqlServerDesign
    
    Classe de Mapeamento do usuario */
    public class UserMap: IEntityTypeConfiguration<User> //interface da entityframework core com a entidade que vc precisa, no caso User
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //aqui dentro voce estipula as configuracoes desejadas

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        }
            
    }
}
