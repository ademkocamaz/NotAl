using Dapper;
using FirebirdSql.Data.FirebirdClient;
using NotAl.Core.DataAccess;
using NotAl.DataAccess.Abstract;
using NotAl.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotAl.DataAccess.Concrete.Dapper
{
    public class DapperNoteDal : INoteDal
    {
        private FbConnection connection;

        public DapperNoteDal()
        {
            connection = new FbConnection(Database.connectionString);
        }
        public void Add(Note entity)
        {
            connection.Open();
            connection.Execute("INSERT INTO NOTES (TITLE,DETAIL) VALUES (@title,@detail)", new { entity.Title, entity.Detail });
            connection.Close();
        }

        public void Delete(Note entity)
        {
            connection.Open();
            connection.Execute("DELETE FROM NOTES WHERE ID=@id", new { entity.Id });
            connection.Close();
        }

        public Note Get(int id)
        {
            connection.Open();
            var note = connection.Query<Note>("SELECT * FROM NOTES WHERE ID=@id", new { id }).FirstOrDefault();
            connection.Close();
            return note;
        }

        public List<Note> GetAll()
        {
            connection.Open();
            var list = connection.Query<Note>("SELECT * FROM NOTES").ToList();
            connection.Close();
            return list;
        }

        public void Update(Note entity)
        {
            connection.Open();
            connection.Execute("UPDATE NOTES SET TITLE=@title, DETAIL=@detail WHERE ID=@id", new {entity.Title,entity.Detail,entity.Id});
            connection.Close();
        }
    }
}
