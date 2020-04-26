using System;
using System.Collections;
public class Grant: IComparable<Grant>
{
    public Grant(string title, string link, string pubDate, string content)
    {
        Title = title;
        Link = link;
        PubDate = pubDate;
        Content = content;
        //int Score = 0;
        //Description = description;
        //EligibilityInfo = eligibilityInfo;
    }

    public string Title { get; set; }
    public string Link { get; set; }
    public string PubDate { get; set; }
    public string Content { get; set; }
    public int Score { get; set; }
    


    public int CompareTo(Grant other)
    {
        if(this.Score > other.Score)
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