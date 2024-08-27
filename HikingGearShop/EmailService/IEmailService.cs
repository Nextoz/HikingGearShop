using HikingGearShop.OrderService.Data;
using System.Net.Mail;

namespace HikingGearShop.EmailService
{
    public interface IEmailService
    {
        void SendMonthyOrdersEmail();
        MailMessage GenerateEmailContent(List<Order> orders, string costumerEmail);
    }
}
