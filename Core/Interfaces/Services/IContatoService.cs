using Core.DTOs;

namespace Core.Interfaces.Services
{
    public interface IContatoService
    {
        IList<ContatoDTO> GetAll();

        ContatoDTO GetById(int id);

        IList<ContatoDTO> GetAllByDDD(short DDD);
    }
}
