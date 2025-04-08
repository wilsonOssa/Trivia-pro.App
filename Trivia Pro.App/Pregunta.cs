using System.Collections.Generic;

namespace Trivia_Pro.App
{
    public abstract class Pregunta
    {
        public string Texto { get; set; }
        public List<string> Opciones { get; set; }
        public string RespuestaCorrecta { get; set; }
        public string Categoria { get; set; }
        public string Nivel { get; set; }
        public int Tiempo { get; set; }
        public abstract int Puntaje { get; }

        public bool EvaluarRespuesta(string respuesta)
        {
            return respuesta.Equals(RespuestaCorrecta);
        }
    }
}
