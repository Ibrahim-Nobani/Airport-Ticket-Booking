using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

public class CsvParser
{
    private char _delimiter;

    public CsvParser(char delimiter = ',')
    {
        _delimiter = delimiter;
    }
    public List<List<string>> ParseCsv(string csvText)
    {
        List<List<string>> rows = new List<List<string>>();

        var lines = File.ReadLines(csvText).Skip(1);

        foreach (var line in lines)
        {
            List<string> fields = line.Split(_delimiter).ToList();
            rows.Add(fields);
            System.Console.WriteLine($"{string.Join(", ", fields)}");
        }

        return rows;
    }
}
