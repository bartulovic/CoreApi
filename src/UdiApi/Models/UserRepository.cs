using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdiApi.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
           Add(new User { Name = "Usario Test: Miljenko Bartulovic", Birthdate = new DateTime(1975,2,8)});
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        public void Add(User item)
        {
            _context.Usuarios.Add(item);
            _context.SaveChanges();
        }

        public User Find(long id)
        {
            return _context.Usuarios.FirstOrDefault(t => t.Id == id);
        }

        public void Remove(long id)
        {
            var entity = _context.Usuarios.First(t => t.Id == id);
            _context.Usuarios.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(User item)
        {
            _context.Usuarios.Update(item);
            _context.SaveChanges();
        }
    }
}
