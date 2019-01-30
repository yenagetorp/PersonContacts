using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace WPF_PersonsDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            listBoxPersons.Items.Add(new Person("Kalle", "Anka", "kalle.anka@ankeborg.se", "480101-1234") { PhoneNumbers = new List<string>() { "070-000 00 00", "08-123 456 78" } });
            listBoxPersons.Items.Add(new Person("Musse", "Pigg", "musse.pigg@ankeborg.se", "591104-1234") { PhoneNumbers = new List<string>() { "070-111 22 33", "08-987 654 32" } });
            listBoxPersons.Items.Add(new Person("Alexander", "Anka", "alexander.anka@ankeborg.se", "510707-1234") { PhoneNumbers = new List<string>() { "070-999 88 77", "08-444 111 99" } });
        }

        private void ListBoxPersons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Person person = listBoxPersons.SelectedItem as Person;

            if (person == null)
                return;

            textBoxFirstName.Text = person.FirstName;
            textBoxLastName.Text = person.LastName;
            textBoxEmail.Text = person.EmailAddress;
            textBoxSSN.Text = person.SSN;

            listBoxPhoneNumbers.ItemsSource = person.PhoneNumbers;
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonAddPerson_Click(object sender, RoutedEventArgs e)
        {
            var person = new Person(
                textBoxFirstName.Text,
                textBoxLastName.Text,
                textBoxEmail.Text,
                textBoxSSN.Text)
            {
                PhoneNumbers = (List<string>)listBoxPhoneNumbers.ItemsSource
            };

            listBoxPersons.Items.Add(person);

            ClearTextFields();
        }

        private void ClearTextFields()
        {
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxEmail.Clear();
            textBoxSSN.Clear();
            listBoxPhoneNumbers.ItemsSource = null;
        }

        private void ButtonUpdatePerson_Click(object sender, RoutedEventArgs e)
        {
            var person = listBoxPersons.SelectedItem as Person;

            person.FirstName = textBoxFirstName.Text;
            person.LastName = textBoxLastName.Text;
            person.EmailAddress = textBoxEmail.Text;
            person.SSN = textBoxSSN.Text;

            listBoxPersons.SelectedItem = null;
            listBoxPersons.Items.Refresh();

            ClearTextFields();
        }

        private void ButtonDeletePhoneNumber_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string currentNumber = button.DataContext as string;
            var person = listBoxPersons.SelectedItem as Person;

            person.PhoneNumbers.Remove(currentNumber);

            listBoxPhoneNumbers.Items.Refresh();
        }

        private void ButtonEditPhoneNumber_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string currentNumber = button.DataContext as string;

            textBoxPhoneNumber.Text = currentNumber;
            textBoxPhoneNumber.Focus();
            hiddenTextBoxPhoneNumber.Text = currentNumber;

            buttonAddPhoneNumber.Content = "Update";
        }

        private void ButtonAddPhoneNumber_Click(object sender, RoutedEventArgs e)
        {
            buttonAddPhoneNumber.Content = "Add";

            var person = listBoxPersons.SelectedItem as Person;

            if (person != null)
            {
                int numberIndex = person.PhoneNumbers.IndexOf(hiddenTextBoxPhoneNumber.Text);

                if (numberIndex >= 0)
                    person.PhoneNumbers[numberIndex] = textBoxPhoneNumber.Text;
                else
                    person.PhoneNumbers.Add(textBoxPhoneNumber.Text);
            }
            else
            {
                listBoxPhoneNumbers.ItemsSource = new List<string> { $"{textBoxPhoneNumber.Text}" };
            }

            textBoxPhoneNumber.Clear();
            hiddenTextBoxPhoneNumber.Clear();

            listBoxPhoneNumbers.Items.Refresh();
        }

        private void ButtonDeletePerson_Click(object sender, RoutedEventArgs e)
        {
            listBoxPersons.Items.Remove(listBoxPersons.SelectedItem as Person);

            ClearTextFields();
        }
    }
}