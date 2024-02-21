using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace ExceptionMail
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Bir sayı girin: ");
                int number = Convert.ToInt32(Console.ReadLine());

                int sum = 0;
                for (int i = 1; i <= number; i++)
                {
                    sum += i;
                }

                Console.WriteLine($"1'den {number}'e kadar olan sayıların toplamı: {sum}");
            }
            catch (Exception ex)
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("mail.com");
                    mail.To.Add("merttekin@robotpos.com");
                    mail.Subject = "Uygulama Hatası Bildirimi";
                    mail.Body = "Hata Ayrıntıları: " + ex.ToString();

                    using (SmtpClient smtp = new SmtpClient("smtp.office365.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("mail.com", "password");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }

                Console.WriteLine("Uygulamada bir hata oluştu. Hata ayrıntıları e-posta ile gönderildi.");
            }
        }
    }
}
