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

    // GET: api/<MemoriaController>
    [HttpGet]
    public ActionResult<string> Get([FromRoute] string projid, string tenantId, string dwgFilePath)
    {
        var area =  _unitOfWork.Imemoria.AreaAutocad(Guid.Parse(projid), Guid.Parse(tenantId), dwgFilePath);

        if(area == false)
        {
            return NotFound();
        }
        else
        {
            return Ok();
        }  
    }

    // GET api/<MemoriaController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<MemoriaController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
        _unitOfWork.Commit();
    }

    // PUT api/<MemoriaController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<MemoriaController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
