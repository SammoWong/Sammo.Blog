namespace Sammo.Blog.Web.Common.Results
{
    public class JsonData
    {
        public JsonData(bool state, string msg = "", object data = null)
        {
            State = state;
            Msg = msg;
            Data = data ?? string.Empty;
        }
        public bool State { get; set; }

        public string Msg { get; set; }

        public object Data { get; set; }
    }
}