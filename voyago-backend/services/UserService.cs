using Microsoft.EntityFrameworkCore;
using Voyago_Backend.Data;
using Voyago_Backend.DTOs;
using Voyago_Backend.Models;
using VoyagoBackend.Services;

namespace Voyago_Backend.Services
{
    public class UserService(AppDbContext appDbContext, ILogger<UserService> logger) : IUserService
    {
        public async Task<UserDTO> DeleteUser(Guid userId)
        {
            try
            {
                var userToDelete = await appDbContext.Users.FindAsync(userId) ?? throw new Exception("User not found");
                appDbContext.Users.Remove(userToDelete);
                await appDbContext.SaveChangesAsync();
                return new UserDTO
                {
                    UserId = userToDelete.UserId,
                    FirstName = userToDelete.FirstName,
                    LastName = userToDelete.LastName,
                    Email = userToDelete.Email,
                    DateOfBirth = userToDelete.DateOfBirth,
                    PhoneNumber = userToDelete.PhoneNumber,
                    ProfilePicture = userToDelete.ProfilePicture
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while deleting the user with ID {UserId}", userId);
                throw;
            }

        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            try
            {
                var users = await appDbContext.Users
                    .Include(u => u.Tickets)
                    .Include(u => u.UserTrips)
                    .Select(u => new UserDTO
                    {
                        UserId = u.UserId,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Email = u.Email,
                        DateOfBirth = u.DateOfBirth,
                        PhoneNumber = u.PhoneNumber,
                        ProfilePicture = u.ProfilePicture,
                        Tickets = u.Tickets.Select(ticket => new TicketDTO
                        {
                            TicketId = ticket.TicketId
                        }).ToList(),
                        UserTrips = u.UserTrips.Select(trip => new TripDTO
                        {
                            TripId = trip.TripId
                        }).ToList()
                    })
                    .ToListAsync();

                return users;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving users");
                throw;
            }
        }

        public async Task<UserDTO> GetUserById(Guid userId)
        {
            try
            {
                var user = await appDbContext.Users
                 .Where(u => u.UserId == userId)
                 .Select(u => new UserDTO
                 {
                     UserId = u.UserId,
                     FirstName = u.FirstName,
                     LastName = u.LastName,
                     Email = u.Email,
                     DateOfBirth = u.DateOfBirth,
                     PhoneNumber = u.PhoneNumber,
                     ProfilePicture = u.ProfilePicture,
                     Tickets = u.Tickets.Select(ticket => new TicketDTO
                     {
                         TicketId = ticket.TicketId
                     }).ToList(),
                     UserTrips = u.UserTrips.Select(trip => new TripDTO
                     {
                         TripId = trip.TripId
                     }).ToList()
                 }).FirstOrDefaultAsync() ?? throw new Exception("User not found");
                return user;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving the user with ID {UserId}", userId);
                throw;
            }

        }

        public async Task<List<UserDTO>> GetUsersInTrip(Guid tripId)
        {
            try
            {
                var usersInTrip = await appDbContext.Users
                    .Where(u => u.UserTrips.Any(t => t.TripId == tripId))
                    .Select(u => new UserDTO
                    {
                        UserId = u.UserId,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        PhoneNumber = u.PhoneNumber,
                        ProfilePicture = u.ProfilePicture,
                    }).ToListAsync();

                return usersInTrip;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving users in the trip with ID {TripId}", tripId);
                throw;
            }
        }

        public async Task<UserDTO> UpdateUser(Guid userId, UserUpdateDTO userUpdatedData)
        {
            try
            {
                var user = await appDbContext.Users.FindAsync(userId) ?? throw new Exception("User not found");
                user.FirstName = userUpdatedData.FirstName ?? user.FirstName;
                user.LastName = userUpdatedData.LastName ?? user.LastName;
                user.PhoneNumber = userUpdatedData.PhoneNumber ?? user.PhoneNumber;
                user.ProfilePicture = userUpdatedData.ProfilePicture ?? user.ProfilePicture;

                await appDbContext.SaveChangesAsync();

                return new UserDTO
                {
                    UserId = user.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    DateOfBirth = user.DateOfBirth,
                    PhoneNumber = user.PhoneNumber,
                    ProfilePicture = user.ProfilePicture,
                    Tickets = user.Tickets.Select(t => new TicketDTO { TicketId = t.TicketId }).ToList(),
                    UserTrips = user.UserTrips.Select(ut => new TripDTO { TripId = ut.TripId }).ToList()
                };


            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while updating the user with ID {UserId}", userId);
                throw;
            }

        }
    }
}