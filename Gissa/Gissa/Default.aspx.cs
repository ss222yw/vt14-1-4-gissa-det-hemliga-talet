using Gissa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gissa
{
    public partial class Default : System.Web.UI.Page
    {
        //Kapslar in sessionsvariabel in i en privat egenskap.
        private SecretNumber SecretNumber
        {
            get
            {
                if (Session["SecretNumber"] == null)
                {
                    Session["SecretNumber"] = new SecretNumber();
                    return Session["SecretNumber"] as SecretNumber;

                }
                else
                {
                    return Session["SecretNumber"] as SecretNumber;
                }



            }


        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                int choiceNumber = int.Parse(SecretBox.Text);
                Outcome result = SecretNumber.MakeGuess(choiceNumber);
                PlaceHolder1.Visible = true;
                guesses.Text = string.Join(",  ", SecretNumber.PreviousGuesses);

                if (result == Outcome.High)
                {
                    guesses.Text += String.Format("  För högt!");
                }

                else if (result == Outcome.Low)
                {
                    guesses.Text += String.Format("  För lågt");
                }
                else if (result == Outcome.Correct)
                {
                    ResultLabel.Text += String.Format("<img src=pics/right.png />  Grattis , du klarade det med {0} försök", SecretNumber.Count);
                    SecretBox.Enabled = false;
                    SendButton.Enabled = false;
                    PlaceHolder1.Visible = true;
                    PlaceHolder2.Visible = true;
                    NewSendButton.Visible = true;
                    NewSendButton.Focus();
                }
                else if (result == Outcome.PreviousGuess)
                {
                    guesses.Text += String.Format("<img src=pics/warning.jpg />   Du har gissat redan talet.");
                }
                else if (result == Outcome.NoMoreGuesses)
                {
                    ResultLabel.Text = String.Format("  <img src=pics/wrong.png />   Du har inga gissningar kvar! . Det hemliga talet var {0}", SecretNumber.Number);
                    SecretBox.Enabled = false;
                    SendButton.Enabled = false;
                    PlaceHolder1.Visible = true;
                    PlaceHolder2.Visible = true;
                    NewSendButton.Visible = true;
                    NewSendButton.Focus();
                }
            }


        }

        protected void NewSendButton_Click(object sender, EventArgs e)
        {
            SecretNumber.Initialize();
        }
    }
}