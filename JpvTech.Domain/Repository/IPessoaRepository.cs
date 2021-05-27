using JpvTech.Domain.Entities;
using System;
using System.Collections.Generic;

namespace JpvTech.Domain.Repository
{
    public interface IPessoaRepository
    {
        void Create(Pessoa pessoa);

        Pessoa GetCpf(string cpf);

        Pessoa GetById(Guid id);

        void Update(Pessoa pessoa);

        void Delete(Guid id);

        IEnumerable<Pessoa> GetList();
    }
}
