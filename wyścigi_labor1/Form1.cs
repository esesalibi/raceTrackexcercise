using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace wyścigi_labor1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();



            InitBettors();
            InitGreyhounds();
            InitControls();
        }
        Greyhound[] greyhounds = new Greyhound[4];
        Guy[] guys = new Guy[3];
        Guy selectedGuy;

        private void InitBettors()
        {
            guys[0] = new Guy()
            {
                Name = "Janek",
                MyBet = new Bet(),
                Cash = 50,
                MyRadioButton = RadioButton1,
                MyLabel = label4,
            };
            selectedGuy = guys[0];
            guys[1] = new Guy()
            {
                Name = "Bartek",
                MyBet = new Bet(),
                Cash = 75,
                MyRadioButton = radioButton2,
                MyLabel = label5,
            };
            guys[2] = new Guy()
            {
                Name = "Arek",
                MyBet = new Bet(),
                Cash = 45,
                MyRadioButton = radioButton3,
                MyLabel = label6
            };
            ClearGuysBets();
        }

        private void ClearGuysBets()
        {
            foreach (var guy in guys)
            {
                guy.ClearBet();

            }
        }

        private void InitGreyhounds()
        {
            Random myRandomizer = new Random();
            greyhounds[0] = new Greyhound()
            {
                Id = 1,
                MyPictureBox = pictureBox2,
                StartingPosition = pictureBox2.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox2.Width,
                MyRandom = myRandomizer
            };
            greyhounds[1] = new Greyhound()
            {
                Id = 2,
                MyPictureBox = pictureBox3,
                StartingPosition = pictureBox3.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox3.Width,
                MyRandom = myRandomizer
            };
            greyhounds[2] = new Greyhound()
            {
                Id = 3,
                MyPictureBox = pictureBox4,
                StartingPosition = pictureBox4.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox4.Width,
                MyRandom = myRandomizer
            };
            greyhounds[3] = new Greyhound()
            {
                Id = 4,
                MyPictureBox = pictureBox5,
                StartingPosition = pictureBox5.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox5.Width,
                MyRandom = myRandomizer
            };
        }

        private void InitControls()
        {
            minimumBetLabel.Text = "minimalny zakład" + numericUpDown1.Minimum.ToString();
            SetSelectedGuyName();
        }

        private void SetSelectedGuyName()
        {
            label1.Text = selectedGuy.Name;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            groupBox1.Enabled = false;
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SetSelectedGuy(0);
        }

        private void SetSelectedGuy(int index)
        {
            selectedGuy = guys[index];
            SetSelectedGuyName();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SetSelectedGuy(1);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SetSelectedGuy(2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectedGuy.PlaceBet(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value));
            selectedGuy.UpdateLabels();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var pies in greyhounds)
            {
                if (pies.Run())
                {
                    timer1.Stop();
                    RaceFinished(pies);
                    groupBox1.Enabled = true;
                }
            }
        }

        private void RaceFinished(Greyhound pies)
        {
            MessageBox.Show($"Chart numer {pies.Id} wygrał wyścig","Mamy zwycięzcę!");
            CollectBets(pies);
            RaceRestart();
        }

        private void RaceRestart()
        {
            ClearGuysBets();
            foreach(var pies in greyhounds)
            {
                pies.TakeStartingPosition();
            }
        }

        private void CollectBets(Greyhound pies)
        {
            foreach (var ziomek in guys)
            {
                ziomek.Collect(pies.Id);
                ziomek.UpdateLabels();
                
            }
        }
        
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
