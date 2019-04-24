namespace MicroPOS.DAL
{
   public static class Helper
   {
      public static bool IsNullOrDefault<T>(this T? value) where T : struct
      {
         return default(T).Equals(value.GetValueOrDefault());
      }
   }
}
