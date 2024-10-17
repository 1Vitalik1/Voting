using System.IO;
using System.Text.Json;
using System.Windows.Controls;
using System.Windows.Input;

namespace Voting.pages
{
    /// <summary>
    /// Логика взаимодействия для ThanksPage.xaml
    /// </summary>
    public partial class ThanksPage : Page
    {
        public ThanksPage()
        {
            InitializeComponent();
            string json = JsonSerializer.Serialize(App.specializations);
            File.WriteAllText("save", json);
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.frame.GoBack();
        }
    }
}
