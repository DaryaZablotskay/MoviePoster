using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.EmailHelper.Interfaces
{
    public interface IEmailSender
    {
        Task Send(string place, DateTime date, string userEmail, string film);
    }
}
