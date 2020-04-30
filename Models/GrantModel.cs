using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
public class GrantModel : IComparable<GrantModel>
{
    // Getters and setters go here.
    public string Title { get; set; }
    public string Link { get; set; }
    public string PubDate { get; set; }
    public string Content { get; set; }
    public string RawText { get; set; }
    public string GrantAmount { get; set; }
    public string GrantDueDate { get; set; }
    public int Score { get; set; }


    // Our constructor goes here.
    public GrantModel(string title, string link, string pubDate, string content, string rawText, string grantAmount, string grantDueDate)
    {
        Title = title;
        Link = link;
        PubDate = pubDate;
        Content = content;
        RawText = rawText;
        GrantAmount = grantAmount;
        GrantDueDate = grantDueDate;
    }
    

    // CompareTo() is a function that is automatically called by the Sort() method
    // because of the IComparable<Grant> extension given.
    public int CompareTo(GrantModel other)
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