using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divisio.Models
{
    public class UserModel : GlobalModel
    {
        private int idUser;
        private string naam;
        private string voornaam;
        private string straat;
        private string huisnummer;
        private int idPostcodeGemeente;

        public int IdUser
        {
            get { return idUser; }
            set
            {
                idUser = value;
                FirePropertyChanged();
            }
        }

        public string Naam
        {
            get { return naam; }
            set
            {
                naam = value;
                FirePropertyChanged();
            }
        }

        public string Voornaam
        {
            get { return voornaam; }
            set
            {
                voornaam = value;
                FirePropertyChanged();
            }
        }

        public string Straat
        {
            get { return straat; }
            set
            {
                straat = value;
                FirePropertyChanged();
            }
        }

        public string Huisnummer
        {
            get { return huisnummer; }
            set
            {
                huisnummer = value;
                FirePropertyChanged();
            }
        }

        public int IdPostcodeGemeente
        {
            get { return idPostcodeGemeente; }
            set
            {
                idPostcodeGemeente = value;
                FirePropertyChanged();
            }
        }
    }
}
