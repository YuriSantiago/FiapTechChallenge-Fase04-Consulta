using Core.DTOs;

namespace Core.Interfaces.Services
{
    public interface IRegiaoService
    {
        IList<RegiaoDTO> GetAll();

        RegiaoDTO GetById(int id);

        RegiaoDTO? GetByDDD(short DDD);
    }
}
