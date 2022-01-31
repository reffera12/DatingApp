using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using API.Entities;
using System.Security.Cryptography;
using System.Text;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext dataContext){
            if(await dataContext.Users.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/UsersData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            
            foreach (var user in users)
            {
                using var hmac = new HMACSHA512();

                user.UserName = user.UserName.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password"));
                user.PasswordSalt = hmac.Key; 

                dataContext.Users.Add(user);
            }
            await dataContext.SaveChangesAsync();
        } 
    }
}
