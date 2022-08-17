using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Configurations
{
   public  class AppUserConfiguration:BaseConfiguration<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            base.Configure(builder);
            builder.HasOne(x => x.Profile).WithOne(x => x.AppUser).HasForeignKey<AppUserProfile>(x => x.ID);//birebir ilişki icin ayarımızı burada yaptık...

            //Bizim AppUser class'ımızın bizim yazdıgımız property'lerin yanı sıra Microsoft'un identity kütüphanesinden gelen property'leri de olacaktır...Identity'den gelen bu property'lerin icerisinde primary key olan ve Id ismine sahip olan bir property daha olacaktır...DOlayısıyla bu class , tabloya cevrilirken hem bizim ID property'miz hem de Identity'den gönderdigi Id property'si Sql'deki Incasesensitive durumu yüzünden aynı sütun sayılarak size migration durumunda bir tabloda aynı isimde iki sütun olamaz diye bir hata cıkaracaktır...Dolayısıyla bizim burada ID'miz C#'ta kalsa onu (kendi ID'mizi) Sql'e göndermememiz gerekecektir...

            builder.Ignore(x => x.ID);

        }
    }
}
