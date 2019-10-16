using CasaQuery.Models;
using GraphQL.Types;

namespace CasaQuery.Queries{

    public class CasaType:ObjectGraphType<Casa>{
        public CasaType(){
            Name="Casa";
            Description="La casa disponibles";
            Field(u=>u.Id,type:typeof(IntGraphType)).Description("La id de la casa");
            Field(u=>u.Nombre).Description("El nombre especifico de la casa");;
            Field(u=>u.Direccion).Description("La direccion donde esta ubicada");;
            Field(u=>u.Precio).Description("El precio de la casa");;

        }
    }

}