using ProjectEPlant.Models;
using ProjectEPlant.Views;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ProjectEPlant.Services
{
    public interface IFirebaseConnection
    {
        Task<List<RegisterPlantPage>> PostRegisterPlantAsync(RegisterPlantModel model);
        Task saveImage(Stream imgSteram, string nameImage);
        Task<List<Item>> PostRegisterCama(Item model);
        Task<List<Item>> GetCamasAsync();
        Task saveUserData(UserDataModel model);
    }
}
