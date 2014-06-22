namespace JustEat.Implementation.Managers
{
    public class BaseDataManager
    {
        protected readonly WebClient WebClient;

        public BaseDataManager(WebClient webClient)
        {
            this.WebClient = webClient;
        }
    }
}
