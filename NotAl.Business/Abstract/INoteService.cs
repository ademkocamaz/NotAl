using NotAl.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotAl.Business.Abstract
{
    public interface INoteService
    {
        Note Get(int id);
        List<Note> GetAll();
        void Add(Note note);
        void Update(Note note);
        void Delete(Note note);
    }
}
