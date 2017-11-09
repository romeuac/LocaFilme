using System.Web;
using System.Web.Mvc;

namespace LocaFilme
{
    public class FilterConfig
    {
        // Sao filtros utilizados para a aplicacao inteira
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            // Adicionando a necessidade de um Login para utilizar toda a aplicacao
            // ENTRETANTO, irei deixar o HomeController com acesso aa anonimos (vide o arquivo do HomeController)
            filters.Add(new AuthorizeAttribute());

            // Eliminando o acesso ao antigo url da applicacao 
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
