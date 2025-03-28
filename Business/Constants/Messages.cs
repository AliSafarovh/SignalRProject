using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {

        // Ümumi mesajlar
        public static string MaintenanceTime = "Sistem baxımdadır";
        public static string AuthorizationDenied = "Səlahiyyətiniz yoxdur";

        // Məhsul ilə bağlı mesajlar
        public static string ProductAdded = "Məhsul yükləndi";
        public static string ProductNameInvalid = "Bu adda məhsul artıq mövcuddur";
        public static string ProductNameNotFound = "Bu adda məhsul mövcüd deyil";
        public static string ProductNotFound = "Heç bir məhsul tapılmadı";
        public static string ProductListed = "Məhsulların siyahısı";
        public static string ProductDeleted = "Məhsul silindi";
        public static string ProductUpdated = "Məhsul dəyişdirildi";
        public static string ProductCountOfCategoryError = "Daxil etdiyiniz məhsulun ən azı 10 məhsul olduğu kateqoriyada olmalıdır";

        // Kateqoriya ilə bağlı mesajlar
        public static string CategoryLimitedExceeded = "Kateqoriya limiti aşılmışdır";

        // İstifadəçi ilə bağlı mesajlar
        public static string UserNotFound = "İstifadəçi tapılmadı";
        public static string PasswordError = "Şifrə səhvdir";
        public static string SuccessfulLogin = "Sistemdə uğurlu giriş";
        public static string UserAlreadyExists = "Bu istifadəçi artıq mövcuddur";
        public static string UserRegistered = "İstifadəçi uğurla qeydiyyatdan keçdi";
        public static string AccessTokenCreated = "Access token uğurla yaradıldı";


    }
}
