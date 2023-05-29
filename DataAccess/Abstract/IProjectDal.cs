﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProjectDal:IEntityRepository<Project>
    {
        Task ProjectAllDelete(int id);
    }
}
