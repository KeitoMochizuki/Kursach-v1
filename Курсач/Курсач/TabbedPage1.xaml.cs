using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Курсач
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPage1 : TabbedPage
    {
        public TabbedPage1()
        {
            InitializeComponent();
            Login page = new Login();
            Navigation.PushModalAsync(page);
        }
        protected override void OnAppearing()
        {
            ShowPair();
        }

        private void ShowPair()
        {
            //Добавляем словарь в коллекцию для отображения
            LibPair.ItemsSource = App.Database.GetPair();
        }

        private async void AddPairButton(object sender, EventArgs e)
        {
            //Получаем слово и перевод
            string eng = "-", rus = "-";
            eng = EngField.Text.Trim();
            rus = RusField.Text.Trim();
            
            //Проверяем что поля не пустые
            if (eng.Length < 1 && rus.Length < 1)
            {
                await DisplayAlert("Ошибка", "Одно из полей пустое", "Ok");
                return;
            }
            else
            {
                //Проверяем язык ввода
                if (!Regex.IsMatch(eng, "^[A-Za-z]+$"))
                {
                    await DisplayAlert("Ошибка", "Один из символов в поле Английского не соотвествует", "Ok");
                    return;
                    // Сработает если хотя бы 1 символ - кириллица
                }

                if (!Regex.IsMatch(rus, "^[А-Яа-я]+$"))
                {
                    await DisplayAlert("Ошибка", "Один из символов в поле Русского не соотвествует", "Ok");
                    return;
                    // Сработает если хотя бы 1 символ - латиница
                }
            }

            //Создаем тестовый экземпляр класса
            Lib l = new Lib();
            //Вызываем метод для получения слова и перевода
            l = App.Database.GetEng(eng);
            //Проверяем что у слова не было такого перевода
            if(l.RUS == rus)
            {
                await DisplayAlert("Ошибка", "Такой перевод существует", "Ok");
                return;
            }

            //Создаем класс для дальнейшего добавления
            Lib lib = new Lib
            {
                ENG = eng,
                RUS = rus,
            };

            //Вызываем метод для добавления 
            App.Database.SavePair(lib);

            //Очищаем поля
            EngField.Text = "";
            RusField.Text = "";
        }
        private void Mode_1(object sender, EventArgs e)
        {
            RusEng page = new RusEng();
            var newNavigationPage = new NavigationPage(page);
            Application.Current.MainPage = newNavigationPage;
            //Navigation.PushModalAsync(page);
        }

        private void Mode_2(object sender, EventArgs e)
        {
            EngRus page = new EngRus();
            var newNavigationPage = new NavigationPage(page);
            Application.Current.MainPage = newNavigationPage;
            //Navigation.PushModalAsync(page);
        }

        private async void SearchPair(object sender, EventArgs e)
        {
            //Получаем слово
            string word = Field.Text;
            //Создаем тестовый экземпляр класса
            Lib l = new Lib();
            //Проверяем что поля не пустые
            if (word == null)
            {
                await DisplayAlert("Ошибка", "Полей пустое", "Ok");
                return;
            }
            //Проверяем язык ввода
            if (Regex.IsMatch(word, "^[A-Za-z]+$"))
            {
                l = App.Database.GetEng(word);
            }
            if (Regex.IsMatch(word, "^[А-Яа-я]+$"))
            {
                l = App.Database.GetRus(word);
            }
            //Проверяем наличие введеного слово
            if (l == null)
            {
                await DisplayAlert("Ошибка", "Нет такого слова", "Ok");
                return;
            }

            //Добавляем найденный результат в коллекцию
            List<Lib> list = new List <Lib>();
            list.Add(l);
            Word1.ItemsSource=list;

            //Очищаем поле ввода
            Field.Text = " ";
        }
    }
}