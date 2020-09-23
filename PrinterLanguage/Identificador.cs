using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterLanguage
{
    public class Identificador : IEquatable<string>
    {
        private string _strToken;

        public Identificador()
        {

        }

        public Identificador(string strNombre)
        {
            Nombre = strNombre;
        }

        public Identificador(string strToken, string strNombre, string strTipo, string strContenido)
        {
            Token = strToken;
            Nombre = strNombre;
            Tipo = strTipo;
            Contenido = strContenido;
        }

        public string Token
        {
            get { return _strToken; }
            set { _strToken = value; }
        }

        private string _strNombre;

        public string Nombre
        {
            get { return _strNombre; }
            set { _strNombre = value; }
        }

        private string _strTipo;

        public string Tipo
        {
            get { return _strTipo; }
            set { _strTipo = value; }
        }

        private string _strContenido;

        public string Contenido
        {
            get { return _strContenido; }
            set { _strContenido = value; }
        }

        public override string ToString()
        {
            return Nombre;
        }

        public bool Equals(string other)
        {
            return Nombre.Equals(other);
        }
    }
}
