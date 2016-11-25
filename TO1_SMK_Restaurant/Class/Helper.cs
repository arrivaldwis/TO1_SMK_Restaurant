using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                if (address.IndexOfAny(".".ToCharArray()) != -1)
                {
                    if (!address.Contains("..") || !address.Contains(".@") || !address.Contains("@.") || !address.Contains("._."))
                    {
                        if (!address.EndsWith("."))
                        {
                            msg = true;
                        }
                    }
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

        public bool onlyNumberTextField(TextBox tb)
        {
            bool msg = true;
            if (tb.Text.Any(x => char.IsLetter(x)))
            {
                msg = false;
            }

            return msg;
        }

        public static smk_restaurantEntities GetDB()
        {
            return new smk_restaurantEntities();
        }
    }
}
