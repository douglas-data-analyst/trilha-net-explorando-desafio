namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            //R:    Comparar a capacidade da suíte com a quantidade de hóspedes e cadastrar os hóspedes caso caiba.
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                //R:    Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido.
                throw new Exception($"A capacidade da suíte ({Suite.Capacidade}) é menor que o número de hóspedes ({hospedes.Count}).");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            //R:    Utiliza o operador null-conditional (?.) para verificar se Hospedes não é nulo antes de acessar Count, 
            //      e o operador de coalescência nula (??) para retornar 0 caso Hospedes seja nulo, prevenindo 
            //      NullReferenceException.
            return Hospedes?.Count?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            //R:    Multiplica os dias reservados pelo valor da diária da suíte para calcular o valor total.
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            //R:    Aplica um desconto de 10% se os dias reservados forem 10 ou mais.
            if (DiasReservados >= 10)
            {
                //R:    Multiplicar por 0.9 significa manter 90% do valor original (que é o mesmo que dar 10% de desconto)
                //      então o valor é reduzido em 10% e deixa o codigo mais conciso.    
                valor *= 0.9m;
            }
            return valor;
        }
    }
}