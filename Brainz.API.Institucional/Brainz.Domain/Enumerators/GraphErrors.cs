using Brainz.API.Framework.Enumerators;

namespace Brainz.Domain.Enumerators
{
    public class GraphErrors : Enumeration
    {
        public GraphErrors(int id, string code, string name) : base(id, code, name) { }

        public static GraphErrors RetrieveUserInfo = new GraphErrors(1, "GR001", "Erro ao obter usuario no Microsoft Graph.");
        public static GraphErrors UserNotFound = new GraphErrors(2, "GR002", "Usuário Microsoft não encontrado.");
    }
}
