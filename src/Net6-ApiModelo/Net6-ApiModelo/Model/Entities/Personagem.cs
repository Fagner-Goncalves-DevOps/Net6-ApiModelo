namespace Net6_ApiModelo.Model.Entities
{
    // Principal (parent)
    public class Personagem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;


        //relations serve somente para gerar relação no Mapping para "principal", nao entra no processo databela. 
        public Classes? Classes { get; set; }
    }
}


//Algumas regras para nosso dominio, para ficar mais claro o entendimento

//um personagem so pode ter uma classe.
//ex: fagner - warrior

//essa classe so pode ter um tipo de arma
//ex: warrior - swords
//ex: hunter  - hunterBow

//essa classe pode ter mais de um tipo de Habilidade
//então um personagem pode ter mais que um habilidade tambem, ele tem uma lista de habilidade de acordo com sua classe

//ex: warrior -  skills passiva e ativas - nomes delas(skillDeGuerra, SkillEmChamadas, SkillArmaduraDeOuro )
//ex: Personagem>fagner, Classe>warrior , habilidade>passiva("varias")-ativa("varias")

//ponto de atenção
//personagem fala com a classe e a classe fala com as armasporclasses e com as habilidades
