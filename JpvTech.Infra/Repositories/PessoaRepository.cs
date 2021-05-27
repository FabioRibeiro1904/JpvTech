using JpvTech.Domain.Entities;
using JpvTech.Domain.Queries;
using JpvTech.Domain.Repository;
using JpvTech.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JpvTech.Infra.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly DataContext _context;
        public PessoaRepository(DataContext context)
        {
            _context = context;
        }
        public void Create(Pessoa pessoa)
        {
            pessoa.Cpf.Trim().Replace(".", "").Replace("-", "");
            _context.Pessoa.Add(pessoa);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var delPessoa = _context.Pessoa.Find(id);
            _context.Pessoa.Remove(delPessoa);
            _context.SaveChanges();
        }

        public Pessoa GetById(Guid id)
        {
            return _context.Pessoa.AsNoTracking().FirstOrDefault(PessoaQueries.GetById(id));
        }

        public Pessoa GetCpf(string cpf)
        {
            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            return (_context.Pessoa.AsNoTracking().Where(PessoaQueries.GetCpf(cpf)).FirstOrDefault());
        }

        public void Update(Pessoa pessoa)
        {
            _context.Entry(pessoa).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Pessoa> GetList()
        {
            return _context.Pessoa.AsNoTracking().ToList();
        }
    }
}
