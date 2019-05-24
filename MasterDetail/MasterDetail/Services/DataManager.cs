using MasterDetail.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace MasterDetail.Services
{
    public static class DataManager
    {
        public static async void RegisterUserAsync(User user)
        {
            await Task.Run(() => DataStore.Users.Add(user));
        }

        public static void RegisterUser(User user)
        {
            DataStore.Users.Add(user);
        }

    }
}
