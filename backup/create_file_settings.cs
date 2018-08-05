using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Backup
{
    public struct Entry
    {
        public string pathBackup;
        public string[] pathOrigal;
    }

    public class Journal
    {
        public string path;
        public List<string> error = new List<string> { "Ошибки:" };
        public List<string> info = new List<string> { "Информация:" };
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Программа запущена {0}.\n", DateTime.Now);

            //Файлы журнала находятся в папке проекта "project_backup".
            Journal log = new Journal();
            log.path = @"..\..\..\" + DateTime.Now.ToString("dd.MM.yyyy hh-mm-ss");

            //Файл настроек находится в папке проекта "project_backup".
            string pathSetting = @"..\..\..\settings";
            //CreateFileSettings(pathSetting, log);

            //0 строка - путь к каталогу для бэкапа,
            //1 строка - путь к исходным каталогам.
            string[][] settingsFile = ReadSettings(pathSetting, log);

            if (!Array.Exists(settingsFile, element => element == null) && settingsFile[0].Length != 0 && settingsFile[1].Length != 0)
            {
                for (int i = 0; i < settingsFile[1].Length; i++) DirectoryCopy(settingsFile[1][i], settingsFile[0][0], log);
            }
            else
            {
                Console.WriteLine("Ошибка: файл настроек имеет недостаточно параметров.");
                log.error.Add("Ошибка файла настроек");
            }
            CreateFileEvent(log);
            Console.WriteLine("\nКопирование завершено. Название файла журнала: {0}", Path.GetFullPath(log.path));
        }

        static void SaveFile(string path, string json, Journal log)
        {
            try
            {
                //Файл настроек перезаписывается (в случае наличия).                
                using (FileStream fs = File.Create(path))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(json);
                    fs.Write(info, 0, info.Length);
                }
                Console.WriteLine("Файл успешно сохранен!");
                log.info.Add("Файл настроек был успешно сохранен.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: {0}", ex.Message);
                log.error.Add("Ошибка при сохранении файла настроек: " + ex.Message);
            }
        }

        static string[][] ReadSettings(string path, Journal log)
        {
            string settings = File.ReadAllText(path);
            string[][] mass = new string[2][];
            try
            {
                JObject json = JObject.Parse(settings);
                mass[0] = new string[] { (string)json["pathBackup"] };
                string[] pathOrigal = json["pathOrigal"].Select(t => (string)t).ToArray();
                mass[1] = pathOrigal;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: {0}", ex.Message);
                log.error.Add("Ошибка чтении файла настроек: " + ex.Message);
            }
            return mass;
        }

        static void DirectoryCopy(string source, string recipient, Journal log)
        {
            DirectoryInfo dir = new DirectoryInfo(source);
            FileInfo[] files = dir.GetFiles();
            DirectoryInfo[] dirs = dir.GetDirectories();

            //При копировании подкаталогов нужно создать папку.
            if (!Directory.Exists(recipient))
            {
                try
                {
                    Directory.CreateDirectory(recipient);
                    log.info.Add("Был создан новый каталог " + recipient);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: {0}", ex.Message);
                    log.error.Add("Ошибка при создании каталога: " + recipient);
                }
            }

            //Копировние файлов.           
            foreach (FileInfo file in files)
            {
                try
                {
                    string pathFile = Path.Combine(recipient, file.Name);
                    file.CopyTo(pathFile, true);
                    log.info.Add("Файл успешно скопирован: " + file.FullName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: {0}", ex.Message);
                    log.error.Add("Ошибка при копировании файла: " + file.FullName);
                }
            }

            //Копирование файлов из подкаталогов.
            foreach (DirectoryInfo subdir in dirs)
            {
                try
                {
                    string pathFile = Path.Combine(recipient, subdir.Name);
                    DirectoryCopy(subdir.FullName, pathFile, log);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: {0}", ex.Message);
                    log.error.Add("Ошибка при запросе доступа к : " + subdir.FullName);
                }
            }
        }

        static void CreateFileSettings(string pathSetting, Journal log)
        {
            Entry obj = new Entry
            {
                pathBackup = @"C:\Users\Alisa\Documents\infotecs\backup",
                pathOrigal = new string[] { @"C:\Users\Alisa\Documents\infotecs\finder-1", @"C:\Users\Alisa\Documents\infotecs\finder-2" }
            };

            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            Console.WriteLine("Файл создан!\n{0}", json);

            SaveFile(pathSetting, json, log);
        }

        static string GetPath()
        {
            Console.WriteLine("Введите путь: ");
            string path = Console.ReadLine();
            while (!Directory.Exists(path))
            {
                Console.WriteLine("Данного пути в системе не обнаружено.");
                GetPath();
            }
            return path;
        }

        static void CreateFileEvent(Journal log)
        {
            string file = DateTime.Now + "\r\n\n" + string.Join(Environment.NewLine, log.error) + "\r\n\n" + string.Join(Environment.NewLine, log.info);
            using (FileStream fs = File.Create(log.path))
            {
                try
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(file);
                    fs.Write(info, 0, info.Length);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: {0}", ex.Message);
                }
            }
        }
    }
}