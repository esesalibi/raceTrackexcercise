using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wyścigi_labor1
{
    public class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;

        public string GetDescription()
        {
            if (Amount != 0)
                return $"{Bettor.Name} stawia {Amount} zł na charta numer {Dog}";
            else
                return $"{Bettor.Name} nie zawarł zakładu";
        }

        public int Payout(int winner)
        {
            if (Dog == winner)
                return Amount;
            else
                return -Amount;
        }
    }
}
