using Dapper;
using Microsoft.EntityFrameworkCore;
using NetCore_InfraData.Data.Context;
using NetCore_InfraData.Domain.Entities;
using NetCore_InfraData.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace NetCore_InfraData.Data.Repositories
{
    public class RespostaRepository : RepositoryBase<Resposta>, IRespostaRepository
    {
        public RespostaRepository(DBContext context)
            : base(context)
        {
        }
        public override IEnumerable<Resposta> ObterTodos()
        {
            var cn = Db.Database.GetDbConnection();
            string sql = @"SELECT  R.*                                   
                            FROM Respostas as R";
            var respostas = cn.Query<Resposta>(sql)
                .Distinct()
                .ToList();
            return respostas;

        }
        public IEnumerable<Resposta> ObterMinhasRespostas(string autor)
        {
            var cn = Db.Database.GetDbConnection();
            string sql = @"SELECT  P.Id,P.Autor,P.Titulo,P.Descricao,P.CategoriaId,P.DataCadastro,
                                   R.Id,R.Autor,R.Descricao,R.PerguntaId,
                                   C.Id,C.Titulo,C.Descricao
                            FROM Perguntas P INNER JOIN
                                Respostas R ON P.Id = R.PerguntaId INNER JOIN
                                Categorias C ON P.CategoriaId = C.Id
                            WHERE R.autor=@autor";
            var respostas = cn.Query<Pergunta, Resposta, Categoria, Resposta>(sql,
                (p, r, c) =>
                {
                    if (r != null)
                        p.Respostas.Add(r);
                    p.Categoria = c;

                    return r;
                }
                , new { autor = autor }
                , splitOn: "Id,Id,Id")
                .Distinct()
                .ToList();
            return respostas;
        }
    }
}
