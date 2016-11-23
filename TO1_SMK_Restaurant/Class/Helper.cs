using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TO1_SMK_Restaurant.Class
{
    public class Helper
    {
        public bool emailValidation(string email)
        {
            bool msg = false;
            try
            {
                string address = new MailAddress(email).Address;

                if (!address.EndsWith(".") && !address.Contains("@.") && !address.Contains(".@") && !address.Contains(".@.") && !address.Contains("_@"))
                {
                    msg = true;
                }
                else
                {
                    msg = false;
                }
            }
            catch (Exception ex)
            {
                msg = false;
            }

            return msg;
        }
    }
}
