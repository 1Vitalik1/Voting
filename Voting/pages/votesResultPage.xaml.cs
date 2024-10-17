using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace Voting.pages
{
    /// <summary>
    /// Логика взаимодействия для votesResultPage.xaml
    /// </summary>
    public partial class votesResultPage : Page
    {
        public votesResultPage()
        {
            InitializeComponent();
            foreach(Specialization specialization in App.specializations)
            {
                statistic.Items.Add(specialization.ToString());
            }
        }

 
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("save")) File.Delete("save");
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            App.frame.GoBack();
        }

        private void setFile_Click(object sender, RoutedEventArgs e)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Collection<string> files = new Collection<string>();
            foreach (Specialization specialization in App.specializations) files.Add(specialization.ToString());
            string filePath = Path.Combine(desktopPath, "Отчёт.txt");
            if (File.Exists(filePath)) File.Delete(filePath);
            File.WriteAllLines(filePath, files);
            
        }
    }
}
