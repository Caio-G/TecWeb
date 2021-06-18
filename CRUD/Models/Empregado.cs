using System;    
using System.Collections.Generic;    
using System.ComponentModel.DataAnnotations;    
using System.Linq;    
using System.Threading.Tasks;        

namespace MVCAdoDemo.Models    
{        public class Empregado        
    {            
        public int ID { get; set; }            [Required]            
        public string Nome { get; set; }            [Required]            
        public string Genero { get; set; }            [Required]            
        public string Departamento { get; set; }            [Required]            
        public string Cidade { get; set; }        
    }    
}
