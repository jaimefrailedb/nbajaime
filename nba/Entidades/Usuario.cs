using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nba.Entidades
{
    public class Usuario
    {
        int idUsuario;
        string nombre;
        string alias;
        string login;
        string password;
        string movil;
        string mail;
        int acceso;

        public Usuario()
        {
            this.idUsuario = -1;
            this.nombre = string.Empty;
            this.alias = string.Empty;
            this.login = string.Empty;
            this.password = string.Empty;
            this.movil = string.Empty;
            this.mail = string.Empty;
            this.acceso = -1;
        }

        public Usuario(int idUsuario, string nombre, string alias, string login, string password, string movil, string mail, int acceso)
        {
            this.IdUsuario = idUsuario;
            this.Nombre = nombre;
            this.Alias = alias;
            this.Login = login;
            this.Password = password;
            this.Movil = movil;
            this.Mail = mail;
            this.Acceso = acceso;
        }

        public int IdUsuario
        {
            get
            {
                return idUsuario;
            }

            set
            {
                idUsuario = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Alias
        {
            get
            {
                return alias;
            }

            set
            {
                alias = value;
            }
        }

        public string Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Movil
        {
            get
            {
                return movil;
            }

            set
            {
                movil = value;
            }
        }

        public string Mail
        {
            get
            {
                return mail;
            }

            set
            {
                mail = value;
            }
        }

        public int Acceso
        {
            get
            {
                return acceso;
            }

            set
            {
                acceso = value;
            }
        }

        
    }
}
