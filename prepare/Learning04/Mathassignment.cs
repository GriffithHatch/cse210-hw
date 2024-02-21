class Mathassignment : Assignment{
    private string textbookSection;
    private string problems;

    public Mathassignment(string studentName, string topic,string textbookSection, string problems) : base(studentName, topic) {
        this.textbookSection = textbookSection;
        this.problems = problems;
    }

    public string GetHomeworkList(){
        return $"{textbookSection} Problems {problems}";
    }
}