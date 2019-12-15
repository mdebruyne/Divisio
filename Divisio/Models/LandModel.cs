using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divisio.Models
{
    public class LandModel:GlobalModel
    {
        private int idLand;
        private string land;

        public int IdLand
        {
            get { return idLand; }
            set
            {
                idLand = value;
                FirePropertyChanged();
            }
        }

        public string Land
        {
            get { return land; }
            set
            {
                land = value;
                FirePropertyChanged();
            }
        }
    }
}
