﻿namespace E_Shop.DataAccess.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ProfileImage { get; set; } = string.Empty;
    }
}
