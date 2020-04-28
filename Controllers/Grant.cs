using System;
using System.Collections;
public class Grant : IComparable<Grant>
{
    // Getters and setters go here.
    public string Title { get; set; }
    public string Link { get; set; }
    public string PubDate { get; set; }
    public string Content { get; set; }
    public string RawText { get; set; }
    public int Score { get; set; }


    // Our constructor goes here.
    public Grant(string title, string link, string pubDate, string content, string rawText)
    {
        Title = title;
        Link = link;
        PubDate = pubDate;
        Content = content;
        RawText = rawText;
        //int Score = 0;
        //Description = description;
        //EligibilityInfo = eligibilityInfo;
    }
    

    // Our functions go here.
    public int CompareTo(Grant other)
    {
        if (this.Score > other.Score)
        {
            return -1;
        }
        else if (this.Score < other.Score)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}



//string description, string eligibilityInfo