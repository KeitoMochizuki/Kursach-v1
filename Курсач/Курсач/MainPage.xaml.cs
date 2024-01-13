using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Курсач
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ShowPair();
        }

        private void ShowPair()
        {
            LibPair.ItemsSource = App.Database.GetPair();
            //LibPair.ItemsSource = App.Db.GetPair();
        }

        private async void AddPairButton(object sender, EventArgs e)
        {
            string eng = "-", rus = "-";
            eng = EngField.Text.Trim();
            rus = RusField.Text.Trim();

            if (eng.Length < 1 && rus.Length < 1)
            {
                await DisplayAlert("Ошибка", "Одно из полей пустое", "Ok");
                return;
            }
            else
            {
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
            
            
            Lib lib = new Lib
            {
                ENG = eng,
                RUS = rus,
            };

            App.Database.SavePair(lib);
            //App.Db.SavePair(lib);
            ShowPair();

            EngField.Text = "";
            RusField.Text = "";
        }
    }
}
