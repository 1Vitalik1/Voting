using System.Windows.Controls;
namespace Voting.pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            viewAllCard();
        }

        public void viewAllCard()
        {
            foreach (Specialization specialization in App.specializations)
                allCard.Children.Add(new SpecializationTemplate(specialization).getTemplate());
        }
    }
}
