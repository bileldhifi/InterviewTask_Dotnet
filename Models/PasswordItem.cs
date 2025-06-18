using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTask_Dotnet.Models
{
    public class PasswordItem
    {
    public int Id { get; set; }
    public string Category { get; set; } = string.Empty;
    public string App { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string EncryptedPassword { get; set; } = string.Empty;
    }
}