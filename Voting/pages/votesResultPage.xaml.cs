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
            for (int i = 0; i < App.specializations.Count; i++)
            {
                if(i != 7)
                {
                    Specialization specialization = App.specializations[i];
                    statistic.Items.Add(specialization.ToString());
                }
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
            for (int i = 0; i < App.specializations.Count; i++)
            {
                if(i != 7) 
                {
                    Specialization specialization = App.specializations[i];
                    files.Add(specialization.ToString());
                }
            }

            string filePath = Path.Combine(desktopPath, "Отчёт.txt");
            if (File.Exists(filePath)) File.Delete(filePath);
            File.WriteAllLines(filePath, files);
            for(int i = 0; i < App.specializations.Count; i++)
            {
                if(i != 7)
                {
                    Specialization specialization = App.specializations[i];
                    files.Add(specialization.ToString());
                }
            }
            
        }
    }
}
