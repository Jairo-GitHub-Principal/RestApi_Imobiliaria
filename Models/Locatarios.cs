using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;  //usado para atribuir uma tipagem nos dados, na hora de criar os DB


namespace WebAPI_ImobiliariaSantos.Models
{
    public class Locatarios
    {
         public int Id {get; set;}
         
         [StringLength(64)]
        public string nomeLocatario{get; set;}

         [StringLength(64)]
        public string cpfLocatario {get; set;} 

        [StringLength(64)]
        public string dataNascLocatario{get; set;}

        [StringLength(64)] // faz com que o efcore, informe essse campo como varchar, na hr de criar o DB
        public string dataLocLocatario {get; set;}

         [StringLength(64)]
        public string dataVencimentoAlugLocatario{get; set;}

        // os dados abixo serve para criar o rerlacionamento entre tabelas "Imoveis e Locatario"
        public int ImovelId{get; set;}
        public Imoveis Imovel{get;set;}
        
        
    }
}