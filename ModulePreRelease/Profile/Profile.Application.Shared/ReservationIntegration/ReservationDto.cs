namespace Profile.Application.Contract.ReservationIntegration
{
    public class ReservationDto
    {
        public Guid Id { get; set; }
        public Guid ProfileId { get; set; }
        public string ConfirmationNo { get; set; }
        public string RoomNo { get; set; }
        public string Status { get; set; }
    }
}
