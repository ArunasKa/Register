namespace RegisterApi.Domain.Dtos
{
    public class SingupDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public PersonDto PersonDto { get; set; }
    }
}
