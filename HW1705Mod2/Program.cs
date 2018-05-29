using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HW1705Mod2
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
        }
# region mod1
        static void Task1()
        {
            string str = "123456";
            FileInfo file = new FileInfo("NewFile.txt");
            using (FileStream fs = file.Open(FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default))
                {
                    sw.Write(str);
                }
                fs.Close();
            }
            string st2 = "";
            foreach (var item in str.Reverse())
            {
                st2 += item;
            }
            FileInfo file2 = new FileInfo("NewFile2.txt");
            using (FileStream fs = file2.Open(FileMode.Create, FileAccess.Write))
            {

                using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default))
                {
                    //Console.WriteLine(st2);
                    sw.Write(st2);
                }
                fs.Close();
            }
        }
        static void Task2()
        {
            string text = "asofe";
            string bookva = "aoieu";
            string mirror = "";
            foreach (var item in text.Reverse())
            {
                if (bookva.Contains(item))
                {
                    Console.Write(item);
                    mirror += item;
                }
            }
            FileInfo file = new FileInfo("Task2File.txt");
            using (FileStream fs = file.Open(FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default))
                {
                    sw.Write(mirror);
                }
                fs.Close();
            }
        }
        #endregion
        #region mod2
        void QueueZadanie8()
        {
            /*8.	Дан файл, содержащий информацию о сотрудниках фирмы: фамилия, имя, отчество, пол, возраст, размер зарплаты. 
             * За один просмотр файла напечатать элементы файла в следующем порядке: сначала все данные о сотрудниках младше 30 лет,
             * потом данные об остальных сотрудниках, сохраняя исходный порядок в каждой группе сотрудников.*/

            Queue<Sotrudnik> queue = new Queue<Sotrudnik>();
            // одним циклом никак
            for (int i = 0; i < 20; i++)
            {
                queue.Enqueue(new Sotrudnik("XJ" + rand.Next(1, 100), true, rand.Next(18, 120), rand.Next(100, 1000000)));
            }
            Console.WriteLine("\n------------------------------------------Младше 30 лет\n");
            foreach (Sotrudnik item in queue)
            {
                if (item.age < 30)
                    Console.WriteLine("Full name: " + item.fullName + " | Male: " + item.pol + " | Age: " + item.age + " | Salary size: " + item.salarySize);
            }
            Console.WriteLine("\n------------------------------------------Старше 30 лет\n");
            foreach (Sotrudnik item in queue)
            {
                if (item.age >= 30)
                    Console.WriteLine("Full name: " + item.fullName + " | Male: " + item.pol + " | Age: " + item.age + " | Salary size: " + item.salarySize);
            }

            //foreach (Sotrudnik item in queue.OrderBy(o => o.age < 30))
            //{
            //    if (item.age < 30)
            //        Console.WriteLine("Full name: " + item.fullName + " | Male: " + item.pol + " | Age: " + item.age + " | Salary size: " + item.salarySize);
            //}

        }
        void QueueZadanie9()
        {
            /*9.	Дан файл, содержащий информацию о студентах: фамилия, имя, отчество, номер группы, 
             * оценки по трем предметам текущей сессии. За один просмотр файла напечатать элементы файла в 
             * следующем порядке: сначала все данные о студентах, успешно сдавших сессию, потом данные об остальных
             * студентах, сохраняя исходный порядок в каждой группе сотрудников.*/

            Queue<Student> queue = new Queue<Student>();
            // одним циклом никак
            int[] scores;
            for (int i = 0; i < 200; i++)
            {
                scores = new int[3] { rand.Next(1, 5), rand.Next(1, 5), rand.Next(1, 5) };
                queue.Enqueue(new Student("XJ" + rand.Next(1, 100), rand.Next(18, 120), scores));
            }

            Console.WriteLine("Успешно сдавшие сессию\n");
            foreach (Student item in queue)
            {
                double avg = item.scores.Average(o => (int)(o));
                if (avg >= 4)
                {
                    Console.WriteLine("Full name: " + item.fullName + " | Number of gourp: " + item.numberOfGroup);
                    //Console.WriteLine(avg);
                }
            }

            Console.WriteLine("\nНеуспешно сдавшие сессию\n");
            foreach (Student item in queue)
            {
                double avg = item.scores.Average(o => (int)(o));
                if (avg < 4)
                {
                    Console.WriteLine("Full name: " + item.fullName + " | Number of gourp: " + item.numberOfGroup);
                    // Console.WriteLine(avg);
                }
            }


        }
        void QueueZadanie10()
        {
            Queue<Student> queue = new Queue<Student>();
            // одним циклом никак
            int[] scores;
            for (int i = 0; i < 200; i++)
            {
                scores = new int[3] { rand.Next(1, 5), rand.Next(1, 5), rand.Next(1, 5) };
                queue.Enqueue(new Student("XJ" + rand.Next(1, 100), rand.Next(18, 120), scores));
            }
            Console.WriteLine("Успешно обучающиеся на 4 и 5\n");
            foreach (Student item in queue)
            {
                double avg = item.scores.Average(o => (int)(o));
                if (avg >= 4)
                {
                    Console.WriteLine("Full name: " + item.fullName + " | Number of gourp: " + item.numberOfGroup);
                    //Console.WriteLine(avg);
                }
            }
            Console.WriteLine("\nУспешно обучающиеся на 3 и ниже\n");
            foreach (Student item in queue)
            {
                double avg = item.scores.Average(o => (int)(o));
                if (avg < 4)
                {
                    Console.WriteLine("Full name: " + item.fullName + " | Number of gourp: " + item.numberOfGroup);
                    // Console.WriteLine(avg);
                }
            }
        }
        #endregion
    }


}