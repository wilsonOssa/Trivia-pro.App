using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Trivia_Pro.App;

public static class PreguntaFactory
{
    private static List<PreguntaDTO> _preguntasCargadas; // Almacena todas las preguntas del JSON
    private static readonly Random _random = new Random();

    // Constructor estático: carga las preguntas al iniciar la aplicación
    static PreguntaFactory()
    {
        _preguntasCargadas = CargarPreguntasDesdeJSON();
    }

    // Método para cargar el JSON
    private static List<PreguntaDTO> CargarPreguntasDesdeJSON()
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "preguntas.json");
        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<RootObject>(json).Preguntas;
    }

    // Método público para crear preguntas según categoría y nivel (¡aquí va implementado!)
    public static Pregunta CrearPregunta(string categoria, string nivel)
    {
        // Filtra preguntas por categoría y nivel
        var preguntasFiltradas = _preguntasCargadas
            .Where(p => p.Categoria == categoria && p.Nivel == nivel)
            .ToList();

        if (preguntasFiltradas.Count == 0)
            throw new Exception("No hay preguntas disponibles para esta categoría/nivel.");

        // Selecciona una pregunta aleatoria
        var preguntaDTO = preguntasFiltradas[_random.Next(preguntasFiltradas.Count)];

        // Crea la instancia según el nivel
        Pregunta pregunta;
        switch (nivel)
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

        // Asigna propiedades desde el DTO
        pregunta.Texto = preguntaDTO.Texto;
        pregunta.Opciones = preguntaDTO.Opciones;
        pregunta.RespuestaCorrecta = preguntaDTO.RespuestaCorrecta;
        pregunta.Categoria = preguntaDTO.Categoria;
        pregunta.Nivel = preguntaDTO.Nivel;

        return pregunta;
    }
}