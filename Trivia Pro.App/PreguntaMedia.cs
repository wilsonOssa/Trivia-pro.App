using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia_Pro.App
{
    public class PreguntaMedia : Pregunta
    {
        public PreguntaMedia()
        {
            Tiempo = 15;
            Puntaje = 10;
            Nivel = "Medio";
        }
        public override int Puntaje { get; }
    }

}
