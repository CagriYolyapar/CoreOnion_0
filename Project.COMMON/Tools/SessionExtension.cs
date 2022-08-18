using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.COMMON.Tools
{
    public static class SessionExtension
    {
        //Session["scart"]

        //Serialization => Bir yapının Json formata dönüstürülmesidir

        //Deserialization => Json formatındaki bir bilginin ilgili yapıya dönüstürülmesidir

        //Bir Extension metodun alacagı ilk parametre ilgili davranısın hangi tipe eklenmesini istiyorsanız o tipte olmalıdır...

        //Extension metotlar sadece static sınıflarda yaratılabilir...Bir metot this ile parametre almazsa o zaman klasik bir metot olur...

        public static void SetObject(this ISession session,string key,object value)
        {
            string objectString = JsonConvert.SerializeObject(value); //Burada bize gelen object degeri JSON formatta bir string'e cevirdik...

            session.SetString(key, objectString);

        }

        //Session'u geri almak lazım...Generic Metotlar

        public static T GetObject<T>(this ISession session,string key) where T:class //(T bir referans tip olmak zorundadır)
        {
            string objectString = session.GetString(key);
            if (string.IsNullOrEmpty(objectString)) return null;
            T deserializeObject = JsonConvert.DeserializeObject<T>(objectString);
            return deserializeObject;
        }
    }
}
