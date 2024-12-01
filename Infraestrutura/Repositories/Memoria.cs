using Autodesk.AutoCAD.Interop;
using Autodesk.AutoCAD.Interop.Common;
using QuadrosNBR.Aplicacao.Repositories;
using QuadrosNBR.Dominio.Entities;
using QuadrosNBR.Infraestrutura.DataBase.Context;
using QuadrosNBR.Infraestrutura.Repositories.Base;

namespace QuadrosNBR.Infraestrutura.Repositories;

public class Memoria(AppDbContext _appDbContext) : Repository<MemoriaDominio>(_appDbContext), IMemoria
{
    public bool AreaAutocad(Guid projetoId, Guid tenantId, string dwgFilePath)
    {
        var areas = GetArea(projetoId, tenantId, dwgFilePath);

        if (areas is not null)
        {
            _appDbContext.Memorias.BulkSynchronize(areas);
            return true;
        }
        else
        {
            return false;
        }            
    }

    private static List<MemoriaDominio>? GetArea(Guid projetoId, Guid tenantId, string dwgFilePath)
    {
        if (Path.Exists(dwgFilePath) is true)
            return null;

        List<MemoriaDominio> memoriaDominio = [];

        ushort? Ordenacao;

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

                    try
                    {
                        Ordenacao = ushort.Parse(layer.Description.Trim());
                    }
                    catch
                    {
                        Ordenacao = null;
                    }

                    if (layer.Lock is false)
                    {
                        MemoriaDominio memoriaDominios = new(
                            null,
                            polyline.Layer,
                            (decimal)polyline.Area,
                            Ordenacao,
                            0,
                            null,
                            null,
                            0,
                            false,
                            false,
                            false,
                            false,
                            null,
                            projetoId,
                            tenantId);
                             
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
