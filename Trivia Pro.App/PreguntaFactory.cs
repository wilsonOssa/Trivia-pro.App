using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia_Pro.App
{
    public static class PreguntaFactory
    {
        public static Pregunta CrearPregunta(string categoria, string nivel)
        {
            // Ejemplo de pregunta (puedes cargarlas desde un archivo JSON o base de datos)
            var pregunta = new PreguntaFacil(); // Cambia según el nivel
            pregunta.Categoria = categoria;
            pregunta.Texto = "¿Cuál es la capital de Francia?";
            pregunta.Opciones = new List<string> { "Madrid", "París", "Berlín", "Roma" };
            pregunta.RespuestaCorrecta = "París";

            return pregunta;
        }
    }
}
