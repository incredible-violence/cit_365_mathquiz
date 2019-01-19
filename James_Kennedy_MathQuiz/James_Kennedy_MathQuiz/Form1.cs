using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace James_Kennedy_MathQuiz
{
    public partial class Form1 : Form
    {
        // random object
        Random randomizer = new Random();

        // addition variables
        int addend1;
        int addend2;

        // subtraction variables
        int minuend;
        int subtrahend;

        // multiplication values
        int multiplicand;
        int multiplier;

        // division values
        int dividend;
        int divisor;

        // timer value
        int timeLeft;

        public Form1()
        {
            InitializeComponent();
            // display current date
            // variable containing today's date
            DateTime today = DateTime.Now;

            // output current date but not current time
            dateLabel.Text = today.ToString("dd MMMM yyyy");

        }

        public void StartTheQuiz()
        {
            // addition problem
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            sum.Value = 0;

            // subtraction problem
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);

            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();

            difference.Value = 0;

            // multiplication problem
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);

            multLeftLabel.Text = multiplicand.ToString();
            multRightLabel.Text = multiplier.ToString();

            product.Value = 0;

            // division problem
            divisor = randomizer.Next(2, 11);
            int tempQuotient = randomizer.Next(2, 11);
            dividend = divisor * tempQuotient;

            divideLeftLabel.Text = dividend.ToString();
            divideRightLabel.Text = divisor.ToString();

            quotient.Value = 0;

            // timer start
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void plusRightLabel_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You Got all the Answers Correct!", "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                // Display the new time left
                // by updating the Time Left label.
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                // If the user ran out of time, stop the timer, show
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");

                // show correct answers
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplier * multiplicand;
                quotient.Value = dividend / divisor;

                startButton.Enabled = true;
            }
        }

        private bool CheckAnswer()
        {
            if ((addend1 + addend2 == sum.Value) 
                && (minuend - subtrahend == difference.Value) 
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
