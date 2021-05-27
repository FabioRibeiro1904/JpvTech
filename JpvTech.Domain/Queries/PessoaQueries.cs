using JpvTech.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace JpvTech.Domain.Queries
{
    public static class PessoaQueries
    {
        public static Expression<Func<Pessoa, bool>> GetCpf(string cpf)
        {
            return x => x.Cpf == cpf;
        }

        public static Expression<Func<Pessoa, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
