using System.Diagnostics.CodeAnalysis;

// #nullable disable

namespace Ailos.Nullable
{
    public record CustomerViewModel
    {
        /// <summary>
        /// Propriedade não anulável com inicializxação nula utilizando o operador "!" para evitar erros do compilador
        /// </summary>
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Propriedade não anulável marcada como anulável, mas com o atributo [NotNull] tendo o efeito de uma propriedade não anulável
        /// </summary>
        [NotNull] public string? LastName { get; set; }

        /// <summary>
        /// Propriedade anulável
        /// </summary>
        public string? MiddleName { get; set; }

        /// <summary>
        /// Propriedade que não aceita parametro nulo
        /// </summary>
        [DisallowNull] public Address? Address { get; set; }

        public string FullName => $"{FirstName} {MiddleName} {LastName}";
    }

    public class Address
    {
        public int ZipCode { get; set; }
    }
}
