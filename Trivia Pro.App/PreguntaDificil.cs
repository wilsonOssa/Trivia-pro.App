namespace Trivia_Pro.App
{
    public class PreguntaDificil : Pregunta
    {
        public PreguntaDificil()
        {
            Tiempo = 10; // 10 segundos para preguntas de nivel Difícil
        }

        public override int Puntaje => 15; // 15 puntos por respuesta correcta en nivel Difícil
    }
}
