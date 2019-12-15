using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divisio.Models
{
    public class PostcodeGemeenteModel:GlobalModel
    {
        private int idGemeente;
        private string postcode;
        private string gemeente;
        private int idProvincie;


        public int IdGemeente
        {
            get { return idGemeente; }
            set
            {
                idGemeente = value;
                FirePropertyChanged();
            }
        }

        public string Postcode
        {
            get { return postcode; }
            set
            {
                postcode = value;
                FirePropertyChanged();
            }
        }

        public string Gemeente
        {
            get { return gemeente; }
            set
            {
                gemeente = value;
                FirePropertyChanged();
            }
        }

        public int IdProvincie
        {
            get { return idProvincie; }
            set
            {
                idProvincie = value;
                FirePropertyChanged();
            }
        }
    }
}
