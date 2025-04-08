using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Trivia_Pro.App
{
    public static class PreguntaFactory
    {
        // Almacena los DTOs cargados desde el JSON
        private static List<PreguntaDTO> _preguntasCargadas;
        private static readonly Random _random = new Random();

        // Cargar las preguntas del JSON en el constructor estático
        static PreguntaFactory()
        {
            try
            {
                _preguntasCargadas = CargarPreguntasDesdeJSON();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar preguntas: " + ex.Message);
                _preguntasCargadas = new List<PreguntaDTO>();
            }
        }

        private static List<PreguntaDTO> CargarPreguntasDesdeJSON()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "preguntas.json");
            string json = File.ReadAllText(path);
            RootObject root = JsonConvert.DeserializeObject<RootObject>(json);
            return root.Preguntas;
        }

        // Devuelve una pregunta aleatoria y única según la categoría y nivel indicados
        public static Pregunta ObtenerPreguntaAleatoria(string categoria, string nivel)
        {
            var preguntasFiltradas = _preguntasCargadas
                .Where(p => p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase)
                         && p.Nivel.Equals(nivel, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (preguntasFiltradas.Count == 0)
            {
                return null;
            }

            int indice = _random.Next(preguntasFiltradas.Count);
            PreguntaDTO preguntaDTO = preguntasFiltradas[indice];

            // Elimina la pregunta seleccionada para evitar repeticiones en la sesión
            _preguntasCargadas.Remove(preguntaDTO);

            return CrearPregunta(preguntaDTO);
        }

        // Crea una instancia concreta de Pregunta según el nivel indicado
        public static Pregunta CrearPregunta(PreguntaDTO preguntaDTO)
        {
            Pregunta pregunta;
            switch (preguntaDTO.Nivel)
            {
                case "Fácil":
                    pregunta = new PreguntaFacil();
                    break;
                case "Medio":
                    pregunta = new PreguntaMedia();
                    break;
                case "Difícil":
                    pregunta = new PreguntaDificil();
                    break;
                default:
                    throw new ArgumentException("Nivel no válido");
            }

            // Copiar las propiedades del DTO a la instancia de Pregunta
            pregunta.Texto = preguntaDTO.Texto;
            pregunta.Opciones = preguntaDTO.Opciones;
            pregunta.RespuestaCorrecta = preguntaDTO.RespuestaCorrecta;
            pregunta.Categoria = preguntaDTO.Categoria;
            pregunta.Nivel = preguntaDTO.Nivel;
            return pregunta;
        }
    }
}
