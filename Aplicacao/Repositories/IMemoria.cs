﻿using QuadrosNBR.Aplicacao.Repositories.Base;
using QuadrosNBR.Dominio.Entities;

namespace QuadrosNBR.Aplicacao.Repositories;

public interface IMemoria : IRepository<MemoriaDominio>
{
    bool AreaAutocad(Guid projetoId, Guid tenantId, string dwgFilePath);
}
