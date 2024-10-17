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
                        new Specialization("Монтаж, техническое обслуживание, эксплуатация и ремонт промышленного оборудования", "image\\6.png"),
                        new Specialization("Монтаж и эксплуатация оборудования и систем газоснабжения", "image\\7.png"),
                        new Specialization("Строительство и эксплуатация зданий и сооружений", "image\\2.png"),
                        new Specialization("Техническое обслуживание и ремонт двигателей, систем и агрегатов автомобилей", "image\\4.png"),
                        new Specialization("Информационные системы и программирование", "image\\1.png"),
                        new Specialization("Сооружение и эксплуатация газонефтепроводов и газонефтехранилищ", "image\\8.png"),
                        new Specialization("Экономика и бухгалтерский учет на предприятиях ", "image\\3.png"),
                        new Specialization("Сооружение и эксплуатация газонефтепроводов и газонефтехранилищ", "https://avatars.mds.yandex.net/i?id=6a44c1493427ee6ba422677414466bbf468891d7-11509297-images-thumbs&n=13"),
                        new Specialization("Переработка нефти и газа", "image\\5.png"),
            };

            }
        }

    }

}
