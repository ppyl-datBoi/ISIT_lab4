using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication20
{
    class solution
    {
        public int[] yavno(int[,] arr) //явный победитель
        {
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);
            int[] solv = new int[n];

            for (int k = 0; k < m; k++)
            {
                for (int i = 0; i < n; i++) //главный элемент
                {
                    for (int j = 0; j < n; j++) //элемент с которым сравниваем
                    {
                        if (i != j) //не сравнимаем с самим собой
                        {
                            if (arr[i, k] < arr[j, k]) //если главный элемент значимее элемента для сравнения, то
                            {
                                solv[i] = solv[i] + 1; //в таблицу результатов добавляем +1
                            }
                        }
                    }
                }

            }
            return solv;
        }

        public int[] kopland(int[,] arr) //копланд
        {
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);
            int[] solv = new int[n];

            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < m; i++) //главный элемент
                {
                    for (int j = 0; j < m; j++) //элемент с которым сравниваем
                    {
                        if (i != j) //не сравнимаем с самим собой
                        {
                            if (arr[k, i] < arr[k, j]) //если главный элемент значимее элемента для сравнения, то
                            {
                                solv[i] = solv[i] + 1; //в таблицу результатов добавляем +1
                            }
                            else
                            {
                                solv[i] = solv[i] - 1;
                            }
                        }
                    }
                }

            }
            return solv;
        }

        public int[] simpson(int[,] arr)
        {
            int n = arr.GetLength(0); // строки
            int m = arr.GetLength(1); // столбцы
            int[] solv = new int[n];
            int[,] dop = new int[n, m];
            for (int i = 0; i < n; i++) //главный элемент
            {
                for (int j = 0; j < n; j++) //элемент с которым сравниваем
                {
                    if (i != j) //не сравнимаем с самим собой
                    {
                        for (int k = 0; k < m; k++)
                        {
                            if (arr[i, k] < arr[j, k]) //если главный элемент значимее элемента для сравнения, то
                            {
                                dop[i, j] = dop[i, j] + 1;
                            }
                        }
                    }
                }
            }
            int[] max = new int[n];
            int maxv = 0;
            //выбрать минимальное по строкам, побеждает с максимальным из мах
            for (int i = 0; i < dop.GetLength(0); i++)
            {
                maxv = dop[1, 2];
                for (int j = 0; j < dop.GetLength(1); j++)
                {
                    if (dop[i, j] < maxv && dop[i, j] != 0)
                        maxv = dop[i, j];
                }
                max[i] = maxv;
            }
            return max;
        }

        public int[] board(string[,] mass,int rows,int cols)
        {

            string[] temp = new string[rows];

            for (int i = 0; i < rows - 1; i++)
            {
                temp[i] = "";
                for (int j = 0; j < cols; j++)
                {
                    temp[i] += mass[i,j];
                }
            }

            List<string> tt = new List<string>();//сами варианты 12345, 12354 и т.д.
            tt.Add(temp[0]);
            List<int> tt2 = new List<int>();//их кол-во
            tt2.Add(1);
            bool a;
            for (int i = 1; i < rows - 1; i++)//группируем голоса
            {
                a = false;
                for (int j = 0; j < tt.Count; j++)
                {
                    if (tt[j] == temp[i])
                    {
                        a = true;
                        tt2[j]++;
                    }

                }
                if (!a)
                {
                    tt.Add(temp[i]);
                    tt2.Add(1);
                }
            }
            int candidatcount = cols;
            int[] candidat = new int[candidatcount];//candidat[x] += tt2[i] * ball in tt[i]
            for (int i = 0; i < tt.Count; i++)//из всех групп 12345 берем каждую группу отдельно и считаем баллы
                for (int j = 0; j < tt[i].Length; j++)//выбирае каждого кандидата из группы 1>2>3>4>5
                {
                    string pos = Convert.ToString(tt[i][j]);
                    if (j < tt[i].Length - 1)//если позиция кандидата не последняя
                        candidat[Convert.ToInt32(pos) - 1] += tt2[i] * (candidatcount - j);
                }

            return candidat;
        }

        public void maximum(int[] array, out int value, out int index)
        {
            value = index = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > value)
                {
                    value = array[i];
                    index = i + 1;
                }
            }
        }
    }
}
