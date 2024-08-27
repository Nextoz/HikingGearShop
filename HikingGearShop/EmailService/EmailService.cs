
using HikingGearShop.OrderService.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;

namespace HikingGearShop.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IOrderRepository _orderRepository;
       
        public EmailService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public void SendMonthyOrdersEmail()
        {
            var ordersForPreviousMonth =  _orderRepository.GetOrderForPreviousMonth(DateTime.Now);
            
            var ordersPerCustomer = ordersForPreviousMonth.GroupBy(o => o.CustomerEmail);

            foreach(var customerOrders in ordersPerCustomer)
            {
                var mailContent = GenerateEmailContent(customerOrders.ToList(), customerOrders.Key);

                SendEmail(mailContent);
            }
        }

        public MailMessage GenerateEmailContent(List<Order> orders, string costumerEmail)
        {
            var document = new Document();
            MemoryStream ms = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(document, ms);

            document.Open();
            document.Add(new Paragraph("Monthly Order Summary"));
            document.Add(new Paragraph($"Customer: {costumerEmail}"));
            document.Add(new Paragraph($"Date: {DateTime.Now.ToShortDateString()}"));
            document.Add(new Paragraph("\n"));

            foreach (var order in orders)
            {
                document.Add(new Paragraph($"Order ID: {order.Id}"));
                document.Add(new Paragraph($"Order Date: {order.OrderDate.ToShortDateString()}"));
                document.Add(new Paragraph($"Total Price: {order.TotalPrice:C}"));
                document.Add(new Paragraph("Items:"));

                foreach (var item in order.Items)
                {
                    document.Add(new Paragraph($"- {item.Quantity}x {item.Product.Name} at {item.Price:C} each"));
                }

                document.Add(new Paragraph("\n")); 
            }

            writer.CloseStream = false;
            document.Close();
            ms.Position = 0;

            MailMessage mailMessage = new MailMessage("noreply@hikewebshop.dk", costumerEmail)
            {
                Subject = "Monthly Order Summary",
                IsBodyHtml = true,
                Body = "Please find attached your monthly order summary."
            };

            mailMessage.Attachments.Add(new Attachment(ms, "MonthlyOrderSummary.pdf"));

            return mailMessage;

        }

        private static void SendEmail(MailMessage mailMessage)
        {
            SmtpClient smtpClient = new SmtpClient()
            {
                Host = "smtp.hikewebshop.dk",
                Port = 587,
                EnableSsl = true,
                Credentials = CredentialCache.DefaultNetworkCredentials // Der skal være ægte credentials her
            };

            smtpClient.Send(mailMessage);
        }

    }

}

