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
using Packager;

namespace Message
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            //MessageBox.Show(tree.Code("xxxyyzz"));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //HaffmanCoder.HTree tree = new HaffmanCoder.HTree();
            var info = HaffmanCoder.Code(@"Статическое кодирование Хаффмана");
            label.Content = info.CompressedValue;
            
            label_Copy.Content = HaffmanCoder.Decode(label.Content.ToString()).value;
        }
    }
}
