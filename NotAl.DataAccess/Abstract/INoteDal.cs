using NotAl.Core.DataAccess;
using NotAl.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotAl.DataAccess.Abstract
{
    public interface INoteDal:IEntityRepository<Note>
    {

    }
}
