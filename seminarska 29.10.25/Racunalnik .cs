using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seminarska_29._10._25
{
    public class Racunalnik : Igralec
    {
        public Racunalnik(string ime) : base(ime)
        {
        }
        public override Karta OdigrajKarto()
        {
            // Preprosta strategija: vedno odigraj prvo karto iz roke
            return base.OdigrajKarto();
        }
    }
    
    
}
