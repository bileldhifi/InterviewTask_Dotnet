using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using InterviewTask_Dotnet.Models;

namespace InterviewTask_Dotnet.Repositories
{
    public class InMemoryPasswordRepository : IPasswordRepository
    {
    private readonly List<PasswordItem> _items = new();
    private int _nextId = 1;

    public IEnumerable<PasswordItem> GetAll() => _items;

    public PasswordItem? GetById(int id) =>
        _items.FirstOrDefault(item => item.Id == id);

    public void Add(PasswordItem item)
    {
        item.Id = _nextId++;
        _items.Add(item);
    }

    public void Update(PasswordItem item)
    {
        var existing = GetById(item.Id);
        if (existing is null) return;

        existing.Category = item.Category;
        existing.App = item.App;
        existing.UserName = item.UserName;
        existing.EncryptedPassword = item.EncryptedPassword;
    }

    public void Delete(int id)
    {
        var item = GetById(id);
        if (item is not null)
        {
            _items.Remove(item);
        }
    }
    }
}