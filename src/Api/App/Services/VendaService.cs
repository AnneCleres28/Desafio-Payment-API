using Api.App.Interface;
using Api.Domain.Entities;
using Api.Domain.Enum;
using Api.Infra.Context;
using Api.Infra.Repositories;

namespace Api.App.Services
{
    public class VendaService : IVenda
    {
        private readonly PottencialContext _context;

        public VendaService(PottencialContext context)
        {
            _context = context;
        }
        
        public dynamic Create(Venda venda)
        {
            if (venda.Itens.Length <= 0)
                throw new Exception("A inclusão de uma venda deve possuir pelo menos 1 item");
            
            if (_context.Vendedores.Find(venda.Vendedor) == null)
                throw new Exception("Vendedor não cadastrado");

            return new VendaRepository(_context).Create(venda);    
        }

        public List<Venda> GetAll()
        {
            return new VendaRepository(_context).GetAll();
        }

        public dynamic GetByIdJoin(int id)
        {
            return new VendaRepository(_context).GetByIdJoin(id);
        }

        public dynamic UpdateStatus(int id, EnumStatus newStatus)
        {
            var dbVenda = new VendaRepository(_context).GetById(id);
            
            if (dbVenda == null)
                return null;
            
            if (Status.IsValid(dbVenda.Status, newStatus))
                return new VendaRepository(_context).UpdateStatus(id, newStatus);
            else
                throw new Exception($"Não é possível alterar o status da venda de '{dbVenda.Status}' para '{newStatus}'");
        }
    }
}