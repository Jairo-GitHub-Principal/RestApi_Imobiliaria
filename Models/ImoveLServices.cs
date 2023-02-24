using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace WebAPI_ImobiliariaSantos.Models
{
    public class ImoveLServices
    {
        
          public Imoveis CadastrarImovel(Imoveis novoImovel)
        {
            
            using(var contexto = new ContextoDataBase())
            {
                contexto.Add(novoImovel);
                contexto.SaveChanges();
                return novoImovel;
            }
        }

         public List<Imoveis> ListarImoveis()
        {
            using(var contexto = new ContextoDataBase())
            {
                return contexto.imoveis.ToList<Imoveis>();
            }
        }
        
        
    }
}