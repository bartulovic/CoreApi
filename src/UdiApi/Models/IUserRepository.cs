using System.Collections.Generic;

namespace UdiApi.Models
{
    public interface IUserRepository
    {
        void Add(User item);
        IEnumerable<User> GetAll();
        User Find(long id);
        void Remove(long id);
        void Update(User item);
    }
}
