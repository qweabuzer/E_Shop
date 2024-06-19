using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace Electronics_shop.Core
{
    public class Users
    {
        private Users(Guid id, string name, string email, string login, string password, string image)
        {
            Name = name;
            Email = email;
            Login = login;
            Password = password;
            ProfileImage = image;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string ProfileImage { get; set; }

        public const string noImage = "https://www.no5.com/media/1772/place-holder-image.png";
        public static int UserCounter { get; set; } = 0;

        public static Result<Users> Create(Guid id, string name, string email, string login, string password, string image)
        {
            if (!Regex.IsMatch(login, "^[a-zA-Z0-9]+$"))
                return Result.Failure<Users>("Для поля Login запрещены все символы кроме латинских букв и цифр");

            if (!Regex.IsMatch(password, "^[a-zA-Z0-9]+$"))
                return Result.Failure<Users>("Для поля Password запрещены все символы кроме латинских букв и цифр");

            if (string.IsNullOrEmpty(image))
                image = noImage;

            if (string.IsNullOrEmpty(name))
            {
                var userName = "user" + UserCounter.ToString();
                name = userName;
            }


            var user = new Users(
            id,
            name,
            email,
            login,
            password,
            image);

            UserCounter++;

            return Result.Success<Users>(user);
        }
    }

}