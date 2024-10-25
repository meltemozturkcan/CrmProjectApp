using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmProject.Application.DTOs
{//belirli kriterlere göre müşteri verilerini filtrelemek için kullanılır.
    public record CustomerFilterDto(
      string? SearchTerm,//Müşterilerde, ad, soyad, e-posta gibi alanlarda bir arama yapmak için kullan
      string? Region,//Bir müşteri belirli bir bölgeye aitse, bu değer üzerinden filtrelenir. Eğer bölge seçilmemişse, tüm bölgeler dahil edilir.
      DateTime? FromDate,//kayıt tarihine göre başlangıç tarihinden itibaren filtreleme yapmak için
      DateTime? ToDate,//Kayıt tarihi bitiş tarihine göre müşteri verilerini filtreler. DateTime? ile null olabilir ve tüm tarihler dahil edilir
      int PageNumber = 1,//Verilerin büyük kümeler halinde gelmesini önlemek için sonuçlar parça parça (sayfalı) getirilir.
      int PageSize = 10);//her sayfada 10 müşteri kaydı dönecek
}
