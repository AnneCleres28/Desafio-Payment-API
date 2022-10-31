using System.Text.Json.Serialization;

namespace Api.Domain.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumStatus
    {
        Aguardando,
        Aprovado,
        Cancelada,
        Enviado,
        Entregue
    }
}