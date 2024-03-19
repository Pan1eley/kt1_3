﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RealtyMarket
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    public partial class AirportEntities : DbContext
    {
        private static AirportEntities _context;
        public AirportEntities()
            : base("name=AirportEntities")
        {
        }
        public static AirportEntities GetContext()
        {
            if (_context == null)
                _context = new AirportEntities();
            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        // Добавляем метод для проверки существования пользователя
        public bool UserExists(string username, string password)
        {
            // Реализуйте соответствующий код запроса к базе данных для проверки пользователя
            var user = Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == password);
            return user != null;
        }

        // Добавляем метод для регистрации нового пользователя
        public bool RegisterUser(string username, string password)
        {
            try
            {
                // Реализуйте соответствующий код запроса к базе данных для вставки нового пользователя
                Users.Add(new Users { Username = username, PasswordHash = password});
                SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Обработайте исключение, если не удалось зарегистрировать пользователя
                // (например, если пользователь с таким именем уже существует)
                return false;
            }
        }

        public virtual DbSet<Airport> Airport { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
