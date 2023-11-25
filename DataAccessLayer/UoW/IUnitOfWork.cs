using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UoW
{
    public interface IUnitOfWork
    {
        IContactUsDal ContactUsDal { get; }
        void Commit();
    }
}
