using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using QuadrosNBR.Aplicacao.IUnitOfWork;
using QuadrosNBR.Dominio.Entities;


namespace QuadrosNBR.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MemoriaController : ControllerBase
{
    private readonly IValidator<MemoriaDominio> _validator;

    private readonly IMapper _mapper;

    private readonly IUnitOfWork _unitOfWork;

    public MemoriaController(IUnitOfWork unitOfWork, IValidator<MemoriaDominio> validator, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
        _mapper = mapper;
    }

   
    [HttpPost]
    public ActionResult<string> PostAreaAutocad([FromRoute] string projid, string tenantId, string dwgFilePath)
    {
        var area =  _unitOfWork.Imemoria.AreaAutocad(Guid.Parse(projid), Guid.Parse(tenantId), dwgFilePath);
     
        if (area is true)
        {
            return Ok();
        }
        else
        {
            return NotFound();
        }  
    }

   
}
