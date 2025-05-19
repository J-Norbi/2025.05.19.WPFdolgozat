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
        ServerConnection connection = new ServerConnection();
        public MainWindow()
        {
            InitializeComponent();
            Start();
        }
        async void Start()
        {
            List<Mushroom> list = await connection.GetGomba();
            foreach (Mushroom gomba in list)
            {
                StackPanel panel = new StackPanel();
                gombaLista.Children.Add(panel);
                Label oneLabel = new Label() { Content= $"Név: {gomba.nev}, mérgező: {gomba.mergezo}, szin: {gomba.szin}, megjegyzés: {gomba.megjegyzes}"};
                Button oneButton = new Button() { Content = "Törlés", Tag = gomba.id };
                panel.Children.Add(oneLabel);
                panel.Children.Add(oneButton);
                panel.Orientation = Orientation.Horizontal;
                oneButton.Click += DeleteEvent;
            }
        }
        async void DeleteEvent(object s, EventArgs e)
        {
            Button button = s as Button;
            await connection.deleteOne((int)button.Tag);
        }
        void AddGomba(object s, EventArgs e)
        {

        }
        
    }
}
