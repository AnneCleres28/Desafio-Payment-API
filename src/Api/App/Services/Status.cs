using Api.Domain.Enum;

namespace Api.App.Services
{
    public static class Status
    {
        public static bool IsValid(EnumStatus from, EnumStatus to)
        {
            if ((from == EnumStatus.Aguardando) && 
                (to == EnumStatus.Aprovado || to == EnumStatus.Cancelada))
                    return true;
            else if ((from == EnumStatus.Aprovado) &&
                (to == EnumStatus.Enviado || to == EnumStatus.Cancelada))
                    return true;
            else if ((from == EnumStatus.Enviado) &&
                (to == EnumStatus.Entregue))
                    return true;
            else
                return false;
        }
    }
}