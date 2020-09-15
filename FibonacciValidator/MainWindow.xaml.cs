
using Logic.Abstract;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using Logic.Implementation;


namespace FibonacciValidator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IFibonacciService fibonacciService;
        private StringBuilder validSequence;
        private StringBuilder invalidSequence;
        private int[] sequence;
        private bool isSubmitted;
        public MainWindow()
        {
            InitializeComponent();

            invalidSequence = new StringBuilder();
            validSequence = new StringBuilder();
            isSubmitted = false;

            //Initializing the interface for injection
            fibonacciService = new FibonacciService();

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isSubmitted == true)
                {
                    invalidSequence = new StringBuilder();
                    validSequence = new StringBuilder();
                }
                isSubmitted = false;

                //Clear the result labels
                DisplayMaxNumberLbl.Content = string.Empty;
                DisplayValidEnteriesLbl.Content = string.Empty;
                DisplayInvalidEnteriesLbl.Content = string.Empty;

                var maxValue = MaxNumberTxtbox.Text;
                MaxNumberTxtbox.IsEnabled = false;

                var random = RandomNumberTxtBox.Text;

                //Check for empty textbox for random value(s)
                if (string.IsNullOrEmpty(random))
                    MessageBox.Show("Please enter random values.");

                //Generate Fibonacci sequence using max value
                sequence = fibonacciService.GenerateValues(maxValue);
                bool exist = sequence.Contains(Convert.ToInt32(random));
                
                if (!exist)
                {
                    invalidSequence.Append(random + ", ");
                    MessageBox.Show($"Invalid number in the Fibonacci sequence --> {random}");
                }
                else
                {
                    validSequence.Append(random + ", ");
                    MessageBox.Show($"Valid number in the Fibonacci sequence --> {random}");
                }
                RandomNumberTxtBox.Text = string.Empty;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }       

        

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            DisplayMaxNumberLbl.Content = MaxNumberTxtbox.Text;
            DisplayInvalidEnteriesLbl.Content = invalidSequence.ToString();
            DisplayValidEnteriesLbl.Content = validSequence.ToString();

            MaxNumberTxtbox.IsEnabled = true;
            MaxNumberTxtbox.Text = string.Empty;
            isSubmitted = true;
        }
    }
}
