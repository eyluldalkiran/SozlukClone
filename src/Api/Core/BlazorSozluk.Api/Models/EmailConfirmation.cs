using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
//Bir kullanıcı yeni hesap oluşturduğunda ya da varolan emailini güncellemk istediğinde
namespace BlazorSozluk.Api.Domain.Models
{
    public class EmailConfirmation : BaseEntity
    {
        public string OldEmailAddress { get; set; }
        public string NewEmailAddress { get; set; }
    }
}
