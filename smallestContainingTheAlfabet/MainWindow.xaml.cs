using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace smallestContainingTheAlfabet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string removeRepetedCharacters(string str)
        {
            string used = "";
            string result = "";

            foreach (char singleLetter in str)
            {
                if (used.IndexOf(singleLetter) == -1)
                {
                    used += singleLetter;
                    result += singleLetter;
                }
            }

            return result;
        }

        string smallestStringContainingTheAlphabet(string str)
        {
            string stringToReturn = "The string does not contain the alphabet";
            if (str.Length < 26)
            {
                return stringToReturn; 
            }
            else
            {
                int maxExtention = str.Length - 26;
                List<string> stringsContainingTheAlphabet = new List<string>();
                for (int i = 0; i < maxExtention; i++)
                {
                    for (int j = 0; j <= maxExtention - i; j++)
                    {
                        string currentString = str.Substring(j, 26 + i);
                        currentString = currentString.ToLower();
                        string onlyLetters = "";
                        foreach (char character in currentString)
                        {
                            if (((int)character >= 97) && ((int)character <= 122))
                            {
                                onlyLetters += character;
                            }
                        }

                        if (removeRepetedCharacters(onlyLetters).Length >= 26)
                        {
                            stringsContainingTheAlphabet.Add(currentString);
                        }

                    }
                }

                if (stringsContainingTheAlphabet.Count > 0)
                {
                    int minLength = stringsContainingTheAlphabet[0].Length;
                    stringToReturn = stringsContainingTheAlphabet[0];

                    foreach (string singleSubstring in stringsContainingTheAlphabet)
                    {
                        if (singleSubstring.Length < minLength)
                        {
                            minLength = singleSubstring.Length;
                            stringToReturn = singleSubstring;
                        }
                    }
                }

                return stringToReturn;
            }
        }

        private void findButton_Click(object sender, RoutedEventArgs e)
        {
            smallestSubstringBox.Text = smallestStringContainingTheAlphabet(initialStringBox.Text);
        }
    }
}
