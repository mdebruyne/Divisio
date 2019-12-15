using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divisio.Models
{
    public class ProvincieModel : GlobalModel
    {
        private int idProvincie;
        private string provincie;
        private int idLand;

        public int IdProvincie
        {
            get { return idProvincie; }
            set
            {
                idProvincie = value;
                FirePropertyChanged();
            }
        }
        public string Provincie
        {
            get { return provincie; }
            set
            {
                provincie = value;
                FirePropertyChanged();
            }
        }
        public int IdLand
        {
            get { return idLand; }
            set
            {
                idLand = value;
                FirePropertyChanged();
            }
        }
    }
}
