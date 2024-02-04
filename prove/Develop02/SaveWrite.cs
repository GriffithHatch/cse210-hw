class SaveWrite
{
    public static string[] ReadFromFile(){
        Console.Write("Enter filename: ");
        var filename = Console.ReadLine();
        return File.ReadAllLines(filename);
        
    }
    public static void WriteFile(string[] entries){
        Console.WriteLine("Enter Filename: ");

        var filename = Console.ReadLine();
        File.WriteAllLines(filename, entries);

        // var filename = Console.ReadLine();
        // using (StreamWriter exportFile = new StreamWriter(filename))
        // {
        //     foreach(var p in entries)
        //     {
        //         exportFile.WriteLine(p);
        //     }

        // }
        // File.WriteAllLines(filename, entries);


    }

}