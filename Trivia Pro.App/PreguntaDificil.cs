using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia_Pro.App
{
    public class PreguntaDificil : Pregunta
    {
        public PreguntaDificil ()
        {
            Tiempo = 10;
            Puntaje = 15;
            Nivel = "Difícil";
        }
        public override int Puntaje { get; }
    }

}
