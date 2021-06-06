using System;

namespace Lazy.Abp.Utils
{
    public static class DateTimeHelper
    {
        public static int CalcAgrByBirthdate(DateTime birthdate, DateTime nowTime)
        {
            int age = nowTime.Year - birthdate.Year;
            if (nowTime.Month < birthdate.Month || (nowTime.Month == birthdate.Month && nowTime.Day < birthdate.Day))
            {
                age--;
            }
            return age < 0 ? 0 : age;
        }
    }
}
