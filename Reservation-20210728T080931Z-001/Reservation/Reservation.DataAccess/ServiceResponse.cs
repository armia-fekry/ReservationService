namespace Reservation.DataAccess
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool succeed { get; set; } = true;
        public string message { get; set; } = "Succeed";
    }
}
