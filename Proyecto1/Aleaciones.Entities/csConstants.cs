using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aleaciones.Entities
{
    public class csConstants
    {
        // System User Messages
        public static string ValidateFields(string namField) { return "El campo " + namField + " es obligatorio."; }
        public static string SuccessMessage = "El registro se ha guardado con éxito.";
        public static string SuccessMessageTitle = "Captura Exitosa.";
        public static string ValidateUpdate = "Seleccione el registro a actualizar.";
        public static string ValidateDelete = "Seleccione el registro a eliminar.";
        public static string ErrorMessageTitle = "Error en Captura.";
        public static string ConfirmMessageTitle = "Confirmación";
        public static string DeleteMessage = "¿Está seguro que desea eliminar el registro seleccionado ?";
        public static string DelSuccessMessage = "El registro se ha eliminado con éxito";
        public static string DelSuccessTitle = "Registro borrado";

        public static string DuplicateMessage(string namField) { return "El valor capturado en el campo " + namField + " ya existe, favor de capturar nuevamente."; }

        // Datatype Validation Messages
        public static string ValidateTitle = "Error en Captura";
        public static string ValidateNumbers = "Este campo permite solo números.";
        public static string ValidateLoginMessage = "Usuario y/o Contraseña incorrecta.";

        //Error messages
        public static string StrngFormat = "El formato de la celda debe de ser númerico.";
        public static string MailValidationError = "El formato del correo no es valido.";
        public static string NoFileMessage = "No se ha seleccionado ningun archivo.";

    }
}
