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

namespace WpfStylesTriggersThemesApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Style style1 = new Style();
            //style1.Setters.Add(new Setter() { Property = Control.BackgroundProperty, Value = new SolidColorBrush(Colors.Magenta) });
            //style1.Setters.Add(new Setter() { Property = Control.HeightProperty, Value = 100.0});
            //btn3.Style = style1;

            List<string> list = new List<string>()
            {
                "light",
                "dark"
            };
            styleBox.SelectionChanged += StyleBox_SelectionChanged;
            styleBox.ItemsSource = list;
            styleBox.SelectedItem = "light";
        }

        private void StyleBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string style = styleBox.SelectedItem as string;
            var path = new Uri(style + ".xaml", UriKind.Relative);
            ResourceDictionary dict = Application.LoadComponent(path) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            MessageBox.Show(btn.Content.ToString());
        }
    }

    
}
