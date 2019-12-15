using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Divisio.Models
{
    public class AccountModel : GlobalModel
    {
        private int idAccount;
        private string usernaam;
        private string paswoord;
        private string email;
        private Boolean actief;
        private int? idAccountType;
        private int? idUser;
        //private string validatiePaswoordBericht;


        public int IdAccount
        {
            get { return idAccount; }
            set
            {
                idAccount = value;
                FirePropertyChanged();
            }
        }


        public string Usernaam
        {
            get { return usernaam; }
            set
            {
                usernaam = value;
                FirePropertyChanged();
            }
        }

        public string Paswoord
        {
            get { return paswoord; }
            set
            {
                paswoord = value;
                FirePropertyChanged();
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                FirePropertyChanged();
            }
        }

        public Boolean Actief
        {
            get { return actief; }
            set
            {
                actief = value;
                FirePropertyChanged();
            }
        }

        public int? IdAccountType
        {
            get { return idAccountType; }
            set
            {
                idAccountType = value;
                FirePropertyChanged();
            }
        }

        public int? IdUser
        {
            get { return idUser; }
            set
            {
                idUser = value;
                FirePropertyChanged();
            }
        }

        /*public string ValidatiePaswoordBericht
        {
            get { return validatiePaswoordBericht; }
            set
            {
                validatiePaswoordBericht = value;
                FirePropertyChanged();
            }
        }*/




        public static bool ValideerEmail(string emailAddress)
        {
            var regex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            bool isValid = Regex.IsMatch(emailAddress, regex, RegexOptions.IgnoreCase);
            return isValid;
        }
    }
}
