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
        private static List<PreguntaDTO> _preguntasOriginales;
        private static List<PreguntaDTO> _preguntasDisponibles;
        private static readonly Random _random = new Random();

        static PreguntaFactory()
        {
            try
            {
                _preguntasOriginales = CargarPreguntasDesdeJSON();
                RecargarPreguntas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar preguntas: " + ex.Message);
                _preguntasOriginales = new List<PreguntaDTO>();
                _preguntasDisponibles = new List<PreguntaDTO>();
            }
        }

        public static void RecargarPreguntas()
        {
            _preguntasDisponibles = new List<PreguntaDTO>(_preguntasOriginales);
        }

        private static List<PreguntaDTO> CargarPreguntasDesdeJSON()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "preguntas.json");
            string json = File.ReadAllText(path);
            RootObject root = JsonConvert.DeserializeObject<RootObject>(json);
            return root.Preguntas;
        }

        public static List<Pregunta> ObtenerPreguntasAleatorias(string categoria, string nivel)
        {
            // Obtener preguntas filtradas por categoría y nivel
            var preguntasFiltradas = _preguntasDisponibles
                .Where(p =>
                    p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase) &&
                    p.Nivel.Equals(nivel, StringComparison.OrdinalIgnoreCase)
                )
                .OrderBy(p => _random.Next()) // Mezclar preguntas
                .ToList();

            // Eliminar las preguntas seleccionadas de la lista disponible
            foreach (var pregunta in preguntasFiltradas)
            {
                _preguntasDisponibles.Remove(pregunta);
            }

            return preguntasFiltradas.Select(p => CrearPregunta(p)).ToList();
        }

        public static Pregunta CrearPregunta(PreguntaDTO preguntaDTO)
        {
            Pregunta pregunta;
            switch (preguntaDTO.Nivel.ToLower()) // Convertir a minúsculas
            {
                case "fácil":
                    pregunta = new PreguntaFacil();
                    break;
                case "medio":
                    pregunta = new PreguntaMedia();
                    break;
                case "difícil":
                    pregunta = new PreguntaDificil();
                    break;
                default:
                    throw new ArgumentException($"Nivel no válido: {preguntaDTO.Nivel}");
            }

            // Asignar propiedades
            pregunta.Texto = preguntaDTO.Texto;
            pregunta.Opciones = preguntaDTO.Opciones;
            pregunta.RespuestaCorrecta = preguntaDTO.RespuestaCorrecta;
            pregunta.Categoria = preguntaDTO.Categoria;
            pregunta.Nivel = preguntaDTO.Nivel;

            return pregunta; // Retorno garantizado
        }
    }
}