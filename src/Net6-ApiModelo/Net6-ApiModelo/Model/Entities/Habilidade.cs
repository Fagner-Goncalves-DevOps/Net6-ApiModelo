namespace Net6_ApiModelo.Model.Entities
{
    public class Habilidade
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Descricao { get; set; }
        public string? Tipo { get; set; }


        //FK Tabela Classes sera mapeado dentro map Classes
        public int IdClasses { get; set; }


        //relations serve somente para gerar relação no Mapping.
        public Classes? Classes { get; set; }


    }
}
