public class Grant
{
    public Grant(string title, string link, string pubDate, string content)
    {
        Title = title;
        Link = link;
        PubDate = pubDate;
        Content = content;
        int Score = 0;
        //Description = description;
        //EligibilityInfo = eligibilityInfo;
    }

    public string Title { get; set; }
    public string Link { get; set; }
    public string PubDate { get; set; }
    public string Content { get; set; }
    public int Score { get; set; }
}

//string description, string eligibilityInfo