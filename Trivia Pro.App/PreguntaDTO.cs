using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia_Pro.App
{
    public class PreguntaDTO
    {
        public string Texto { get; set; }
        public List<string> Opciones { get; set; }
        public string RespuestaCorrecta { get; set; }
        public string Categoria { get; set; }
        public string Nivel { get; set; }
    }

    public class RootObject
    {
        public List<PreguntaDTO> Preguntas { get; set; }
    }
}
