namespace SampleProject.Web.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IFileLogger fileLogger;
        public  static Dictionary<InputType, string> dist = new Dictionary<InputType, string>() {
            {InputType.EmailSent, "email sent"}, {InputType.UserCreated, "user created"}};

        public CustomerController(IFileLogger fileLogger) {
            this.fileLogger = fileLogger;;
        }
        [HttpPost]
        public void CreateUser(DonorDetails donorDetails)
        {
            if (donorDetails == null) throw new ArgumentNullException(nameof(donorDetails));
            this.fileLogger.AddEntry(dist[InputType.UserCreated]);
        }

        [HttpPost]
        public void SendEmail(EmailDetails emailDetails)
        {
            if (emailDetails == null) throw new ArgumentNullException(nameof(emailDetails));
            this.fileLogger.AddEntry(dist[InputType.EmailSent]);
        }
    }
}