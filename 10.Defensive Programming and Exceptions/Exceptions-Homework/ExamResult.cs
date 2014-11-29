using System;

public class ExamResult
{
    public int Grade { get; private set; }
    public int MinGrade { get; private set; }
    public int MaxGrade { get; private set; }
    public string Comments { get; private set; }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentException("Grade must be positive integer number!", "grade");
        }
        if (minGrade < 0)
        {
            throw new ArgumentException("Minimal grade must be positive integer number!", "minGrade");
        }
        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("Maxmal grade must be greather than minimal grade!", "maxGrade");
        }
        if (comments == null)
        {
            throw new ArgumentNullException("comments", "Comments must be initialized!");
        }
        if (comments == "")
        {
            throw new ArgumentException("Comments can't be empty string!", "comments");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
