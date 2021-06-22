using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSDLDPT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (cb_1.Checked)
                bai1();
            if (cb_2.Checked)
                TinhBai2();
            if (cb_3.Checked)
                TinhBai3();
            if (cb_4.Checked)
                TinhBai4();
        }
        private void bai1()
        {
            //bai1
            Console.WriteLine("********Tinh khoang cach giua cac van ban theo cosine");
            List<float> d1, d2, d3, d4, d5, q;
            int b1_sl = 0;
            q = new List<float>();
            if (!txtb1_Q.Text.Equals(""))
            {
                string[] z = txtb1_Q.Text.Trim().Split(',');
                for (int i = 0; i < z.Length; i++)
                {
                    q.Add(float.Parse(z[i]));
                }
                b1_sl = q.Count;
            }
            if (!txtb1_1.Text.Equals(""))
            {
                d1 = new List<float>();
                string[] z = txtb1_1.Text.Trim().Split(',');
                for (int i = 0; i < z.Length; i++)
                {
                    d1.Add(float.Parse(z[i]));
                }
                Console.Write("S(D1,Q)= ");
                Console.WriteLine(TinhBai1(d1, q, b1_sl));
            }
            if (!txtb1_2.Text.Equals(""))
            {
                d2 = new List<float>();
                string[] z = txtb1_2.Text.Trim().Split(',');
                for (int i = 0; i < z.Length; i++)
                {
                    d2.Add(float.Parse(z[i]));
                }
                Console.Write("S(D2,Q)= ");
                Console.WriteLine(TinhBai1(d2, q, b1_sl));
            }
            if (!txtb1_3.Text.Equals(""))
            {
                d3 = new List<float>();
                string[] z = txtb1_3.Text.Trim().Split(',');
                for (int i = 0; i < z.Length; i++)
                {
                    d3.Add(float.Parse(z[i]));
                }
                Console.Write("S(D3,Q)= ");
                Console.WriteLine(TinhBai1(d3, q, b1_sl));
            }
            if (!txtb1_4.Text.Equals(""))
            {
                d4 = new List<float>();
                string[] z = txtb1_4.Text.Trim().Split(',');
                for (int i = 0; i < z.Length; i++)
                {
                    d4.Add(float.Parse(z[i]));
                }
                Console.Write("S(D4,Q)= ");
                Console.WriteLine(TinhBai1(d4, q, b1_sl));
            }
            if (!txtb1_5.Text.Equals(""))
            {
                d5 = new List<float>();
                string[] z = txtb1_5.Text.Trim().Split(',');
                for (int i = 0; i < z.Length; i++)
                {
                    d5.Add(float.Parse(z[i]));
                }
                Console.Write("S(D5,Q)= ");
                Console.WriteLine(TinhBai1(d5, q, b1_sl));
            }
        }
        private float TinhBai1(List<float> a, List<float> b, int sl)
        {
            float kq = 0;
            float tren = 0, duoi1 = 0, duoi2 = 0;
            for(int i = 0; i < sl; i++)
            {
                tren += a[i] * b[i];
                duoi1 += a[i] * a[i];
                duoi2 += b[i] * b[i];
            }
            kq = tren / (float)(Math.Sqrt(duoi1) * Math.Sqrt(duoi2));
            return kq;
        }
        private void TinhBai2()
        {
            Console.WriteLine("\n\n********Bai tap Vladimir Levenstein");
            string source2 = txtb2_1.Text;
            string source1 = txtb2_2.Text;
            var source1Length = source1.Length;
            var source2Length = source2.Length;

            var matrix = new int[source1Length + 1, source2Length + 1];

            // Initialization of matrix with row size source1Length and columns size source2Length
            for (var i = 0; i <= source1Length; matrix[i, 0] = i++) { }
            for (var j = 0; j <= source2Length; matrix[0, j] = j++) { }

            // Calculate rows and collumns distances
            for (var i = 1; i <= source1Length; i++)
            {
                for (var j = 1; j <= source2Length; j++)
                {
                    var cost = (source2[j - 1] == source1[i - 1]) ? 0 : 1;

                    matrix[i, j] = Math.Min(
                        Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),
                        matrix[i - 1, j - 1] + cost);
                }
            }
            // return result
            for (int i=0;i<= source1Length; i++)
            {
                for (int j = 0; j <= source2Length; j++)
                    Console.Write($"{matrix[i, j],-4}");
                Console.WriteLine("");
            }
        }
        private void TinhBai3()
        {
            Console.WriteLine("\n\n********Bai tap huffman");
            List<HuffmanNode> nodeList;
            ProcessMethods pMethods = new ProcessMethods();
            nodeList = pMethods.getListFromFile(txtb3_1.Text.Trim());
            setColor();
            Console.WriteLine("#Ki tu   -   #Tan So");
            setColorDefault();
            pMethods.PrintInformation(nodeList);
            pMethods.getTreeFromList(nodeList);
            pMethods.setCodeToTheTree("", nodeList[0]);
            Console.WriteLine("\n\n");
            setColor();
            Console.WriteLine(" #   Cay   # \n");
            setColorDefault();
            pMethods.PrintTree(0, nodeList[0]);
            setColor();
            Console.WriteLine("\n\n#Ki Tu    -    #Ma\n");
            setColorDefault();
            pMethods.PrintfLeafAndCodes(nodeList[0]);
            Console.WriteLine("\n");
        }
        private void TinhBai4()
        {
            Console.WriteLine("\n\n********Bai tap muc xam");
            string[] x1 = txtb4_1.Text.Trim().Split(',');
            string[] x2 = txtb4_2.Text.Trim().Split(',');
            string[] x3 = txtb4_3.Text.Trim().Split(',');
            string[] q = txtb4_Q.Text.Trim().Split(',');
            List<float> l1 = new List<float>();
            List<float> l2 = new List<float>();
            List<float> l3 = new List<float>();
            List<float> lq = new List<float>();
            var z1 = new float[Int32.Parse(txtb4_max.Text) - Int32.Parse(txtb4_min.Text)+1];
            var z2 = new float[Int32.Parse(txtb4_max.Text) - Int32.Parse(txtb4_min.Text)+1];
            var z3 = new float[Int32.Parse(txtb4_max.Text) - Int32.Parse(txtb4_min.Text)+1];
            var zq = new float[Int32.Parse(txtb4_max.Text) - Int32.Parse(txtb4_min.Text)+1];
            for (int i=0; i< x1.Length; i++)
            {
                l1.Add(float.Parse(x1[i]));
            }
            for (int i = 0; i < x2.Length; i++)
            {
                l2.Add(float.Parse(x2[i]));
            }
            for (int i = 0; i < x3.Length; i++)
            {
                l3.Add(float.Parse(x3[i]));
            }
            for (int i = 0; i < q.Length; i++)
            {
                lq.Add(float.Parse(q[i]));
            }
            for (float i = 0; i <= float.Parse(txtb4_max.Text) - float.Parse(txtb4_min.Text); i++)
            {
                z1[(int)i] = (float)(l1.Where(x => x == (i + float.Parse(txtb4_min.Text)))).Count();
                z2[(int)i] = (float)(l2.Where(x => x == (i + float.Parse(txtb4_min.Text)))).Count();
                z3[(int)i] = (float)(l3.Where(x => x == (i + float.Parse(txtb4_min.Text)))).Count();
                zq[(int)i] = (float)(lq.Where(x => x == (i + float.Parse(txtb4_min.Text)))).Count();
            }
            Console.WriteLine("X1:");
            for (int i = 0; i <= Int32.Parse(txtb4_max.Text) - Int32.Parse(txtb4_min.Text); i++)
            {
                Console.Write($"{i + Int32.Parse(txtb4_min.Text),-4}");
            }
            Console.WriteLine("");
            for (int i = 0; i <= Int32.Parse(txtb4_max.Text) - Int32.Parse(txtb4_min.Text); i++)
            {
                Console.Write($"{z1[i],-4}");
            }
            Console.Write(" Tong: " + l1.Count);
            Console.WriteLine("\nX2:");
            for (int i = 0; i <= Int32.Parse(txtb4_max.Text) - Int32.Parse(txtb4_min.Text); i++)
            {
                Console.Write($"{i + Int32.Parse(txtb4_min.Text),-4}");
            }
            Console.WriteLine("");
            for (int i = 0; i <= Int32.Parse(txtb4_max.Text) - Int32.Parse(txtb4_min.Text); i++)
            {
                Console.Write($"{z2[i],-4}");
            }
            Console.Write(" Tong: " + l2.Count);
            Console.WriteLine("\nX3:");
            for (int i = 0; i <= Int32.Parse(txtb4_max.Text) - Int32.Parse(txtb4_min.Text); i++)
            {
                Console.Write($"{i + Int32.Parse(txtb4_min.Text),-4}");
            }
            Console.WriteLine("");
            for (int i = 0; i <= Int32.Parse(txtb4_max.Text) - Int32.Parse(txtb4_min.Text); i++)
            {
                Console.Write($"{z3[i],-4}");
            }
            Console.Write(" Tong: " + l3.Count);
            Console.WriteLine("\nQ:");
            for (int i = 0; i <= Int32.Parse(txtb4_max.Text) - Int32.Parse(txtb4_min.Text); i++)
            {
                Console.Write($"{i + Int32.Parse(txtb4_min.Text),-4}");
            }
            Console.WriteLine("");
            for (int i = 0; i <= Int32.Parse(txtb4_max.Text) - Int32.Parse(txtb4_min.Text); i++)
            {
                Console.Write($"{zq[i],-4}");
            }
            Console.Write(" Tong: " + lq.Count);
            Console.Write("\n\nTinh khoang cach giua Xi toi Q theo phuong phap khoang cach euclide:\n");
            float kq1 = 0;
            float kq2 = 0;
            float kq3 = 0;
            for (int i = 0; i <= Int32.Parse(txtb4_max.Text) - Int32.Parse(txtb4_min.Text); i++)
            {
                kq1 += Math.Abs((zq[i] / (float)lq.Count) - (z1[i] / (float)l1.Count));
                kq2 += Math.Abs((zq[i] / (float)lq.Count) - (z2[i] / (float)l2.Count));
                kq3 += Math.Abs((zq[i] / (float)lq.Count) - (z3[i] / (float)l3.Count));
            }
            Console.WriteLine("d(X1,Q)= " + kq1);
            Console.WriteLine("d(X2,Q)= " + kq2);
            Console.WriteLine("d(X3,Q)= " + kq3);
            
        }
        public static void setColor()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        public static void setColorDefault()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
