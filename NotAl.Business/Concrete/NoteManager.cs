using FluentValidation;
using NotAl.Business.Abstract;
using NotAl.Business.ValidationRules.FluentValidation;
using NotAl.DataAccess.Abstract;
using NotAl.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotAl.Business.Concrete
{
    public class NoteManager : INoteService
    {
        private INoteDal noteDal;
        private NoteValidator validator;
        public NoteManager(INoteDal noteDal)
        {
            this.noteDal = noteDal;
            this.validator = new NoteValidator();

        }
        public void Add(Note note)
        {
            var result = validator.Validate(note);
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }
            noteDal.Add(note);
        }

        public void Delete(Note note)
        {
            noteDal.Delete(note);
        }

        public Note Get(int id)
        {
            return noteDal.Get(id);
        }

        public List<Note> GetAll()
        {
            return noteDal.GetAll();
        }

        public void Update(Note note)
        {
            var result = validator.Validate(note);
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }
            noteDal.Update(note);
        }
    }
}
