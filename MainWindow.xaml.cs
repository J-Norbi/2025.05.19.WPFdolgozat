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

namespace _2025._05._19.WPFdolgozat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServerConnection connection = new ServerConnection("http://127.1.1.1:3000");
        List<Mushroom> allMushroom = new List<Mushroom>();
        public MainWindow()
        {
            InitializeComponent();
            Start();
        }
        async void Start()
        {
            allMushroom = await connection.GetGomba();
        }
        void AddGomba(object s, EventArgs e)
        {

        }
        
    }
}
