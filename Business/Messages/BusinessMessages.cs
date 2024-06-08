namespace Business.Messages;

public class BusinessMessages
{
    public static string UserNotActive = "Bu kullanıcı pasife alınmış";
    public static string UserDontExists = "Kullanıcı mevcut değil";
    public static string AuthorizationDenied = "Yetkiniz yok.";
    public static string PasswordError = "Şifre hatalı";
    public static string SuccessfulLogin = "Sisteme giriş başarılı";
    public static string UserAlreadyExists = "Bu email ile kayıtlı bir kullanıcı zaten mevcutt";



    public static string ImageError = "Desteklenmeyen format";

    public static string TCKNCouldNotBeVerified = "TC Kimlik numarası doğrulanamadı.";

    public static string CreateAccessTokenNot = "Token Oluşturulamadı.";
    public const string RefreshDontExists = "Böyle bir token bulunamadı.";
    public const string InvalidRefreshToken = "Geçersiz refresh token.";
    public const string InvalidResetToken = "Geçersiz reset token.";


    public const string? PasswordHaveToEqualToCheckPassword = "Yeni şifre ile ikinci şifre eşleşmiyor";
    public const string NewPasswordShouldBeDifferent = "Şifreniz son şifreyle anyı olamaz.";
    public const string PasswordDontMatch = "Yanlış E-posta veya şifre.";

    public const string SurveyNotExists = "Anket bulunamadı";


}
