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
    }
}
