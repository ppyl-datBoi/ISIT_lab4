
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace UnitTests_laba4
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            List<string> tt = new List<string>();//сами варианты 12345, 12354 и т.д.
            List<int> tt2 = new List<int>();//их кол-во
            int candidatcount = 5;

            string row = "13245";
            tt.Add(row);
            tt2.Add(5);

            row = "21354";
            tt.Add(row);
            tt2.Add(3);

            row = "31245";
            tt.Add(row);
            tt2.Add(5);

            row = "23451";
            tt.Add(row);
            tt2.Add(10);

            row = "32415";
            tt.Add(row);
            tt2.Add(4);

            int[] candidat = new int[candidatcount];//candidat[x] += tt2[i] * ball in tt[i]
            for (int i = 0; i < tt.Count; i++)//из всех групп 12345 берем каждую группу отдельно и считаем баллы
                for (int j = 0; j < tt[i].Length; j++)//выбирае каждого кандидата из группы 1>2>3>4>5
                {
                    string pos = Convert.ToString(tt[i][j]);
                    if (j < tt[i].Length - 1)//если позиция кандидата не последняя
                        candidat[Convert.ToInt32(pos) - 1] += tt2[i] * (candidatcount - j);
                }
            foreach(int a in candidat)
                if(a == 0) Assert.Fail("Кандидаты: {0},{1},{2},{3},{4}", candidat[0], candidat[1], candidat[2], candidat[3], candidat[4]);
        }
    }
}
