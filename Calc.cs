using System;
using System.Windows.Forms;
//using Ahmad.Salahieh;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void NumClick(string num)
        {// مثود طباعة الرقم المناسب عند الضغط 
            if (inOut.Text.Length > 1)
            { // معالجة حالة الارقام التي تبدأ بصفر ثم فاصلة عشرية
                if (inOut.Text[0].Equals('0') && inOut.Text[1].Equals('.'))
                    goto pr;
            }
            else if (inOut.Text.Length > 0)
            { // لعدم ادخال اكثر من صفر في اول خانة
                if (inOut.Text[0].Equals('0'))
                {
                    inOut.Text = "";
                    if (operation.Text.Equals("")) //للتميز بين اي عدد يتم ادخاله
                        num1.Text = "";
                    else num2.Text = "";
                }
            }
        pr: inOut.Text += num;
            if (operation.Text.Equals(""))
                num1.Text += num;
            else
                num2.Text += num;
        }
        private void OperClick(string op)
        { //ميثود الضغط على نوع العملية
            if (num1.Text.Length != 0)
            { // التأكد من خانة العدد الاول ليست فارغة
                operation.Text = op;
                if(inOut.Text != "")
                num1.Text = inOut.Text; // وضع الناتج بخانة النص الاولى
                inOut.Text = "";
                num2.Text = "";
                dot.Enabled = true;
                done = false;
            }
        }
        bool done = false; // متحول لتحديد انتهاء اجراء العملية
        private void Clear()
        {// ميثود تصفير البرنامج بعد انتهاء العملية
            if (done == true)
            {
                done = false;
                inOut.Text = "";
                num1.Text = "";
                operation.Text = "";
                num2.Text = "";
                dot.Enabled = true;
            }
        }
        private void Zero_Click(object sender, EventArgs e)
        { 
            Clear(); //استدعاء تصفير البرنامج اذا وجد اجراء سابق
            NumClick("0"); //استدعاء الادخال
        }

        private void One_Click(object sender, EventArgs e)
        {
            Clear();
            NumClick("1");
        }

        private void Two_Click(object sender, EventArgs e)
        {
            Clear();
            NumClick("2");
        }

        private void Three_Click(object sender, EventArgs e)
        {
            Clear();
            NumClick("3");
        }

        private void Four_Click(object sender, EventArgs e)
        { 
            Clear();
            NumClick("4");
        }

        private void Five_Click(object sender, EventArgs e)
        {
            Clear();
            NumClick("5");
        }

        private void Six_Click(object sender, EventArgs e)
        {
            Clear();
            NumClick("6");
        }

        private void Seven_Click(object sender, EventArgs e)
        {
            Clear();
            NumClick("7");
        }

        private void Eight_Click(object sender, EventArgs e)
        {
            Clear();
            NumClick("8");
        }

        private void Nine_Click(object sender, EventArgs e)
        {
            Clear();
            NumClick("9");
        }
        private void Dot_Click(object sender, EventArgs e)
        {
            if (inOut.Text.Length != 0 && done == false)
            {// عدم ادخال فاصلة عشرية في الخانة الاولى
                inOut.Text += ".";
                if (operation.Text.Equals(""))
                    num1.Text += ".";
                else num2.Text += ".";
                dot.Enabled = false; //تعطيل زر الفاصلة لعدم ادخالها اكثر من مرة
            }
        }
        private void Clear_Click(object sender, EventArgs e)
        { //حدث زر التصفير
            done = true;
            Clear();
        }

        private void Sum_Click(object sender, EventArgs e)
        {
            OperClick("+"); // ادخال نوع العملية الحسابية
        }

        private void Multiply_Click(object sender, EventArgs e)
        {
            OperClick("×");
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            OperClick("-");
        }

        private void Divide_Click(object sender, EventArgs e)
        {
            OperClick("÷");
        }

        private void Equal_Click(object sender, EventArgs e)
        {// "حدث النقر عل زر ال"يساوي
            if (operation.Text == "+" && num2.Text.Length != 0)
            {//التحقق من نوع العملية وخانة العدد الثاني ليست فارغة
             // قبل اجراء العملية
            double result = double.Parse(num1.Text) + double.Parse(num2.Text);
                inOut.Text = result.ToString(); // طباعة الناتج
                 done = true; //تأكيد انتهاء اجراء العملية
            }
            else if (operation.Text == "-" && num2.Text.Length != 0)
            {
                double result = double.Parse(num1.Text) - double.Parse(num2.Text);
                inOut.Text = result.ToString();
                done = true;
            }
            else if (operation.Text == "×" && num2.Text.Length != 0)
            {
                double result = double.Parse(num1.Text) * double.Parse(num2.Text);
                inOut.Text = result.ToString();
                done = true;
            }
            else if (operation.Text == "÷" && num2.Text.Length != 0)
            {
                if (double.Parse(num2.Text) != 0)
                {// معالجة حالة القسمة على صفر
                    double result = double.Parse(num1.Text) / double.Parse(num2.Text);
                    inOut.Text = result.ToString();
                }
                    
                else if (double.Parse(num1.Text) == 0 && double.Parse(num2.Text) == 0)
                { // باعتبار قسمة 0/0 مسموحة
                    inOut.Text = "0.0";
                }
                else {
                    // اظهار تنويه عند القسمة على صفر
                    inOut.Text = "Cannot num/0"; 
                }
                done = true;
            }
        }
    }
}
