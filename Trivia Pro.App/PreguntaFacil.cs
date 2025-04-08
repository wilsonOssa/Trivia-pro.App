namespace Trivia_Pro.App
{
    public class PreguntaFacil : Pregunta
    {
        public PreguntaFacil()
        {
            Tiempo = 20; // 20 segundos para preguntas de nivel Fácil
        }

        public override int Puntaje => 5; // 5 puntos por respuesta correcta en nivel Fácil
    }
}
