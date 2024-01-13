using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Курсач
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EngRus : ContentPage
    {
        public int k;
        public EngRus()
        {
            InitializeComponent();
            //Создаем переменные для хранения 4 ответов и 1 слова
            List<string> ans = new List<string>();
            string Word, answer1, answer2, answer3, answer4;
            var random = new Random();

            //Заполняем переменные
            var pickIndex = random.Next(500);
            Word = App.Database.GetItemById(pickIndex + 1).ENG;
            answer1 = App.Database.GetItemById(pickIndex + 1).RUS;
            pickIndex = random.Next(500);
            answer2 = App.Database.GetItemById(pickIndex + 1).RUS;
            pickIndex = random.Next(500);
            answer3 = App.Database.GetItemById(pickIndex + 1).RUS;
            pickIndex = random.Next(500);
            answer4 = App.Database.GetItemById(pickIndex + 1).RUS;

            //Добавляем 4 ответа в список
            ans.Add(answer1);
            ans.Add(answer2);
            ans.Add(answer3);
            ans.Add(answer4);

            //Перемешиваем ответы
            for (int i = 0; i < 4; i++)
            {
                int a = random.Next(4), b = random.Next(4);
                string tmp = ans[a];
                if (a == k)
                {
                    k = b;
                    ans[a] = ans[b];
                    ans[b] = tmp;
                    continue;
                }
                if (b == k)
                {
                    k = a;
                    ans[a] = ans[b];
                    ans[b] = tmp;
                    continue;
                }
                ans[a] = ans[b];
                ans[b] = tmp;
            }

            //Создаем будующие элементы интерфейса
            Label l = new Label();
            l.Text = "Выберете правильный ответ";
            l.FontSize = 30;
            l.TextColor = Color.Black;
            Label l2 = new Label();
            l2.Text = Word;
            l2.FontSize = 30;
            l2.TextColor = Color.Black;
            Frame frame = new Frame();
            frame.Content = l2;
            Grid grid = new Grid()
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                },
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star)}
                }
            };
            //Называю кнопки как ответы
            Button b1 = new Button { HeightRequest = 100 };
            b1.Text = ans[0];
            b1.Clicked += Button_Clicked;
            Button b2 = new Button { HeightRequest = 100 };
            b2.Text = ans[1];
            b2.Clicked += Button_Clicked_1;
            Button b3 = new Button { HeightRequest = 100 };
            b3.Text = ans[2];
            b3.Clicked += Button_Clicked_2;
            Button b4 = new Button { HeightRequest = 100 };
            b4.Text = ans[3];
            b4.Clicked += Button_Clicked_3;
            grid.Children.Add(b1, 0, 0);
            grid.Children.Add(b2, 0, 1);
            grid.Children.Add(b3, 1, 0);
            grid.Children.Add(b4, 1, 1);
            Button b5 = new Button { HeightRequest = 100 };
            b5.Text = "Выход";
            b5.Clicked += Button_Clicked_4;
            StackLayout stackLayout = new StackLayout
            {
                Children =
                {
                    l,frame,grid,b5
                },
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            stackLayout.Spacing = 8;
            this.Content = stackLayout;
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            TabbedPage1 page = new TabbedPage1();
            Navigation.PushModalAsync(page);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //Проверка ответа
            if (k == 0)
            {
                await DisplayAlert("Молодец", "Правильный ответ", "Ok");
                EngRus page = new EngRus();
                await Navigation.PushModalAsync(page);
            }
            else
            {
                await DisplayAlert("Ошибка", "Попробуй еще", "Ok");
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            //Проверка ответа
            if (k == 1)
            {
                await DisplayAlert("Молодец", "Правильный ответ", "Ok");
                EngRus page = new EngRus();
                await Navigation.PushModalAsync(page);
            }
            else
            {
                await DisplayAlert("Ошибка", "Попробуй еще", "Ok");
            }
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            //Проверка ответа
            if (k == 2)
            {
                await DisplayAlert("Молодец", "Правильный ответ", "Ok");
                EngRus page = new EngRus();
                await Navigation.PushModalAsync(page);

            }
            else
            {
                await DisplayAlert("Ошибка", "Попробуй еще", "Ok");
            }
        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            //Проверка ответа
            if (k == 3)
            {
                await DisplayAlert("Молодец", "Правильный ответ", "Ok");
                EngRus page = new EngRus();
                await Navigation.PushModalAsync(page);
            }
            else
            {
                await DisplayAlert("Ошибка", "Попробуй еще", "Ok");
            }
        }
    }
}