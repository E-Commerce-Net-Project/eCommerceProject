using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IColorDal : IGenericDal<Color>
    {
    }
}
