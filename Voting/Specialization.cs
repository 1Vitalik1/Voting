using System.Windows.Controls;
using System.Windows.Media.Effects;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using Voting.pages;

namespace Voting
{
    internal class Specialization
    {
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public int voteCount { get; set; }

        public Specialization(string name, string description, string image)
        {
            this.name = name;
            this.description = description;
            this.image = image;
        }

    }

    internal class SpecializationGraph
    {
        Border border { get; set; } = new Border() { Width = 50, Height = 500, Margin = new Thickness(40), Background = new SolidColorBrush(Color.FromRgb(24, 26, 36)), CornerRadius = new CornerRadius(5),
            Effect = new DropShadowEffect() { Color = Color.FromRgb(54, 110, 192), ShadowDepth = 0, BlurRadius = 50 }
        };

        StackPanel stackPanel { get; set; } = new StackPanel() { Orientation = Orientation.Horizontal };
        TextBlock name { get; set; } = new TextBlock() { TextAlignment = TextAlignment.Center, Width = 20, TextWrapping = TextWrapping.Wrap, Foreground = new SolidColorBrush(Colors.White), FontSize = 23 };
        ProgressBar progressBar { get; set; } = new ProgressBar() { Width = 30, Value = 50, Orientation = Orientation.Vertical };

        internal SpecializationGraph(Specialization specialization, int maxValue)
        {
            border.Child = stackPanel;
            stackPanel.Children.Add(name);
            stackPanel.Children.Add(progressBar);
            progressBar.Maximum = maxValue;
            progressBar.Value = specialization.voteCount;
            name.Text = ($"{specialization.name} - {specialization.voteCount}");
        }

        public Border getGraph() => border;


    }

    internal class SpecializationTemplate
    {
        Specialization specialization { get; set; }

        Border root { get; set; } = new Border() { Width = 350, 
            Height = 500, Margin = new Thickness(40), 
            Background = new SolidColorBrush(Color.FromRgb(24,26,36)), 
            CornerRadius = new CornerRadius(5), 
            Effect = new DropShadowEffect() { Color = Color.FromRgb(54, 110, 192), ShadowDepth = 0, BlurRadius = 50  } };
        Grid grid { get; set; } = new Grid();
        Border image { get; set; } = new Border() { Margin = new Thickness(25)};
        Line line = new Line() { VerticalAlignment = VerticalAlignment.Bottom, Stroke = new SolidColorBrush(Color.FromRgb(54,110,192)), X1 = 350 };
        StackPanel stackPanel { get; set; } = new StackPanel() { };
        TextBlock blockName { get; set; } =  new TextBlock() { Margin = new Thickness(10), FontSize = 22, HorizontalAlignment = HorizontalAlignment.Center, Foreground = new SolidColorBrush(Colors.White), Text = "Name"};
        TextBlock blockDescription { get; set; } = new TextBlock() { TextWrapping = TextWrapping.Wrap, Margin = new Thickness(10), FontSize = 22, HorizontalAlignment = HorizontalAlignment.Center, Foreground = new SolidColorBrush(Colors.White), Text = "Description" };
        Border buttonVote { get; set; } = new Border() { VerticalAlignment = VerticalAlignment.Bottom, Background = new SolidColorBrush(Color.FromRgb(54,110,192)), Margin = new Thickness(15)};
        TextBlock buttonVoteText { get; set; } = new TextBlock() { HorizontalAlignment = HorizontalAlignment.Center, Foreground = new SolidColorBrush(Colors.White), FontSize = 20, Text = "Проголосовать" };

        public SpecializationTemplate(Specialization specialization)
        {
            this.specialization = specialization;

            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(7, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(10, GridUnitType.Star) });

            root.Child = grid;
           
            grid.Children.Add(image);
            grid.Children.Add(stackPanel);
            stackPanel.Children.Add(blockName);
            stackPanel.Children.Add(blockDescription);
            grid.Children.Add(line);
            grid.Children.Add(buttonVote);
            buttonVote.Child = buttonVoteText;
            buttonVote.MouseLeftButtonDown += SendVote;
            blockName.Text = specialization.name;
            blockDescription.Text = specialization.description;
            image.Background = new ImageBrush(new BitmapImage(new Uri(specialization.image)));

            Grid.SetRow(stackPanel, 1);
            Grid.SetRow(buttonVote, 1);

        }

        private void SendVote(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            App.specializations[App.specializations.IndexOf(specialization)].voteCount++;
            votesResultPage votesResultPage = new votesResultPage();
            App.backFrame.Visibility = Visibility.Visible;
            App.frame.Navigate(votesResultPage);
        }

        public Border getTemplate() => root;
    }
}
