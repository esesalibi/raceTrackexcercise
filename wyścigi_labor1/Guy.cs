using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wyścigi_labor1
{
    public class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;

        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdateLabels()
        {
            MyRadioButton.Text = $"{Name} ma {Cash} zł";
            MyLabel.Text = MyBet.GetDescription();
        }

        public void ClearBet()
        {
            MyBet.Bettor = this;
            MyBet.Amount = 0;
            UpdateLabels();

        }

        public bool PlaceBet(int amount, int dogToWin)
        {
            if (Cash < amount)
                return false;

            
            MyBet.Bettor = this;
            MyBet.Amount = amount;
            MyBet.Dog = dogToWin;
            return true;

        }
        public void Collect(int winner)
        {
            Cash += MyBet.Payout(winner);
        }
    }
}
