using CarBook.Application.Interfaces;
using CarBook.Persistence.Options;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace CarBook.Persistence.Repositories;

public class SendMailRepository(IOptions<MailSettingsOption> options) : ISendMailRepository
{
    private readonly MailSettingsOption _mailSettings = options.Value;
    private static readonly Regex BoldRegex = new(@"\*\*(.+?)\*\*", RegexOptions.Compiled);
    private static readonly Regex InfoLineRegex = new(
        @"^(?<icon>[^\p{L}\p{N}\s*]+)\s+\*\*(?<label>[^*]+)\*\*\s*(?<value>.+)$",
        RegexOptions.Compiled);
    private static readonly Regex CalloutRegex = new(
        @"^(?<icon>[^\p{L}\p{N}\s*]+)\s*(?<text>.+)$",
        RegexOptions.Compiled);

    private static string Enc(string text) =>
        BoldRegex.Replace(WebUtility.HtmlEncode(text), "<strong>$1</strong>");

    public async Task SendForgotPasswordCode(string Email, string resetCode)
    {
        var email = new MimeMessage();

        email.From.Add(new MailboxAddress("CarBook Destek", _mailSettings.SenderEmail));
        email.To.Add(MailboxAddress.Parse(Email));
        email.Subject = "CarBook - Şifre Sıfırlama Doğrulama Kodu";

        var builder = new BodyBuilder
        {
            HtmlBody = GetCarBookForgetPasswordEmailTemplate(resetCode)
        };

        email.Body = builder.ToMessageBody();

        using var smtp = new SmtpClient();

        await smtp.ConnectAsync(_mailSettings.Server, _mailSettings.Port, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_mailSettings.SenderEmail, _mailSettings.Password);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }

    public async Task SendMailAsync(string ReceiverEmail, string ReceiverName, string ReplySubject, string ReplyMessage)
    {
        var email = new MimeMessage();
        email.From.Add(new MailboxAddress("CarBook Ekibi", _mailSettings.SenderEmail));
        email.To.Add(MailboxAddress.Parse(ReceiverEmail));
        email.Subject = !string.IsNullOrEmpty(ReplySubject) ? ReplySubject : "CarBook - Mesajınız Hakkında Bilgilendirme";

        var builder = new BodyBuilder
        {
            HtmlBody = GetCarBookReplyEmailTemplate(ReceiverName, ReplyMessage)
        };

        email.Body = builder.ToMessageBody();

        using var smtp = new SmtpClient();

        await smtp.ConnectAsync(_mailSettings.Server, _mailSettings.Port, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_mailSettings.SenderEmail, _mailSettings.Password);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }

    public async Task SendWelcomeEmailAsync(string emailAddress, string userName)
    {
        var email = new MimeMessage();
        email.From.Add(new MailboxAddress("CarBook Ekibi", _mailSettings.SenderEmail));
        email.To.Add(MailboxAddress.Parse(emailAddress));
        email.Subject = "CarBook - CarBook Ailesine Hoş Geldiniz";

        var builder = new BodyBuilder
        {
            HtmlBody = GetCarBookWelcomeEmailTemplate(userName)
        };

        email.Body = builder.ToMessageBody();

        using var smtp = new SmtpClient();

        await smtp.ConnectAsync(_mailSettings.Server, _mailSettings.Port, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_mailSettings.SenderEmail, _mailSettings.Password);

        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }

