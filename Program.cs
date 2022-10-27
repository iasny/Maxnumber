using System;
using System.Collections.Generic;
namespace Maxnumber
{
    class Program
    {
        static void Main()
        {
            string s = Console.ReadLine();
            //Список для результата, может быть несколько строк равной длинны 
            List<string> res = new List<string>();
            //Переменная для хранения временной строки, которую будем заполнять
            string temp_res = "";
            for (int i = 0; i < s.Length; i++)
            {
                //Ищем, есть ли новый символ, если нет, пишем дальше нашу длинную строку
                if (!temp_res.Contains(s[i]))
                {
                    temp_res += s[i];
                }
                //Символ нашёлся, мы дошли до конца заполнения строки без повторов
                else
                {
                    //Проверяем, есть ли что-то уже в итоговом списке
                    if (res.Count != 0)
                    {
                        //Если больше либо равно, обработать, иначе пропустить
                        //Новая строка больше - чистим список итогов, вносим только строку
                        if (res[0].Length < temp_res.Length)
                        {
                            res.Clear();
                            res.Add(temp_res);
                        }
                        //Новая строка равна тому, что уже есть - добавляем её в список
                        else if (res[0].Length == temp_res.Length)
                        {
                            res.Add(temp_res);
                        }
                        //Обновляем темповую строку, начинаем с того символа, на котором закончилась старая
                        //Так как char и string разные, надо в явном виде конвертировать
                        temp_res = s[i].ToString();
                    }
                    //Результатов ещё нет, так что просто заносим и обнуляем темповую сроку
                    else
                    {
                        res.Add(temp_res);
                        temp_res = s[i].ToString();
                    }
                }
            }
            //Финальный запуск для последней полученной строки, в цикле она доформировалась и цикл закончился, поэтому её надо обработать отдельно
            //Темповую строку можно уже не обнулять, она свою работу сделала
            if (res.Count != 0)
            {
                if (res[0].Length < temp_res.Length)
                {
                    res.Clear();
                    res.Add(temp_res);
                }
                else if (res[0].Length == temp_res.Length)
                {
                    res.Add(temp_res);
                }
            }
            //Результатов ещё нет, так что просто заносим и обнуляем темповую сроку
            else
            {
                res.Add(temp_res);
            }
            Console.WriteLine("Самые длинные сочетания без повтора в строке " + s + ":");
            foreach (string rs in res)
            {
                Console.WriteLine(rs);
            }
        }
    }
}
