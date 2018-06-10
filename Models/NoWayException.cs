using System;
namespace KursachAttemp2.Models
{
    public class NoWayException : Exception
    {
        public NoWayException()
            : base("There isn't a way")
        {
        }
    }
}
