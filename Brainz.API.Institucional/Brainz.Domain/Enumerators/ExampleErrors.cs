using Brainz.API.Framework.Enumerators;

namespace Brainz.Domain.Enumerators
{
    public class ExampleErrors : Enumeration
    {
        public ExampleErrors(int id, string code, string name) : base(id, code, name) { }

        public static ExampleErrors NotFoundName = new ExampleErrors(1, "EX001", "O nome não pode ser nulo.");

        public static ExampleErrors NotFoundBirthDate = new ExampleErrors(2, "EX002", "A data de nascimento nome não pode ser nula.");

        public static ExampleErrors InvalidPayload = new ExampleErrors(3, "EX003", "Verifique os campos informados.");

        public static ExampleErrors InvalidRequest = new ExampleErrors(4, "EX004", "Não foi possível completar a requisição.");

        public static ExampleErrors NotFoundEntity = new ExampleErrors(5, "EX005", "Registro não encontrado.");

        public static ExampleErrors PageMaximumExceeded = new ExampleErrors(6, "EX006", "Página solicitada é maior que o total de páginas geradas.");
        
    }
}