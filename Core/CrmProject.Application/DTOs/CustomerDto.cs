using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmProject.Application.DTOs
{
    //record nesneleri karşılaştırırken referans değil, içerik üzerinden karşılaştırmayı sağlar. sınıf olarak tanımlandığı için { get; set; } yazmaya gerek kalmaz.
    //DTOlar API'den gelen veriyi istemciye sunmak için kullanılır.
    public record CustomerDto(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string Region,
    DateTime RegistrationDate);
}
