using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace E_Shop.Core.Models
{
    public class Users
    {
        private Users(Guid id, string name, string email, string login, string password, string image)
        {
            Id = id;
            Name = name;
            Email = email;
            Login = login;
            Password = password;
            ProfileImage = image;
        }
        public Guid Id { get; }
        public string Name { get; }
        public string Email { get; }
        public string Login { get; }
        public string Password { get; }
        public string ProfileImage { get; }

        public const string noImage = "https://www.no5.com/media/1772/place-holder-image.png";
        public static int UserCounter { get; set; } = 0;

        public static Result<Users> Create(Guid id, string name, string email, string login, string password, string image)
        {
            if (!Regex.IsMatch(login, "^[a-zA-Z0-9]+$"))
                return Result.Failure<Users>("Для поля Login запрещены все символы кроме латинских букв и цифр");

            if (!Regex.IsMatch(password, "^[a-zA-Z0-9]+$"))
                return Result.Failure<Users>("Для поля Password запрещены все символы кроме латинских букв и цифр");

            if (string.IsNullOrWhiteSpace(image))
                image = noImage;

            if (string.IsNullOrWhiteSpace(name))
            {
                var userName = "user" + UserCounter.ToString();
                name = userName;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return Result.Failure<Users>("Неверный формат email");


            var user = new Users(
            id,
            name,
            email,
            login,
            password,
            image);

            UserCounter++;

            return Result.Success(user);
        }
    }

}