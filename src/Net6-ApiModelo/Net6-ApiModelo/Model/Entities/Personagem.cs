namespace Net6_ApiModelo.Model.Entities
{
    // Principal (parent)
    public class Personagem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        //Uma pessoa pode ter uma lista de classes "mais de uma" 1:N
        public IEnumerable<Classes> Classes { get; set; } = new List<Classes>(); //novo modelo para negar os nullables
    }
}


//Autorreferência de um para muitos futuramente
//commitar ajuste 1:N
//mais um branch com visão 1:1 e configurar
//mais uma branch com visão N:N e configurar
//alimentar a api, controller ajuste 
