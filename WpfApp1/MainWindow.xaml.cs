using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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
using Microsoft.Win32;
using WpfApp1.Utilities;
using Brushes = System.Drawing.Brushes;
using Color = System.Windows.Media.Color;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool fileOpen = false;
        private bool settingsOpen = false;
        private bool editOpen = false;
        private string filename;
        static WObj WObject = new WObj();
        static Helper help = new Helper();
        Regex r = new Regex(@"m(ov|vn)|a(d[drc]|nd|sr)|s(ub|bc|t[rm])|r(or|rx|s[bc])|l(s[rl]|d[rm])|b(l|ic|ran)?|e(or|qu)|orr|cm[pn]|t(st|eq)|dcd|fill|end");

        private Color colors2 = new Color()
        {

        };

        /* private Color[] colors = new Color[]
         {
             //System.Windows.Media.ColorConverter.ConvertFromString("#00A9CC")
             ColorTranslator.FromHtml("#00A9CC"),    //Blue
             ColorTranslator.FromHtml("#FF3A28"),    //Red
             ColorTranslator.FromHtml("#F9B731"),    //Yellow
             ColorTranslator.FromHtml("#353333"),    //Black
             ColorTranslator.FromHtml("#F9F9F9")     //White
         };
 */

        public MainWindow()
        {

            InitializeComponent();
            MouseDown += Window_MouseDown;

        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        //file
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!fileOpen)
            {
                fileMenu.Visibility = Visibility.Visible;
                fileOpen = true;
            }
            else
            {
                close();
            }
        }
        //close
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }
        //maximize
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SystemCommands.MaximizeWindow(this);
        }
        //minimize
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }
        //save
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (filename != null)
            {
                TextWriter write = new StreamWriter(filename);
                string cont = new TextRange(editor.Document.ContentStart, editor.Document.ContentEnd).Text;
                write.Write(cont);
                write.Close();
                Console.WriteLine(filename);
            }
        }
        //save as
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "text"; // Default file name
            save.DefaultExt = ".text"; // Default file extension
            save.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension
            bool? result = save.ShowDialog();
            if (result == true)
            {
                filename = save.FileName;
                TextWriter write = new StreamWriter(filename);
                string cont = new TextRange(editor.Document.ContentStart, editor.Document.ContentEnd).Text;
                write.Write(cont);
                write.Close();
                Console.WriteLine(filename);
            }
            close();
        }
        //open
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                editor.Document.Blocks.Add(new Paragraph(new Run(File.ReadAllText(openFileDialog.FileName))));
            }
            close();
        }
        //edit
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {

        }
        //settings
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (!settingsOpen)
            {
                settingsMenu.Visibility = Visibility.Visible;
                settingsOpen = true;
            }
            else
            {
                close();
            }
        }

        private void close()
        {
            settingsMenu.Visibility = Visibility.Hidden;
            fileMenu.Visibility = Visibility.Hidden;
            settingsOpen = false;
            fileOpen = false;
        }

        private void Grid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            IEnumerable<TextRange> wordRanges = GetAllWordRanges(editor.Document);
            foreach (TextRange wordRange in wordRanges)
            {
                if (wordRange.Text == "mov")
                {
                    wordRange.ApplyPropertyValue(TextElement.ForegroundProperty, new System.Windows.Media.SolidColorBrush(Color.FromRgb(0, 169, 204)));
                    //break;
                }
                else if(wordRange.Text == "add")
                {
                    wordRange.ApplyPropertyValue(TextElement.ForegroundProperty, new System.Windows.Media.SolidColorBrush(Color.FromRgb(0, 169, 204)));
                }
                else if (wordRange.Text == "and")
                {
                    wordRange.ApplyPropertyValue(TextElement.ForegroundProperty, new System.Windows.Media.SolidColorBrush(Color.FromRgb(0, 169, 204)));
                }
                else if (wordRange.Text == "end")
                {
                    wordRange.ApplyPropertyValue(TextElement.ForegroundProperty, new System.Windows.Media.SolidColorBrush(Color.FromRgb(0, 169, 204)));
                }
                else if (wordRange.Text == "ldr")
                {
                    wordRange.ApplyPropertyValue(TextElement.ForegroundProperty, new System.Windows.Media.SolidColorBrush(Color.FromRgb(0, 169, 204)));
                }
                else if (wordRange.Text == "mul")
                {
                    wordRange.ApplyPropertyValue(TextElement.ForegroundProperty, new System.Windows.Media.SolidColorBrush(Color.FromRgb(0, 169, 204)));
                }
                else if (wordRange.Text == "mvn")
                {
                    wordRange.ApplyPropertyValue(TextElement.ForegroundProperty, new System.Windows.Media.SolidColorBrush(Color.FromRgb(0, 169, 204)));
                }
                else if (wordRange.Text == "rsb")
                {
                    wordRange.ApplyPropertyValue(TextElement.ForegroundProperty, new System.Windows.Media.SolidColorBrush(Color.FromRgb(0, 169, 204)));
                }
                else if (wordRange.Text == "str")
                {
                    wordRange.ApplyPropertyValue(TextElement.ForegroundProperty, new System.Windows.Media.SolidColorBrush(Color.FromRgb(0, 169, 204)));
                }
                else if (wordRange.Text == "sub")
                {
                    wordRange.ApplyPropertyValue(TextElement.ForegroundProperty, new System.Windows.Media.SolidColorBrush(Color.FromRgb(0, 169, 204)));
                }
                else if (wordRange.Text == "teq")
                {
                    wordRange.ApplyPropertyValue(TextElement.ForegroundProperty, new System.Windows.Media.SolidColorBrush(Color.FromRgb(0, 169, 204)));
                }
                else
                {
                    wordRange.ApplyPropertyValue(TextElement.ForegroundProperty, new System.Windows.Media.SolidColorBrush(Color.FromRgb(255, 255, 255)));
                }
            }
        }

        public static IEnumerable<TextRange> GetAllWordRanges(FlowDocument document)
        {
            string pattern = @"[^\W\d](\w|[-']{1,2}(?=\w))*";
            TextPointer pointer = document.ContentStart;
            while (pointer != null)
            {
                if (pointer.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                {
                    string textRun = pointer.GetTextInRun(LogicalDirection.Forward);
                    MatchCollection matches = Regex.Matches(textRun, pattern);
                    foreach (Match match in matches)
                    {
                        int startIndex = match.Index;
                        int length = match.Length;
                        TextPointer start = pointer.GetPositionAtOffset(startIndex);
                        TextPointer end = start.GetPositionAtOffset(length);
                        yield return new TextRange(start, end);
                    }
                }

                pointer = pointer.GetNextContextPosition(LogicalDirection.Forward);
            }
        }

        public static void updateRegisterViews(int register)
        {
            switch (register)
            {
                case 0: ((MainWindow)App.Current.Windows[0]).register0.Content = "Register 0: " + help.bitArrayToInt(WObject.Registers.registerLocations[0]);
                    break;
                case 1: ((MainWindow)App.Current.Windows[0]).register1.Content = "Register 1: " + help.bitArrayToInt(WObject.Registers.registerLocations[1]);
                    break;
                case 2: ((MainWindow)App.Current.Windows[0]).register2.Content = "Register 2: " + help.bitArrayToInt(WObject.Registers.registerLocations[2]);
                    break;
                case 3: ((MainWindow)App.Current.Windows[0]).register3.Content = "Register 3: " + help.bitArrayToInt(WObject.Registers.registerLocations[3]);
                    break;
                case 4: ((MainWindow)App.Current.Windows[0]).register4.Content = "Register 4: " + help.bitArrayToInt(WObject.Registers.registerLocations[4]);
                    break;
                case 5: ((MainWindow)App.Current.Windows[0]).register5.Content = "Register 5: " + help.bitArrayToInt(WObject.Registers.registerLocations[5]);
                    break;
                case 6: ((MainWindow)App.Current.Windows[0]).register6.Content = "Register 6: " + help.bitArrayToInt(WObject.Registers.registerLocations[6]);
                    break;
                case 7: ((MainWindow)App.Current.Windows[0]).register7.Content = "Register 7: " + help.bitArrayToInt(WObject.Registers.registerLocations[7]);
                    break;
                case 8: ((MainWindow)App.Current.Windows[0]).register8.Content = "Register 8: " + help.bitArrayToInt(WObject.Registers.registerLocations[8]);
                    break;
                case 9: ((MainWindow)App.Current.Windows[0]).register9.Content = "Register 9: " + help.bitArrayToInt(WObject.Registers.registerLocations[9]);
                    break;
                case 10:((MainWindow)App.Current.Windows[0]).register10.Content = "Register 10: " + help.bitArrayToInt(WObject.Registers.registerLocations[10]);
                    break;
                case 11:((MainWindow)App.Current.Windows[0]).register11.Content = "Register 11: " + help.bitArrayToInt(WObject.Registers.registerLocations[11]);
                    break;
                case 12:((MainWindow)App.Current.Windows[0]).register12.Content = "Register 12: " + help.bitArrayToInt(WObject.Registers.registerLocations[12]);
                    break;
                case 13:((MainWindow)App.Current.Windows[0]).register13.Content = "Register 13: " + help.bitArrayToInt(WObject.Registers.registerLocations[13]);
                    break;
                default: ((MainWindow)App.Current.Windows[0]).register0.Content = "Register 0: " + "No comprenday";
                    break;
            }
            
        }
        
        private static string ron()
        {
            var requestUri = "http://ron-swanson-quotes.herokuapp.com/v2/quotes";
            string text;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUri);
            httpWebRequest.Method = WebRequestMethods.Http.Get;
            httpWebRequest.Accept = "application/json";

            var response = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                text = sr.ReadToEnd();
            }
            return text;
        }


        public List<List<Tuple<string, string>>> getMatches()
        {
            string s = new TextRange(editor.Document.ContentStart, editor.Document.ContentEnd).Text;
            Console.WriteLine(s);
            string[] output = s.Split('\n');
            //output.ToList().ForEach(i => Console.Write(i.ToString()));
            List<List<Tuple<string, string>>> recievedList = new List<List<Tuple<string, string>>>();
            foreach (string i in output)
            {
                //Console.WriteLine(i);
                recievedList.Add(Parser.makeTokenFromLine(i));
            }
            return recievedList;
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            List<List<Tuple<string, string>>> recievedList = getMatches();

            for(int i = 0; i < recievedList[i].Count; i++)
            {
                    if (recievedList[i][0].Item2.ToLower().Equals("mov"))
                    {
                        Tuple<string, string> t = recievedList[i][0];
                        Tuple<string, string> regNum = recievedList[i][1];
                        Tuple<string, string> numReg = recievedList[i][3];
                        Console.WriteLine(numReg.Item2);
                        Console.WriteLine(regNum.Item2);
                        BitArray b = new BitArray(new int[] { Int32.Parse(numReg.Item2) });
                        Mov.mov(WObject, Int32.Parse(regNum.Item2), b);
                        updateRegisterViews(Int32.Parse(regNum.Item2));
                    }
            }


            //((MainWindow) App.Current.Windows[0]).register0.Content = "Register 0: some number";//delete later
            //((MainWindow) App.Current.Windows[0]).register3.Content = ron();
            /*
            commandList["mov"].Invoke();
            foreach (Match m in r.Matches(s))
            {
                try
                {
                    Console.WriteLine(destRegister);
                    commandList[m.Value].Invoke();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Compile error: " + exception);
                    throw;
                }
            }
            */
        }

        private void editor_KeyDown(object sender, KeyEventArgs e)
        {
            /*if (e.Equals("{ENTER}"))
            {
                
            }*/
        }
    }
}
