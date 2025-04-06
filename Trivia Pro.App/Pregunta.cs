using System.Collections.Generic;

public abstract class Pregunta
{
    public string Texto { get; protected set; }
    public List<string> Opciones { get; protected set; }
    public string RespuestaCorrecta { get; protected set; }
    public string Categoria { get; protected set; }
    public string Nivel { get; protected set; }
    public int Tiempo { get; protected set; }
    public abstract int Puntaje { get; }

    public bool EvaluarRespuesta(string respuesta)
    {
        return respuesta == RespuestaCorrecta;
    }
}