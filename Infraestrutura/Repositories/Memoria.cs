﻿using QuadrosNBR.Aplicacao.Repositories;
using QuadrosNBR.Dominio.Entities;
using QuadrosNBR.Infraestrutura.DataBase.Context;
using QuadrosNBR.Infraestrutura.Repositories.Base;

namespace QuadrosNBR.Infraestrutura.Repositories;

public class Memoria(AppDbContext _appDbContext) : Repository<MemoriaDominio>(_appDbContext), IMemoria
{
   
}