using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace Voting
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    


    public partial class App : Application
    {
        internal static Border backFrame = new Border();
        internal static Collection<Specialization> specializations = new Collection<Specialization>();
        internal static Frame frame = new Frame();

        public App()
        {
            if (File.Exists("save"))
            {
                var deserializedSpecializations = JsonSerializer.Deserialize<Collection<Specialization>>(File.ReadAllText("save"));
                foreach (var item in deserializedSpecializations)
                    specializations.Add(item);
            }
            else
            {
                specializations = new Collection<Specialization>()
            {
                        new Specialization("Экономисты", "Экономика и бухгалтерский учет на предприятиях (по отраслям)", "https://avatars.mds.yandex.net/i?id=6a44c1493427ee6ba422677414466bbf468891d7-11509297-images-thumbs&n=13"),
                        new Specialization("Монтажники", "Монтаж и эксплуатация оборудования и систем газоснабжения", "https://avatars.mds.yandex.net/i?id=6a44c1493427ee6ba422677414466bbf468891d7-11509297-images-thumbs&n=13"),
                        new Specialization("Строители", "Строительство и эксплуатация зданий и сооружений", "https://avatars.mds.yandex.net/i?id=6a44c1493427ee6ba422677414466bbf468891d7-11509297-images-thumbs&n=13"),
                        new Specialization("Автомобилисты", "Техническое обслуживание и ремонт двигателей, систем и агрегатов автомобилей", "https://avatars.mds.yandex.net/i?id=6a44c1493427ee6ba422677414466bbf468891d7-11509297-images-thumbs&n=13"),
                        new Specialization("Программисты", "Информационные системы и программирование", "https://avatars.mds.yandex.net/i?id=6a44c1493427ee6ba422677414466bbf468891d7-11509297-images-thumbs&n=13"),
            };

            }
        }

    }

}
