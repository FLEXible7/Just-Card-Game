using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Same_Cards
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        List<string> iconsNames = new List<string>()
        {
            "j", "j", "l", "l", "b", "b", ",", ",",
            "-", "-", "[", "[", "v", "v", "o", "o"
        };

        Label firstClicked, secondClicked;

        public Form1()
        {
            InitializeComponent();
            PutIconsToCards();
        }

        private void card_Click(object sender, EventArgs e)
        {
            Label clickedCard = sender as Label;

            if (firstClicked != null && secondClicked != null)
                return;

            if (clickedCard == null)
                return;

            if (clickedCard.ForeColor == Color.White)
                return;

            if (firstClicked == null)
            {
                firstClicked = clickedCard;
                firstClicked.ForeColor = Color.White;
                return;
            }

            secondClicked = clickedCard;
            secondClicked.ForeColor = Color.White;

            CheckForEnd();
        
            if (firstClicked.Text == secondClicked.Text)
            {
                firstClicked = null;
                secondClicked = null;
            }

            else timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }

        public void PutIconsToCards()
        {
            Label picture;
            int randomIndex;


            for (int i = 0; i < CardsPanel.Controls.Count; i++)
            {
                if (CardsPanel.Controls[i] is Label)
                {
                    picture = (Label)CardsPanel.Controls[i];
                }
                else continue;

                randomIndex = random.Next(0, iconsNames.Count);
                picture.Text = iconsNames[randomIndex];
                iconsNames.RemoveAt(randomIndex);
            }
        }

        public void CheckForEnd()
        {
            Label label;

            for(int i = 0; i < CardsPanel.Controls.Count; i++)
            {
                label = CardsPanel.Controls[i] as Label;

                if (label != null && label.ForeColor == label.BackColor)
                    return;
            }
            MessageBox.Show("Победа!");
            Close();
        }
    }
}
