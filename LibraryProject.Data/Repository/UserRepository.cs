﻿using LibraryProject.Data.Interfaces;

namespace LibraryProject.Data;

public class UserRepository : IUserService
{
    private readonly LibraryContext _context;

    public UserRepository(LibraryContext context)
    {
        _context = context;
    }

    public IEnumerable<User> GetAllUsers() => _context.Users.ToList();

    public User GetUserById(int id) => _context.Users.FirstOrDefault(u => u.Id == id);

    public void AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void UpdateUser(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void DeleteUser(int id)
    {
        var user = _context.Users.Find(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}