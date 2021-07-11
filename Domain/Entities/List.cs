namespace Domain.Entities
{
    public class List
    {
        public int idlist { get; set; }
        public string text { get; set; }
        public bool done { get; set; }

        public void AlterItem(string text, bool done)
        {
            this.text = text;
            this.done = done;
        }
    }
}