    public async Task SendResetPassword(string Name, string Surname, string Email)
    {
        var email = new MimeMessage();
        email.From.Add(new MailboxAddress("CarBook Güvenlik", _mailSettings.SenderEmail));
        email.To.Add(MailboxAddress.Parse(Email));
        email.Subject = "CarBook - Şifreniz Başarıyla Sıfırlandı";

        string fullName = $"{Name} {Surname}".Trim();

        var builder = new BodyBuilder
        {
            HtmlBody = GetCarBookResetPasswordEmailTemplate(fullName)
        };

        email.Body = builder.ToMessageBody();

        using var smtp = new SmtpClient();

        await smtp.ConnectAsync(_mailSettings.Server, _mailSettings.Port, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_mailSettings.SenderEmail, _mailSettings.Password);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }
    public async Task SendReservationDetailsAsync(string toEmail, string subject, string message)
    {
        var email = new MimeMessage();
        email.From.Add(new MailboxAddress("CarBook", _mailSettings.SenderEmail));
        email.To.Add(MailboxAddress.Parse(toEmail));
        email.Subject = subject;

        var builder = new BodyBuilder
        {
            HtmlBody = GetCarBookReservationDetailsTemplate(message)
        };

        email.Body = builder.ToMessageBody();

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_mailSettings.Server, _mailSettings.Port, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_mailSettings.SenderEmail, _mailSettings.Password);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }

    private string GetCarBookReplyEmailTemplate(string receiverName, string replyMessage)
    {
        string formattedMessage = string.IsNullOrEmpty(replyMessage)
            ? ""
            : replyMessage.Replace("\r\n", "<br/>").Replace("\n", "<br/>");

        return $@"
<!DOCTYPE html>
<html lang='tr'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>CarBook Bilgilendirme</title>
</head>
<body style='margin: 0; padding: 0; background-color: #f3f4f6; font-family: -apple-system, BlinkMacSystemFont, ""Segoe UI"", Roboto, Helvetica, Arial, sans-serif;'>
    <table border='0' cellpadding='0' cellspacing='0' width='100%' style='table-layout: fixed;'>
        <tr>
            <td align='center' style='padding: 40px 10px;'>
                <!-- Ana Kart -->
                <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px; background-color: #ffffff; border-radius: 12px; overflow: hidden; box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1); border: 1px solid #e5e7eb;'>
                    
                    <!-- Header / Logo Alanı -->
                    <tr>
                        <td align='center' style='background-color: #111827; padding: 32px 20px; border-bottom: 4px solid #10b981;'>
                            <h1 style='color: #ffffff; font-size: 28px; font-weight: 800; margin: 0; letter-spacing: -0.5px;'>
                                CAR<span style='color: #10b981;'>BOOK</span>
                            </h1>
                            <p style='color: #9ca3af; font-size: 13px; margin: 6px 0 0 0; text-transform: uppercase; letter-spacing: 1px;'>Müşteri Destek Hizmetleri</p>
                        </td>
                    </tr>

                    <!-- İçerik Alanı -->
                    <tr>
                        <td style='padding: 40px 32px; color: #374151;'>
                            <h2 style='color: #111827; font-size: 20px; font-weight: 700; margin-top: 0; margin-bottom: 16px;'>
                                Sayın {(string.IsNullOrEmpty(receiverName) ? "Müşterimiz" : receiverName)},
                            </h2>
                            <p style='color: #4b5563; font-size: 15px; line-height: 1.6; margin-bottom: 24px;'>
                                Bizimle iletişime geçtiğiniz için teşekkür ederiz. İletmiş olduğunuz talebiniz/mesajınız detaylıca incelenmiş olup yanıtımız aşağıda bilgilerinize sunulmuştur:
                            </p>

                            <!-- AI Yanıt Kutusu (Beyaz, Yeşil Vurgulu ve Koyu Çerçeveli) -->
                            <div style='background-color: #f9fafb; border-left: 4px solid #10b981; border-top: 1px solid #f3f4f6; border-right: 1px solid #f3f4f6; border-bottom: 1px solid #f3f4f6; border-radius: 0 8px 8px 0; padding: 20px 24px; margin-bottom: 28px;'>
                                <div style='color: #111827; font-size: 15px; line-height: 1.7; whitespace: pre-wrap;'>
                                    {formattedMessage}
                                </div>
                            </div>

                            <p style='color: #4b5563; font-size: 14px; line-height: 1.5; margin-bottom: 0;'>
                                Başka bir konuda yardıma ihtiyacınız olması durumunda bu e-postaya yanıt vererek veya web sitemiz üzerinden müşteri temsilcilerimizle iletişime geçebilirsiniz.
                            </p>
                        </td>
                    </tr>

                    <!-- Alt Bilgi / Footer -->
                    <tr>
                        <td style='background-color: #f9fafb; padding: 24px 32px; border-top: 1px solid #f3f4f6; text-align: center;'>
                            <p style='color: #111827; font-weight: 600; font-size: 14px; margin: 0 0 4px 0;'>CarBook Araç Kiralama A.Ş.</p>
                            <p style='color: #6b7280; font-size: 12px; margin: 0 0 16px 0;'>Konforlu ve Güvenli Yolculuğun Adresi</p>
                            <div style='border-top: 1px solid #e5e7eb; padding-top: 16px;'>
                                <p style='color: #9ca3af; font-size: 11px; margin: 0;'>
                                    © {DateTime.Now.Year} CarBook. Tüm hakları saklıdır.<br/>
                                    Bu e-posta otomatik olarak oluşturulmuştur.
                                </p>
                            </div>
                        </td>
                    </tr>

                </table>
            </td>
        </tr>
    </table>
</body>
</html>";
    }

    private string GetCarBookWelcomeEmailTemplate(string UserName)
    {
        string displayName = string.IsNullOrEmpty(UserName) ? "Değerli Üyemiz" : UserName;

        return $@"<!DOCTYPE html><html lang='tr'><head>    <meta charset='UTF-8'>    <meta name='viewport' content='width=device-width, initial-scale=1.0'>    <title>CarBook'a Hoş Geldiniz</title></head><body style='margin: 0; padding: 0; background-color: #f3f4f6; font-family: -apple-system, BlinkMacSystemFont, ""Segoe UI"", Roboto, Helvetica, Arial, sans-serif;'>    <table border='0' cellpadding='0' cellspacing='0' width='100%' style='table-layout: fixed;'>        <tr>            <td align='center' style='padding: 40px 10px;'>                <!-- Ana Kart -->                <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px; background-color: #ffffff; border-radius: 12px; overflow: hidden; box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1); border: 1px solid #e5e7eb;'>                                        <!-- Header / Logo Alanı -->                    <tr>                        <td align='center' style='background-color: #111827; padding: 32px 20px; border-bottom: 4px solid #10b981;'>                            <h1 style='color: #ffffff; font-size: 28px; font-weight: 800; margin: 0; letter-spacing: -0.5px;'>                                CAR<span style='color: #10b981;'>BOOK</span>                            </h1>                            <p style='color: #9ca3af; font-size: 13px; margin: 6px 0 0 0; text-transform: uppercase; letter-spacing: 1px;'>Aramıza Hoş Geldiniz</p>                        </td>                    </tr>                    <!-- İçerik Alanı -->                    <tr>                        <td style='padding: 40px 32px; color: #374151;'>                            <h2 style='color: #111827; font-size: 20px; font-weight: 700; margin-top: 0; margin-bottom: 16px;'>                                Sayın {displayName},                            </h2>                            <p style='color: #4b5563; font-size: 15px; line-height: 1.6; margin-bottom: 24px;'>                                CarBook ailesine katıldığınız için büyük bir heyecan duyuyoruz! Hesabınız başarıyla oluşturuldu. Artık geniş araç filomuzdan dilediğiniz aracı saniyeler içinde kiralayabilir, yolculuklarınızı konforlu ve güvenli hale getirebilirsiniz.                            </p>                            <!-- Bilgilendirme Kutusu -->                            <div style='background-color: #f9fafb; border-left: 4px solid #10b981; border-top: 1px solid #f3f4f6; border-right: 1px solid #f3f4f6; border-bottom: 1px solid #f3f4f6; border-radius: 0 8px 8px 0; padding: 20px 24px; margin-bottom: 28px;'>                                <h3 style='color: #111827; font-size: 15px; font-weight: 700; margin: 0 0 10px 0;'>Hesabınızla Neler Yapabilirsiniz?</h3>                                <ul style='margin: 0; padding-left: 18px; color: #4b5563; font-size: 14px; line-height: 1.8;'>                                    <li>Uygun fiyatlı ve son model araçları listeleyebilirsiniz.</li>                                    <li>Geçmiş ve aktif rezervasyonlarınızı kolayca yönetebilirsiniz.</li>                                    <li>Size özel kampanya ve indirimlerden anında haberdar olabilirsiniz.</li>                                </ul>                            </div>                            <!-- Buton (Call to Action) -->                            <table border='0' cellpadding='0' cellspacing='0' width='100%' style='margin-bottom: 28px;'>                                <tr>                                    <td align='center'>                                        <a href='https://carbook.com' target='_blank' style='background-color: #10b981; color: #ffffff; display: inline-block; padding: 14px 32px; font-size: 15px; font-weight: 600; text-decoration: none; border-radius: 8px;'>                                            Hemen Araç Kirala                                        </a>                                    </td>                                </tr>                            </table>                            <p style='color: #4b5563; font-size: 14px; line-height: 1.5; margin-bottom: 0;'>                                Herhangi bir sorunuz veya desteğe ihtiyacınız olduğunda 7/24 müşteri hizmetlerimizle iletişime geçebilirsiniz. Keyifli yolculuklar dileriz!                            </p>                        </td>                    </tr>                    <!-- Alt Bilgi / Footer -->                    <tr>                        <td style='background-color: #f9fafb; padding: 24px 32px; border-top: 1px solid #f3f4f6; text-align: center;'>                            <p style='color: #111827; font-weight: 600; font-size: 14px; margin: 0 0 4px 0;'>CarBook Araç Kiralama A.Ş.</p>                            <p style='color: #6b7280; font-size: 12px; margin: 0 0 16px 0;'>Konforlu ve Güvenli Yolculuğun Adresi</p>                            <div style='border-top: 1px solid #e5e7eb; padding-top: 16px;'>                                <p style='color: #9ca3af; font-size: 11px; margin: 0;'>                                    © {DateTime.Now.Year} CarBook. Tüm hakları saklıdır.<br/>                                    Bu e-posta otomatik olarak oluşturulmuştur.                                </p>                            </div>                        </td>                    </tr>                </table>            </td>        </tr>    </table></body></html>";
    }

    private string GetCarBookForgetPasswordEmailTemplate(string resetCode)
    {
        return $@"<!DOCTYPE html><html lang='tr'><head>    <meta charset='UTF-8'>    <meta name='viewport' content='width=device-width, initial-scale=1.0'>    <title>Şifre Sıfırlama Doğrulama Kodu</title></head><body style='margin: 0; padding: 0; background-color: #f3f4f6; font-family: -apple-system, BlinkMacSystemFont, ""Segoe UI"", Roboto, Helvetica, Arial, sans-serif;'>    <table border='0' cellpadding='0' cellspacing='0' width='100%' style='table-layout: fixed;'>        <tr>            <td align='center' style='padding: 40px 10px;'>                <!-- Ana Kart -->                <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px; background-color: #ffffff; border-radius: 12px; overflow: hidden; box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1); border: 1px solid #e5e7eb;'>                                        <!-- Header / Logo Alanı -->                    <tr>                        <td align='center' style='background-color: #111827; padding: 32px 20px; border-bottom: 4px solid #10b981;'>                            <h1 style='color: #ffffff; font-size: 28px; font-weight: 800; margin: 0; letter-spacing: -0.5px;'>                                CAR<span style='color: #10b981;'>BOOK</span>                            </h1>                            <p style='color: #9ca3af; font-size: 13px; margin: 6px 0 0 0; text-transform: uppercase; letter-spacing: 1px;'>Hesap Güvenliği</p>                        </td>                    </tr>                    <!-- İçerik Alanı -->                    <tr>                        <td style='padding: 40px 32px; color: #374151;'>                            <h2 style='color: #111827; font-size: 20px; font-weight: 700; margin-top: 0; margin-bottom: 16px;'>                                Sayın Kullanıcımız,                            </h2>                            <p style='color: #4b5563; font-size: 15px; line-height: 1.6; margin-bottom: 24px;'>                                CarBook hesabınız için şifre sıfırlama talebinde bulundunuz. Aşağıdaki doğrulama kodunu kullanarak yeni şifrenizi belirleyebilirsiniz:                            </p>                            <!-- Kod Kutusu -->                            <div style='background-color: #f9fafb; border: 2px dashed #10b981; border-radius: 8px; padding: 20px; text-align: center; margin-bottom: 28px;'>                                <span style='display: block; color: #6b7280; font-size: 12px; font-weight: 600; text-transform: uppercase; letter-spacing: 1px; margin-bottom: 6px;'>Şifre Sıfırlama Kodu</span>                                <span style='color: #111827; font-size: 32px; font-weight: 800; letter-spacing: 6px; font-family: monospace;'>{resetCode}</span>                            </div>                            <p style='color: #6b7280; font-size: 13px; line-height: 1.5; margin-bottom: 24px;'>                                ⚠️ <strong>Güvenlik Uyarısı:</strong> Eğer bu talebi siz yapmadıysanız lütfen bu e-postayı dikkate almayınız ve hesabınızın güvenliği için şifrenizi kimseyle paylaşmayınız.                            </p>                            <p style='color: #4b5563; font-size: 14px; line-height: 1.5; margin-bottom: 0;'>                                Güvenli yolculuklar dileriz.                            </p>                        </td>                    </tr>                    <!-- Alt Bilgi / Footer -->                    <tr>                        <td style='background-color: #f9fafb; padding: 24px 32px; border-top: 1px solid #f3f4f6; text-align: center;'>                            <p style='color: #111827; font-weight: 600; font-size: 14px; margin: 0 0 4px 0;'>CarBook Araç Kiralama A.Ş.</p>                            <p style='color: #6b7280; font-size: 12px; margin: 0 0 16px 0;'>Konforlu ve Güvenli Yolculuğun Adresi</p>                            <div style='border-top: 1px solid #e5e7eb; padding-top: 16px;'>                                <p style='color: #9ca3af; font-size: 11px; margin: 0;'>                                    © {DateTime.Now.Year} CarBook. Tüm hakları saklıdır.<br/>                                    Bu e-posta otomatik olarak oluşturulmuştur.                                </p>                            </div>                        </td>                    </tr>                </table>            </td>        </tr>    </table></body></html>";
    }

    private string GetCarBookResetPasswordEmailTemplate(string fullName)
    {
        string displayName = string.IsNullOrEmpty(fullName.Trim()) ? "Değerli Kullanıcımız" : fullName;

        return $@"<!DOCTYPE html><html lang='tr'><head>    <meta charset='UTF-8'>    <meta name='viewport' content='width=device-width, initial-scale=1.0'>    <title>Şifreniz Başarıyla Sıfırlandı</title></head><body style='margin: 0; padding: 0; background-color: #f3f4f6; font-family: -apple-system, BlinkMacSystemFont, ""Segoe UI"", Roboto, Helvetica, Arial, sans-serif;'>    <table border='0' cellpadding='0' cellspacing='0' width='100%' style='table-layout: fixed;'>        <tr>            <td align='center' style='padding: 40px 10px;'>                <!-- Ana Kart -->                <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px; background-color: #ffffff; border-radius: 12px; overflow: hidden; box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1); border: 1px solid #e5e7eb;'>                                        <!-- Header / Logo Alanı -->                    <tr>                        <td align='center' style='background-color: #111827; padding: 32px 20px; border-bottom: 4px solid #10b981;'>                            <h1 style='color: #ffffff; font-size: 28px; font-weight: 800; margin: 0; letter-spacing: -0.5px;'>                                CAR<span style='color: #10b981;'>BOOK</span>                            </h1>                            <p style='color: #9ca3af; font-size: 13px; margin: 6px 0 0 0; text-transform: uppercase; letter-spacing: 1px;'>Hesap Güvenliği</p>                        </td>                    </tr>                    <!-- İçerik Alanı -->                    <tr>                        <td style='padding: 40px 32px; color: #374151;'>                            <h2 style='color: #111827; font-size: 20px; font-weight: 700; margin-top: 0; margin-bottom: 16px;'>                                Sayın {displayName},                            </h2>                            <p style='color: #4b5563; font-size: 15px; line-height: 1.6; margin-bottom: 24px;'>                                CarBook hesabınızın şifresi başarıyla güncellenmiştir. Artık yeni şifrenizle sistemimize güvenle giriş yapabilirsiniz.                            </p>                            <!-- Bilgilendirme Kutusu -->                            <div style='background-color: #f9fafb; border-left: 4px solid #10b981; border-top: 1px solid #f3f4f6; border-right: 1px solid #f3f4f6; border-bottom: 1px solid #f3f4f6; border-radius: 0 8px 8px 0; padding: 20px 24px; margin-bottom: 28px;'>                                <p style='color: #111827; font-size: 14px; font-weight: 600; margin: 0 0 6px 0;'>İşlem Detayları:</p>                                <ul style='margin: 0; padding-left: 18px; color: #4b5563; font-size: 13.5px; line-height: 1.6;'>                                    <li><strong>Tarih:</strong> {DateTime.Now:dd.MM.yyyy HH:mm}</li>                                    <li><strong>Durum:</strong> Başarılı</li>                                </ul>                            </div>                            <!-- Güvenlik Uyarısı -->                            <p style='color: #6b7280; font-size: 13px; line-height: 1.5; margin-bottom: 24px;'>                                ⚠️ <strong>Bu işlemi siz yapmadıysanız:</strong> Hesabınızın yetkisiz kişilerin eline geçmiş olabileceğini düşünüyorsanız lütfen hemen müşteri hizmetlerimizle iletişime geçin.                            </p>                            <!-- Buton (Giriş Yap) -->                            <table border='0' cellpadding='0' cellspacing='0' width='100%' style='margin-bottom: 28px;'>                                <tr>                                    <td align='center'>                                        <a href='https://carbook.com/Auth/Login' target='_blank' style='background-color: #10b981; color: #ffffff; display: inline-block; padding: 14px 32px; font-size: 15px; font-weight: 600; text-decoration: none; border-radius: 8px;'>                                            Giriş Ekranına Git                                        </a>                                    </td>                                </tr>                            </table>                            <p style='color: #4b5563; font-size: 14px; line-height: 1.5; margin-bottom: 0;'>                                Güvenli yolculuklar dileriz.                            </p>                        </td>                    </tr>                    <!-- Alt Bilgi / Footer -->                    <tr>                        <td style='background-color: #f9fafb; padding: 24px 32px; border-top: 1px solid #f3f4f6; text-align: center;'>                            <p style='color: #111827; font-weight: 600; font-size: 14px; margin: 0 0 4px 0;'>CarBook Araç Kiralama A.Ş.</p>                            <p style='color: #6b7280; font-size: 12px; margin: 0 0 16px 0;'>Konforlu ve Güvenli Yolculuğun Adresi</p>                            <div style='border-top: 1px solid #e5e7eb; padding-top: 16px;'>                                <p style='color: #9ca3af; font-size: 11px; margin: 0;'>                                    © {DateTime.Now.Year} CarBook. Tüm hakları saklıdır.<br/>                                    Bu e-posta otomatik olarak oluşturulmuştur.                                </p>                            </div>                        </td>                    </tr>                </table>            </td>        </tr>    </table></body></html>";
    }

    private string GetCarBookReservationDetailsTemplate(string message)
    {
        var lines = message.Replace("\r\n", "\n").Split('\n')
         .Select(l => l.Trim())
         .Where(l => l.Length > 0)
         .ToList();

        var body = new StringBuilder();
        var infoRows = new List<(string Icon, string Label, string Value)>();

        void FlushInfoRows()
        {
            if (infoRows.Count == 0) return;

            body.Append("""<table role="presentation" width="100%" cellpadding="0" cellspacing="0" style="margin:20px 0;background:#F7F9FC;border:1px solid #E1E6EC;border-radius:14px;border-collapse:separate;">""");

            for (var i = 0; i < infoRows.Count; i++)
            {
                var (icon, label, value) = infoRows[i];
                var isPrice = label.Contains("Fiyat", StringComparison.OrdinalIgnoreCase);
                var border = i == infoRows.Count - 1 ? "none" : "1px solid #E9EEF4";
                var valueStyle = isPrice
                    ? "font-size:20px;font-weight:800;color:#3A7BC8;"
                    : "font-size:15px;font-weight:600;color:#2E3A46;";

                body.Append($"""
                <tr>
                  <td width="60" valign="middle" style="padding:14px 0 14px 16px;border-bottom:{border};">
                    <div style="width:40px;height:40px;line-height:40px;text-align:center;background:#EAF2FB;border-radius:12px;font-size:19px;">{Enc(icon)}</div>
                  </td>
                  <td valign="middle" style="padding:14px 16px 14px 8px;border-bottom:{border};">
                    <div style="font-size:11px;letter-spacing:0.6px;text-transform:uppercase;color:#8A96A3;font-weight:700;">{Enc(label)}</div>
                    <div style="margin-top:3px;{valueStyle}">{Enc(value)}</div>
                  </td>
                </tr>
                """);
            }

            body.Append("</table>");
            infoRows.Clear();
        }

        for (var i = 0; i < lines.Count; i++)
        {
            var line = lines[i];

            if (i == 0)
            {
                body.Append($"""<p style="margin:0 0 14px;font-size:19px;font-weight:700;color:#2E3A46;">{Enc(line)}</p>""");
                continue;
            }

            var info = InfoLineRegex.Match(line);
            if (info.Success)
            {
                infoRows.Add((
                    info.Groups["icon"].Value,
                    info.Groups["label"].Value.Trim().TrimEnd(':').Trim(),
                    info.Groups["value"].Value.Trim().TrimStart(':').Trim()));
                continue;
            }

            FlushInfoRows();

            // 3) İmza
            if (line.Contains("CarBook Ekibi", StringComparison.OrdinalIgnoreCase))
            {
                body.Append($"""<p style="margin:26px 0 0;padding-top:18px;border-top:1px solid #E9EEF4;font-size:15px;color:#2E3A46;">{Enc(line)}</p>""");
                continue;
            }

            // 4) Uyarı kutusu (❗ turuncu, diğerleri mavi)
            var callout = CalloutRegex.Match(line);
            if (callout.Success)
            {
                var icon = callout.Groups["icon"].Value;
                var isWarning = icon.StartsWith("❗", StringComparison.Ordinal) || icon.StartsWith("⚠", StringComparison.Ordinal);
                var bg = isWarning ? "#FFF6E5" : "#EAF2FB";
                var accent = isWarning ? "#F5B041" : "#4A90E2";
                var color = isWarning ? "#7A5312" : "#2A5F9E";

                body.Append($"""<div style="margin:10px 0;padding:13px 16px;background:{bg};border-left:4px solid {accent};border-radius:10px;font-size:14px;line-height:1.6;color:{color};">{Enc(line)}</div>""");
                continue;
            }

            // 5) Normal paragraf
            body.Append($"""<p style="margin:0 0 14px;">{Enc(line)}</p>""");
        }

        FlushInfoRows();

        return $"""
            <div style="background:#EAF2FB;padding:28px 12px;font-family:Segoe UI,Roboto,Arial,sans-serif;">
              <table role="presentation" align="center" width="100%" cellpadding="0" cellspacing="0" style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:18px;overflow:hidden;border:1px solid #E1E6EC;">
                <tr>
                  <td style="background-color:#4A90E2;background-image:linear-gradient(135deg,#4A90E2,#3A7BC8);padding:30px 28px 26px;text-align:center;color:#ffffff;">
                    <div style="font-size:32px;line-height:1;">🚗</div>
                    <div style="font-size:26px;font-weight:800;letter-spacing:0.5px;margin-top:8px;">CarBook</div>
                    <div style="font-size:12.5px;margin-top:4px;color:#DCEBFA;">Yolculuğunuz burada başlıyor</div>
                    <div style="display:inline-block;margin-top:16px;padding:7px 18px;background-color:#6BA6E8;border-radius:30px;font-size:12px;font-weight:700;color:#ffffff;">✅ Rezervasyon Bilgilendirmesi</div>
                  </td>
                </tr>
                <tr>
                  <td style="padding:28px;color:#2E3A46;font-size:14.5px;line-height:1.7;">{body}</td>
                </tr>
                <tr>
                  <td style="background:#FBFAF7;padding:16px 28px;text-align:center;border-top:1px solid #EEF1F5;color:#8A96A3;font-size:11.5px;line-height:1.6;">
                    Bu e-posta CarBook rezervasyon sistemi tarafından gönderilmiştir.<br>© {DateTime.Now.Year} CarBook · Tüm hakları saklıdır.
                  </td>
                </tr>
              </table>
            </div>
            """;
    }
}
