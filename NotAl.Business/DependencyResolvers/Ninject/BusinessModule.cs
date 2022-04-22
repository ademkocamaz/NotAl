using Ninject.Modules;
using NotAl.Business.Abstract;
using NotAl.Business.Concrete;
using NotAl.DataAccess.Abstract;
using NotAl.DataAccess.Concrete.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotAl.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<INoteService>().To<NoteManager>().InSingletonScope();
            Bind<INoteDal>().To<DapperNoteDal>().InSingletonScope();
        }
    }
}
