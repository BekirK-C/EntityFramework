using System;
using System.Collections.Generic;
using System.Data;
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

namespace EntityFramework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OkulEfEntities db;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new OkulEfEntities();                          // Datagride öğrenci
            dgogrenci.ItemsSource = db.Ogrencilers.ToList();    // listesini getiriyoruz.
        }

        private void Button_Click(object sender, RoutedEventArgs e)   // Kaydetme işlemi
        {
            Ogrenciler yeniOgrenci = new Ogrenciler();
            yeniOgrenci.Numara = Convert.ToInt32(txtno.Text);
            yeniOgrenci.Ad = txtad.Text;
            yeniOgrenci.Soyad = txtsoyad.Text;
            db.Ogrencilers.Add(yeniOgrenci);
            db.SaveChanges();
            dgogrenci.ItemsSource = db.Ogrencilers.ToList();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e) //Kayıt Silme
        {
            int silinecek = Convert.ToInt32(txtno.Text);
            var silinecekKisi = db.Ogrencilers.Where(w => w.Numara == silinecek).FirstOrDefault();
            db.Ogrencilers.Remove(silinecekKisi);
            db.SaveChanges();
            dgogrenci.ItemsSource = db.Ogrencilers.ToList();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e) //Kayıt Güncelleme
        {
            int guncelle = Convert.ToInt32(txtno.Text);     
            var guncellenecekOgrenci = db.Ogrencilers.Where(w => w.Numara == guncelle).FirstOrDefault();     // Numaraya göre kontrol yapılıyor
            guncellenecekOgrenci.Ad = txtad.Text;
            guncellenecekOgrenci.Soyad = txtsoyad.Text;
            db.SaveChanges();
            dgogrenci.ItemsSource = db.Ogrencilers.ToList();
        }
    }
}
