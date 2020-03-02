namespace Escalada.Models
{
    public class Inscription
    {
        public int Id { get; set; }
        public int QtdAdulto { get; set; }
        public int QtdInfantil { get; set; }
        public decimal ValorTotal { get; set; } // O valor deve ser positivo.
        public decimal ValorRecebido { get; set; } // O valor deve ser positivo.
        public Customer ClienteId;
        public Event Evento;
        public PaymentType TipoPagamento { get; set; }
    }
}