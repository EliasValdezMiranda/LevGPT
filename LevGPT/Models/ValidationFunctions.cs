namespace LevGPT.Models
{
    static internal class ValidationFunctions
    {

        /// <summary>
        /// El método <c>verificarString</c> verifica que una cadena no esté vacía.
        /// </summary>
        /// <param name="valor">variable string a validar</param>
        /// <returns><c>true</c> si valor no es nulo o un string vacío, 
        /// <c>false</c> si valor es nulo o un string vacio</returns>
        static public bool verificarString(string? valor, int? longitud = null)
        {
            return longitud != null ?
                   (valor != null) && (valor != string.Empty) && (valor.Length < longitud)
                   : (valor != null) && (valor != string.Empty);
        }

        /// <summary>
        /// El método <c>validarTextBox</c> checa que la entrada del TextBox sea válida.
        /// </summary>
        /// <param name="textBox">Objeto TextBox cuya propiedad "Text" será validada</param>
        /// <param name="longitud">int longitud correspondiente a la longitud máxima de la entrada del TextBox</param>
        /// <returns><c>true</c> si el texto introducido no es nulo y es menor a la longitud especificada,
        /// <c>false</c> si no cumple una de las condiciones anteriores.</returns>
        static public bool validarTextBox(TextBox textBox, int longitud)
        {
            return verificarString(textBox.Text, longitud);
        }
    }
}
