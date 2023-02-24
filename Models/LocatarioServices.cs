using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_ImobiliariaSantos.Models
{
    public class LocatarioServices
    {
         public Locatarios CadastrarLocatario(Locatarios novoLocatario)
        {
            using(var contexto = new ContextoDataBase())
            {
                contexto.Add(novoLocatario);
                contexto.SaveChanges();
                return novoLocatario;
            }
            }
         public List<Locatarios> ListarLocatarios()
        {
            using(var contexto = new ContextoDataBase())
            {
                return contexto.locatarios.ToList<Locatarios>();
            }
        }
        
    }
}