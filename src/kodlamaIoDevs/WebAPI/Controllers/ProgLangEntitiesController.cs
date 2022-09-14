using Application.Features.ProgLang.Commands.CreateProgLang;
using Application.Features.ProgLang.Commands.DeleteProgLang;
using Application.Features.ProgLang.Commands.UpdateProgLang;
using Application.Features.ProgLang.Dtos;
using Application.Features.ProgLang.Models;
using Application.Features.ProgLang.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProgLangEntitiesController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
    {
        GetListProgLangEntityQuery getListProgLangEntityQuery = new() { PageRequest = pageRequest };
        ProgLangEntityListModel result = await Mediator.Send(getListProgLangEntityQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdProgLangEntityQuery getByIdProgLangEntityQuery)
    {
        GetByIdProgLangEntityDto getByIdProgLangEntityDto = await Mediator.Send(getByIdProgLangEntityQuery);
        return Ok(getByIdProgLangEntityDto);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProgLangEntityCommand createProgLangEntityCommand)
    {
        CreatedProgLangEntityDto result = await Mediator.Send(createProgLangEntityCommand);
        return Created("",result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Remove([FromRoute] DeleteProgLangEntityCommand deleteProgLangEntityCommand)
    {
        DeletedProgLangEntityDto result = await Mediator.Send(deleteProgLangEntityCommand);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProgLangEntityCommand updateProgLangEntityCommand)
    {
        await Mediator.Send(updateProgLangEntityCommand); 
        return NoContent();
    }

   
}

