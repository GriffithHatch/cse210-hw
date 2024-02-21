class Writingassignment : Assignment{
    private string title;

    public Writingassignment(string studentName, string topic, string title) : base(studentName,topic) {
        this.title = title;
    }

    public string GetWritingInformation(){
        return $"{title}";
    }
}