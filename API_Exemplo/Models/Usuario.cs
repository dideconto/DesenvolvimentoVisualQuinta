using System;

namespace API.Models 
{
    public class Usuario
    {
        public Usuario()
        {
            CriadoEm = DateTime.Now;
        }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime CriadoEm { get; set; }        
    }
}