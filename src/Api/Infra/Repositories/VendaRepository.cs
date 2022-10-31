using Api.App.Interface;
using Api.Domain.Entities;
using Api.Domain.Enum;
using Api.Infra.Context;

namespace Api.Infra.Repositories
{
    public class VendaRepository : IVenda
    {
        private readonly PottencialContext _context;

        public VendaRepository(PottencialContext context)
        {
            _context = context;
        }

        public dynamic Create(Venda venda)
        {
            _context.Add(venda);
            _context.SaveChanges();
            return GetByIdJoin(venda.Id);
        }

        public List<Venda> GetAll()
        {
            return _context.Vendas.ToList();
        }

        public dynamic GetByIdJoin(int id)
        {
            if (_context.Vendas.Find(id) == null)
                return null;
            else
            {
                var query = from vendedor in _context.Vendedores
                            join venda in _context.Vendas on vendedor.Id equals venda.Vendedor
                            where venda.Id == id
                            select new
                            {
                                Id = venda.Id,
                                Data = venda.Data,
                                Status = venda.Status,
                                Vendedor_id = vendedor.Id,
                                Vendedor_nome = vendedor.Nome,
                                Vendedor_cpf = vendedor.Cpf,
                                Vendedor_email = vendedor.Email,
                                Vendedor_telefone = vendedor.Telefone,                   
                                Itens_id = venda.Itens
                            };
                return query;
            }
        }

        public dynamic UpdateStatus(int id, EnumStatus newStatus)
        {
            var venda = _context.Vendas.Find(id);
            if (venda != null)
            {
                venda.Status = newStatus;
                _context.Vendas.Update(venda);
                _context.SaveChanges();
            }
            return GetByIdJoin(id);
        }

        public Venda GetById(int id)
        {
            return _context.Vendas.Find(id);
        }
    }
}