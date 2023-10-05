﻿using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Cores.JazaniT1.Domain.Cores.Repositories;

namespace JazaniT1.Domain.Admins.Repositories
{
    //Definiendo el contrato de la Interfaz
    public interface ILevelEducationRepository: ICrudRepository<LevelEducation,int>
    { }
}
