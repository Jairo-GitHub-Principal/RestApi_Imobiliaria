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
         
        public string nomeLocatario{get; set;}

        public string cpfLocatario {get; set;} 

        public string dataNascLocatario{get; set;}

        public string dataLocLocatario {get; set;}

      
        public string dataVencimentoAlugLocatario{get; set;}
           
      
         public string imagemLocatario{get; set;}
        
        
        
    }
}