using Domain.Commands.DeleteList;
using Domain.Commands.InsertList;
using Domain.Commands.UpdateList;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListDDDMediator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryList _repository;

        public ListController(IMediator mediator, IRepositoryList repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        /// <summary>
        /// Insertir um item da lista
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert([FromBody] InsertListCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command) );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retornar todos itens da Lista
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var entity = await _repository.GetAll();

            return Ok(entity);
        }

        /// <summary>
        /// Deleta um item da lista
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteListCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command) + "\n Item excluido com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualizar item
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateListCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
