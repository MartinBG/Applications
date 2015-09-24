using System;

namespace Application_Objects
{
    public class Application
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public DateTime? PostDate { get; set; }
        public string Subject { get; set; }
        public string RegistrationNumber { get; set; }
        public bool IsActive { get; set; }

        public Application()
        {
            this.Sender = "";
            this.PostDate = null;
            this.Subject = "";
            this.RegistrationNumber = "";
            this.IsActive = false;
        }

        public Application(string sender, DateTime postDate, string subject, string registrationNumber, bool isActive)
        {
            this.Sender = sender;
            this.PostDate = postDate;
            this.Subject = subject;
            this.RegistrationNumber = registrationNumber;
            this.IsActive = isActive;
        }

    }
}
