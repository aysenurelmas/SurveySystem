namespace Business.Messages;

public class BusinessMessages
{
    public static string UserNotActive = "Bu kullanıcı pasife alınmış";
    public static string UserDontExists = "Kullanıcı mevcut değil";
    public static string AuthorizationDenied = "Yetkiniz yok.";
    public static string PasswordError = "Şifre hatalı";
    public static string SuccessfulLogin = "Sisteme giriş başarılı";
    public static string UserAlreadyExists = "Bu email ile kayıtlı bir kullanıcı zaten mevcutt";




    public static string CreateAccessTokenNot = "Token Oluşturulamadı.";

    public const string? PasswordHaveToEqualToCheckPassword = "Yeni şifre ile ikinci şifre eşleşmiyor";
    public const string NewPasswordShouldBeDifferent = "Şifreniz son şifreyle anyı olamaz.";
    public const string PasswordDontMatch = "Yanlış E-posta veya şifre.";
    public const string HasUserParticipatedAsync = "Kullanıcı bu ankete zaten katıldı.";
    public const string SurveyNotFound = "Anket bulunamadı";


}
