using Core.DTOs;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class ContatoService : IContatoService
    {

        private readonly IContatoRepository _contatoRepository;
        private readonly IRegiaoRepository _regiaoRepository;

        public ContatoService(IContatoRepository contatoRepository, IRegiaoRepository regiaoRepository)
        {
            _contatoRepository = contatoRepository;
            _regiaoRepository = regiaoRepository;
        }

        public IList<ContatoDTO> GetAll()
        {
            var contatosDTO = new List<ContatoDTO>();
            var contatos = _contatoRepository.GetAll(c => c.Include(r => r.Regiao));

            foreach (var contato in contatos)
            {
                contatosDTO.Add(new ContatoDTO()
                {
                    Id = contato.Id,
                    DataInclusao = contato.DataInclusao,
                    Nome = contato.Nome,
                    Telefone = contato.Telefone,
                    Email = contato.Email,
                    Regiao = new RegiaoDTO()
                    {
                        Id = contato.Regiao.Id,
                        DataInclusao = contato.Regiao.DataInclusao,
                        DDD = contato.Regiao.DDD,
                        Descricao = contato.Regiao.Descricao
                    }
                });
            }

            return contatosDTO;

        }

        public ContatoDTO GetById(int id)
        {
            var contato = _contatoRepository.GetById(id, c => c.Include(r => r.Regiao));

            var contatoDTO = new ContatoDTO()
            {
                Id = contato.Id,
                DataInclusao = contato.DataInclusao,
                Nome = contato.Nome,
                Telefone = contato.Telefone,
                Email = contato.Email,
                Regiao = new RegiaoDTO()
                {
                    Id = contato.Regiao.Id,
                    DataInclusao = contato.Regiao.DataInclusao,
                    DDD = contato.Regiao.DDD,
                    Descricao = contato.Regiao.Descricao
                }
            };

            return contatoDTO;
        }

        public IList<ContatoDTO> GetAllByDDD(short ddd)
        {
            var contatosDTO = new List<ContatoDTO>();
            var contatos = _contatoRepository.GetAllByDDD(ddd);

            foreach (var contato in contatos)
            {
                contatosDTO.Add(new ContatoDTO()
                {
                    Id = contato.Id,
                    DataInclusao = contato.DataInclusao,
                    Nome = contato.Nome,
                    Telefone = contato.Telefone,
                    Email = contato.Email,
                    Regiao = new RegiaoDTO()
                    {
                        Id = contato.Regiao.Id,
                        DataInclusao = contato.Regiao.DataInclusao,
                        DDD = contato.Regiao.DDD,
                        Descricao = contato.Regiao.Descricao
                    }
                });
            }

            return contatosDTO;
        }

    }
}
