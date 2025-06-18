using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewTask_Dotnet.Models;

namespace InterviewTask_Dotnet.Repositories
{
    public interface IPasswordRepository
    {
    IEnumerable<PasswordItem> GetAll();
    PasswordItem? GetById(int id);
    void Add(PasswordItem item);
    void Update(PasswordItem item);
    void Delete(int id);
    }
}