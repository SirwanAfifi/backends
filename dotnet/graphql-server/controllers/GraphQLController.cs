using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using graphql_server.routes;
using Microsoft.AspNetCore.Mvc;

namespace graphql_server.controllers
{
    [Microsoft.AspNetCore.Components.Route("graphql")]
    public class GraphQLController : Controller
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _executer;
        public GraphQLController(ISchema schema, 
            IDocumentExecuter executer)
        {
            _schema = schema;
            _executer = executer;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] 
            GraphQlQueryDto query)
        {
            var result = await _executer.ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = query.Query;
                _.Inputs = query.Variables?.ToInputs();
                
            });
            if(result.Errors?.Count > 0)
            {
                return BadRequest();
            }
            return Ok(result.Data);
        }
    }
}