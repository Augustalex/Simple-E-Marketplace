using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Labb1.Models
{
    public class User
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }

        public int Age { get; set; }
        
        public string BillingAddress { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

    }

    public class UserDbContext : DbContext
    {
        public UserDbContext() : base("UserDbContext")
        {
        }

        public DbSet<User> users { get; set; }

    }

    public class UserBuilder
    {

        private User user = new User();
        private bool done = false;

        public User Build()
        {
            if (
                user.FirstName != null &&
                user.LastName != null &&
                user.Age > 0 &&
                user.BillingAddress != null &&
                user.City != null &&
                user.Country != null &&
                user.Title != null &&
                user.Email != null &&
                user.Id != 0
                )
            {
                return user;
            }
            else
            {
                throw new Exception("All properties of User not set. Cannot build!");
            }
        }

        public UserBuilder SetFirstName(string firstName)
        {
            user.FirstName = firstName;
            return this;
        }

        public UserBuilder SetLastName(string lastName)
        {
            user.LastName = lastName;
            return this;
        }

        public UserBuilder SetAge(int age)
        {
            user.Age = age;
            return this;
        }

        public UserBuilder SetBillingAddress(string address)
        {
            user.BillingAddress = address;
            return this;
        }

        public UserBuilder SetCountry(string country)
        {
            user.Country = country;
            return this;
        }

        public UserBuilder SetCity(string city)
        {
            user.City = city;
            return this;
        }

        public UserBuilder SetEmail(string email)
        {
            try
            {
                if (Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                    user.Email = email;
            }
            catch (RegexMatchTimeoutException)
            {
                throw new Exception("Invalid email address entered for user.");
            }

            return this;
        }

        public UserBuilder SetTitle(string title)
        {
            user.Title = title;
            return this;
        }

        public UserBuilder SetId(int id)
        {
            user.Id = id;
            return this;
        }
    }
}