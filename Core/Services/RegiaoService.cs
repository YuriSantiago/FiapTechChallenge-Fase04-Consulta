using Core.DTOs;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Core.Services
{
    public class RegiaoService : IRegiaoService
    {

        private readonly IRegiaoRepository _regiaoRepository;

        public RegiaoService(IRegiaoRepository regiaoRepository)
        {
            _regiaoRepository = regiaoRepository;
        }

        public IList<RegiaoDTO> GetAll()
        {
            var regioesDTO = new List<RegiaoDTO>();
            var regioes = _regiaoRepository.GetAll();

            foreach (var regiao in regioes)
            {
                regioesDTO.Add(new RegiaoDTO()
                {
                    Id = regiao.Id,
                    DataInclusao = regiao.DataInclusao,
                    DDD = regiao.DDD,
                    Descricao = regiao.Descricao
                });
            }

            return regioesDTO;

        }

        public RegiaoDTO GetById(int id)
        {
            var regiao = _regiaoRepository.GetById(id);

            var regiaoDTO = new RegiaoDTO()
            {
                Id = regiao.Id,
                DataInclusao = regiao.DataInclusao,
                DDD = regiao.DDD,
                Descricao = regiao.Descricao
            };

            return regiaoDTO;
        }

        public RegiaoDTO? GetByDDD(short ddd)
        {
            var regiao = _regiaoRepository.GetByDDD(ddd);

            if (regiao is not null)
            {
                var regiaoDTO = new RegiaoDTO()
                {
                    Id = regiao.Id,
                    DataInclusao = regiao.DataInclusao,
                    DDD = regiao.DDD,
                    Descricao = regiao.Descricao
                };

                return regiaoDTO;
            }

            return null;
        }

        }
    }
