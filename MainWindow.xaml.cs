/*
 * FILE         : MainWindow.xaml.cs
 * PROJECT      : Assignment 4
 * PROGRAMMER   : Group 3: Jackson Ruby, Mounika Kasarla, Artem Nahornyi, Sukhwinder Singh, Dipalee Gupta
 * DATE         : Oct. 1, 2019
 * DESCRIPTION  :
 *      Money game where the user has to choose amounts of coins to equal a given value.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChangeGame
{
    public partial class MainWindow : Window
    {
        private const int IMAGE_SPLIT_DIVISOR = 2;
        private const int IMAGE_CLICK_MONETARY_INCREMENT = 1;
        private const int MIN_RANDOM_DOLLAR_VALUE = 1;
        private const int MAX_RANDOM_DOLLAR_VALUE = 20;
        private const int MIN_RANDOM_CENT_VALUE = 0;
        private const int MAX_RANDOM_CENT_VALUE = 100;
        private const string DEFAULT_TEXTBOX_VALUE = "0";
        private const string MESSAGE_CORRECT_ANSWER = "Well Done! You found the exact change!";
        private const string MESSAGE_INCORRECT_ANSWER = "That isn't quite right.";
        private readonly SolidColorBrush REGULAR_TEXTBOX_COLOUR = new SolidColorBrush(Colors.Black);
        private readonly SolidColorBrush PLACEHOLDER_TEXTBOX_COLOUR = new SolidColorBrush(Colors.Gray);
        private readonly SolidColorBrush COLOUR_CORRECT_ANSWER = new SolidColorBrush(Color.FromRgb(159, 228, 176));
        private readonly SolidColorBrush COLOUR_INCORRECT_ANSWER = new SolidColorBrush(Color.FromRgb(196, 16, 16));
       

        //money object and answer declaration for use throughout the MainWindow class
        private MoneyData moneyCalculation;
        private decimal answer;

        /*
        * FUNCTION      : MainWindow()
        * DESCRIPTION   :
        *       Occurs on form load. Sets up the game initially.
        */
        public MainWindow()
        {
            InitializeComponent();
            resetValues();
            newAnswer();
            hideMessageItems();
        }

        /*
        * FUNCTION      : ImgPenny_MouseLeftButtonDown()
        * DESCRIPTION   :
        *       Occurs on penny image click.
        */
        private void ImgPenny_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //check which side of the coin was clicked
            if (Mouse.GetPosition(imgPenny).X < (imgPenny.ActualWidth / IMAGE_SPLIT_DIVISOR))
            {
                //increase number of pennys on form and in money object
                moneyCalculation.Pennys += IMAGE_CLICK_MONETARY_INCREMENT;
                txtPenny.Text = moneyCalculation.Pennys.ToString();
                txtPenny.Foreground = REGULAR_TEXTBOX_COLOUR;
            }
            else if (moneyCalculation.Pennys > 0)
            {
                //decrease number of pennys on form and in money object
                moneyCalculation.Pennys -= IMAGE_CLICK_MONETARY_INCREMENT;
                txtPenny.Text = moneyCalculation.Pennys.ToString();
                if (txtPenny.Text == DEFAULT_TEXTBOX_VALUE) txtPenny.Foreground = PLACEHOLDER_TEXTBOX_COLOUR;
            }
        }

        /*
        * FUNCTION      : ImgNickel_MouseLeftButtonDown()
        * DESCRIPTION   :
        *       Occurs on nickel image click.
        */
        private void ImgNickel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //check which side of the coin was clicked
            if (Mouse.GetPosition(imgNickel).X < (imgNickel.ActualWidth / IMAGE_SPLIT_DIVISOR))
            {
                //increase number of nickels on form and in money object
                moneyCalculation.Nickels += IMAGE_CLICK_MONETARY_INCREMENT;
                txtNickel.Text = moneyCalculation.Nickels.ToString();
                txtNickel.Foreground = REGULAR_TEXTBOX_COLOUR;
            }
            else if (moneyCalculation.Nickels > 0)
            {
                //decrease number of nickels on form and in money object
                moneyCalculation.Nickels -= IMAGE_CLICK_MONETARY_INCREMENT;
                txtNickel.Text = moneyCalculation.Nickels.ToString();
                if (txtNickel.Text == DEFAULT_TEXTBOX_VALUE) txtNickel.Foreground = PLACEHOLDER_TEXTBOX_COLOUR;
            }
        }

        /*
        * FUNCTION      : ImgDime_MouseLeftButtonDown()
        * DESCRIPTION   :
        *       Occurs on dime image click.
        */
        private void ImgDime_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //check which side of the coin was clicked
            if (Mouse.GetPosition(imgDime).X < (imgDime.ActualWidth / IMAGE_SPLIT_DIVISOR))
            {
                //increase number of dimes on form and in money object
                moneyCalculation.Dimes += IMAGE_CLICK_MONETARY_INCREMENT;
                txtDime.Text = moneyCalculation.Dimes.ToString();
                txtDime.Foreground = REGULAR_TEXTBOX_COLOUR;
            }
            else if (moneyCalculation.Dimes > 0)
            {
                //decrease number of dimes on form and in money object
                moneyCalculation.Dimes -= IMAGE_CLICK_MONETARY_INCREMENT;
                txtDime.Text = moneyCalculation.Dimes.ToString();
                if (txtDime.Text == DEFAULT_TEXTBOX_VALUE) txtDime.Foreground = PLACEHOLDER_TEXTBOX_COLOUR;
            }
        }

        /*
        * FUNCTION      : ImgQuarter_MouseLeftButtonDown()
        * DESCRIPTION   :
        *       Occurs on quarter image click.
        */
        private void ImgQuarter_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //check which side of the coin was clicked
            if (Mouse.GetPosition(ImgQuarter).X < (ImgQuarter.ActualWidth / IMAGE_SPLIT_DIVISOR))
            {
                //increase number of quarters on form and in money object
                moneyCalculation.Quarters += IMAGE_CLICK_MONETARY_INCREMENT;
                txtQuarter.Text = moneyCalculation.Quarters.ToString();
                txtQuarter.Foreground = REGULAR_TEXTBOX_COLOUR;
            }
            else if (moneyCalculation.Quarters > 0)
            {
                //decrease number of quarters on form and in money object
                moneyCalculation.Quarters -= IMAGE_CLICK_MONETARY_INCREMENT;
                txtQuarter.Text = moneyCalculation.Quarters.ToString();
                if (txtQuarter.Text == DEFAULT_TEXTBOX_VALUE) txtQuarter.Foreground = PLACEHOLDER_TEXTBOX_COLOUR;
            }
        }

        /*
        * FUNCTION      : ImgLoonie_MouseLeftButtonDown()
        * DESCRIPTION   :
        *       Occurs on loonie image click.
        */
        private void ImgLoonie_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //check which side of the coin was clicked
            if (Mouse.GetPosition(imgLoonie).X < (imgLoonie.ActualWidth / IMAGE_SPLIT_DIVISOR))
            {
                //increase number of loonies on form and in money object
                moneyCalculation.Loonies += IMAGE_CLICK_MONETARY_INCREMENT;
                txtLoonie.Text = moneyCalculation.Loonies.ToString();
                txtLoonie.Foreground = REGULAR_TEXTBOX_COLOUR;
            }
            else if (moneyCalculation.Loonies > 0)
            {
                //decrease number of loonies on form and in money object
                moneyCalculation.Loonies -= IMAGE_CLICK_MONETARY_INCREMENT;
                txtLoonie.Text = moneyCalculation.Loonies.ToString();
                if (txtLoonie.Text == DEFAULT_TEXTBOX_VALUE) txtLoonie.Foreground = PLACEHOLDER_TEXTBOX_COLOUR;
            }
        }

        /*
        * FUNCTION      : ImgToonie_MouseLeftButtonDown()
        * DESCRIPTION   :
        *       Occurs on toonie image click.
        */
        private void ImgToonie_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //check which side of the coin was clicked
            if (Mouse.GetPosition(imgToonie).X < (imgToonie.ActualWidth / IMAGE_SPLIT_DIVISOR))
            {
                //increase number of toonies on form and in money object
                moneyCalculation.Toonies += IMAGE_CLICK_MONETARY_INCREMENT;
                txtToonie.Text = moneyCalculation.Toonies.ToString();
                txtToonie.Foreground = REGULAR_TEXTBOX_COLOUR;
            }
            else if (moneyCalculation.Toonies > 0)
            {
                //decrease number of toonies on form and in money object
                moneyCalculation.Toonies -= IMAGE_CLICK_MONETARY_INCREMENT;
                txtToonie.Text = moneyCalculation.Toonies.ToString();
                if (txtToonie.Text == DEFAULT_TEXTBOX_VALUE) txtToonie.Foreground = PLACEHOLDER_TEXTBOX_COLOUR;
            }
        }

        /*
        * FUNCTION      : BtnCheckAnswer_Click()
        * DESCRIPTION   :
        *       Occurs on click of check answer button.
        */
        private void BtnCheckAnswer_Click(object sender, RoutedEventArgs e)
        {
            //check if the total of all coin values equal the answer
            if (answer == moneyCalculation.CalculateTotal())
            {
                //change message to correct                
                lblMessage.Content = MESSAGE_CORRECT_ANSWER;
                cvsMessage.Background = COLOUR_CORRECT_ANSWER;
            }
            else
            {
                //change message to incorrect
                lblMessage.Content = MESSAGE_INCORRECT_ANSWER;
                cvsMessage.Background = COLOUR_INCORRECT_ANSWER;
            }
            //show the message view
            showMessageItems();
        }

        /*
        * FUNCTION      : BtnNewGame_Click()
        * DESCRIPTION   :
        *       Occurs on click of the new game button.
        */
        private void BtnNewGame_Click(object sender, RoutedEventArgs e)
        {
            //reset coin values and generate new answer
            resetValues();
            newAnswer();
        }

        /*
        * FUNCTION      : BtnResetCoins_Click()
        * DESCRIPTION   :
        *       Occurs on click of the reset coins button.
        */
        private void BtnResetCoins_Click(object sender, RoutedEventArgs e)
        {
            //resets coin values
            resetValues();
        }

        /*
        * FUNCTION      : ResetValues()
        * DESCRIPTION   :
        *       Resets coin values on the form and in the money object.
        */
        private void resetValues()
        {
            //reset the moneyData object
            moneyCalculation = new MoneyData();

            //reset all textboxes to default
            txtPenny.Text = DEFAULT_TEXTBOX_VALUE;
            txtNickel.Text = DEFAULT_TEXTBOX_VALUE;
            txtDime.Text = DEFAULT_TEXTBOX_VALUE;
            txtQuarter.Text = DEFAULT_TEXTBOX_VALUE;
            txtLoonie.Text = DEFAULT_TEXTBOX_VALUE;
            txtToonie.Text = DEFAULT_TEXTBOX_VALUE;

            //reset all textbox foreground colours to default
            txtPenny.Foreground = PLACEHOLDER_TEXTBOX_COLOUR;            
            txtNickel.Foreground = PLACEHOLDER_TEXTBOX_COLOUR;            
            txtDime.Foreground = PLACEHOLDER_TEXTBOX_COLOUR;            
            txtQuarter.Foreground = PLACEHOLDER_TEXTBOX_COLOUR;            
            txtLoonie.Foreground = PLACEHOLDER_TEXTBOX_COLOUR;            
            txtToonie.Foreground = PLACEHOLDER_TEXTBOX_COLOUR;
        }

        /*
        * FUNCTION      : NewAnswer()
        * DESCRIPTION   :
        *       Sets up a new random money value.
        */
        private void newAnswer()
        {
            //generate random number
            Random rand = new Random();
            string strValOfNum = rand.Next(MIN_RANDOM_DOLLAR_VALUE, MAX_RANDOM_DOLLAR_VALUE).ToString() + "." 
                               + rand.Next(MIN_RANDOM_CENT_VALUE, MAX_RANDOM_CENT_VALUE).ToString();
            
            //set number to form and variable
            answer = decimal.Parse(strValOfNum);
            txtAnswer.Text = answer.ToString("C");
        }

        /*
        * FUNCTION      : textBoxAllowOnlyNumericInput()
        * DESCRIPTION   :
        *       Handles input from the keyboard into textboxes and allows only numeric input.
        */
        private void textBoxAllowOnlyNumericInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !new Regex("[0-9]+").IsMatch(e.Text);
        }

        /*
        * FUNCTION      : textBoxTextToInt()
        * DESCRIPTION   :
        *       Converts string to integer, returns 0 if non-numeric.
        */
        private int textBoxTextToInt(string textBoxText)
        {
            int returnValue = 0;
            try { returnValue = int.Parse(textBoxText); }
            catch { }
            return returnValue;
        }

        /*
        * FUNCTION      : hidePlaceholder()
        * DESCRIPTION   :
        *       Hides placeholder text in textbox when the user clicks within the textbox.
        */
        private void hidePlaceholder(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text == DEFAULT_TEXTBOX_VALUE)
            {
                (sender as TextBox).Text = "";
                (sender as TextBox).Foreground = REGULAR_TEXTBOX_COLOUR;
            }
        }

        /*
        * FUNCTION      : showPlaceholder()
        * DESCRIPTION   :
        *       Shows the placeholder text in textbox when the user clicks outside the textbox after leaving the textbox blank.
        */
        private void showPlaceholder(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace((sender as TextBox).Text))
            {
                (sender as TextBox).Text = DEFAULT_TEXTBOX_VALUE;
                (sender as TextBox).Foreground = PLACEHOLDER_TEXTBOX_COLOUR;
            }

            saveValues();
        }

        /*
        * FUNCTION      : keepTextBoxValue()
        * DESCRIPTION   :
        *       Occurs on key up within a textbox. Saves information on the form.
        */
        private void keepTextBoxValue(object sender, KeyEventArgs e)
        {
            saveValues();
        }

        /*
        * FUNCTION      : saveValues()
        * DESCRIPTION   :
        *       Hides placeholder text in textbox when the user clicks within the textbox.
        */
        private void saveValues()
        {
            //save all values to the money data class
            moneyCalculation.Pennys = textBoxTextToInt(txtPenny.Text);
            moneyCalculation.Nickels = textBoxTextToInt(txtNickel.Text);
            moneyCalculation.Dimes = textBoxTextToInt(txtDime.Text);
            moneyCalculation.Quarters = textBoxTextToInt(txtQuarter.Text);
            moneyCalculation.Loonies = textBoxTextToInt(txtLoonie.Text);
            moneyCalculation.Toonies = textBoxTextToInt(txtToonie.Text);
        }

        /*
        * FUNCTION      : BtnOKMessage_Click()
        * DESCRIPTION   :
        *       Occurs on message button click. Hides the message view.
        */
        private void BtnOKMessage_Click(object sender, RoutedEventArgs e)
        {
            hideMessageItems();
        }

        /*
        * FUNCTION      : hideMessageItems()
        * DESCRIPTION   :
        *       Hides all items used in the messsage view.
        */
        private void hideMessageItems()
        {
            cvsMessage.Visibility = Visibility.Hidden;
            lblMessage.Visibility = Visibility.Hidden;
            btnOKMessage.Visibility = Visibility.Hidden;
        }

        /*
        * FUNCTION      : showMessageItems()
        * DESCRIPTION   :
        *       Shows all items used in the messsage view.
        */
        private void showMessageItems()
        {
            cvsMessage.Visibility = Visibility.Visible;
            lblMessage.Visibility = Visibility.Visible;
            btnOKMessage.Visibility = Visibility.Visible;
        }
    }
}
