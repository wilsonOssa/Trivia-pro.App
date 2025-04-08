namespace Trivia_Pro.App
{
    public class PreguntaMedia : Pregunta
    {
        public PreguntaMedia()
        {
            Tiempo = 15; // 15 segundos para preguntas de nivel Medio
        }

        public override int Puntaje => 10; // 10 puntos por respuesta correcta en nivel Medio
    }
}
