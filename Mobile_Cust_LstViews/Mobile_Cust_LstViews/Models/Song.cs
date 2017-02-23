using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Cust_LstViews.Models
{
    public class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public int YearReleased { get; set; }
        public int BPM { get; set; }
        public bool IsFavorite { get; set; }

    }
}
