using Voyago_Backend.DTOs;
using Voyago_Backend.Models;

namespace VoyagoBackend.Services
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllUsers();
        Task<UserDTO> GetUserById(Guid userId);
        Task<List<UserDTO>> GetUsersInTrip(Guid tripId);
        Task<UserDTO> UpdateUser(Guid userId, UserUpdateDTO userUpdatedData);
        Task<UserDTO> DeleteUser(Guid userId);
    }
}