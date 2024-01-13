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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //Получаем логин и пароль
            string user = UserName.Text;
            string pass = Password.Text;

            //Проверяем что поля пароль и логин заполнены
            if (user == null || pass == null)
            {
                await DisplayAlert("Ошибка", "Одно из полей пустое", "Ok");
                return;
            }

            //Создаем класс с данными для проверки
            Info i = new Info
            {
                Username = user,
                Password = pass
            };

            //Проверяем пользователя
            if (!App.Us.CheckUser(user))
            {
                if (pass == App.Us.GetUserByName(user).Password)
                    await this.Navigation.PopModalAsync();
                else
                {
                    await DisplayAlert("Ошибка", "Неправильный логин или пароль", "Ok");
                    user = null;
                    pass = null;
                    return;
                }
            }
            else
            {
                await DisplayAlert("Ошибка", "Такого пользователя не существует", "Ok");
                return;
            }
        }

            
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            Registration page2 = new Registration();
            await Navigation.PushModalAsync(page2);
        }
    }
}