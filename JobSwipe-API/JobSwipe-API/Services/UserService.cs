using JobSwipe_API.Data;
using JobSwipe_API.Models;
using JobSwipe_API.Models.DTO.Auth;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace JobSwipe_API.Services
{
    public interface IUserService
    {
        Task<bool> CheckPassword(JobswipeUser user, string password);
        Task<int> CreateAsyncPrivate(RegisterPrivateUserDTO user);
        Task<int> CreateAsyncCompany(RegisterCompanyUserDTO user);
        Task DeleteUser(object user);
        Task<IEnumerable<PrivateUser>> GetPrivateUsers();
        Task<object> GetUserByEmail(string email);
        Task UpdateAsync(object user);
        Task<ICollection<object>> GetAllUsers();
        Task<IEnumerable<CompanyUser>> GetCompanyUsers();
    }

    public class UserService(ApplicationDbContext context) : IUserService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<PrivateUser>> GetPrivateUsers()
        {
            var users = await _context.PrivateUsers.ToListAsync();
            return users;
        }

        public async Task<ICollection<object>> GetAllUsers()
        {
            var privateUsers = await _context.PrivateUsers.ToListAsync();
            var companyUsers = await _context.CompanyUsers.ToListAsync();

            var users = new List<object>();
            users.AddRange(privateUsers);
            users.AddRange(companyUsers);

            return users;
        }

        public async Task<object> GetUserByEmail(string email)
        {
            var privateUser = await _context.PrivateUsers
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Email == email);
            if (privateUser != null)
            {
                return privateUser;
            }

            var companyUser = await _context.CompanyUsers
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Email == email);
            if (companyUser != null)
            {
                return companyUser;
            }

            throw new Exception("User not found");
        }

        public async Task<int> CreateAsyncPrivate(RegisterPrivateUserDTO userDTO)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "Private");
            if (role == null)
            {
                throw new Exception("Role not found");
            }

            var privateUser = new PrivateUser
            {
                Email = userDTO.Email,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                AboutMe = userDTO.AboutMe,
                Location = userDTO.Location,
                PasswordHash = GetPasswordHash(userDTO.Password),
                Created = DateTime.UtcNow,
                Id = Guid.NewGuid(),
                RoleId = role.Id,
            };

            _context.PrivateUsers.Add(privateUser);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<int> CreateAsyncCompany(RegisterCompanyUserDTO userDTO)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "Company");
            if (role == null)
            {
                throw new Exception("Role not found");
            }
            var companyUser = new CompanyUser
            {
                Email = userDTO.Email,
                CompanyName = userDTO.CompanyName,
                Location = userDTO.Location,
                AboutCompany = userDTO.AboutCompany,
                Website = userDTO.Website,
                PasswordHash = GetPasswordHash(userDTO.Password),
                Created = DateTime.UtcNow,
                Id = Guid.NewGuid(),
                RoleId = role.Id,
            };

            _context.CompanyUsers.Add(companyUser);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task UpdateAsync(object user)
        {
            if (user is PrivateUser privateUser)
            {
                _context.PrivateUsers.Update(privateUser);
            }
            else if (user is CompanyUser companyUser)
            {
                _context.CompanyUsers.Update(companyUser);
            }
            else
            {
                throw new ArgumentException("User must be a PrivateUser or CompanyUser");
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(object user)
        {
            if (user is PrivateUser privateUser)
            {
                _context.PrivateUsers.Remove(privateUser);
            }
            else if (user is CompanyUser companyUser)
            {
                _context.CompanyUsers.Remove(companyUser);
            }
            else
            {
                throw new ArgumentException("User must be a PrivateUser or CompanyUser");
            }

            await _context.SaveChangesAsync();
        }

        public Task<bool> CheckPassword(JobswipeUser user, string password)
        {
            var hashedPassword = GetPasswordHash(password);
            return Task.FromResult(user.PasswordHash == hashedPassword);
        }

        public static string GetPasswordHash(string data)
        {
            var hash = "";
            var binaryData = SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(data));
            hash = Convert.ToBase64String(binaryData);
            return hash;
        }

        public async Task<IEnumerable<CompanyUser>> GetCompanyUsers()
        {
            var users = await _context.CompanyUsers.ToListAsync();
            return users;
        }
    }
}
