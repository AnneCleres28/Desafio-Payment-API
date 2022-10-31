using Api.Domain.Entities;
using Api.Domain.Enum;

namespace Api.App.Interface
{
    public interface IVenda
    {
        public dynamic Create(Venda venda);
        
	    public List<Venda> GetAll();

        public dynamic GetByIdJoin(int id);

        public dynamic UpdateStatus(int id, EnumStatus newStatus);
    }
}