using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Курсач.User;

namespace Курсач
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registration : ContentPage
    {

        public Registration()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //Получаем логин и пароль
            string user = UserName.Text;
            string pass = Password.Text;

            //Проверяем что поля пароль и логин заполнены
            if (user == null)
            {
                await DisplayAlert("Ошибка", "Логин пустой", "Ok");
                pass = null;
                return;
            }
            if (pass == null)
            {
                await DisplayAlert("Ошибка", "Пароль пустой", "Ok");
                user = null;
                return;
            }

            //Создаем класс для хранения данных пользователя
            Info info = new Info { 
                Username = user,
                Password = pass
            };

            //Проверяем есть ли такой пользователь
            if (App.Us.CheckUser(user))
            {
                App.Us.SavePair(info);
            }
            else
            {
                await DisplayAlert("Ошибка", "Такой пользователь существует", "Ok");
                return;
            }

            await this.Navigation.PopModalAsync();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
           this.Navigation.PopModalAsync();
        }
    }
}