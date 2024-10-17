using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace Voting.pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        System.Collections.IList list;
        public MainPage()
        {
            InitializeComponent();
            list = allItems.Children;
            for (int i = 0; i < list.Count; i++)
            {
                Border border = (Border)list[i];
                border.Background = new ImageBrush(new BitmapImage(new Uri(App.specializations[i].image, UriKind.RelativeOrAbsolute)));
                Border flow = (Border)border.Child;
                TextBlock text = (TextBlock)flow.Child;
                text.FontSize = 20;
                text.Text = App.specializations[i].name;
                border.MouseLeftButtonDown += Card_MouseLeftButtonDown;
                border.MouseEnter += Card_MouseEnter;
                border.MouseLeave += Card_MouseLeave;
            }
        }

        private void Card_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Border border = (Border)sender;
            border.Opacity = 1;
        }

        private void Card_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Border border = (Border)sender;
            border.Opacity = 0.75;
        }

        private void Card_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Border border = (Border)sender;
            App.specializations[list.IndexOf(border)].voteCount += 1;
            ThanksPage page = new ThanksPage();
            App.frame.Navigate(page);
        }
    }
}
