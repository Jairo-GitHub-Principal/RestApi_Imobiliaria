using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;  //usado para atribuir uma tipagem nos dados, na hora de criar os DB
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_ImobiliariaSantos.Models
{
    public class Imoveis
    {
        public int Id {get; set;}
         
         [StringLength(64)]
        public string tipoImovel{get; set;}

         [StringLength(64)]
        public string enderecoImovel {get; set;} 

        [StringLength(64)]
        public string finalidadeImovel{get; set;}

        [StringLength(64)] // faz com que o efcore, informe essse campo como varchar, na hr de criar o DB
        public string descricaoImovel {get; set;}

        
        [Column(TypeName = "DECIMAL(5,2)")]
        public decimal precoImovel{get; set;}

        [StringLength(1000)]
        public string imagemImovel {get;set;}


        

        

       

        

        





        
    }
}