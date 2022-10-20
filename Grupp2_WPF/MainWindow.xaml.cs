using Microsoft.Win32;
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
using System.IO;

namespace Grupp2_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> techList = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btnGenerateWebsite_Click(object sender, RoutedEventArgs e)
        {
            string[] techniques = { "   C#", "daTAbaser", "WebbuTVeCkling ", "clean Code   " };
            string[] messagesToClass = { "Glöm inte att övning ger färdighet!", "Öppna boken på sida 257." };

            /*
             * Skriva ut data
             */
            printPage();

            string printStart()
            {
                string start = "<!DOCTYPE html>\n<html>\n<body>\n<main>\n";
                return start;
            }
            string printWelcome(string className, string[] message)
            {
                string welcome = $"<h1> Välkomna {className}! </h1>";

                string welcomeMessage = "";

                foreach (string msg in message)
                {
                    welcomeMessage += $"\n<p><b> Meddelande: </b> {msg} </p>";
                }

                return welcome + welcomeMessage;
            }
            string printKurser()
            {
                string kurser = courseGenerator(techniques);
                return kurser;
            }
            string printEnd()
            {
                string end = "</main>\n</body>\n</html>";
                return end;
            }


            void printPage()
            {
                string website = printStart() + printWelcome("Klass A", messagesToClass) + printKurser() + printEnd();
                txtHtmlBox.Text = website;
            }


            string courseGenerator(string[] techniques)
            {
                string kurser = "";

                foreach (string technique in techniques)
                {
                    string tmp = technique.Trim();
                    kurser += "<p>" + tmp[0].ToString().ToUpper() + tmp.Substring(1).ToLower() + "</p>\n";
                }

                return kurser;
            }
        }

        private void btnSaveWebsite_Click(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.ShowDialog();

            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".html"; // Default file extension
            dlg.Filter = "Text documents (.html)|*.html"; // Filter files by ex
                                                        // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string txt = txtHtmlBox.Text;
                string filename = dlg.FileName;
                File.WriteAllText(filename, txt);
            }
            
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            //dlg.FileName = "Document"; // Default file name
            //dlg.DefaultExt = ".html"; // Default file extension
            dlg.Filter = "Text documents (.html)|*.html"; // Filter files by ex
                                                          // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            // Process save file dialog box results
            if (result == true)
            {
               string file =  File.ReadAllText(dlg.FileName);
               txtHtmlBox.Text = file;  
            }
        }

        private void btnTechGenerator_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
