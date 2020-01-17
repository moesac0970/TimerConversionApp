using B4.PE2.ManuVanLook.Domain.Services;
using System;
using System.Net.Mail;

namespace Consoletest
{
    class Program
    {
        
        static void Main(string[] args)
        {

            Console.ReadKey();
            MailService mailService = new MailService();
            Console.WriteLine("Hello World!");
            string Txtpoints = "7,5";
            string txtBegin = "Hey";
            string txtName = "manu";
            string txtTtile = "feedback test";
            string txtFeedback = "Lorem Ipsum is slechts een proeftekst uit het drukkerij- en zetterijwezen. Lorem Ipsum is de standaard proeftekst in deze bedrijfstak sinds de 16e eeuw, toen een onbekende drukker een zethaak met letters nam en ze door elkaar husselde om een font-catalogus te maken. Het heeft niet alleen vijf eeuwen overleefd maar is ook, vrijwel onveranderd, overgenomen in elektronische letterzetting. Het is in de jaren '60 populair geworden met de introductie van Letraset vellen met Lorem Ipsum passages en meer recentelijk door desktop publishing software zoals Aldus PageMaker die versies van Lorem Ipsum bevatten.";
            string txtPlus = "+++++++++++++++dedede++++++++";
            string txtCon = "---------------dededede----------";
            string email = "manu09ice@gmail.com";
            MailMessage mailMessage = new MailMessage
            {
                Subject = txtTtile,
                Body = $"{txtBegin}\r\n, You've got an {Txtpoints}.\r\n\r\n" +
               $"feeback: {txtFeedback}\r\n" +
               $"--------------------------" + "--------------------------" + "--------------------------\r\n\r\n" +
               $"the pro's of the app: \t{txtPlus}\r\n" +
               $"the con's of the app: \t{txtCon}\r\n" +
               $"\r\n ,Greetings\r\n" +
               $"{txtName}"

            };

            // receivers:
            mailMessage.To.Add(new MailAddress(email));
            mailService = new MailService();
            mailService.SendMail(mailMessage);
            Console.WriteLine("done ***************************$ ");
        }
    }
}
