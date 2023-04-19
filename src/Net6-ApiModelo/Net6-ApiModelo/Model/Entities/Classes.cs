namespace Net6_ApiModelo.Model.Entities
{
    // Dependent (child)
    public class Classes
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Descricao { get; set; }

        //FK Tabela personagem
        public int IdPersoagem { get; set; }

        //relations serve somente para gerar relação no Mapping para "principal", nao entra no processo databela. 
        public Personagem? Personagem { get; set; } 

    }
}
