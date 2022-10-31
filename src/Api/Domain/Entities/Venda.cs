using Api.Domain.Enum;

namespace Api.Domain.Entities
{
    public class Venda
    {     
      public int Id { get; set; }
      public int Vendedor { get; set; }
      public DateTime Data { get; set; }
      public EnumStatus Status { get; set; }
      public int[] Itens { get; set; }
    }
}