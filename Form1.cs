using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boter_kaas_eieren
{
    public partial class Form1 : Form
    {
        bool Turn = true;// true = X turn; false = Y turn
        int Turn_count = 0;



        public Form1()
        {
            InitializeComponent();
        }

        private void bestandToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Button_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (Turn)
                btn.Text = "x";
            else
                btn.Text = "o";

            Turn = !Turn;
            btn.Enabled = false;
            Turn_count++;

            checkForWinner();
        }
        private void checkForWinner()
        {
            bool there_is_a_winner = false;


            //horizonetal checks

            if ((D1.Text == D2.Text) && (D2.Text == D3.Text) && (!D1.Enabled))
                there_is_a_winner = true;

            else if ((S1.Text == S2.Text) && (S2.Text == S3.Text) && (!S1.Enabled))
                there_is_a_winner = true;

            else if ((F1.Text == F2.Text) && (F2.Text == F3.Text) && (!F1.Enabled))
                there_is_a_winner = true;

            //verticale checks

            else if ((D1.Text == S1.Text) && (S1.Text == F1.Text) && (!D1.Enabled))
                there_is_a_winner = true;

            else if ((D2.Text == S2.Text) && (S2.Text == F2.Text) && (!D2.Enabled))
                there_is_a_winner = true;

            else if ((D3.Text == S3.Text) && (S3.Text == F3.Text) && (!D3.Enabled))
                there_is_a_winner = true;


            //diagonaal checks

            else if ((D1.Text == S2.Text) && (S2.Text == F3.Text) && (!D1.Enabled))
                there_is_a_winner = true;

            else if ((D3.Text == S2.Text) && (S2.Text == F1.Text) && (!D3.Enabled))
                there_is_a_winner = true;


            if (there_is_a_winner)
            {
                disableButtons();

                string winner = "";
                if (Turn)
                    winner = "o";
                else
                    winner = "x";

                MessageBox.Show(winner + " wins!", "Gewonnen");
            }//end if
            else
            {
                if (Turn_count == 9)
                    MessageBox.Show(" Gelijk spel!", "Jammer!");
            }
        }//end checkForWinner    

        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button btn = (Button)c;
                    btn.Enabled = false;

                }//end foreach

            }//end try
            catch { }
        }
        private void exitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Turn = true;
            Turn_count = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button btn = (Button)c;
                    btn.Enabled = true;
                    btn.Text = "";
                }//end for each
            }//end try
            catch { }

        }
    }
}