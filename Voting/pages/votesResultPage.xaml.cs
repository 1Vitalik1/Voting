using System.IO;
using System.Text.Json;
using System.Windows.Controls;

namespace Voting.pages
{
    /// <summary>
    /// Логика взаимодействия для votesResultPage.xaml
    /// </summary>
    public partial class votesResultPage : Page
    {
        private int maxValue = 0;
        public votesResultPage()
        {
            InitializeComponent();
            foreach (Specialization specialization in App.specializations)
                maxValue += specialization.voteCount;

            foreach(Specialization specialization in App.specializations)
            {
                allGraphs.Children.Add(new SpecializationGraph(specialization, maxValue).getGraph());
            }

            string json = JsonSerializer.Serialize(App.specializations);
            File.WriteAllText("save", json);
        }
    }
}
