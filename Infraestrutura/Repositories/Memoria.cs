using Autodesk.AutoCAD.Interop.Common;
using Autodesk.AutoCAD.Interop;
using QuadrosNBR.Aplicacao.Repositories;
using QuadrosNBR.Dominio.Entities;
using QuadrosNBR.Infraestrutura.DataBase.Context;
using QuadrosNBR.Infraestrutura.Repositories.Base;

namespace QuadrosNBR.Infraestrutura.Repositories;

public class Memoria(AppDbContext _appDbContext) : Repository<MemoriaDominio>(_appDbContext), IMemoria
{
    public void AreaAutocad(Guid ProjetoId, Guid TenantId, string dwgFilePath)
    {
        var areas = GetArea(ProjetoId, TenantId, dwgFilePath);

        if (areas is not null)
            _appDbContext.Memorias.BulkSynchronize(areas);
    }

    private static List<MemoriaDominio>? GetArea(Guid ProjetoId, Guid TenantId, string dwgFilePath)
    {
        if (Path.Exists(dwgFilePath) is true)
            return null;

        List<MemoriaDominio> memoriaDominio = [];

        AcadApplication? acadApp = null;

        try
        {
            acadApp = new AcadApplication
            {
                Visible = false
            };

            AcadDocument acadDoc = acadApp.Documents.Open(dwgFilePath, ReadOnly: true);

            Thread.Sleep(3000);


            foreach (AcadEntity entity in acadDoc.ModelSpace)
            {
                if (entity is AcadLWPolyline polyline)
                {

                    string layerName = polyline.Layer;
                    AcadLayer layer = acadDoc.Layers.Item(layerName);

                    if (layer.Lock is false)
                    {
                        MemoriaDominio memoriaDominios = new(
                            polyline.Layer,
                            (decimal)polyline.Area,
                            null,
                            0,
                            null,
                            null,
                            null,
                            0,
                            false,
                            false,
                            false,
                            null,
                            false,
                            ProjetoId,
                            TenantId);

                        memoriaDominio.Add(memoriaDominios);
                    }
                }
            }

            acadDoc.Close();
            return memoriaDominio;
        }
        catch
        {
            return null;
        }
        finally
        {
            acadApp?.Quit();
        }
    }
}
