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
using Microsoft.Win32;
using ТпЛр2.Modeli;
using Products.Kontroller;

namespace Products
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int[] polesnost;
        int[] zena;
        public List<Interface> Shopping = new List<Interface>();
        public List<int> BetterShopping = new List<int>();

        public void ChooseFileClick(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog opfidi = new OpenFileDialog();
                opfidi.ShowDialog();
                List<string> Einkaufsliste = new List<string>();
                string productString;
                if (opfidi.FileName != "")
                {
                    productString = File.ReadAllText(opfidi.FileName);
                    Einkaufsliste.AddRange(productString.Split('\n'));
                }
                zena = new int[Einkaufsliste.Count];
                polesnost = new int[Einkaufsliste.Count];
                Shopping.Clear();
                Informaziaisfaila.ItemsSource = null;
                for (int i = 0; i < Einkaufsliste.Count; i++)
                {
                    string[] odd = new string[4];
                    odd = Einkaufsliste[i].Split(':');
                    Shopping.Add(item: new Composition() {name = odd[1], kategorie = odd[0],  preis = Convert.ToInt32(odd[2]), comfortofuse = Convert.ToInt32(odd[3]) });
                    zena[i] = Convert.ToInt32(odd[2]);
                    polesnost[i] = Convert.ToInt32(odd[3]);
                }
                Informaziaisfaila.ItemsSource = Shopping;
            }
            catch (Exception)
            {
                MessageBox.Show("Придусмотрите другой путь для файла");
                Selectfile.Text = "Путь к файлу";
            }
        }

        public void Count_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = 0;
                Backpack.Items.Clear();
                int dengi = Math.Abs(Convert.ToInt32(Summamdeneg.Text));
                BetterShopping = Rukzak.knapsack(zena, polesnost, dengi);
                for (i = 0; i < (BetterShopping.Count - 1); i++)
                    Backpack.Items.Add(Shopping[BetterShopping[i]].name);
                Backpack.Items.Add("Итоговая полезность: " + BetterShopping[i]);
            }
            catch (Exception)
            { 
                MessageBox.Show("Введите точную денежную сумму");
                Summamdeneg.Text = "Денежная сумма";
            }
        }
    }
}
