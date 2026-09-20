using CarBook.Application.Interfaces;
using CarBook.Persistence.Options;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace CarBook.Persistence.Repositories;

public class SendMailRepository(IOptions<MailSettingsOption> options) : ISendMailRepository
{
    private readonly MailSettingsOption _mailSettings = options.Value;

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

}
