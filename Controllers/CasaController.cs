using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CasaQuery.Models;
using CasaQuery.Queries;
using GraphQL;
using GraphQL.Types;

namespace CasaQuery.Controllers
{
    [ApiController]
    [Route("graphql")]
    public class CasaController : ControllerBase
    {
        private readonly CasaContext contexto;

        public CasaController(CasaContext co){
            contexto=co;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQuery query){
            var inputs=query.Variables.ToInputs();
            var schema= new Schema{
                Query=new CasaQuery.Queries.CasaQuery(contexto)
            };
            var result= await new DocumentExecuter().ExecuteAsync(e=>{
                e.Schema=schema;
                e.Query=query.Query;
                e.OperationName=query.OperationName;
                e.Inputs=inputs;
            });

            if(result.Errors?.Count>0){
                return BadRequest();
            }
            return Ok(result);

        }



        
    }
}
