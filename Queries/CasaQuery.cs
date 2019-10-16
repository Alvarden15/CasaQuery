using GraphQL.Types;
using CasaQuery.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CasaQuery.Queries{
    public class CasaQuery:ObjectGraphType{
        public CasaQuery(CasaContext contexto){
            Field<ListGraphType<CasaType>>("Casas","Lista de casas",
             resolve:context=>{
                var casas= contexto.casa.AsEnumerable().ToList();
                return casas;
             }
            );

            Field<CasaType>("Casa",
            "La casa especifica",
            arguments:new QueryArguments(new QueryArgument<IntGraphType>{
                Name="id",
                Description="La id de la casa que se busca"
            }),
            resolve:context=>{
                var buscado=context.GetArgument<int>("id");
                Casa casa=contexto.casa.FirstOrDefault(e=>e.Id==buscado);
                return casa;
            });

        }
    }

}