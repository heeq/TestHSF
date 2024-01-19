using BeeViral_Pessoas.Util;

namespace BeeViral_Pessoas.Models
{
    public class IndexModel
    {
        public List<Pessoa> pessoas;

        private List<string> _nomes = new List<string>
        {
            "João", "Maria", "José", "Felipe", "Isabela", "Renato", "Jessica", "Ricardo", "Rogério", "Denilson", "Mario", "Luis",
            "Gabriela", "Luiza", "Fernanda"
        };

        private List<string> _sobrenomes = new List<string>
        {
            "Silva", "Almeida", "Pereira", "Alves", "Carvalho", "Mendes", "Costa", "Lopes", "Gonçalves", "Dias", "Nunes", "Ribeiro",
            "Martins", "Gomes", "Braga"
        };

        public IndexModel()
        {
            pessoas = new List<Pessoa>();
            Pessoa individuo;
            Random rnd;

            for (int i = 0; i < 10; i++)
            {
                rnd = new Random();

                individuo = new Pessoa();
                individuo.Nome = _nomes[rnd.Next(0, 15)] + " " + _sobrenomes[rnd.Next(0, 15)];
                individuo.Idade = rnd.Next(1, 100);
                individuo.Email = individuo.Nome.Trim() + "@email.com";

                pessoas.Add(individuo);
            }
        }
    }
}