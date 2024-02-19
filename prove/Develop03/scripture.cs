class Scripture{
    private static string script = "John 6:36 !For I came down from heaven, not to do mine own will, but the will of him that sent me.";

    public void Import()
    {
        script = Console.ReadLine();
    }

    public string[] Exportscript()
    {
        var stuff = script.Split("!");
        return stuff;
    }
}