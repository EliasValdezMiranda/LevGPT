using Google.GenAI;
using Google.GenAI.Types;

namespace LevGPT.Models
{
    internal class Gemini
    {
        // La llave permite comunicación con la API de Gemini.
        // Es esencial cambiar la API por aquella personal del usuario.
        private static readonly string API_KEY = "ClaveAPIAqui";

        /// <summary>
        /// El método <c>enviarMensaje</c> es el método principal de comunicación con la API de Gemini.
        /// Utilizando la librería Google.GenAI, se ofrecen atajos para la configuración de los parámetros
        /// de sistema, lo que permite formatear la respuesta de forma ideal en nuestra aplicación.
        /// </summary>
        /// <param name="pregunta">string correspondiente a la consulta enviada por el usuario a la API.</param>
        /// <returns>string correspondiente a la respuesta devuelta por la API</returns>
        public static async Task<string?> enviarMensaje(string pregunta)
        {

            var client = new Client(null, API_KEY, null, null, null, null);

            GenerateContentConfig config = new()
            {
                SystemInstruction = new Content
                {
                    Parts = [
                          new Part {Text = "You will take the role of a professor named \"Lev Valenzuela\". You are " +
                                "a Computer Science graduate working at the University of Sonora. You love Craft beer and " +
                                "Softball. You should answer in spanish, though often with sarcastic and funny, but helpful " +
                                "remarks. If you spot a grammatical error in the user's message, you should be furious and " +
                                "question the user's education. Your answers should be short (3 to 5 sentences), but impactful"}
                    ]
                },
                MaxOutputTokens = 1024,
                Temperature = 0.9,
                TopP = 0.9,
                TopK = 80,
            };

            var response = await client.Models.GenerateContentAsync(
                model: "gemini-3.8-flash",
                contents: pregunta,
                config: config
            );

            return response == null ? null : response.Candidates[0].Content.Parts[0].Text;
        }

        /// <summary>
        /// El método <c>generarTitulo</c> es un método de asistencia de comunicación con la API de Gemini.
        /// Posterior a la generación de un mensaje, en una conversación nueva, se crea un título corto que
        /// describa lo más relevante de la primera consulta hecha a la API.
        /// </summary>
        /// <param name="contenido">string correspondiente a la consulta enviada por el usuario a la API, utilizada para generar un título relevante.</param>
        /// <returns>string correspondiente al título basado en la pregunta del usuario.</returns>
        public static async Task<string?> generarTitulo(string contenido)
        {
            var client = new Client(null, API_KEY, null, null, null, null);

            GenerateContentConfig config = new()
            {
                MaxOutputTokens = 1024,
                Temperature = 0.3,
                TopP = 0.9,
                TopK = 40,
            };

            var response = await client.Models.GenerateContentAsync(
                model: "gemini-3.8-flash",
                contents: "Based on this first user message, create a very brief " +
                          "conversation title (2-5 words) that captures the main subject. Title only, " +
                          "no other text. Ensure the titles are written in spanish.\n\n" +
                          $"User: {contenido}\n\nTitle:",
                config: config
            );

            return response == null ? null : response.Candidates[0].Content.Parts[0].Text;
        }
    }
}
