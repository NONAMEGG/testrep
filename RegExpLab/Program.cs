using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace RegExpLab
{
    class Program
    {
        static void Main(string[] args)
        {
            /*            string str = " фыидо, fjbld33- 2олт?";
                        Console.WriteLine(str);

                        Console.WriteLine("a)");
                        Regex re = new Regex(@".");
                        MatchCollection mc = re.Matches(str);
                        foreach (var m in mc)
                            Console.WriteLine(m);

                        Console.WriteLine("b)");
                        re = new Regex(@"\w+");
                        mc = re.Matches(str);
                        foreach (Match m in mc)
                            Console.WriteLine(m);

                        Console.WriteLine("c)");
                        re = new Regex(@"\b[0-9]+\w+\b");
                        mc = re.Matches(str);
                        foreach (Match m in mc)
                            Console.WriteLine(m);

                        Console.WriteLine("d)");
                        re = new Regex(@"\b\w*\d\w*\b");
                        mc = re.Matches(str);
                        foreach (Match m in mc)
                            Console.WriteLine(m);

                        Console.WriteLine("e)");
                        re = new Regex(@"\w+3\b");
                        mc = re.Matches(str);
                        foreach (Match m in mc)
                            Console.WriteLine(m);

                        Console.WriteLine("f)");
                        re = new Regex(@"(\w)\1");
                        mc = re.Matches(str);
                        foreach (Match m in mc)
                            Console.WriteLine(m);

                        Console.WriteLine("g)");
                        re = new Regex(@"\b(\w)\1\w*\b");
                        mc = re.Matches(str);
                        foreach (Match m in mc)
                            Console.WriteLine(m);

                        Console.WriteLine("h)");
                        string input = "Test replacement text";
                        re = new Regex(@"(\W*)(\w+)(\W+)(\w+)(\W+)(\w+)(\W*)");
                        Console.WriteLine(re.Replace(input, "$1$4$3$2$5$6$7"));

                        Console.WriteLine("i)");
                        re = new Regex(@"\b[a-zA-Z0-9]+\b");
                        mc = re.Matches(str);
                        foreach (Match m in mc)
                            Console.WriteLine(m);

                        Console.WriteLine("j)");
                        re = new Regex(@"\b\w*[a-zA-Z]\w*\b");
                        mc = re.Matches(str);
                        foreach (Match m in mc)
                            Console.WriteLine(m);

                        Console.WriteLine("k)");
                        string orig = "";
                        try
                        {
                            using (StreamReader sr = new StreamReader("CreateDB.sql"))
                            {
                                orig = sr.ReadToEnd();
                                Console.WriteLine(orig.Length);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка чтения файла: \"CreateDB.sql\"\n{ex}");
                        }


                        Console.WriteLine("1)");
                        re = new Regex(@"\([^0-9, ]*\)");
                        mc = re.Matches(orig);
                        int count = 0;
                        foreach (Match m in mc)
                        {
                            count++;
                        }
                            Console.WriteLine(count);*/

            string inputSql = "";
            try
            {
                using (StreamReader sr = new StreamReader("CreateDB.sql"))
                {
                    inputSql = sr.ReadToEnd();
                    Console.WriteLine(inputSql.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения файла: \"CreateDB.sql\"\n{ex}");
            }


            // Условие 1: Удаление строк типа GO для MySQL
            inputSql = Regex.Replace(inputSql, @"\bGO\b.*\n?", "");
            // USE <LockeyDB>
            inputSql = Regex.Replace(inputSql, @"\bUSE\b.*\n?", "");
            // Условие 2: Удаление строк типа SET ... для MySQL
            inputSql = Regex.Replace(inputSql, @"\bSET\b.*\n?", "");

            // Преобразовать [].[<имя>] в <имя>
            inputSql = Regex.Replace(inputSql, @"\[\w+\]\.\[(\w+)\]", "$1", RegexOptions.IgnoreCase | RegexOptions.Multiline);

            // Преобразовать [<имя>] в <имя>
            inputSql = Regex.Replace(inputSql, @"\[(\w+)\]", "$1");

            // Преобразовать IDENTITY(1,1) в AUTO INCREMENT
            inputSql = Regex.Replace(inputSql, @"\bIDENTITY\(1,1\)", "AUTO_INCREMENT", RegexOptions.IgnoreCase);

            // Преобразовать тип данных timestamp в timestamp NOT NULL DEFAULT CURRENT TIMESTAMP ON UPDATE CURRENT TIMESTAMP
            inputSql = Regex.Replace(inputSql, @"\btimestamp not null\b", "timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP", RegexOptions.IgnoreCase | RegexOptions.Multiline);

            // Преобразовать PRIMARY KEY CLUSTERED
            inputSql = Regex.Replace(inputSql, @"CONSTRAINT (\w+) PRIMARY KEY CLUSTERED \r\n\(\r\n\t(.*)\r\n\)WITH \(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON\)", "PRIMARY KEY ($2)", RegexOptions.IgnoreCase);
            inputSql = Regex.Replace(inputSql, @" ASC", "", RegexOptions.IgnoreCase);

            // Преобразовать PRIMARY KEY NONCLUSTERED
            inputSql = Regex.Replace(inputSql, @"PRIMARY KEY NONCLUSTERED \r\n\(\r\n\t(.*)\r\n\)WITH \(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON\);", "PRIMARY KEY ($1)", RegexOptions.IgnoreCase);

            // Преобразовать UNIQUE NONCLUSTERED
            inputSql = Regex.Replace(inputSql, @"UNIQUE NONCLUSTERED \r\n\(\r\n\t(.*)\r\n\)WITH \(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON\);", "UNIQUE KEY ($1)", RegexOptions.IgnoreCase);

            // Убрать оставшиеся конструкции ON PRIMARY
            inputSql = Regex.Replace(inputSql, @"ON PRIMARY", ";", RegexOptions.IgnoreCase);
            //inputSql = Regex.Replace(inputSql, @"\(\w+\);\);", "($1));", RegexOptions.IgnoreCase);
            //inputSql = Regex.Replace(inputSql, @"UNIQUE KEY \(.*\);", "UNIQUE KEY ($1)", RegexOptions.IgnoreCase);

            // Преобразовать типы данных
            inputSql = Regex.Replace(inputSql, @"\buniqueidentifier\b", "char(32)", RegexOptions.IgnoreCase);
            inputSql = Regex.Replace(inputSql, @"\bxml\b|\bntext\b|\bnvarchar\(max\)\b", "text", RegexOptions.IgnoreCase);
            inputSql = Regex.Replace(inputSql, @"\bimage\b|\bvarbinary\(max\)\b", "BLOB", RegexOptions.IgnoreCase);

            // Удалить лишние пробелы и точки с запятой
            inputSql = Regex.Replace(inputSql, @"\s*;\s*", ";").Trim();
            inputSql = Regex.Replace(inputSql, @";{2,}", ";").Trim();
            string path = "Mysql.sql";
            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(inputSql);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            


        }
    }
}