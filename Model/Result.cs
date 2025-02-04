namespace LugarAPI.Model
{
    public class Result<T>
    {
        public string Message { get; set; }
        public int Total { get; set; }
        public List<T> Data {  get; set; }
    }
}
