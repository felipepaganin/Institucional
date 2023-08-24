namespace Brainz.Domain.ViewModels
{
    public class EventsViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Card1 Card1 { get; set; }

        public Card2 Card2 { get; set; }

        public Card3 Card3 { get; set; }
    }

    public class Card1
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
    }

    public class Card2
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string Image5 { get; set; }
        public string Image6 { get; set; }
        public string Image7 { get; set; }
    }

    public class Card3
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
    }
}
