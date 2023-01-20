using Parcial2UCAB.Persistence.Entities;
using System;
using System.Collections.Generic;

namespace Parcial2UCAB.Requests
{
    public class ActorRequest
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public TipoActor Tipologia  { get; set; }   
        public string Biografia { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string FotoURL { get; set; }

        public ActorRequest(string nombre,string Apellido, string tipologia, string biografia,  DateTime? fechaNacimiento,  string fotoURL)
        {
            Nombre = nombre;
            Biografia = biografia;
            Tipologia = tipologia;
            FechaNacimiento = fechaNacimiento;
            FotoURL = fotoURL;
        }

     /* public enum TipoActor
     {
             
             Protagonista,
           
             Secundario,
             
             DeReparto,
            
             DePequenaPartes
     }*/
   
}
}
