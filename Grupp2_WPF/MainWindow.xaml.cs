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
        private List<string> techs = new List<string>();
        private List<string> messages = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btn_GenerateWebsite_Click(object sender, RoutedEventArgs e)
        {
            string[] techniques = { "   C#", "daTAbaser", "WebbuTVeCkling ", "clean Code   " };
            string[] messagesToClass = { "Glöm inte att övning ger färdighet!", "Öppna boken på sida 257." };

            /*
             * Skriva ut data
             */
            PrintPage();

            string PrintStart()
            {
                string start = "<!DOCTYPE html>\n<html>\n<body>\n<main>\n";
                return start;
            }
            string PrintWelcome(string className, string[] message)
            {
                string welcome = $"<h1> Välkomna {className}! </h1>";

                string welcomeMessage = "";

                foreach (string msg in message)
                {
                    welcomeMessage += $"\n<p><b> Meddelande: </b> {msg} </p>";
                }

                return welcome + welcomeMessage;
            }
            string PrintTech()
            {
                string kurser = CourseGenerator(techniques);
                return kurser;
            }
            string PrintEnd()
            {
                string end = "</main>\n</body>\n</html>";
                return end;
            }


            void PrintPage()
            {
                string website = PrintStart() + PrintWelcome("Klass A", messagesToClass) + PrintTech() + PrintEnd();
                txb_HtmlBox.Text = website;
            }


            string CourseGenerator(string[] techniques)
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

        private void btn_SaveWebsite_Click(object sender, RoutedEventArgs e)
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
                string txt = txb_HtmlBox.Text;
                string filename = dlg.FileName;
                File.WriteAllText(filename, txt);
            }
            
        }

        private void btn_OpenFile_Click(object sender, RoutedEventArgs e)
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
               txb_HtmlBox.Text = file;  
            }
        }

        private void btn_AddTech_Click(object sender, RoutedEventArgs e)
        {
            messages.Add(txt_messages.Text);
            messages.Clear();
        }
    }
}
