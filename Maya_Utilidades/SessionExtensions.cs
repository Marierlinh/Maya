using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Maya_Utilidades
{
    public  static class SessionExtensions
    {
        //Set (para configurar la sesion)
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        //Get (para obtener el valor de la sesion)
        public static  T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value); 
        }
    }
}
