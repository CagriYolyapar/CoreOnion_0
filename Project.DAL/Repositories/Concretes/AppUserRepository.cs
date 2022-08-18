using Microsoft.AspNetCore.Identity;
using Project.DAL.Context;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concretes
{
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {
        //Sizin kendinize özel Crud işlemlerinin yine olması gerekir. ANcak unutmayın ki Identity yapısının özel şifrelemeler ve yetkilendirmeleri icin hazır async metotları vardır... Bu metotların kullanımı icin de ekstra olarak bu Repository'de ayrı alanlar acmak en dogrusudur... Bu metotlar Manager sınıfları icerisinde bulundurulur(UserManager,SignInManager Identity'de gömülü olan sınıflardır...) Bu sınıflar Dependency Injection ile calısırlar... Ve dolayısıyla Constructor based injection yapılabilir...

        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;

        public AppUserRepository(MyContext db,UserManager<AppUser> userManager,SignInManager<AppUser> signInManager):base(db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //Ozel bir Identity metodu async seklinde tanımlanmalıdır...Cünkü siz burada sonucta bir API kullanıyorsunuz...Ve bu API requestlerinin bloklanmadan devam edebilmesi icin ,işlemleri tamamlayarak hatasız bir şekilde akıcı olması icin await keyword'unun kullanılması gerekir...Calısma yaptıgınız metot icerisinde await keyword'unun kullanılabilmesi icin o metodun async seklinde tanımlanması gerekir ve Task döndürmesi gerekir

        public async Task<bool> AddUser(AppUser item)
        {
            //Sadece Asenkron olarak yaratılmkıs (asnyc marklı) metotlar icerisinde await kullanabilirsiniz...

            IdentityResult result =await _userManager.CreateAsync(item, item.PasswordHash);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(item, isPersistent: false); //isPersistent durumu Cookie'de dursun mu durmasın mı
                return true;
            }

            return false;
        }
    }
}
