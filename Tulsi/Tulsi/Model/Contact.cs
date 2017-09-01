namespace Tulsi.Model {
    public class Contact {
        public double ContactProgress { get; set; }

        public string Name { get; set; }
      
        public string Company { get; set; }
      
        public int Number { get; set; }
      
        public bool IsOverDue { get; set; }
      
        public int OverdueDays { get; set; }
    }
}
