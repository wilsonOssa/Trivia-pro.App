using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia_Pro.App
{
    public class PreguntaFacil : Pregunta
    {
        public PreguntaFacil()
        {
            Tiempo = 20;
            Puntaje = 5;
            Nivel = "Fácil";
        }
        public override int Puntaje { get; }
    }

}
