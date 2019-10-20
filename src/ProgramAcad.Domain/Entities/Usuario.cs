using Microsoft.AspNetCore.Identity;
using ProgramAcad.Common.Models;
using System;

namespace ProgramAcad.Domain.Entities
{
    public class Usuario : IdentityUser<Guid>, IEntity
    {
        public Usuario(string nomeCompleto, string nickname, string cpf, string cep, string sexo, int pontos)
        {
            NomeCompleto = nomeCompleto;
            Nickname = nickname;
            Cpf = cpf;
            Cep = cep;
            Sexo = sexo;
            Pontos = pontos;
        }

        public string NomeCompleto { get; protected set; }
        public string Nickname { get; protected set; }
        public string Cpf { get; protected set; }
        public string Cep { get; protected set; }
        public string Sexo { get; protected set; }
        public int Pontos { get; protected set; }
        public DateTime DataCriacao { get; protected set; }
        public bool Status { get; protected set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Usuario compareTo))
                return false;

            if (Id.Equals(compareTo.Id) && Cpf.Equals(compareTo.Cpf))
            {
                return true;
            }

            return false;
        }

        public static bool operator ==(Usuario a, Usuario b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Usuario a, Usuario b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " {EntityId=" + Id + "}";
        }

        public virtual void Deactivate()
        {
            Status = false;
        }
    }
}
